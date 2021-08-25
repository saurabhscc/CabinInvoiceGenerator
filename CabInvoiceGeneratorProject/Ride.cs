using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorProject.CabInvoiceGeneratorProject
{
    /// <summary>
    /// ride class to set data for particular ride
    /// </summary>
    public class Ride
    {
        
        /// variables
        public double distance;
        public int time;
        /// <summary>
        /// Parameterised Constructor to initialise the instance of the ride class 
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(double distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
