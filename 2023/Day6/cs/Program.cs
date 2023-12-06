using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Globalization;
using System.Data;

namespace AOC_Day6
{
    public class Program
    {
        public static List<(long, long)> read() //time, distance
        {
            //TODO: fromat the input file by hand (its kinda cheating, i know)
            string[] lines = File.ReadAllLines("input.txt");
            List<(long, long)> list = new List<(long, long)>();
            lines[0] = lines[0].Remove(0, 10);
            lines[1] = lines[1].Remove(0, 10);
            List<string> time_nums = lines[0].Split(" ").ToList();
            for (int i = 0; i < time_nums.Count; i++)
            {
                if (time_nums[i] == "" || time_nums[i] == " ")
                    time_nums.RemoveAt(i);
            }
            List<string> distance_nums = lines[1].Split(" ").ToList();
            for (int i = 0; i < distance_nums.Count; i++)
            {
                if (distance_nums[i] == "" || distance_nums[i] == " ")
                    distance_nums.RemoveAt(i);
            }
            for (int i = 0; i < time_nums.Count; i++)
                list.Add((long.Parse(time_nums[i]), long.Parse(distance_nums[i])));
            return list;
        }
        public static void part1(List<(long, long)> list)
        {
            int result = 1;
            for (int i = 0; i < list.Count; i++)
            {
                int temp_result = 0;
                for (int j = 1; j < list[i].Item1; j++) //yes, i know i could split it into half but i dont care
                {
                    //j time of holding down the boat
                    if (j * (list[i].Item1 - j) > list[i].Item2)
                        temp_result++;
                }
                result = result * temp_result;
            }
            System.Console.WriteLine(result);
        }

        public static void part2(List<(long, long)> list)
        {
            //Delete spaces between numbers in the input file
        }

        public static void Main(string[] args)
        {
            List<(long, long)> input = read();
            foreach ((int, int) n in input)
            {
                System.Console.WriteLine(n.Item1 + " " + n.Item2);
            }
            // System.Console.WriteLine(input.ToString());
            part1(input);
            // part2(input);
        }
    }
}