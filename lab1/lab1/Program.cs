using System;
using System.Numerics;

namespace lab1
{
    public static class functions
    {
        public static Vector2 F(double x, double y)
        {
            return new Vector2(Convert.ToSingle(x * x), Convert.ToSingle(y * y));
        }
    }

    class Program
    {
        static void Main()
        {
            V3DataArray my_data_array = new V3DataArray("my_data", DateTime.Now, 5, 10, 0.5, 0.2, functions.F);
            Console.WriteLine(my_data_array.ToLongString("F3"));
            V3DataList my_data_list = (V3DataList) my_data_array;
            Console.WriteLine(my_data_list.ToLongString("F3"));
            Console.WriteLine($"V3DataArray: Count = {my_data_array.Count} MaxDistance = {my_data_array.MaxDistance}");
            Console.WriteLine($"V3DataList:  Count = {my_data_list.Count} MaxDistance = {my_data_list.MaxDistance}");



            V3DataList my_data_list_2 = new V3DataList("my_list_2", DateTime.Now);
            my_data_list_2.AddDefaults(3, functions.F);
            V3DataArray my_data_array_2 = new V3DataArray("my_array_2", DateTime.Now);
            V3MainCollection my_collection = new V3MainCollection();
            my_collection.Add(my_data_array);
            my_collection.Add(my_data_list);
            my_collection.Add(my_data_array_2);
            my_collection.Add(my_data_list_2);
            Console.WriteLine(my_collection.ToLongString("F3"));


            for (int i = 0; i < my_collection.Count; ++i)
            {
                Console.WriteLine($"V3DataArray: Count = {my_collection[i].Count} MaxDistance = {my_collection[i].MaxDistance}");
            }
        }
    }
}
