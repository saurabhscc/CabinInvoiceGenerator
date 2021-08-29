using CabInvoiceGeneratorProject.CabInvoiceGeneratorProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorProject
{
    public class InvoiceGenerator
    {
        /// Declaring the object of the class RideType so as to differentiate the data attributes as time and distance.
        RideType rideType;
        /// attributes acting as constant variable.
        private  double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private  double MINIMUM_FARE;
        /// <summary>
        /// Parameterized Constructor.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        public InvoiceGenerator(RideType rideType)
        {
                this.rideType = rideType;
                this.MINIMUM_COST_PER_KM = 10;
                this.COST_PER_TIME = 1;
                this.MINIMUM_FARE = 5;      
        }
        /// <summary>
        /// Method to Compute the total fare of the cab journey when passed with distance and time.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">
        /// Invalid distance
        /// or
        /// Invalid time
        /// </exception>
        public double CalculateFare(double distance, int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            //Return the Max. Value
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                
                foreach (Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException )
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "No rides found");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        public void AddRides(int userId, Ride[] rides)
        {
            RideRepository rideRepository = new RideRepository();
            try
            {
                rideRepository.AddRides(userId, rides);
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
        }
        public InvoiceSummary GetInvoiceSummary(int userId)
        {
            RideRepository rideRepository = new RideRepository();
            try
            {
                return this.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid UserId");
            }
        }
    }
}
