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
        public long DestinationStart;
        public long SourceStart;
        public long range;

        public TypeChange(long DestinationStart, long SourceStart, long range)
        {
            this.DestinationStart = DestinationStart;
            this.SourceStart = SourceStart;
            this.range = range;
        }
        public override string ToString()
        {
            string result = $"{DestinationStart} {SourceStart} {range}";
            return result;
        }
    }
    public class Map
    {
        public List<long> seeds;
        public List<TypeChange> seed_to_soil;
        public List<TypeChange> soil_to_fertilizer;
        public List<TypeChange> fertilizer_to_water;
        public List<TypeChange> water_to_light;
        public List<TypeChange> light_to_temperature;
        public List<TypeChange> temperature_to_humidity;
        public List<TypeChange> humidity_to_location;
        public List<long> soils;
        public List<long> fertilizers;
        public List<long> waters;
        public List<long> lights;
        public List<long> temperatures;
        public List<long> humiditys;
        public List<long> locations;

        public Map(List<long> seeds, List<TypeChange> seed_to_soil, List<TypeChange> soil_to_fertilizer, List<TypeChange> fertilizer_to_water, List<TypeChange> water_to_light, List<TypeChange> light_to_temperature, List<TypeChange> temperature_to_humidity, List<TypeChange> humidity_to_location, List<long> soils, List<long> fertilizers, List<long> waters, List<long> lights, List<long> temperatures, List<long> humiditys, List<long> locations)
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
        public static bool islong(string n)
        {
            if (long.TryParse(n, out long asd))
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
            List<long> seeds = new List<long>();
            for (int i = 1; i < string_seeds.Length; i++)
                seeds.Add(long.Parse(string_seeds[i]));

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
                    TypeChange typeChange = new TypeChange(long.Parse(string_typeChange[0]), long.Parse(string_typeChange[1]), long.Parse(string_typeChange[2]));
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

            List<long> asd = new List<long>();
            Map list = new Map(seeds, seed_to_soil: seed_to_soil, soil_to_fertilizer: soil_to_fertilizer, fertilizer_to_water: fertilizer_to_water, water_to_light: water_to_light, light_to_temperature: light_to_temperature, temperature_to_humidity: temperature_to_humidity, humidity_to_location: humidity_to_location, soils: asd, fertilizers: asd, waters: asd, lights: asd, temperatures: asd, humiditys: asd, locations: asd);
            return list;
        }
        public static void part1(Map list)
        {
            List<long> seeds = new List<long>(list.seeds);
            for (int i = 0; i < list.seeds.Count; i++)
            {
                for (int j = 0; j < list.seed_to_soil.Count; j++)
                {
                    if (seeds[i] >= list.seed_to_soil[j].SourceStart && seeds[i] < list.seed_to_soil[j].SourceStart + list.seed_to_soil[j].range)
                    {
                        seeds[i] = seeds[i] - (list.seed_to_soil[j].SourceStart - list.seed_to_soil[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.soil_to_fertilizer.Count; j++)
                {
                    if (seeds[i] >= list.soil_to_fertilizer[j].SourceStart && seeds[i] < list.soil_to_fertilizer[j].SourceStart + list.soil_to_fertilizer[j].range)
                    {
                        seeds[i] = seeds[i] - (list.soil_to_fertilizer[j].SourceStart - list.soil_to_fertilizer[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.fertilizer_to_water.Count; j++)
                {
                    if (seeds[i] >= list.fertilizer_to_water[j].SourceStart && seeds[i] < list.fertilizer_to_water[j].SourceStart + list.fertilizer_to_water[j].range)
                    {
                        seeds[i] = seeds[i] - (list.fertilizer_to_water[j].SourceStart - list.fertilizer_to_water[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.water_to_light.Count; j++)
                {
                    if (seeds[i] >= list.water_to_light[j].SourceStart && seeds[i] < list.water_to_light[j].SourceStart + list.water_to_light[j].range)
                    {
                        seeds[i] = seeds[i] - (list.water_to_light[j].SourceStart - list.water_to_light[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.light_to_temperature.Count; j++)
                {
                    if (seeds[i] >= list.light_to_temperature[j].SourceStart && seeds[i] < list.light_to_temperature[j].SourceStart + list.light_to_temperature[j].range)
                    {
                        seeds[i] = seeds[i] - (list.light_to_temperature[j].SourceStart - list.light_to_temperature[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.temperature_to_humidity.Count; j++)
                {
                    if (seeds[i] >= list.temperature_to_humidity[j].SourceStart && seeds[i] < list.temperature_to_humidity[j].SourceStart + list.temperature_to_humidity[j].range)
                    {
                        seeds[i] = seeds[i] - (list.temperature_to_humidity[j].SourceStart - list.temperature_to_humidity[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.humidity_to_location.Count; j++)
                {
                    if (seeds[i] >= list.humidity_to_location[j].SourceStart && seeds[i] < list.humidity_to_location[j].SourceStart + list.humidity_to_location[j].range)
                    {
                        seeds[i] = seeds[i] - (list.humidity_to_location[j].SourceStart - list.humidity_to_location[j].DestinationStart);
                        break;
                    }
                }
            }
            System.Console.WriteLine(seeds.Min());
        }

        public static void part2(Map list)
        {
            List<long> def_seeds = new List<long>(list.seeds);
            List<List<long>> seed_pairs = new List<List<long>>();
            List<long> seeds = new List<long>();
            for (int i = 0; i < def_seeds.Count; i += 2)
            {
                List<long> pair = new List<long>();
                pair.Add(def_seeds[i]);
                pair.Add(def_seeds[i + 1]);
                seed_pairs.Add(pair);

            }
            System.Console.WriteLine("asdf");
            for (int i = 0; i < seed_pairs.Count; i++)
            {
                int j = 0;
                while (seed_pairs[i][0] + j < seed_pairs[i][0] + seed_pairs[i][1]-1)
                {
                    seeds.Add(seed_pairs[i][0] + j);
                    j++;
                }
            }
            System.Console.WriteLine(seeds.Count);

            for (int i = 0; i < seeds.Count; i++)
            {
                for (int j = 0; j < list.seed_to_soil.Count; j++)
                {
                    if (seeds[i] >= list.seed_to_soil[j].SourceStart && seeds[i] < list.seed_to_soil[j].SourceStart + list.seed_to_soil[j].range)
                    {
                        seeds[i] = seeds[i] - (list.seed_to_soil[j].SourceStart - list.seed_to_soil[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.soil_to_fertilizer.Count; j++)
                {
                    if (seeds[i] >= list.soil_to_fertilizer[j].SourceStart && seeds[i] < list.soil_to_fertilizer[j].SourceStart + list.soil_to_fertilizer[j].range)
                    {
                        seeds[i] = seeds[i] - (list.soil_to_fertilizer[j].SourceStart - list.soil_to_fertilizer[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.fertilizer_to_water.Count; j++)
                {
                    if (seeds[i] >= list.fertilizer_to_water[j].SourceStart && seeds[i] < list.fertilizer_to_water[j].SourceStart + list.fertilizer_to_water[j].range)
                    {
                        seeds[i] = seeds[i] - (list.fertilizer_to_water[j].SourceStart - list.fertilizer_to_water[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.water_to_light.Count; j++)
                {
                    if (seeds[i] >= list.water_to_light[j].SourceStart && seeds[i] < list.water_to_light[j].SourceStart + list.water_to_light[j].range)
                    {
                        seeds[i] = seeds[i] - (list.water_to_light[j].SourceStart - list.water_to_light[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.light_to_temperature.Count; j++)
                {
                    if (seeds[i] >= list.light_to_temperature[j].SourceStart && seeds[i] < list.light_to_temperature[j].SourceStart + list.light_to_temperature[j].range)
                    {
                        seeds[i] = seeds[i] - (list.light_to_temperature[j].SourceStart - list.light_to_temperature[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.temperature_to_humidity.Count; j++)
                {
                    if (seeds[i] >= list.temperature_to_humidity[j].SourceStart && seeds[i] < list.temperature_to_humidity[j].SourceStart + list.temperature_to_humidity[j].range)
                    {
                        seeds[i] = seeds[i] - (list.temperature_to_humidity[j].SourceStart - list.temperature_to_humidity[j].DestinationStart);
                        break;
                    }
                }

                for (int j = 0; j < list.humidity_to_location.Count; j++)
                {
                    if (seeds[i] >= list.humidity_to_location[j].SourceStart && seeds[i] < list.humidity_to_location[j].SourceStart + list.humidity_to_location[j].range)
                    {
                        seeds[i] = seeds[i] - (list.humidity_to_location[j].SourceStart - list.humidity_to_location[j].DestinationStart);
                        break;
                    }
                }
            }
            System.Console.WriteLine(seeds.Min());
        }

        public static void Main(string[] args)
        {
            Map input = read();
            // System.Console.WriteLine(input.ToString());
            // part1(input);
            part2(input);
        }
    }
}