using bike_rental_API;
using bike_rental_API.Controllers;
using System;
using Xunit;

namespace TestBikeRental
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateWithAdditionalHour()
        {
            BikeRentalController bc = new BikeRentalController();
            Bike bike = new Bike();
            bike.RentalPriceForFirstHour = 3;
            bike.RentalPriceForAdditionalHour = 5;
            bike.ID = 1;
            Customer customer = new Customer();
            customer.ID = 1;
            Rental r = new Rental();
            r.RentalBegin = new DateTime(2018, 02, 14, 8, 15, 0);
            r.RentalEnd = new DateTime(2018, 02, 14, 10, 30, 0);
            r.ID = 1;
            r.Customer = customer;
            r.CustomerId = customer.ID;
            r.Bike = bike;
            r.BikeId = bike.ID;
            r.TotalCosts = bc.CalculateTotalCost(r);
            Assert.Equal(13, r.TotalCosts, 1);
        }
        [Fact]
        public void CalculateFirstHour()
        {
            BikeRentalController bc = new BikeRentalController();
            Bike bike = new Bike();
            bike.RentalPriceForFirstHour = 3;
            bike.RentalPriceForAdditionalHour = 5;
            bike.ID = 1;
            Customer customer = new Customer();
            customer.ID = 1;
            Rental r = new Rental();
            r.RentalBegin = new DateTime(2018, 02, 14, 8, 15, 0);
            r.RentalEnd = new DateTime(2018, 02, 14, 8, 45, 0);
            r.ID = 1;
            r.Customer = customer;
            r.CustomerId = customer.ID;
            r.Bike = bike;
            r.BikeId = bike.ID;
            r.TotalCosts = bc.CalculateTotalCost(r);
            Assert.Equal(3, r.TotalCosts, 1);
        }

        [Fact]
        public void CalculateFree()
        {
            Bike bike = new Bike();
            bike.RentalPriceForFirstHour = 3;
            bike.RentalPriceForAdditionalHour = 5;
            bike.ID = 1;
            Customer customer = new Customer();
            customer.ID = 1;
            Rental r = new Rental();
            r.RentalBegin = new DateTime(2018, 02, 14, 8, 15, 0);
            r.RentalEnd = new DateTime(2018, 02, 14, 8, 25, 0);
            r.ID = 1;
            r.Customer = customer;
            r.CustomerId = customer.ID;
            r.Bike = bike;
            r.BikeId = bike.ID;
            r.TotalCosts = CalculateCosts.CalculateTotalCost(r);
            Assert.Equal(0, r.TotalCosts, 1);
        }
    }
}
