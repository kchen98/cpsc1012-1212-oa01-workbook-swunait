﻿using System;

using System.IO;    // for StreamWriter, StreamReader, and File

namespace ParallelArrayDemo_HockeyPlayerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the maximum number of hockey players to track
            const int MaxPlayers = 2;
            // Declare and create a new string array for hockey player names
            string[] hockeyPlayerNameArray = new string[MaxPlayers];
            // Declare and create a new int array for hockey player points
            int[] hockeyPlayerPointArray = new int[MaxPlayers];
            // Declare a variable to track the current number of players
            int playerCount = 0;
            // Define the menu choice to exit the program
            const int ExitProgramChoice = 99;
            // Declare a variable to track the menuChoice
            int menuChoice;

            // Do the following:
            do
            {
                // Display Menu
                //Console.WriteLine("Hockey Player Stats");
                //Console.WriteLine("-------------------");
                //Console.WriteLine(" 1. Add Player");
                //Console.WriteLine(" 2. List Players");
                //Console.WriteLine(" 4. Remove Player");
                //Console.WriteLine(" 5. Remove All");
                //Console.WriteLine("11. Save data to file");
                //Console.WriteLine("12. Load data from file");
                //Console.WriteLine("99. Exit Program");
                //Console.Write("Enter your menu choice: ");
                const string MenuChoicePrompt = "Hockey Player Stats\n"
                    + "-------------------\n"
                    + " 1. Add Player\n"
                    + " 2. List Players\n"
                    + " 4. Remove Player\n"
                    + " 5. Remove All\n"
                    + "11. Save data to file\n"
                    + "12. Load data from file\n"
                    + "99. Exit Program\n"
                    + "Enter your menu choice: ";
                int[] AcceptedMenuChoiceArray = { 1, 2, 4, 5, 11, 12, 99 };

                // Process menu choice
                //menuChoice = int.Parse(Console.ReadLine());
                menuChoice = PromptForIntegerRange(MenuChoicePrompt, AcceptedMenuChoiceArray);

                switch (menuChoice)
                {
                    case 1: // Add Player
                        {
                            //Console.WriteLine("Add Player");
                            playerCount = AddPlayer(hockeyPlayerNameArray, hockeyPlayerPointArray, playerCount);
                        }
                        break;
                    case 2: // List Players
                        {
                            //Console.WriteLine("List Players");
                            ListPlayers(hockeyPlayerNameArray, hockeyPlayerPointArray, playerCount);
                        }
                        break;
                    case 4: // Remove Player
                        {
                            playerCount = RemovePlayer(hockeyPlayerNameArray, hockeyPlayerPointArray, playerCount);
                        }
                        break;
                    case 5: // Remove All 
                        {
                            playerCount = RemoveAll(hockeyPlayerNameArray, hockeyPlayerPointArray);
                            // Display a feedback message that all players have been removed.
                            Console.WriteLine("Succesfully removed all players from the system.");
                        }
                        break;
                    case 11: // Save data
                        {
                            SaveData(hockeyPlayerNameArray, hockeyPlayerPointArray, playerCount);
                        }
                        break;
                    case 12: // Load data
                        {
                            playerCount = LoadData(hockeyPlayerNameArray, hockeyPlayerPointArray);
                        }
                        break;
                    case 99: // Exit Program
                        {
                            Console.WriteLine("Exit Program");
                        }
                        break;
                    default:    // Invalid Menu Choice
                        {
                            Console.WriteLine("Invalid menu choice");
                        }
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            } while (menuChoice != ExitProgramChoice);

        }

        static string PromptForMinimumLengthString(string prompt, int minLength)
        {
            string stringValue = "";
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(prompt);
                stringValue = Console.ReadLine();
                if (stringValue.Trim().Length >= minLength)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine($"Invalid input value. Input value must contain at minimum {minLength} characters in length.");
                }
            }

            return stringValue;
        }

        static int PromptForIntegerRange(string prompt, int minValue, int maxValue)
        {
            int integerValue = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(prompt);
                try
                {
                    integerValue = int.Parse(Console.ReadLine());
                    if (integerValue >= minValue && integerValue <= maxValue)
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input value. Must be between {minValue} and {maxValue}.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return integerValue;
        }
        static int PromptForIntegerZeroOrPositive(string prompt)
        {
            int integerValue = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(prompt);
                try
                {
                    integerValue = int.Parse(Console.ReadLine());
                    if (integerValue >= 0)
                    {
                        validInput = true;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return integerValue;
        }
        static int PromptForIntegerRange(string prompt, int[] acceptedIntegerArray)
        {
            int integerValue = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(prompt);
                try
                {
                    integerValue = int.Parse(Console.ReadLine());

                    for (int index = 0; index < acceptedIntegerArray.Length; index++)
                    {
                        if (integerValue == acceptedIntegerArray[index])
                        {
                            validInput = true;
                            index = acceptedIntegerArray.Length;
                        }
                    }

                    if (!validInput)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Invalid input value. The input value must be one of the following: ");
                        foreach (int acceptedValue in acceptedIntegerArray)
                        {
                            Console.Write($"{acceptedValue},");
                        }
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            return integerValue;
        }

        static int RemoveAll(string[] nameArray, int[] pointArray)
        {
            for (int index = 0; index < nameArray.Length; index++)
            {
                // Assigned default values for each element
                nameArray[index] = null;
                pointArray[index] = 0;
            }
            return 0;
        }

        static int RemovePlayer(string[] nameArray, int[] pointArray, int arraySize)
        {
            int playerCount = arraySize;

            if (arraySize > 0)
            {
                // Prompt and read in the playerNo to remove
                ListPlayers(nameArray, pointArray, arraySize);

                //Console.Write("Enter the playerNo to remove: ");
                //int playerNo = int.Parse(Console.ReadLine());
                int playerNo = PromptForIntegerRange("Enter the playerNo to remove: ", 0, arraySize);

                if (playerNo != 0)
                {
                    int removeIndex = playerNo - 1;
                    // Shift elements start at removeIndex one element up
                    for (int index = removeIndex; index < (arraySize - 1); index++)
                    {
                        nameArray[index] = nameArray[index + 1];
                        pointArray[index] = pointArray[index + 1];
                    }
                    // Decrease the array size by 1
                    arraySize--;
                    // Reset the last element value to defaults
                    nameArray[arraySize] = null;
                    pointArray[arraySize] = 0;
                    // Print a message to let the user know the item has been removed
                    Console.WriteLine($"PlayerNo {playerNo} has been removed.");

                    // Set playerCount to arraySize
                    playerCount = arraySize;
                }

            }
            else
            {
                Console.WriteLine("There are no players in the system to remove.");
            }

            return playerCount;
        }

        static int AddPlayer(string[] nameArray, int[] pointArray, int arraySize)
        {
            int playerCount = 0;

            if (arraySize < nameArray.Length)
            {
                // Prompt and read in the player name
                //Console.Write("Enter hockey player name: ");
                //nameArray[arraySize] = Console.ReadLine();
                nameArray[arraySize] = PromptForMinimumLengthString("Enter hockey player name: ", 3);

                // Prompt and read in the player points
                //Console.Write("Enter hockey player points: ");
                //pointArray[arraySize] = int.Parse(Console.ReadLine());
                pointArray[arraySize] = PromptForIntegerZeroOrPositive("Enter hockey player points: ");
                // Increment arraySize
                arraySize++;
               
            }
            else
            {
                Console.WriteLine("Team is full - cannot add more players");
            }
            // Set playerCount to arraySize
            playerCount = arraySize;

            return playerCount;
        }

        static void ListPlayers(string[] nameArray, int[] pointArray, int arraySize)
        {
            if (arraySize == 0)
            {
                Console.WriteLine("There are no hockey players in the system.");
            }
            else
            {
                /*      12345678    123456789012345678901234567 123456
                 *      PlayerNo(8) Player Name (27)            Points (6)
                 *      --------    -----------                 ------
                 *             1    Ryan Nugent-Hopkins             18
                 *      
                 * */
                Console.WriteLine();
                Console.WriteLine($"{"PlayerNo",8}  {"Player Name",-27} {"Points",6}");
                Console.WriteLine($"{"--------",8}  {"-----------",-27} {"------",6}");
                for (int index = 0; index < arraySize; index++)
                {
                    Console.WriteLine($"{index + 1,8}  {nameArray[index],-27} {pointArray[index],6}");
                }
            }
        }

        static int LoadData(string[] nameArray, int[] pointArray)
        {
            int recordsRead = 0;
            // Prompt and read in the file path to read data from
            Console.Write("Enter the relative or absolute path of the file to import: ");
            string dataImportFilePath = Console.ReadLine();
            try
            {
                StreamReader reader = new StreamReader(dataImportFilePath);
                const char Delimiter = ',';
                string line;
                int index = 0;
                while (reader.EndOfStream == false && index < nameArray.Length)
                {
                    line = reader.ReadLine();
                    string[] lineValuesArray = line.Split(Delimiter);
                    nameArray[index] = lineValuesArray[0];
                    pointArray[index] = int.Parse(lineValuesArray[1]);
                    index++;
                }
                reader.Close();
                recordsRead = index;
                Console.WriteLine($"Successfully read data from {dataImportFilePath} ");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return recordsRead;
        }
        static void SaveData(string[] nameArray, int[] pointArray, int arraySize)
        {
            if (arraySize == 0)
            {
                Console.WriteLine("There are no hockey players in the system.");
            }
            else
            {
                // Prompt and read in the file path to write data to
                Console.Write("Enter relative or absolute path of the file to export to: ");
                string dataExportFilePath = Console.ReadLine();
                try
                {
                    // Create a StreamWriter object for writing to a text file
                    StreamWriter writer = new StreamWriter(dataExportFilePath);
                    // Define the delimiter character used to separate values
                    const char Delimiter = ',';
                    // Write each element from our parallel arrays to a file
                    for (int index = 0; index < arraySize; index++)
                    {
                        writer.WriteLine($"{nameArray[index]}{Delimiter}{pointArray[index]}");
                    }
                    writer.Close();
                    Console.WriteLine($"Succesfully saved data to {dataExportFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}