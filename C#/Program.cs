using System;
using System.Collections.Generic;
using System.Text;

namespace Program360
{
    public class Castles
    {
        private static List<DataHolder> potential_points = new List<DataHolder>();
        private static int my_taxes;
        private static int nemesis_taxes;

        public static string Process(uint[,] grid)
        {
            potential_points.Clear();
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] != 0)
                    {
                        Point my_castle = new Point(i, j);
                        for (int k = 0; k < grid.GetLength(0); k++)
                        {
                            for (int l = 0; l < grid.GetLength(1); l++)
                            {
                                if (grid[k, l] != 0 && grid[i, j] != 0)
                                {
                                    Point nemesis_castle = new Point(k, l);
                                    Collect_Taxes(my_castle, nemesis_castle, grid);
                                    double castle_distance = Distance(my_castle, nemesis_castle);
                                    if (castle_distance > 3)
                                    // if the castles are at least 3 spaces away
                                    {
                                        if (my_taxes - nemesis_taxes > 0)
                                        // if the difference between the two castles' taxes is positive
                                        {
                                            potential_points.Add(new DataHolder(my_castle, nemesis_castle, my_taxes, nemesis_taxes));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            int highest_difference = 0;
            String answer = "";

            for (int i = 0; i < potential_points.Count; i++)
            {
                int current_difference = potential_points[i].Difference();
                if (current_difference > highest_difference)
                {
                    highest_difference = current_difference;
                    answer = "Your castle at (" + potential_points[i].me.x + "," + potential_points[i].me.y + ") earns " + potential_points[i].me_taxes +
                        ". Your nemesis' castle at (" + potential_points[i].nemesis.x + "," + potential_points[i].nemesis.y + ") earns " +
                        potential_points[i].their_taxes + ".";

                }
            }
            return answer;
        }

        public static void Collect_Taxes(Point me, Point them, uint[,] grid)
        {
            int me_taxes = 0;
            int them_taxes = 0;
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Point current_location = new Point(i, j);
                    if (Distance(current_location, me) == Distance(current_location, them))
                    {
                        me_taxes += 0;
                        them_taxes += 0;
                    }
                    else
                    {
                        if (Distance(current_location, me) < Distance(current_location, them) && Distance(current_location, me) <= 6)
                        {
                            me_taxes += (int)grid[i, j];
                        }
                        else if (Distance(current_location, me) > Distance(current_location, them) && Distance(current_location, them) <= 6)
                        {
                            them_taxes += (int)grid[i, j];
                        }
                    }
                }
            }
            my_taxes = me_taxes;
            nemesis_taxes = them_taxes;
            return;
        }

        /// <summary>
        /// This method calculates the distance between two points.
        /// </summary>
        /// <param name="x1">The first x value.</param>
        /// <param name="y1">The first y value.</param>
        /// <param name="x2">The second x value.</param>
        /// <param name="y2">The second y value.</param>
        /// <returns></returns>
        public static double Distance(Point one, Point two)
        {
            return Math.Sqrt(Math.Pow((two.x - one.x), 2) + Math.Pow((two.y - one.y), 2));
        }

        public static void Main(string[] args)
        {
            uint[,] kingdom = new uint[,] {
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                 { 0, 9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                 { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            };

            Console.WriteLine(Process(kingdom));
        }
    }
}
