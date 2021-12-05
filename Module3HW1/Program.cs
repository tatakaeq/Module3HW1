using System;
using System.Collections.Generic;

namespace Module2HW2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var customList = new CustomList<int>();
            var defaultList = new List<int>();

            defaultList.Add(9);
            defaultList.Add(10);
            defaultList.Add(11);
            defaultList.Add(12);
            defaultList.Add(13);
            defaultList.Add(14);

            customList.Add(4);
            customList.Add(3);
            customList.Add(1);
            customList.Add(2);
            customList.Add(7);
            customList.Add(8);
            customList.Add(5);
            customList.Add(6);
            customList.AddRange(defaultList);
            Console.WriteLine(customList.Remove(6));
            customList.RemoveAt(0);
            customList.Sort();
            foreach (var item in customList)
            {
                Console.WriteLine(item);
            }
        }
    }
}