using CabInvoiceGeneratorProject;
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
        }
    }
}