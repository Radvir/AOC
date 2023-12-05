using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.Common;

namespace AOC_Day4
{
    public class Program
    {
        public static bool isInt(string n)
        {
            if (int.TryParse(n, out int asd))
                return true;
            return false;
        }
        public static List<string> read()
        {
            List<string> list = new List<string>();
            string[] lines = File.ReadAllLines("../ts/input.txt");
            

            return list;
        }
        public static void part1(List<string> list)
        {
            for (int i = 0; i < list.Cunt; i++)
            {
                
            }
        }
        public static void part2(List<string> list)
        {
            
        }

        public static void Main(string[] args)
        {
            List<string> input = read();
            // part1(input);
            part2(input);
        }
    }
}