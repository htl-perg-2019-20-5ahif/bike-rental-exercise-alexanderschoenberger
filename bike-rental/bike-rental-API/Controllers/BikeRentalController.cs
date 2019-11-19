using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bike_rental_API.Controllers
{
    [ApiController]
    [Route("/api")]
    public class BikeRentalController : ControllerBase
    {
        private RentalDBContext rentalDBContext;

        public BikeRentalController()
        {
            rentalDBContext = new RentalDBContext();
        }

        [HttpGet]
        [Route("/customers")]
        public IEnumerable<Customer> GetCustomer()
        {
            return rentalDBContext.Customers.ToList();
        }

        [HttpPost]
        [Route("/customer")]
        public async Task<Customer> PostCustomer(Customer customer)
        {
            rentalDBContext.Customers.Add(customer);
            await rentalDBContext.SaveChangesAsync();
            return customer;
        }

        [HttpPut]
        [Route("/customer")]
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            Customer c = rentalDBContext.Customers.Find(customer.ID);
            c = customer;
            await rentalDBContext.SaveChangesAsync();
            return customer;
        }


        [HttpDelete]
        [Route("/customer/{id}")]
        public async Task<Customer> DeleteCustomer(int id)
        {
            Customer c = rentalDBContext.Customers.Find(id);
            rentalDBContext.Customers.Remove(c);
            await rentalDBContext.SaveChangesAsync();
            return c;
        }

        [HttpGet]
        [Route("/customer/{id}/getAlRental")]
        public Rental GetAllRentalCustomer(int id)
        {
            Customer c = rentalDBContext.Customers.Find(id);
            return rentalDBContext.Rentals.First((Rental r) => r.Customer.ID == id);
        }

        [HttpGet]
        [Route("/bikes")]
        public IEnumerable<Bike> GetBikes()
        {
            return rentalDBContext.Bikes.ToList();
        }

        [HttpPost]
        [Route("/bike")]
        public async Task<Bike> PostBike(Bike bike)
        {
            rentalDBContext.Bikes.Add(bike);
            await rentalDBContext.SaveChangesAsync();
            return bike;
        }

        [HttpPut]
        [Route("/bike/{id}")]
        public async Task<Bike> UpdateBike(Bike bike)
        {
            Bike b = rentalDBContext.Bikes.Find(bike.ID);
            b = bike;
            await rentalDBContext.SaveChangesAsync();
            return bike;
        }


        [HttpDelete]
        [Route("/bike/{id}")]
        public async Task<Bike> DeleteBike(int id)
        {
            Bike b = rentalDBContext.Bikes.Find(id);
            rentalDBContext.Bikes.Remove(b);
            await rentalDBContext.SaveChangesAsync();
            return b;
        }

        [HttpPost]
        [Route("/rental")]
        public async Task<Rental> StartRental(Rental rental)
        {
            rental.Customer = await rentalDBContext.Customers.FindAsync(rental.CustomerId);
            rental.Bike = await rentalDBContext.Bikes.FindAsync(rental.BikeId);

            rental.RentalBegin = System.DateTime.Now;
            rentalDBContext.Rentals.Add(rental);
            await rentalDBContext.SaveChangesAsync();
            return rental;
        }

        [HttpPut]
        [Route("/rental/{id}")]
        public async Task<Rental> StopRental(int id)
        {
            Rental r = rentalDBContext.Rentals.Find(id);
            r.RentalEnd = System.DateTime.Now.AddMinutes(130);
            r.Customer = await rentalDBContext.Customers.FindAsync(r.CustomerId);
            r.Bike = await rentalDBContext.Bikes.FindAsync(r.BikeId);
            r.TotalCosts = CalculateCosts.CalculateTotalCost(r);
            await rentalDBContext.SaveChangesAsync();
            return r;
        }
        

        [HttpGet]
        [Route("/rental/{id}")]
        public async Task<Rental> PayRental(int id)
        {
            Rental r = rentalDBContext.Rentals.Find(id);
            if (r.RentalEnd != null && r.TotalCosts != 0) { r.Paid = true; }
            await rentalDBContext.SaveChangesAsync();
            return r;
        }

        [HttpGet]
        [Route("/rental/unpaid")]
        public async Task<IEnumerable<Rental>> GetUnpaidRentals()
        {
            var rentals = rentalDBContext.Rentals.Where((Rental r) => !r.Paid && r.TotalCosts > 0);
            var ret = new List<OpenRental>();
            foreach (Rental rental in rentals)
            {
                OpenRental or = new OpenRental(rental.Customer.ID, rental.Customer.FirstName, rental.Customer.LastName, rental.ID, rental.RentalBegin, rental.RentalEnd, rental.TotalCosts);
                ret.Add(or);
            }
            await rentalDBContext.SaveChangesAsync();
            return rentals;
        }
    }
    class OpenRental
    {
        public int CustomerID;
        public string CustomerFirstName;
        public string CustomerLastName;
        public int RentalID;
        public DateTime RentalBegin;
        public DateTime RentalEnd;
        public decimal TotalCosts;

        public OpenRental(int CustomerID, string CustomerFirstName, string CustomerLastName, int RentalID, DateTime RentalBegin, DateTime RentalEnd, decimal TotalCosts)
        {
            this.CustomerID = CustomerID;
            this.CustomerFirstName = CustomerFirstName;
            this.CustomerLastName = CustomerLastName;
            this.RentalID = RentalID;
            this.RentalBegin = RentalBegin;
            this.RentalEnd = RentalEnd;
            this.TotalCosts = TotalCosts;
        }
    }
}


