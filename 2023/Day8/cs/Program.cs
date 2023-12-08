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

namespace AOC_Day8
{
    public class Program
    {
        public static ulong GCD(ulong a, ulong b)
        {
            while (b != 0)
            {
                ulong temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static ulong LCM(ulong a, ulong b) => (a * b) / GCD(a, b);

        static ulong list_lcm(List<int> numbers)
        {
            ulong result = (ulong)numbers[0];
            for (int i = 1; i < numbers.Count; i++)
                result = LCM(result, (ulong)numbers[i]);
            return result;
        }
        public static (string, Dictionary<string, (string, string)>) read()
        {
            string[] lines = File.ReadAllLines("input.txt");
            Dictionary<string, (string, string)> list = new Dictionary<string, (string, string)>();
            for (int j = 2; j < lines.Length; j++)
            {
                string[] line = lines[j].Split(" ");
                list.Add(line[0], (line[2].Replace("(", "").Replace(",", ""), line[3].Replace(")", "")));
            }
            return (lines[0], list);
        }
        public static void part1(Dictionary<string, (string, string)> list, string pattern)
        {
            string curr = "AAA";
            ulong result = 0;
            while (curr != "ZZZ")
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i].ToString() == "L")
                        curr = list[curr].Item1;
                    else
                        curr = list[curr].Item2;
                    result++;
                    if (curr == "ZZZ")
                        break;
                }
            }
            System.Console.WriteLine(result);
        }

        public static void part2(Dictionary<string, (string, string)> list, string pattern)
        {
            List<int> steps = new List<int>();
            List<string> curr = new List<string>();
            foreach (string n in list.Keys)
                if (n[2].ToString() == "A") curr.Add(n);
            System.Console.WriteLine(string.Join(" ", curr));
            for (int i = 0; i < curr.Count; i++)
            {
                int step_count = 0;
                while (curr[i][2].ToString() != "Z")
                {
                    for (int j = 0; j < pattern.Length; j++)
                    {
                        if (curr[i][2].ToString() == "Z") break;
                        if (pattern[j].ToString() == "L") curr[i] = list[curr[i]].Item1;
                        else curr[i] = list[curr[i]].Item2;
                        step_count++;
                    }
                }
                steps.Add(step_count);
            }
            System.Console.WriteLine(list_lcm(steps));
        }

        public static void Main(string[] args)
        {
            (string, Dictionary<string, (string, string)>) input = read();
            string pattern = input.Item1;
            // part1(input.Item2, input.Item1);
            part2(input.Item2, input.Item1);
        }
    }
}