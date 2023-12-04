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
    public class Card
    {
        public int id;
        public List<int> win_nums;
        public List<int> own_nums;
        public int matches; //winning matches on the card
        public Card(int id, List<int> win_nums, List<int> own_nums, int matches = 0)
        {
            this.id = id;
            this.win_nums = win_nums;
            this.own_nums = own_nums;
            this.matches = matches;
        }
        public override string ToString()
        {
            string result = $"id:{id} ";
            result += "{[";
            for (int i = 0; i < win_nums.Count - 1; i++)
            {
                result += win_nums[i] + ",";
            }
            result += win_nums[win_nums.Count - 1] + "]";

            result += "[";
            for (int i = 0; i < own_nums.Count - 1; i++)
            {
                result += own_nums[i] + ",";
            }
            result += own_nums[own_nums.Count - 1] + "]}";
            result += " " + matches;
            return result;
        }
    }
    public class Program
    {
        public static bool isInt(string n)
        {
            if (int.TryParse(n, out int asd))
            {
                return true;
            }
            return false;
        }
        public static List<Card> read()
        {
            List<Card> list = new List<Card>();
            string[] lines = File.ReadAllLines("../ts/input.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] nums = lines[i].Remove(0, 8).Split("|");
                string[] winN_sting = nums[0].Split(" ");
                List<int> winN = new List<int>();
                for (int j = 0; j < winN_sting.Length; j++)
                {
                    if (isInt(winN_sting[j]))
                    {
                        winN.Add(int.Parse(winN_sting[j]));
                    }
                }

                string[] ownN_sting = nums[1].Split(" ");
                List<int> ownN = new List<int>();
                for (int j = 0; j < ownN_sting.Length; j++)
                {
                    if (isInt(ownN_sting[j]))
                        ownN.Add(int.Parse(ownN_sting[j]));
                }
                Card temp = new Card(int.Parse($"{lines[i][5]}{lines[i][6]}{lines[i][7]}"), winN, ownN);
                list.Add(temp);
            }
            return list;
        }
        public static void part1(List<Card> list)
        {
            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                int card_result = 0;
                for (int j = 0; j < list[i].win_nums.Count; j++)
                {
                    for (int k = 0; k < list[i].own_nums.Count; k++)
                    {
                        if (list[i].win_nums[j] == list[i].own_nums[k])
                        {
                            if (card_result == 0)
                                card_result = 1;
                            else
                                card_result = card_result * 2;
                        }
                    }
                }
                result += card_result;
            }
            System.Console.WriteLine(result);
        }
        public static int CopyCounts(List<Card> list, int index)
        {
            int result = 0;
            for (int k = 1; k < list[index].matches + 1; k++)
                {
                    if (index + k < list.Count)
                        result += CopyCounts(list, index + k);
                }
            return result;
        }
        public static void part2(List<Card> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].win_nums.Count; j++)
                {
                    for (int k = 0; k < list[i].own_nums.Count; k++)
                    {
                        if (list[i].win_nums[j] == list[i].own_nums[k])
                            list[i].matches++;
                    }
                }
            }


            int result = 0;
            for (int l = 0; l < list.Count; l++)
            {
                System.Console.WriteLine("list l: " + l);
                for (int k = 1; k < list[l].matches + 1; k++)
                {
                    if (l + k < list.Count)
                        result += CopyCounts(list, l + k);
                }
            }
            System.Console.WriteLine(result);
        }

        public static void Main(string[] args)
        {
            List<Card> input = read();
            // for (int i = 0; i < input.Count; i++)
            // {
            //     System.Console.WriteLine(input[i].ToString());
            // }
            // part1(input);
            part2(input);

        }
    }
}