using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bike_rental_API
{
    public class CalculateCosts
    {
        public static decimal CalculateTotalCost(Rental r)
        {
            var substract = r.RentalEnd.Subtract(r.RentalBegin);
            decimal cost;
            if (substract.TotalMinutes <= 15)
            {
                return 0;
            }
            cost = r.Bike.RentalPriceForFirstHour + (Convert.ToDecimal(Math.Ceiling(substract.TotalHours - 1))) * r.Bike.RentalPriceForAdditionalHour;
            return cost;
        }
    }
}
