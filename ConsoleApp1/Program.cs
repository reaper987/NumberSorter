using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Menu() //return method
        {
            Console.WriteLine("\n\nPress any key to return to the main menu...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Yellow;

            char menuOption;
            string filePath;
            List<double> numbers = new List<double>(); //declaration of a list for imported numbers
            List<string> errors = new List<string>(); //declaration of a list for errors during import
            List<double> ascNumbers = new List<double>(); //declaration of a list for numbers sorted in ascending order
            List<double> desNumbers = new List<double>(); //declaration of a list for numbers sorted in descending order
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to number sorter v1.0 by Jakub Veber");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Press [h] for help.");
                Console.WriteLine("Press [i] to import file with numbers to sort.");
                Console.WriteLine("Press [v] to view imported numbers.");
                Console.WriteLine("Press [a] to sort imported numbers in ascending order.");
                Console.WriteLine("Press [d] to sort imported numbers in descending order.");
                Console.WriteLine("Press [p] to show numbers sorted in ascending order.");
                Console.WriteLine("Press [r] to show numbers sorted in descending order.");
                Console.WriteLine("Press [s] to save numbers sorted in ascending order to a file.");
                Console.WriteLine("Press [x] to save numbers sorted in descending order to a file.");
                Console.WriteLine("Press [q] to quit the app.");
                Console.WriteLine("Enter your selection: ");
                menuOption = char.ToLower(Console.ReadKey().KeyChar);
                Console.Clear();
                switch (menuOption) //main menu
                {
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid selection. Please input correct letter corresponding with your choice.");
                        Menu();
                        break;
                    case 'h':
                        Console.Clear();
                        Console.WriteLine("\nThis app was made for university project." +
                            "\nStart by pressing letter [i] to import .txt file with numbers you want to sort. Each number has to be on a new line." +
                            "\nAfter the file has been loaded, you can press [v] to view the numbers in the file." +
                            "\nPress [a] or [d] to sort the numbers in [a]scending or [d]escending order." +
                            "\nYou can display numbers sorted in ascending order by pressing [p]." +
                            "\nYou can display numbers sorted in descending order by pressing [r]." +
                            "\nYou can save the numbers sorted in ascending order to a .txt file by pressing [s]." +
                            "\nYou can save the numbers sorted in descending order to a .txt file by pressing [x]." +
                            "\nTo quit, press [q].");
                        Menu();
                        break;
                    case 'i':
                        Console.Clear();
                        Console.WriteLine("Enter entire path for the file containing numbers you want to sort." +
                            @"For example C:\Users\user\Desktop\numbers.txt");
                        filePath = Convert.ToString(Console.ReadLine());
                        numbers.Clear(); //removes any data stored in numbers list
                        errors.Clear(); //removes any data stored in errors list
                        try
                        {
                            using (StreamReader sr = new StreamReader(filePath))
                            {
                                while (!(sr.EndOfStream))
                                {
                                    string line = sr.ReadLine();
                                    try
                                    {
                                        numbers.Add(double.Parse(line));
                                    }
                                    catch //adds values skipped during import to a list and displays it after the import is complete 
                                    {
                                        errors.Add(line);
                                    }
                                }
                            }
                            if (errors.Count > 0)
                            {
                                Console.WriteLine("There was a problem during importing data.");
                                Console.WriteLine("These values could not be imported");
                                foreach (string error in errors)
                                    Console.WriteLine(error);
                                Console.WriteLine("To view imported data press [v] in the main menu.");
                            }
                            else
                            {
                                Console.WriteLine("Imported completed successfully. No errors found.");
                                Console.WriteLine("To view imported data press [v] in the main menu.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("You've entered the wrong path or there is something wrong with your file.");
                        }
                        Menu();
                        break;
                    case 'v':
                        Console.Clear();
                        Console.WriteLine("Your imported numbers: ");
                        foreach (double x in numbers)
                            Console.WriteLine(x);
                        Menu();
                        break;
                    case 'a':
                        Console.Clear();
                        if (numbers.Count > 0)
                        {
                            ascNumbers.Clear();
                            ascNumbers.AddRange(numbers);
                            ascNumbers.Sort();
                            Console.WriteLine("Numbers sorted in ascending order." +
                                "\nTo view them, press [p] in the main menu");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("There is no data to sort.");
                            Menu();
                        }
                            break;
                    case 'd':
                        Console.Clear();
                        if (numbers.Count > 0)
                        {
                            desNumbers.Clear();
                            desNumbers.AddRange(numbers);
                            desNumbers.Sort();
                            desNumbers.Reverse();
                            Console.WriteLine("Numbers sorted in ascending order." +
                                "\nTo view them, press [p] in the main menu");
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("There is no data to sort.");
                            Menu();
                        }
                        break;
                    case 'p':
                        Console.Clear();
                        if (ascNumbers.Count > 0)
                        {
                            Console.WriteLine("Your imported numbers sorted in ascending order: \n");
                            foreach (double x in ascNumbers)
                                Console.WriteLine(x);
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("There is no data to view.");
                            Menu();
                        }
                            break;
                    case 'r':
                        Console.Clear();
                        if (desNumbers.Count > 0)
                        {
                            Console.WriteLine("Your imported numbers sorted in ascending order: \n");
                            foreach (double x in desNumbers)
                                Console.WriteLine(x);
                            Menu();
                        }
                        else
                        {
                            Console.WriteLine("There is no data to view.");
                            Menu();
                        }
                        break;
                    case 's':
                        Console.Clear();
                        if (ascNumbers.Count > 0)
                        {
                            Console.WriteLine("Enter entire path with the file name and extension you want to save." +
                                                   @"For example C:\Users\user\Desktop\sortednumbers.txt");
                            filePath = Convert.ToString(Console.ReadLine());
                            try
                            {
                                using (StreamWriter sr = new StreamWriter(filePath))
                                {
                                    foreach (double number in ascNumbers)
                                    {
                                        sr.WriteLine(number);
                                    }
                                    sr.Close();
                                    Console.WriteLine("\nData saved succesfully in: "+ filePath);
                                    Menu();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Invalid path or you don't have permission to write to the directory.");
                                Menu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no data to save.");
                            Menu();
                        }
                        break;
                    case 'x':
                        Console.Clear();
                        if (ascNumbers.Count > 0)
                        {
                            Console.WriteLine("Enter entire path with the file name and extension you want to save." +
                                                   @"For example C:\Users\user\Desktop\sortednumbers.txt");
                            filePath = Convert.ToString(Console.ReadLine());
                            try
                            {
                                using (StreamWriter sr = new StreamWriter(filePath))
                                {
                                    foreach (double number in desNumbers)
                                    {
                                        sr.WriteLine(number);
                                    }
                                    sr.Close();
                                    Console.WriteLine("\nData saved succesfully in: " + filePath);
                                    Menu();
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Invalid path or you don't have permission to write to the directory.");
                                Menu();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are no data to save.");
                            Menu();
                        }
                        break;
                    case 'q':
                        Console.Clear();
                        Console.WriteLine("Thank you, for using this app. Goodbye." +
                            "\nSlava Ukraini!" +
                            "\nPress any key to exit...");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                }
            } while (menuOption != 'q');
            Console.ReadKey();
        }
    }
}