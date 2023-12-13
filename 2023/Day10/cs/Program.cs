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
using System.Xml.XPath;

namespace AOC_DayX
{
    public class Program
    {
        public static List<List<string>> read()
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<List<string>> list = new List<List<string>>();
            for (int i = 0; i < lines.Length; i++)
            {
                List<string> temp = new List<string>();
                for (int j = 0; j < lines[i].Length; j++)
                    temp.Add(lines[i][j].ToString());
                list.Add(temp);
            }
            return list;
        }
        public static void part1(List<List<string>> list)
        {
            int result = 1;
            (int, int) start_index = (0, 0); //up&down --- left&right
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IndexOf("S") != -1)
                {
                    start_index = (i, list[i].IndexOf("S"));
                    break;
                }
            }

            (int, int) curr = start_index;
            for (int i = 0; i < 4; i++)
            {
                if (curr.Item1 > 0)
                {
                    string up = list[curr.Item1 - 1][curr.Item2];
                    if ((up == "|" || up == "F" || up == "7")) //above
                    {
                        curr = (curr.Item1 - 1, curr.Item2);
                        break;
                    }
                }
                if (curr.Item1 < list.Count) //belove
                {
                    string down = list[curr.Item1 + 1][curr.Item2];
                    if (down == "|" || down == "J" || down == "L")
                    {
                        curr = (curr.Item1 + 1, curr.Item2);
                        break;
                    }
                }
                if (curr.Item2 > 0) //left
                {
                    string left = list[curr.Item1][curr.Item2 - 1];
                    if (left == "-" || left == "F" || left == "L")
                    {
                        curr = (curr.Item1, curr.Item2 - 1);
                        break;
                    }
                }
                if (curr.Item2 < list[0].Count) //right
                {
                    string right = list[curr.Item1][curr.Item2 + 1];
                    if (right == "-" || right == "=" || right == "J")
                    {
                        curr = (curr.Item1, curr.Item2 + 1);
                        break;
                    }
                }
            }

            (int, int) prev_curr = start_index;
            while (curr != start_index)
            {
                string curr_value = list[curr.Item1][curr.Item2];
                if (curr_value == "|")
                {
                    if (prev_curr.Item1 == curr.Item1 - 1)//pipe coming from up
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 + 1, curr.Item2);
                    }
                    else //pipe coming from down
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 - 1, curr.Item2);
                    }
                }
                else if (curr_value == "-")
                {
                    if (prev_curr.Item2 == curr.Item2 - 1)//pipe is going right
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 + 1);
                    }
                    else //pipe is going left
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 - 1);
                    }
                }
                else if (curr_value == "L")
                {
                    if (prev_curr.Item1 == curr.Item1 - 1)//pipe coming from up
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 + 1);
                    }
                    else //pipe is going up
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 - 1, curr.Item2);
                    }
                }
                else if (curr_value == "J")
                {
                    if (prev_curr.Item1 == curr.Item1 - 1)//pipe comes from up
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 - 1); //going left
                    }
                    else //pipe is going up
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 - 1, curr.Item2);
                    }
                }
                else if (curr_value == "7")
                {
                    if (prev_curr.Item1 == curr.Item1 + 1) //coming from down
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 - 1);//going left
                    }
                    else //coming from left
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 + 1, curr.Item2);
                    }
                }
                else if (curr_value == "F")
                {
                    if (prev_curr.Item1 == curr.Item1 + 1) //coming from down
                    {
                        prev_curr = curr;
                        curr = (curr.Item1, curr.Item2 + 1);//going right
                    }
                    else //going down
                    {
                        prev_curr = curr;
                        curr = (curr.Item1 + 1, curr.Item2);
                    }
                }
                else System.Console.WriteLine("aalsékdfjlkéasdjfkléasdjfél");
                result++;
            }
            System.Console.WriteLine(result/2);//TODO: divede it by 2
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