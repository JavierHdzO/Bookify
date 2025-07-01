using Bookify.Domain.Apartments;
using Bookify.Domain.Common;

namespace Bookify.Domain.Bookings;

public class PricingService
{

    public PricingDetails CalculatePrice(Apartment apartment, DateRange period) 
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(
            apartment.Price.Amount * period.LengthInDays,
            currency);

        decimal percentageUpCharge = 0;

        foreach (var amenity in apartment.Amenities) 
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m, // 5% upcharge for views
                Amenity.AirConditioning => 0.01m, // 1% upcharge for air conditioning
                Amenity.Parking => 0.01m, // 1% upcharge for parking
                _ => 0 // no upcha    rge for other amenities
            }; 
        }


        var amenitiesUpCharge = Money.Zero();
        if (percentageUpCharge > 0) 
        {
            amenitiesUpCharge = new Money(
                priceForPeriod.Amount * percentageUpCharge,
                currency);
        }

        var totalPrice = Money.Zero(currency);

        totalPrice += priceForPeriod;

        if (!apartment.CleaningFee.IsZero()) 
        {
            totalPrice += apartment.CleaningFee;
        }

        totalPrice += amenitiesUpCharge;

        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);

    }

    

}
