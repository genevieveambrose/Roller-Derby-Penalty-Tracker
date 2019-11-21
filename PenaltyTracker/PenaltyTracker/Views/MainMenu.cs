using System;
using System.Collections.Generic;
using System.Text;
using PenaltyTracker.DAL;
using PenaltyTracker.Models;

namespace PenaltyTracker
{
    public class MainMenu
    {
        private ISkaterDAO skaterDAO;
        private IPenatlyDAO penatlyDAO;

        public MainMenu(ISkaterDAO skaterDAO, IPenatlyDAO penatlyDAO)
        {
            this.skaterDAO = skaterDAO;
            this.penatlyDAO = penatlyDAO;
        }

        public void RunMainMenu()
        {
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();
                Console.Clear();
                switch (command.ToLower())
                {
                    case "1":
                        ShowAllSkaters();
                        break;

                    case "2":
                        SkaterSearch();
                        break;

                    case "3":
                        AddSkater();
                        break;

                    case "4":
                        UpdateSkater();
                        break;

                    case "5":
                        AddPenalty();
                        break;

                    case "6":
                        ListPenalties();
                        break;

                    case "7":
                        ListTypePenalties();
                        break;

                    case "8":
                        ShowAllPenalties();
                        break;
                    case "9":
                        RemoveSkater();
                        break;

                    case "q":
                        Console.WriteLine("Thank you for using the penalty tracker!");
                        return;

                    default:
                        Console.WriteLine("The command provided was not a valid command, please try again.");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("Press enter to return to the main menu");
                Console.ReadLine();
                Console.Clear();
                PrintMenu();
            }   
        }

        private void ShowAllPenalties()
        {
            IList<Penalty> penalties = penatlyDAO.ShowAllPenalties();
            if (penalties.Count > 0)
            {
                Console.WriteLine("      Penalty Type     Skater Number");
                foreach (Penalty penalty in penalties)
                {
                    Console.WriteLine($"{penalty.PenaltyId}     {penalty.PenaltyType}                {penalty.SkaterNumber} ");
                }
                Console.WriteLine($"Your team has recieved {penalties.Count} penalties");
            }
            else
            {
                Console.WriteLine("NO PENALTIES IN THE DATABASE");
            }
        }

        private void RemoveSkater()
        {
            //TODO try parse
            Console.WriteLine("Enter the number of the skater you would like to remove: ");
            int skaterNumber = int.Parse(Console.ReadLine());
            bool isRemoved = skaterDAO.RemoveSkater(skaterNumber);

            if (isRemoved)
            {
                Console.WriteLine("SUCCESS!");
            }
            else
            {
                Console.WriteLine("DID NOT REMOVE");
            }
        }

        private void ListTypePenalties()
        {
            Console.WriteLine("Enter the type of penalty to view (B, A, L, H, F, E, C, D, M, P, X, N, I, G)");
            string penaltyType = Console.ReadLine().ToUpper();
            List<string> validPenalties = new List<string>()
            {
                "B", "A", "L", "H", "F", "E", "C", "D", "M", "P", "X", "N", "I", "G"
            };
            if (validPenalties.Contains(penaltyType))
            {
                IList<Penalty> penalties = penatlyDAO.ShowTypePenalties(penaltyType);
                if (penalties.Count > 0)
                {
                    foreach (Penalty penalty in penalties)
                    {
                        Console.WriteLine($"{penalty.PenaltyType} was recieved by skater number {penalty.SkaterNumber.ToString()}");
                    }
                    Console.WriteLine($"There were {penalties.Count} type {penaltyType}!");
                }
                else
                {
                    Console.WriteLine($"NO {penaltyType} PENALTIES IN THE DATABASE");
                }
            }
            else
            {
                Console.WriteLine("Sorry, this is not a valid penalty type. Please hit enter to try again.");
                Console.ReadLine();
                Console.Clear();
                ListTypePenalties();
            }
        }

        private void ListPenalties()
        {
            //TODO try parse
            Console.WriteLine("Enter the skater number to view their penalties:");
            string userNumber = Console.ReadLine();
            int skaterNumber = int.Parse(userNumber);
            Console.WriteLine();
            IList<Penalty> penalties = penatlyDAO.ShowPenalties(skaterNumber);
            if (penalties.Count > 0)
            {
                Console.WriteLine("Skater Number    Penalty Type");
                foreach (Penalty penalty in penalties)
                {
                    Console.WriteLine(penalty.SkaterNumber.ToString().PadRight(17) + penalty.PenaltyType);
                }
                Console.WriteLine();
                Console.WriteLine($"{skaterNumber} has {penalties.Count} penalties!");
            }
            else
            {
                Console.WriteLine("NO PENALTIES IN THE DATABASE");
            }
        }

        private void AddPenalty()
        {
            //TODO try parse
            Console.WriteLine("Enter the skater number who has recieved the penalty");
            string userNumber = Console.ReadLine();
            int skaterNumber = int.Parse(userNumber);
            Console.WriteLine("Enter the type of penalty recieved (B, A, L, H, F, E, C, D, M, P, X, N, I, G)");
            string penaltyType = Console.ReadLine().ToUpper();
            List<string> penalties = new List<string>()
            {
                "B", "A", "L", "H", "F", "E", "C", "D", "M", "P", "X", "N", "I", "G"
            };

            if (penalties.Contains(penaltyType))
            {

                bool result = penatlyDAO.AddPenalty(skaterNumber, penaltyType);

                if (result)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Sorry, did not add penalty. Please try again!");
                }
            }
            else
            {
                Console.WriteLine("Sorry, this is not a valid penalty type. Please hit enter to try again.");
                Console.ReadLine();
                Console.Clear();
                AddPenalty();
            }
        }

