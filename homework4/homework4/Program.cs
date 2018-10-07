using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace homework4
{
    public class ClockEventArgs : EventArgs
    {
        public int thisyear;
        public int thismonth;
        public int thisday;
        public int thishour;
        public int thisminute;
        public int thissecond;

        public ClockEventArgs(int thisyear, int thismonth, int thisday, int thishour, int thisminute, int thissecond)
        {
            Year = thisyear;
            Month = thismonth;
            Day = thisday;
            Hour = thishour;
            Minute = thisminute;
            Second = thissecond;
        }
        public int Year
        {
            get
            { return thisyear; }
            set
            {
                if (value > 2017)
                    thisyear = value;
                else
                    throw new ArgumentOutOfRangeException("Year error");

            }
        }
        public int Month
        {
            get
            { return thismonth; }
            set
            {
                if (value > 0 && value < 13)
                    thismonth = value;
                else
                    throw new ArgumentOutOfRangeException("Month error");

            }
        }
        public int Day
        {
            get
            { return thisday; }
            set
            {
                if (value > 0 && value < 32)
                    thisday = value;
                else
                    throw new ArgumentOutOfRangeException("Day error");

            }
        }
        public int Hour
        {
            get
            { return thishour; }
            set
            {
                if (value >= 0 && value <= 23)
                    thishour = value;
                else
                    throw new ArgumentOutOfRangeException("Hour error");

            }
        }
        public int Minute
        {
            get
            { return thisminute; }
            set
            {
                if (value >= 0 && value <= 59)
                    thisminute = value;
                else
                    throw new ArgumentOutOfRangeException("Minute error");

            }
        }
        public int Second
        {
            get
            { return thissecond; }
            set
            {
                if (value >= 0 && value <= 59)
                    thissecond = value;
                else
                    throw new ArgumentOutOfRangeException("Second error");

            }
        }
    }

    public delegate void ClockEventHandler(object sender, ClockEventArgs e);

    public class Clock
    {
        public event ClockEventHandler ClockRemind;
        public void ClockOn(ClockEventArgs args)
        {
            DateTime settime = new DateTime(args.thisyear, args.thismonth, args.thisday, args.thishour, args.thisminute, args.thissecond);
            if (ClockRemind != null)
            {
                int n = 0;
                while (true)
                {
                    DateTime today = DateTime.Now;
                    while (today > settime)
                    {
                        n++;
                        if (n == 1)
                        {
                            break;
                        }
                    }
                    if (n == 1)
                    {
                        break;
                    }
                }
                ClockRemind(this, args);
            }
        }

    }

    public class UseClock
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            clock.ClockRemind += ClockRemindFun;
            ClockEventArgs obj = new ClockEventArgs(2018, 10, 7, 23, 41, 10);//设置闹钟时间
            clock.ClockOn(obj);
        }
        static void ClockRemindFun(object sender, ClockEventArgs e)
        {
            Console.WriteLine("Time!!!!");
        }
    }
   
}


