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

namespace AOC_Day4
{
    public class TypeChange
    {
        public int DestinationStart;
        public int SourceStart;
        public int range;

        public TypeChange(int DestinationStart, int SourceStart, int range)
        {
            this.DestinationStart = DestinationStart;
            this.SourceStart = SourceStart;
            this.range = range;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < range; i++)
                result += DestinationStart + i + " ";
            return result;
        }
    }
    public class Map
    {
        public List<int> seeds;
        public List<TypeChange> seed_to_soil;
        public List<TypeChange> soil_to_fertilizer;
        public List<TypeChange> fertilizer_to_water;
        public List<TypeChange> water_to_light;
        public List<TypeChange> light_to_temperature;
        public List<TypeChange> temperature_to_humidity;
        public List<TypeChange> humidity_to_location;
        public List<int> soils;
        public List<int> fertilizers;
        public List<int> waters;
        public List<int> lights;
        public List<int> temperatures;
        public List<int> humiditys;
        public List<int> locations;

        public Map(List<int> seeds, List<TypeChange> seed_to_soil, List<TypeChange> soil_to_fertilizer, List<TypeChange> fertilizer_to_water, List<TypeChange> water_to_light, List<TypeChange> light_to_temperature, List<TypeChange> temperature_to_humidity, List<TypeChange> humidity_to_location, List<int> soils, List<int> fertilizers, List<int> waters, List<int> lights, List<int> temperatures, List<int> humiditys, List<int> locations)
        {
            this.seeds = seeds;
            this.seed_to_soil = seed_to_soil;
            this.soil_to_fertilizer = soil_to_fertilizer;
            this.fertilizer_to_water = fertilizer_to_water;
            this.water_to_light = water_to_light;
            this.light_to_temperature = light_to_temperature;
            this.temperature_to_humidity = temperature_to_humidity;
            this.humidity_to_location = humidity_to_location;
            this.soils = soils;
            this.fertilizers = fertilizers;
            this.waters = waters;
            this.lights = lights;
            this.temperatures = temperatures;
            this.humiditys = humiditys;
            this.locations = locations;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < seeds.Count; i++)
                result += seeds[i] + " ";
            result += "\n";
            result += "\nseed_to_soil\n";
            for (int i = 0; i < seed_to_soil.Count; i++)
                result += seed_to_soil[i].ToString() + "\n";
            result += "\nsoil_to_fertilizer\n";
            for (int i = 0; i < soil_to_fertilizer.Count; i++)
                result += soil_to_fertilizer[i].ToString() + "\n";
            result += "\nfertilizer_to_water\n";
            for (int i = 0; i < fertilizer_to_water.Count; i++)
                result += fertilizer_to_water[i].ToString() + "\n";
            result += "\nwater_to_light\n";
            for (int i = 0; i < water_to_light.Count; i++)
                result += water_to_light[i].ToString() + "\n";
            result += "\nlight_to_temperature\n";
            for (int i = 0; i < light_to_temperature.Count; i++)
                result += light_to_temperature[i].ToString() + "\n";
            result += "\ntemperature_to_humidity\n";
            for (int i = 0; i < temperature_to_humidity.Count; i++)
                result += temperature_to_humidity[i].ToString() + "\n";
            result += "\nhumidity_to_location\n";
            for (int i = 0; i < humidity_to_location.Count; i++)
                result += humidity_to_location[i].ToString() + "\n";
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
        public static Map read()
        {
            string[] lines = File.ReadAllLines("input.txt");
            List<List<string>> sections = new List<List<string>>();
            List<string> section = new List<string>();
            for (int i = 0; i < lines.Length + 1; i++)
            {
                if (i != lines.Length && lines[i] != "")
                    section.Add(lines[i]);
                else
                {
                    List<string> asdg = new List<string>(section);
                    sections.Add(asdg);
                    section.Clear();
                }
            }

            //seeds
            string[] string_seeds = sections[0][0].Split(" ");
            List<int> seeds = new List<int>();
            for (int i = 1; i < string_seeds.Length; i++)
                seeds.Add(int.Parse(string_seeds[i]));

            List<TypeChange> seed_to_soil = new List<TypeChange>();
            List<TypeChange> soil_to_fertilizer = new List<TypeChange>();
            List<TypeChange> fertilizer_to_water = new List<TypeChange>();
            List<TypeChange> water_to_light = new List<TypeChange>();
            List<TypeChange> light_to_temperature = new List<TypeChange>();
            List<TypeChange> temperature_to_humidity = new List<TypeChange>();
            List<TypeChange> humidity_to_location = new List<TypeChange>();

            for (int i = 1; i < sections.Count; i++)
            {
                for (int j = 1; j < sections[i].Count; j++)
                {
                    string[] string_typeChange = sections[i][j].Split(" ");
                    TypeChange typeChange = new TypeChange(int.Parse(string_typeChange[0]), int.Parse(string_typeChange[1]), int.Parse(string_typeChange[2]));
                    if (sections[i][0].Contains("seed-to-soil"))
                        seed_to_soil.Add(typeChange);
                    else if (sections[i][0].Contains("soil-to-fertilizer"))
                        soil_to_fertilizer.Add(typeChange);
                    else if (sections[i][0].Contains("fertilizer-to-water"))
                        fertilizer_to_water.Add(typeChange);
                    else if (sections[i][0].Contains("water-to-light"))
                        water_to_light.Add(typeChange);
                    else if (sections[i][0].Contains("light-to-temperature"))
                        light_to_temperature.Add(typeChange);
                    else if (sections[i][0].Contains("temperature-to-humidity"))
                        temperature_to_humidity.Add(typeChange);
                    else if (sections[i][0].Contains("humidity-to-location"))
                        humidity_to_location.Add(typeChange);
                    else
                        throw new Exception("error");
                }
            }

            List<int> asd = new List<int>();
            Map list = new Map(seeds, seed_to_soil: seed_to_soil, soil_to_fertilizer: soil_to_fertilizer, fertilizer_to_water: fertilizer_to_water, water_to_light: water_to_light, light_to_temperature: light_to_temperature, temperature_to_humidity: temperature_to_humidity, humidity_to_location: humidity_to_location, soils: asd, fertilizers: asd, waters: asd, lights: asd, temperatures: asd, humiditys: asd, locations: asd);
            return list;
        }
        public static void part1(Map list)
        {
            List<int> seeds = new List<int>(list.seeds);
            int i = 0;
            while (i < list.seed_to_soil.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.seed_to_soil[i].SourceStart && seeds[j] < list.seed_to_soil[i].SourceStart + list.seed_to_soil[i].range)
                    {
                        seeds[j] = seeds[j] - (list.seed_to_soil[i].SourceStart - list.seed_to_soil[i].DestinationStart);
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.soil_to_fertilizer.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.soil_to_fertilizer[i].SourceStart && seeds[j] < list.soil_to_fertilizer[i].SourceStart + list.soil_to_fertilizer[i].range)
                    {
                        seeds[j] = seeds[j] - (list.soil_to_fertilizer[i].SourceStart - list.soil_to_fertilizer[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.fertilizer_to_water.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.fertilizer_to_water[i].SourceStart && seeds[j] < list.fertilizer_to_water[i].SourceStart + list.fertilizer_to_water[i].range)
                    {
                        System.Console.WriteLine("asdfsadf");
                        seeds[j] = seeds[j] - (list.fertilizer_to_water[i].SourceStart - list.fertilizer_to_water[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.water_to_light.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.water_to_light[i].SourceStart && seeds[j] < list.water_to_light[i].SourceStart + list.water_to_light[i].range)
                    {
                        seeds[j] = seeds[j] - (list.water_to_light[i].SourceStart - list.water_to_light[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.light_to_temperature.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.light_to_temperature[i].SourceStart && seeds[j] < list.light_to_temperature[i].SourceStart + list.light_to_temperature[i].range)
                    {
                        seeds[j] = seeds[j] - (list.light_to_temperature[i].SourceStart - list.light_to_temperature[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.temperature_to_humidity.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.temperature_to_humidity[i].SourceStart && seeds[j] < list.temperature_to_humidity[i].SourceStart + list.temperature_to_humidity[i].range)
                    {
                        seeds[j] = seeds[j] - (list.temperature_to_humidity[i].SourceStart - list.temperature_to_humidity[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            System.Console.WriteLine(string.Join(" ", seeds));
            i = 0;
            while (i < list.humidity_to_location.Count)
            {
                for (int j = 0; j < seeds.Count; j++)
                {
                    if (seeds[j] >= list.humidity_to_location[i].SourceStart && seeds[j] < list.humidity_to_location[i].SourceStart + list.humidity_to_location[i].range)
                    {
                        seeds[j] = seeds[j] - (list.humidity_to_location[i].SourceStart - list.humidity_to_location[i].DestinationStart);
                        break;
                    }
                }
                i++;
            }
            //TODO: repeate this for the all changees

            System.Console.WriteLine(string.Join(" ", seeds));
        }
        public static void part2(Map list)
        {

        }

        public static void Main(string[] args)
        {
            Map input = read();
            // System.Console.WriteLine(input.ToString());
            part1(input);
            // part2(input);
        }
    }
}