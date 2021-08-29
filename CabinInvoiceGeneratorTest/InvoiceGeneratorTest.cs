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
        }
    }
}