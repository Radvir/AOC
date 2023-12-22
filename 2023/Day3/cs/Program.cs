using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Data.Common;
using System.Globalization;

namespace AOC_Day4
{
    public class Program
    {
        public static int getInt(List<string> list, int line, int index)
        {
            int curr_index = index;
            while (curr_index > 0 && isInt(list[line][curr_index - 1].ToString()))
                curr_index--;


            int string_num_len = 1;
            if (curr_index + 1 < list[line].Length && isInt($"{list[line][curr_index + 1]}"))
            {
                string_num_len = 2;
                if (curr_index + 2 < list[line].Length && isInt($"{list[line][curr_index + 2]}"))
                    string_num_len = 3;
            }
            string string_num = "";
            for (int i = 0; i < string_num_len; i++)
                string_num += list[line][curr_index + i];

            return int.Parse(string_num);
        }
        public static int gearRatio(List<string> list, int line, int index)
        {
            int first_num = 0;
            int first_num_line = -1;
            int second_num = 0;
            //left side
            if (0 < index && line > 0 && isInt(list[line - 1][index - 1].ToString())) //top left
            {
                int temp = getInt(list, line - 1, index - 1);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line - 1;
                }
            }
            if (0 < index && line + 1 < list[line].Length && isInt(list[line + 1][index - 1].ToString())) //down left
            {
                int temp = getInt(list, line + 1, index - 1);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line + 1;
                }
                else if (second_num == 0 && (first_num != temp || line + 1 != first_num_line))
                { System.Console.WriteLine(first_num + "-" + temp); return first_num * temp; }
            }
            if (0 < index && isInt(list[line][index - 1].ToString())) //left
            {
                int temp = getInt(list, line, index - 1);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line;
                }
                else if (second_num == 0)
                    return first_num * temp;
            }
            if (line > 0 && isInt(list[line - 1][index].ToString())) //above
            {
                int temp = getInt(list, line - 1, index);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line - 1;
                }
                else if (second_num == 0 && (first_num != temp || line - 1 != first_num_line))
                    return first_num * temp;
            }
            if (line < list.Count && isInt(list[line + 1][index].ToString())) //below
            {
                int temp = getInt(list, line + 1, index);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line + 1;
                }
                else if (second_num == 0 && (first_num != temp || line + 1 != first_num_line))
                {
                    return first_num * temp;
                }
            }
            //right
            if (index + 1 < list[0].Length && line > 0 && isInt(list[line - 1][index + 1].ToString())) //top right
            {
                int temp = getInt(list, line - 1, index + 1);
                if (first_num == 0)
                {
                    first_num = temp;
                    first_num_line = line - 1;
                }
                else if (second_num == 0 && (first_num != temp || line - 1 != first_num_line || list[line - 1][index] == '.'))
                    {System.Console.WriteLine(first_num + "-" + temp);return first_num * temp;}
            }
            if (index + 1 < list[0].Length && line + 1 < list[line].Length && isInt(list[line + 1][index + 1].ToString())) //down right
            {
                int temp = getInt(list, line + 1, index + 1);
                if (first_num == 0)
                    first_num = temp;
                else if (second_num == 0 && (first_num != temp || first_num_line != line + 1 || list[line + 1][index] == '.'))
                    {System.Console.WriteLine(first_num + "-" + temp);return first_num * temp;}
            }
            if (index + 1 < list[0].Length && isInt(list[line][index + 1].ToString())) //right
            {
                int temp = getInt(list, line, index + 1);
                if (first_num == 0)
                    first_num = temp;
                else if (second_num == 0)
                    return first_num * temp;
            }
            return first_num * second_num;
        }
        public static bool isInt(string n)
        {
            if (int.TryParse(n, out int asd))
                return true;
            return false;
        }
        public static bool isSymbol(string n)
        {
            if (n == "." || isInt(n))
                return false;
            return true;
        }
        public static List<string> read()
        {
            List<string> list = new List<string>();
            string[] lines = File.ReadAllLines("../input.txt");
            for (int i = 0; i < lines.Length; i++)
                list.Add(lines[i]);
            return list;
        }
        public static void part1(List<string> list)
        {
            int result = 0;
            // first line
            for (int j = 0; j < list[0].Length; j++)
            {
                int string_num_len = 0;
                bool valid = false;
                int num_start_index = j;
                if (isInt($"{list[0][j]}"))
                {

                    //creating the num
                    string_num_len = 1;
                    if (j + 1 < list[0].Length && isInt($"{list[0][j + 1]}"))
                    {
                        string_num_len = 2;
                        if (j + 2 < list[0].Length && isInt($"{list[0][j + 2]}"))
                            string_num_len = 3;

                    }
                }
                if (string_num_len > 0)
                {
                    if (j > 0 && (isSymbol($"{list[0][j - 1]}") || isSymbol($"{list[0 + 1][j - 1]}")))
                        valid = true;
                    if (isSymbol($"{list[0 + 1][j]}")/*TODO:check above*/)
                        valid = true;
                    if (j + 1 < list[0].Length && (isSymbol($"{list[0][j + 1]}") || isSymbol($"{list[0 + 1][j + 1]}"/*TODO: chekc avove too*/)))
                        valid = true;
                    if (string_num_len > 1 && j + 2 < list[0].Length && (isSymbol($"{list[0][j + 2]}") || isSymbol($"{list[0 + 1][j + 2]}")/*TODO: chekc above*/))
                        valid = true;
                    if (string_num_len > 2 && j + 3 < list[0].Length && (isSymbol($"{list[0][j + 3]}") || isSymbol($"{list[0 + 1][j + 3]}")/*TODO: check above*/))
                        valid = true;
                }

                if (valid)
                {
                    string string_num = "";
                    for (int k = 0; k < string_num_len; k++)
                    {
                        string_num += list[0][num_start_index + k];
                    }
                    if (string_num != "")
                    {
                        result += int.Parse(string_num);
                        System.Console.WriteLine(string_num);
                    }
                }
                if (string_num_len > 0) j += string_num_len - 1;
            }

            // body
            for (int l = 1; l < list.Count - 1; l++)
            {
                for (int m = 0; m < list[l].Length; m++)
                {
                    int string_num_len = 0;
                    bool valid = false;
                    int num_start_index = m;
                    if (isInt($"{list[l][m]}"))
                    {
                        //creating the num
                        string_num_len = 1;
                        if (m + 1 < list[l].Length && isInt($"{list[l][m + 1]}"))
                        {
                            string_num_len = 2;
                            if (m + 2 < list[l].Length && isInt($"{list[l][m + 2]}"))
                                string_num_len = 3;

                        }
                    }
                    if (string_num_len > 0)
                    {
                        if (m > 0 && (isSymbol($"{list[l][m - 1]}") || isSymbol($"{list[l + 1][m - 1]}") || isSymbol($"{list[l - 1][m - 1]}")))
                            valid = true;
                        if (isSymbol($"{list[l + 1][m]}") || isSymbol($"{list[l - 1][m]}"))
                            valid = true;
                        if (m + 1 < list[l].Length && (isSymbol($"{list[l][m + 1]}") || isSymbol($"{list[l + 1][m + 1]}") || isSymbol($"{list[l - 1][m + 1]}")))
                            valid = true;
                        if (string_num_len > 1 && m + 2 < list[l].Length && (isSymbol($"{list[l][m + 2]}") || isSymbol($"{list[l + 1][m + 2]}") || isSymbol($"{list[l - 1][m + 2]}")))
                            valid = true;
                        if (string_num_len > 2 && m + 3 < list[l].Length && (isSymbol($"{list[l][m + 3]}") || isSymbol($"{list[l + 1][m + 3]}") || isSymbol($"{list[l - 1][m + 3]}")))
                            valid = true;
                    }

                    if (valid)
                    {
                        string string_num = "";
                        for (int k = 0; k < string_num_len; k++)
                        {
                            string_num += list[l][num_start_index + k];
                        }
                        if (string_num != "")
                        {
                            result += int.Parse(string_num);
                            System.Console.WriteLine(string_num);
                        }
                    }
                    if (string_num_len > 0) m += string_num_len - 1;
                }
            }
            // last line
            int last_index = list.Count - 1;
            for (int n = 0; n < list[last_index].Length; n++)
            {
                int string_num_len = 0;
                bool valid = false;
                int num_start_index = n;
                if (isInt($"{list[last_index][n]}"))
                {
                    //creating the num
                    string_num_len = 1;
                    if (n + 1 < list[last_index].Length && isInt($"{list[last_index][n + 1]}"))
                    {
                        string_num_len = 2;
                        if (n + 2 < list[last_index].Length && isInt($"{list[last_index][n + 2]}"))
                            string_num_len = 3;
                    }
                }
                if (string_num_len > 0)
                {
                    if (n > 0 && (isSymbol($"{list[last_index][n - 1]}") || isSymbol($"{list[last_index - 1][n - 1]}")))
                        valid = true;
                    if (isSymbol($"{list[last_index - 1][n]}"))
                        valid = true;
                    if (n + 1 < list[last_index].Length && (isSymbol($"{list[last_index][n + 1]}") || isSymbol($"{list[last_index - 1][n + 1]}")))
                        valid = true;
                    if (string_num_len > 1 && n + 2 < list[last_index].Length && (isSymbol($"{list[last_index][n + 2]}") || isSymbol($"{list[last_index - 1][n + 2]}")))
                        valid = true;
                    if (string_num_len > 2 && n + 3 < list[last_index].Length && (isSymbol($"{list[last_index][n + 3]}") || isSymbol($"{list[last_index - 1][n + 3]}")))
                        valid = true;
                }

                if (valid)
                {
                    string string_num = "";
                    for (int k = 0; k < string_num_len; k++)
                    {
                        string_num += list[last_index][num_start_index + k];
                    }
                    if (string_num != "")
                    {
                        result += int.Parse(string_num);
                        System.Console.WriteLine(string_num);
                    }
                }
                if (string_num_len > 0) n += string_num_len - 1;
            }
            System.Console.WriteLine(result);
        }
        public static void part2(List<string> list)
        {
            int result = 0;
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    if (list[i][j] == '*')
                    {
                        result += gearRatio(list, i, j);
                    }
                }
            }
            System.Console.WriteLine(result);
        }

        public static void Main(string[] args)
        {
            List<string> input = read();
            // part1(input);
            part2(input);
        }
    }
}