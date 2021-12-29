using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ClassLibrary_DZ4
{
    public class DailyForecastRepository : IEnumerable<DailyForecast>
    {
        DailyForecast day { get; set; }
        List<DailyForecast> list;

        public DailyForecastRepository()
        {
            this.day = new DailyForecast();
            this.list = new List<DailyForecast>();
        }

        public DailyForecastRepository(DailyForecastRepository dfr) : this()
        { 
            foreach (DailyForecast day in dfr)
            {
                DailyForecast copy = new DailyForecast(day.time, day.Weather);
                this.list.Add(copy);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public IEnumerator<DailyForecast> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, list);
        }

        internal void Add(DailyForecast day)
        { 
            int count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                if (this.list[i].time.Date == day.time.Date)
                {
                    this.list[i] = day;
                    
                }
                if (this.list[i].time.Date != day.time.Date)
                {
                    count-- ; 
                }
            }
            if(count == 0)
            {
                int ind = this.list.Count - 1;
                if (ind < 0 || ind >= 0 && day.time.Date > list[this.list.Count - 1].time.Date) this.list.Add(day);
                else if (ind >= 0 && day.time.Date < list[0].time.Date) this.list.Insert(0, day);
                else
                {
                    for (int i = 1; i < this.list.Count - 1; i++)
                    {
                        if (list[i - 1].time.Date < day.time.Date && day.time.Date < list[i].time.Date)
                            this.list.Insert(i, day);
                    }
                }  
            }
        }

        internal void Add(List<DailyForecast> days)
        {
            foreach(DailyForecast df in list) {
                for (int i = 0; i < days.Count; i++)
                {
                    if (df.time.Date == days[i].time.Date)
                    {
                        days.RemoveAt(i);
                    }
                }
            }
            this.list.AddRange(days);
        }

        internal void Remove(DateTime time)
        {
            int toRemove = 0, index = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (this.list[i].time.Date == time.Date)
                {
                    toRemove++;
                    index = i;
                }
            }
            if(toRemove == 0)
            {
                throw new NoSuchDailyWeatherException($"No daily forecast for {time}");
            } 
            else this.list.RemoveAt(index);
        }
    }

    [Serializable]
    public class NoSuchDailyWeatherException : Exception
    {
        public NoSuchDailyWeatherException() { }
        public NoSuchDailyWeatherException(string message) : base(message) { }
        public NoSuchDailyWeatherException(string message, Exception innerException) : base(message, innerException) { }
        protected NoSuchDailyWeatherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
