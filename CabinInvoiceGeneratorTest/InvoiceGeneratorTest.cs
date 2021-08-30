using CabInvoiceGeneratorProject;
using CabInvoiceGeneratorProject.CabInvoiceGeneratorProject;
using NUnit.Framework;

namespace CabinInvoiceGeneratorTest
{
    public class InvoiceGeneratorTest
    {
        public class Tests
        {
            InvoiceGenerator invoice;
            [Test]
            public void GivenDistanceTime_ShouldReturnTotalFare()
            {
                //// Creating instance of InvoiceGenerator for Normal Ride
                invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                double distance = 2.0;
                int time = 5;
                //Calculate Fare
                double fare = invoice.CalculateFare(distance, time);
                double expected = 25;
                Assert.AreEqual(expected, fare);
            }
            [Test]
            public void GivenMultipleRides_WhenAnalyze_ShouldReturnTotalFaresOfMultipleRides()
            {
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);

                Ride[] rides = { new Ride(6, 15), new Ride(12, 30), new Ride(18, 45), };

                InvoiceSummary summary = new InvoiceSummary(3, 450);
                InvoiceSummary expected = invoice.CalculateFare(rides);
                Assert.AreEqual(summary.totalFare, expected.totalFare);
            }
            [Test]
            public void GivenMultipleRides_WhenAnalyze_ShouldReturnAverageFaresOfMultipleRides()
            {
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);

                Ride[] rides = { new Ride(6, 15), new Ride(12, 30), new Ride(18, 45), };

                InvoiceSummary summary = new InvoiceSummary(3, 450);
                InvoiceSummary expected = invoice.CalculateFare(rides);
                Assert.AreEqual(summary.averageFare, expected.averageFare);
            }
            [Test]
            public void GivenUserId_WhenAnalyze_ShouldReturnFareForUser()
            {
                Ride[] ride1 = { new Ride(6, 15), new Ride(12, 30), new Ride(18, 45) };
                Ride[] ride2 = { new Ride(8, 16), new Ride(12, 24), new Ride(16, 32) };
                Ride[] ride3 = { new Ride(10, 18), new Ride(20, 36),new Ride(30, 48) };

                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRides(1, ride1);
                rideRepository.AddRides(2, ride2);
                rideRepository.AddRides(3, ride3);
                var rideArray = rideRepository.GetRides(1);
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                InvoiceSummary summary = new InvoiceSummary(3, 450);
                InvoiceSummary expected = invoice.CalculateFare(rideArray);
                Assert.AreEqual(summary.totalFare, expected.totalFare);
            }
            [Test]
            public void GivenUserId_WhenAnalyze_ShouldReturnAverageFareForUser()
            {
                Ride[] ride1 = { new Ride(6, 15), new Ride(12, 30), new Ride(18, 45) };
                Ride[] ride2 = { new Ride(8, 16), new Ride(12, 24), new Ride(16, 32) };
                Ride[] ride3 = { new Ride(10, 18), new Ride(20, 36), new Ride(30, 48) };

                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRides(1, ride1);

                rideRepository.AddRides(2, ride2);
                rideRepository.AddRides(3, ride3);
                var rideArray = rideRepository.GetRides(1);
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL_RIDE);
                InvoiceSummary summary = new InvoiceSummary(3, 450);
                InvoiceSummary expected = invoice.CalculateFare(rideArray);
                Assert.AreEqual(summary.averageFare, expected.averageFare);
            }
            [Test]
            public void GivenUserId_WhenAnalyze_ShouldReturnFareForPremiumUser()
            {
                Ride[] ride1 = { new Ride(6, 15), new Ride(12, 30), new Ride(18, 45) };
                Ride[] ride2 = { new Ride(8, 16), new Ride(12, 24), new Ride(16, 32) };
                Ride[] ride3 = { new Ride(10, 18), new Ride(20, 36), new Ride(30, 48) };

                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRides(1, ride1);
                rideRepository.AddRides(2, ride2);
                rideRepository.AddRides(3, ride3);
                var rideArray = rideRepository.GetRides(1);
                InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIUM_RIDE);
                InvoiceSummary summary = new InvoiceSummary(3, 720);
                InvoiceSummary expected = invoice.CalculateFare(rideArray);
                Assert.AreEqual(summary.totalFare, expected.totalFare);
            }
        }
    }
}
