using System;

namespace lab1
{
    abstract class V3Data
    {
        public string name { get; }
        public DateTime time { get; }
        public abstract int Count { get; }
        public abstract double MaxDistance { get; }
        public V3Data(string name, DateTime time)
        {
            this.name = name;
            this.time = time;
        }
        public abstract string ToLongString(string format);
        public override string ToString()
        {
            return $"name = {name} time = {time}";
        }
    }
}
