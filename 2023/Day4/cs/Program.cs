using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace AOC_Day4
{
    public class Card
    {
        public List<int> win_nums;
        public List<int> own_nums;
        public Card(List<int> win_nums, List<int> own_nums)
        {
            this.win_nums = win_nums;
            this.own_nums = own_nums;
        }
        public override string ToString()
        {
            string result = "";
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
            return result;
        }
    }
    public class Program
    {
        public static bool isInt(string n){
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
                    if(isInt(ownN_sting[j]))
                        ownN.Add(int.Parse(ownN_sting[j]));
                }
                Card temp = new Card(winN, ownN);
                list.Add(temp);
            }
            return list;
        }
        public static void part1(List<Card> list) {
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
                            if(card_result == 0)
                                card_result = 1;
                            else
                                card_result = card_result*2;
                        }
                    }
                }
                result += card_result;
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
            part1(input);
        }
    }
}