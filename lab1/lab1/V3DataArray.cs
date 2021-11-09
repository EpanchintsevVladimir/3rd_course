using System;
using System.Numerics;

namespace lab1
{
    class V3DataArray : V3Data
    {
        public int x_n { get; }
        public int y_n { get; }
        public double x_step { get; }
        public double y_step { get; }
        public Vector2[,] grid { get; }
        public V3DataArray(string name, DateTime time) : base(name, time)
        {
            x_n = 0;
            y_n = 0;
            x_step = 0.0;
            y_step = 0.0;
            grid = new Vector2[0, 0];
        }
        public V3DataArray(string name, DateTime time, int x_n, int y_n,
                           double x_step, double y_step, FdblVector2 F) : base(name, time)
        {
            this.x_n = x_n;
            this.y_n = y_n;
            this.x_step = x_step;
            this.y_step = y_step;
            grid = new Vector2[x_n, y_n];
            for (int i = 0; i < x_n; ++i)
            {
                for (int j = 0; j < y_n; ++j)
                {
                    grid[i, j] = F(i * x_step, j * y_step);
                }
            }
        }
        public override int Count { get => grid.Length; }
        public override double MaxDistance { get =>  Math.Sqrt(Math.Pow((x_n - 1) * x_step, 2) + Math.Pow((y_n - 1) * y_step, 2)); }
        public override string ToString()
        {
            return $"{base.ToString()} x_nodes = {x_n} y_nodes = {y_n} x_step = {x_step} y_step = {y_step}";
        }
        public override string ToLongString(string format = "")
        {
            string str = ToString() + '\n';
            for (int i = 0; i < x_n; ++i)
            {
                for (int j = 0; j < y_n; ++j)
                {
                    str += $"--: x = {(x_step * i).ToString(format)} y = {(y_step * j).ToString(format)} field = {grid[i, j].ToString(format)}\n";
                }
            }
            return str;
        }
        public static explicit operator V3DataList(V3DataArray array)
        {
            V3DataList list = new V3DataList(array.name, array.time);
            for (int i = 0; i < array.x_n; i++)
            {
                for (int j = 0; j < array.y_n; j++)
                {
                    list.Add(new DataItem(array.x_step * i, array.y_step * j, array.grid[i, j]));
                }
            }
            return list;
        }
    }
}
