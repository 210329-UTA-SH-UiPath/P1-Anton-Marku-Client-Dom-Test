using System;

namespace Domain
{
    public class Revenue
    {
        public int Store { get; set; }
        public double Rev { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Week { get; set; }

        public Revenue()
        {

        }

        public override string ToString()
        {
            return $"Store {Store} made ${Rev} for week {Week}, month {Month} of {Year}";
        }
    }
}
