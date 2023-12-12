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

namespace AOC_DayX
{
    public class Program
    {
        public static (bool, string) isPipe(string s){
            string pipes = "|-LJ7F";
            if (pipes.Contains(s))
                return (true, pipes[pipes.IndexOf(s.ToString())].ToString());
            return (false, "");
        }
        public static List<List<string>> read()
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < lines.Length; i++)
            {
                List<string> temp = new List<string>(lines[i].Split(""));
                list.Add(temp);
            }
            return list;
        }
        public static void part1(List<List<string>> list)
        {
            (int, int) start_index = (0, 0);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IndexOf("S") != -1)
                {
                    start_index = (i, list[i].IndexOf("S"));
                    break;
                }
            }

            //TODO: check the starting points surruindings
        }

        public static void part2(List<List<string>> list)
        {
            
        }

        public static void Main(string[] args)
        {
            List<List<string>> input = read();
            part1(input);
            // part2(input);
        }
    }
}