using System;
using System.Globalization;
using Interfaces.Entities;
using Interfaces.Services;
namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data:");
            Console.WriteLine("Car Model: ");
            string model = Console.ReadLine();
            Console.WriteLine("Pickup (dd/MM/yyyy HH:ss): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.WriteLine("Return (dd/MM/yyyy HH:ss): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.WriteLine("Enter price per hour:");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("Enter price per day: ");
            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("Invoice:");
            Console.WriteLine(carRental.Invoice); ;
        }
    }
}
