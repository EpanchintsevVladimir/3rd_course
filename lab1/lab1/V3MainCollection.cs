using System.Collections.Generic;

namespace lab1
{
    class V3MainCollection
    {
        private List<V3Data> collection;
        public V3MainCollection()
        {
            collection = new List<V3Data>();
        }
        public int Count { get => collection.Count; }
        public V3Data this[int i] { get => collection[i]; }
        public bool Contains(string ID)
        {
            foreach (V3Data data in collection)
            {
                if (data.name == ID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Add(V3Data v3Data)
        {
            if (Contains(v3Data.name))
            {
                return false;
            }
            collection.Add(v3Data);
            return true;
        }
        public string ToLongString(string format = "")
        {
            string str = "";
            foreach (V3Data data in collection)
            {
                str += $"{data.ToLongString(format)}\n";
            }
            return str;
        }
        public override string ToString()
        {
            string str = "";
            foreach (V3Data data in collection)
            {
                str += $"{data}\n";
            }
            return str;
        }
    }
}
