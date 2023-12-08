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
        public override string ToString() { return $"{cards} {bid}"; }
    }
    public class Program
    {
        public static int comparator(Hand a, Hand b)
        {
            string asd = "J23456789TQKA";

            for (int i = 0; i < a.cards.Length; i++)
            {
                if (asd.IndexOf(a.cards[i]) > asd.IndexOf(b.cards[i])) return -1;
                if (asd.IndexOf(a.cards[i]) < asd.IndexOf(b.cards[i])) return 1;
            }
            return 0;
        }
        public static List<T> QuickSort<T>(List<T> lista, Func<T, T, int> comparator) => QuickSort(lista, 0, lista.Count - 1, comparator);
        public static List<T> QuickSort<T>(List<T> lista, int e, int v, Func<T, T, int> comparator)
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
            string[] lines = File.ReadAllLines("../input.txt");
            List<Hand> list = new List<Hand>();
            for (int i = 0; i < lines.Length; i++)
                list.Add(new Hand(lines[i].Split(" ")[0], int.Parse(lines[i].Split(" ")[1])));
            return list;
        }
        public static void part1(List<Hand> list)
        {
            int total_winnings = 0;
            List<Hand> five_of_a_kind = new List<Hand>();
            List<Hand> four_of_a_kind = new List<Hand>();
            List<Hand> full_house = new List<Hand>();
            List<Hand> three_of_a_kind = new List<Hand>();
            List<Hand> two_pair = new List<Hand>();
            List<Hand> one_pair = new List<Hand>();
            List<Hand> high_card = new List<Hand>();

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
                    five_of_a_kind.Add(list[i]);
                    continue;
                }

                bool br = false;
                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 4)
                    {
                        four_of_a_kind.Add(list[i]);
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
                                full_house.Add(list[i]);
                                br = true;
                                break;
                            }
                        }
                    }
                    if (br)
                        break;
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 3)
                    {
                        three_of_a_kind.Add(list[i]);
                        br = true;
                        break;
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
                                two_pair.Add(list[i]);
                                br = true;
                                break;
                            }
                        }
                    }
                    if (br)
                        break;
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 2)
                    {
                        one_pair.Add(list[i]);
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
                    high_card.Add(list[i]);
            }

            Dictionary<string, List<Hand>> hands = new Dictionary<string, List<Hand>>();
            hands.Add("five_of_a_kind", five_of_a_kind);
            hands.Add("four_of_a_kind", four_of_a_kind);
            hands.Add("full_house", full_house);
            hands.Add("three_of_a_kind", three_of_a_kind);
            hands.Add("two_pair", two_pair);
            hands.Add("one_pair", one_pair);
            hands.Add("high_card", high_card);

            int rank = 0;
            foreach (string n in hands.Keys)
            {
                hands[n] = QuickSort(hands[n], comparator);
                rank += hands[n].Count;
            }
            foreach (string n in hands.Keys)
            {
                for (int i = 0; i < hands[n].Count; i++)
                {
                    total_winnings += hands[n][i].bid * rank;
                    rank--;
                }
            }
            System.Console.WriteLine(total_winnings);
        }

        public static void part2(List<Hand> list)
        {
            int total_winnings = 0;
            List<Hand> five_of_a_kind = new List<Hand>();
            List<Hand> four_of_a_kind = new List<Hand>();
            List<Hand> full_house = new List<Hand>();
            List<Hand> three_of_a_kind = new List<Hand>();
            List<Hand> two_pair = new List<Hand>();
            List<Hand> one_pair = new List<Hand>();
            List<Hand> high_card = new List<Hand>();

            for (int i = 0; i < list.Count; i++)
            {
                Dictionary<string, int> occurences = new Dictionary<string, int>();
                occurences.Add("J", 0);
                for (int j = 0; j < list[i].cards.Length; j++)
                {
                    if (occurences.ContainsKey($"{list[i].cards[j]}"))
                        occurences[$"{list[i].cards[j]}"]++;
                    else
                        occurences.Add($"{list[i].cards[j]}", 1);
                }


                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 5 || (n != "J" && occurences[n] + occurences["J"] == 5))
                    {
                        five_of_a_kind.Add(list[i]);
                        continue;
                    }
                }

                bool br = false;
                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 4 || (n != "J" && occurences[n] + occurences["J"] == 4))
                    {
                        four_of_a_kind.Add(list[i]);
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
                            if (occurences[m] == 2 || (n != "J" && m != "J" && occurences[m] + occurences["J"] == 2)) //m never equals to n
                            {
                                full_house.Add(list[i]);
                                br = true;
                                break;
                            }
                        }
                    }
                    else if (n != "J" && occurences[n] + occurences["J"] == 3)
                    {
                        foreach (string m in occurences.Keys)
                        {
                            if (m != "J" && occurences[m] == 2)
                            {
                                full_house.Add(list[i]);
                                br = true;
                                break;
                            }
                        }
                    }
                    if (br)
                        break;
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 3 || (n != "J" && occurences[n] + occurences["J"] == 3))
                    {
                        three_of_a_kind.Add(list[i]);
                        br = true;
                        break;
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
                            if (n != m && (occurences[m] == 2 || (m != "J" && n != "J" && occurences[m] + occurences["J"] == 2)))
                            {
                                two_pair.Add(list[i]);
                                br = true;
                                break;
                            }
                        }
                    }
                    if (br)
                        break;
                }
                if (br)
                    continue;

                foreach (string n in occurences.Keys)
                {
                    if (occurences[n] == 2 || (n != "J" && occurences[n] + occurences["J"] == 2))
                    {
                        one_pair.Add(list[i]);
                        br = true;
                        break;
                    }
                }
                if (br)
                    continue;

                // foreach (string n in occurences.Keys)
                // {
                //     if (occurences[n] != 1)
                //     {
                //         br = true;
                //         break;
                //     }
                // }
                // if (br)
                //     continue;
                else
                    high_card.Add(list[i]);
            }

            Dictionary<string, List<Hand>> hands = new Dictionary<string, List<Hand>>();
            hands.Add("five_of_a_kind", five_of_a_kind);
            hands.Add("four_of_a_kind", four_of_a_kind);
            hands.Add("full_house", full_house);
            hands.Add("three_of_a_kind", three_of_a_kind);
            hands.Add("two_pair", two_pair);
            hands.Add("one_pair", one_pair);
            hands.Add("high_card", high_card);

            int rank = 0;
            foreach (string n in hands.Keys)
            {
                hands[n] = QuickSort(hands[n], comparator);
                rank += hands[n].Count;
            }
            foreach (string n in hands.Keys)
            {
                for (int i = 0; i < hands[n].Count; i++)
                {
                    total_winnings += hands[n][i].bid * rank;
                    rank--;
                }
            }
            System.Console.WriteLine(total_winnings);
        }

        public static void Main(string[] args)
        {
            List<Hand> input = read();
            // part1(input);
            part2(input);
        }
    }
}