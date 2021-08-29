using CabInvoiceGeneratorProject.CabInvoiceGeneratorProject;
using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGeneratorProject
{
    public class RideRepository
    {
        readonly Dictionary<int, List<Ride>> userRides = null;

        public RideRepository()
        {
            this.userRides = new Dictionary<int, List<Ride>>();
        }

        public void AddRides(int userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userId, list);
                }
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "Rides are null");
            }
        }

        public Ride[] GetRides(int userName)
        {
            try
            {
                return this.userRides[userName].ToArray();
            }
            catch
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "Invalid User Name");
            }
        }
    }
}
