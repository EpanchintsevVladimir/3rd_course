using System;
using System.Collections.Generic;

namespace lab1
{
    class V3DataList : V3Data
    {
        public List<DataItem> data { get; }
        public V3DataList(string name, DateTime time) : base(name, time)
        {
            data = new List<DataItem>();
        }
        public bool Add(DataItem newItem)
        {
            foreach (DataItem item in data)
            {
                if ((item.x == newItem.x) && (item.y == newItem.y))
                {
                    return false;
                }
            }
            data.Add(newItem);
            return true;
        }
        public int AddDefaults(int nItems, FdblVector2 F)
        {
            Random rand = new Random(nItems);
            int count = 0;
            for (int i = 0; i < nItems; ++i)
            {
                double x = rand.NextDouble() * 100;
                double y = rand.NextDouble() * 100;
                if (Add(new DataItem(x, y, F(x, y))))
                {
                    count++;
                }
            }
            return count;
        }
        public override int Count { get => data.Count; }
        public override double MaxDistance
        {
            get
            {
                double maxDist = 0.0;
                for (int i = 0; i < data.Count; ++i)
                {
                    for (int j = i + 1; j < data.Count; ++j)
                    {
                        double dist = Math.Sqrt(Math.Pow(data[i].x - data[j].x, 2) + Math.Pow(data[i].y - data[j].y, 2));
                        if (dist > maxDist)
                        {
                            maxDist = dist;
                        }
                    }
                }
                return maxDist;
            }
        }
        public override string ToString()
        {
            return $"{base.ToString()} {data.Count}";
        }
        public override string ToLongString(string format = "")
        {
            string str = ToString() + '\n';
            foreach (DataItem item in data)
            {
                str += $"--: {item.ToLongString(format)}\n";
            }
            return str;
        }
    }
}
