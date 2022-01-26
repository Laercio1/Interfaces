using System;
using Interfaces.Entities;

namespace Interfaces.Services
{
    class RentalService
    {
        public double PricePerhour { get; set; }
        public double PricePerDay { get; set; }

        private ITaxService _TaxService;
        public RentalService(double pricePerhour, double pricePerDay, ITaxService taxService)
        {
            PricePerhour = pricePerhour;
            PricePerDay = pricePerDay;
            _TaxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duration.TotalHours <= 12.0)
            {
                basicPayment = PricePerhour * Math.Ceiling(duration.TotalHours);
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalDays);
            }

            double tax = _TaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
        }
    }
}
