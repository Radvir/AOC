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

namespace AOC_Day7
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
        static List<T> QuickSort<T>(List<T> lista, Func<T, T, int> comparator) => QuickSort(lista, 0, lista.Count - 1, comparator);
        static List<T> QuickSort<T>(List<T> lista, int e, int v, Func<T, T, int> comparator)
        {
            if (e < v)
            {
                (int i, int j) = (e, v);
                while (i != j)
                {
                    if (i < j != (comparator(lista[i], lista[j]) == -1))
                    {
                        (i, j) = (j, i);
                        (lista[i], lista[j]) = (lista[j], lista[i]);
                    }
                    j += i < j ? -1 : 1;
                }

                QuickSort(lista, e, i - 1, comparator);
                QuickSort(lista, i + 1, v, comparator);
            }
            return lista;
        }
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
            int total_winnings = 0;
            List<int> five_of_a_kind = new List<int>(); //index
            List<int> four_of_a_kind = new List<int>(); //index
            List<int> full_house = new List<int>(); //index
            List<int> three_of_a_kind = new List<int>(); //index
            List<int> two_pair = new List<int>(); //index
            List<int> one_pair = new List<int>(); //index
            List<int> high_card = new List<int>(); //index

            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<string, int> occurences = new Dictionary<string, int>();
                for (int j = 0; j < list[i].cards.Length; j++)
                {
                    if (occurences.ContainsKey($"{list[i].cards[j]}"))
                        occurences[$"{list[i].cards[j]}"]++;
                    else
                        occurences.Add($"{list[i].cards[j]}", 1);
                }


                if (list[i].cards[0] == list[i].cards[1] && list[i].cards[1] == list[i].cards[2] && list[i].cards[2] == list[i].cards[3] && list[i].cards[3] == list[i].cards[4])
                {
                    five_of_a_kind.Add(i);
                    continue;
                }

                bool br = false;
                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 4)
                    {
                        four_of_a_kind.Add(i);
                        br = true;
                        break;
                    }
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 3)
                    {
                        three_of_a_kind.Add(i);
                        br = true;
                        break;
                    }
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 3)
                    {
                        foreach (string m in occurences.Keys)
                        {
                            if (occurences[m] == 2)
                            {
                                full_house.Add(i);
                                br = true;
                                break;
                            }
                        }
                    }
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 2)
                    {
                        foreach (string m in occurences.Keys)
                        {
                            if (n != m && occurences[m] == 2)
                            {
                                two_pair.Add(i);
                                br = true;
                                break;
                            }
                        }
                    }
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 2)
                    {
                        one_pair.Add(i);
                        br = true;
                        break;
                    }
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] != 1)
                    {
                        br = true;
                        break;
                    }
                }
                if (br)
                    continue;
                else
                    high_card.Add(i);
            }

            Dictionary<string, List<int>> hand_types = new Dictionary<string, List<int>>();
            hand_types.Add("five_of_a_kind", five_of_a_kind);
            hand_types.Add("four_of_a_kind", four_of_a_kind);
            hand_types.Add("full_house", full_house);
            hand_types.Add("three_of_a_kind", three_of_a_kind);
            hand_types.Add("two_pair", two_pair);
            hand_types.Add("one_pair", one_pair);
            hand_types.Add("high_card", high_card);
            string card_types = "23456789TJQKA";

            //TODO: sort each list
            //hand_types[n] = QuickSort(hand_types[n], (a, b) => card_types.IndexOf(list[a].cards[0]) - card_types.IndexOf(list[b].cards[0]));

            int rank = 1;
            foreach (string n in hand_types.Keys)
            {
                for (int j = 0; j < hand_types[n].Count; j++)
                {
                    total_winnings += list[hand_types[n][j]].bid * rank;
                    rank++;
                }
            }
            System.Console.WriteLine(total_winnings);
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