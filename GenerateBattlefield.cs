using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_game
{
    public class GenerateBattlefield
    {
        /// <summary>
        /// Set random bool
        /// </summary>
        /// <returns>Random bool value</returns>
        public static bool RandomBool()
        {
            bool boolValue;
            Random random = new Random();
            if (Math.Round(random.NextDouble()).ToString() == "1")
            {
                boolValue = true;
            }
            else
            {
                boolValue = false;
            }
            return boolValue;
        }
        /// <summary>
        /// Create random battlefield containing 5 ships, which cant be placed on each other
        /// </summary>
        /// <returns>array of bool values</returns>
        public static bool[,] GenerateField()
        {
            bool[,] tab = new bool[10, 10];
            //int carrier = 5;
            //int battleship = 4;
            //int destroyer = 3;
            //int submarine = 3;
            //int patrolBoat = 2;

            int[] ships = new int[5] { 5, 4, 3, 3, 2 };

            Random random = new Random();
            for (int i = 0; i < ships.Length; i++)
            {
                bool isShipPlaced = false;
                while (!isShipPlaced)
                {
                    int row = random.Next(0, 10);
                    int column = random.Next(0, 10);
                    bool placeHorizontal = RandomBool();
                    int check = 0;
                    bool placedProperly = true;
                    while (placedProperly)
                    {
                        if (placeHorizontal)
                        {
                            if (row + ships[i] < 9)
                            {
                                for (int k = 0; k < ships[i]; k++)
                                {
                                    if (tab[row + k, column] == false)
                                    {
                                        check++;
                                    }
                                    if (check == ships[i])
                                    {
                                        for (int j = 0; j < ships[i]; j++)
                                        {
                                            tab[row + j, column] = true;
                                        }
                                        isShipPlaced = true;
                                    }
                                    else
                                    {
                                        placedProperly = false;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < ships[i]; k++)
                                {
                                    if (tab[row - k, column] == false)
                                    {
                                        check++;
                                    }
                                    if (check == ships[i])
                                    {
                                        for (int j = 0; j < ships[i]; j++)
                                        {
                                            tab[row - j, column] = true;
                                        }
                                        isShipPlaced = true;
                                    }
                                    else
                                    {
                                        placedProperly = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (column + ships[i] < 9)
                            {
                                for (int k = 0; k < ships[i]; k++)
                                {
                                    if (tab[row, column + k] == false)
                                    {
                                        check++;
                                    }
                                    if (check == ships[i])
                                    {
                                        for (int j = 0; j < ships[i]; j++)
                                        {
                                            tab[row, column + j] = true;
                                        }
                                        isShipPlaced = true;
                                    }
                                    else
                                    {
                                        placedProperly = false;
                                    }
                                }
                            }
                            else
                            {
                                for (int k = 0; k < ships[i]; k++)
                                {
                                    if (tab[row, column - k] == false)
                                    {
                                        check++;
                                    }
                                    if (check == ships[i])
                                    {
                                        for (int j = 0; j < ships[i]; j++)
                                        {

                                            tab[row, column - j] = true;
                                        }
                                        isShipPlaced = true;
                                    }
                                    else
                                    {
                                        placedProperly = false;
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return tab;
        }
    }
}
