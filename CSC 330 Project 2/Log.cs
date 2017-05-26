//Log.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBookingSystem
{
    //Log inherits from Guest
    class Log : Guest
    {
        //Private variables
        private int roomRented;
        private DateTime rBegin;
        private DateTime rEnd;

        //Default Constructors
        public Log() { }

        //Four parameter constructor
        public Log( int r, DateTime rB, DateTime rE, Guest g )
        {
            roomRented = r;
            rBegin = rB;
            rEnd = rE;
        }

        //Get Set Functions
        public int RoomRented { get; set; }
        public DateTime RBegin { get; set; }
        public DateTime REnd { get; set; }
    }
}
