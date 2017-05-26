//Guest.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    //Guest Class
    class Guest
    {
        //Private variables
        private string name;
        private double profit;

        //Default Constructor
        public Guest( )
        {
            name = "EMPTY";
            profit = 0;
        }

        //Two parameter constructor
        public Guest( string n, double p )
        {
            name = n;
            profit = p;
        }

        //Get Set functions
        public string Name { get; set; }

        public double Profit { get; set; }
    }
}