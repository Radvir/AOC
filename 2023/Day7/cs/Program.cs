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
    public class Hand
    {
        public string cards;
        public int bid;
        public Hand(string cards, int bid)
        {
            this.cards = cards;
            this.bid = bid;
        }
        public override string ToString() => $"{cards} {bid}";
    }
    public class Program
    {
        public static List<Hand> read()
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<Hand> list = new List<Hand>();
            for (int i = 0; i < lines.Length; i++)
                list.Add(new Hand(lines[i].Split(" ")[0], int.Parse(lines[i].Split(" ")[1])));
            return list;
        }
        public static void part1(List<Hand> list)
        {
            
        }

        public static void part2(List<Hand> list)
        {

        }

        public static void Main(string[] args)
        {
            List<Hand> input = read();
            part1(input);
            // part2(input);
        }
    }
}