        private void UpdateSkater()
        {
            Console.WriteLine("Enter the skater number whose name you would like to update:");
            string userInput = Console.ReadLine();
            int skaterNumber;
            bool isInt = int.TryParse(userInput, out skaterNumber);
            if (isInt)
            {
                Console.WriteLine("Enter the updated name");
                string newName = Console.ReadLine();

                Skater updatedSkater = new Skater
                {
                    Number = skaterNumber,
                    Name = newName
                };

                bool result = skaterDAO.UpdateSkater(updatedSkater);

                if (result)
                {
                    Console.WriteLine("Success!");
                }
                else
                {
                    Console.WriteLine("Sorry, did not update. Please try again!");
                }
            }
            else
            {
                Console.WriteLine("Sorry, this is not a valid skater number. Please hit enter to try again.");
                Console.ReadLine();
                Console.Clear();
                UpdateSkater();
            }
        }

        private void AddSkater()
        {
            Console.WriteLine("Enter the number of the skater you want to add: ");
            string userInput = Console.ReadLine();
            int userNumber;
            bool isInt = int.TryParse(userInput, out userNumber);
            if (isInt)
            {
                Console.WriteLine("Enter the name of the skater you want to add");
                string userName = Console.ReadLine();

                Skater newSkater = new Skater()
                {
                    Number = userNumber,
                    Name = userName
                };

                int id = skaterDAO.AddSkater(newSkater);

                if (id > 0)
                {
                    Console.WriteLine("SUCCESS!");
                }
                else
                {
                    Console.WriteLine("Did not create - please try again!");
                }
            }
            else
            {
                Console.WriteLine("This is not a valid number. Please hit enter to try again.");
                Console.ReadLine();
                Console.Clear();
                AddSkater();
            }
        }

        private void SkaterSearch()
        {
            Console.WriteLine("Enter the number of the skater");
            string userInput = Console.ReadLine();
            int skaterNumber;
            bool isInt = int.TryParse(userInput, out skaterNumber);
            if (isInt)
            {
                IList<Skater> skaters = skaterDAO.Search(skaterNumber);

                if (skaters.Count > 0)
                {
                    foreach (Skater skater in skaters)
                    {
                        Console.WriteLine($"Skater number {skater.Number} is {skater.Name}!");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, this skater is not on the roster. Please hit enter to try again.");
                    Console.ReadLine();
                    Console.Clear();
                    SkaterSearch();
                }
            }
            else
            {
                Console.WriteLine("This is not a valid skater number. Please hit enter to try again.");
                Console.ReadLine();
                Console.Clear();
                SkaterSearch();
            }
        }

        private void ShowAllSkaters()
        {
            IList<Skater> skaters = skaterDAO.ShowSkaters();
            if (skaters.Count > 0)
            {
                foreach (Skater skater in skaters)
                {
                    Console.WriteLine(skater.Number.ToString().PadRight(10) + skater.Name);
                }
            }
            else
            {
                Console.WriteLine("NO SKATERS IN THE DATABASE");
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine(@"        .'*.*'.==.      ______                _ _           _____              _                  .==.'*.*'.       ");
            Console.WriteLine(@"        '*/X@*'  (      | ___ \              | | |         |_   _|            | |                 )  '*@X\*'       ");
            Console.WriteLine(@"         //X@    '.     | |_/ /__ _ __   __ _| | |_ _   _    | |_ __ __ _  ___| | _____ _ __     .'    @X\\        ");
            Console.WriteLine(@"        ''X@      \     |  __/ _ \ '_ \ / _` | | __| | | |   | | '__/ _` |/ __| |/ / _ \ '__|    /      @X''       ");
            Console.WriteLine(@"    ____xX@        '    | | |  __/ | | | (_| | | |_| |_| |   | | | | (_| | (__|   <  __/ |      '        @Xx____   ");
            Console.WriteLine(@"   (____)      (____    \_|  \___|_| |_|\__,_|_|\__|\__, |   \_/_|  \__,_|\___|_|\_\___|_|          )            ) ");
            Console.WriteLine(@"   '....------._____|                                __/ |                                     |_____.------....'  ");
            Console.WriteLine(@"  (( . )       (( . )                               |___/                                     (( . )        (( . ) ");
            Console.WriteLine(@"   ``-'         ``-'                                                                           ``-'          ``-'  ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please type in a command");
            Console.WriteLine("1 - Show all skaters");
            Console.WriteLine("2 - Skater search by number");
            Console.WriteLine("3 - Add a new skater to the roster");
            Console.WriteLine("4 - Update skater name");
            Console.WriteLine("5 - Add a penalty to a skater");
            Console.WriteLine("6 - List a skater's penalties");
            Console.WriteLine("7 - List penalties by type");
            Console.WriteLine("8 - List all team penalties");
            Console.WriteLine("9 - Remove a skater from the roster");
            Console.WriteLine("Q - Quit");
        }
    }
}