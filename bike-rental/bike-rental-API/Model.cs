using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace bike_rental_API
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public enum Male { Male, Female, Unknown }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        [MaxLength(75)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string HouseNumber { get; set; }
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(75)]
        public string Town { get; set; }
    }

    public class Bike
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(25)]
        public string Brand { get; set; }
        [Required]
        public DateTime? PurchaseDate { get; set; }
        [MaxLength(100)]
        public string Notes { get; set; }
        public DateTime? DateOfLastService { get; set; }
        [Required]
        [DataType("decimal(18,2)")]
        [Range(1, double.MaxValue)]
        public decimal RentalPriceForFirstHour { get; set; }

        [Required]
        [DataType("decimal(18,2)")]
        [Range(1, double.MaxValue)]
        public decimal RentalPriceForAdditionalHour { get; set; }

        public enum BikeCategory { StandardBike, Mountainbike, TreckingBike, RacingBike };
    }
    public class Rental
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        [Required]
        public int BikeId { get; set; }
        
        public Bike Bike { get; set; }
        public DateTime RentalBegin { get; set; }
        
        public DateTime RentalEnd { get; set; }
        
        [DataType("decimal(18,2)")]
        public decimal TotalCosts { get; set; }
        [Required]
        public bool Paid { get; set; }
        
    }
}