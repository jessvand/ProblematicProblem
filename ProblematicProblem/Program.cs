using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static Random rng = new Random();
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
           
            Console.Write("Hello, welcome to the random activity generator! \n Would you like to generate a random activity? yes/no: ");
            var userResponse = Console.ReadLine().ToLower();

            while (userResponse != "no" && userResponse != "yes")
            {
                Console.WriteLine("Please answer 'yes' or 'no'.");
                userResponse = Console.ReadLine().ToLower();
            }
            

            if (userResponse == "no")
            {
                Console.WriteLine("Come back later then, I guess. Bye!");
                return;

            }
            else
            {

                Console.WriteLine("Great! Lets get started!");
            };

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            

            var willParse = int.TryParse(Console.ReadLine(), out int userAge);
            
            while (!willParse)
            {
                Console.WriteLine("No, no, no. Your AGE. How old are you?");
                willParse =int.TryParse(Console.ReadLine() , out userAge);
            }
            
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? yes / no:");
            userResponse = Console.ReadLine().ToLower();

            while(userResponse != "yes" && userResponse != "no")
            {
                Console.WriteLine("Please confirm or whether you'd like to see the current list of activities. yes / no:");
                userResponse = Console.ReadLine().ToLower();
            }
            

            if (userResponse == "yes")
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity}");
                    Thread.Sleep(250);
                }
                Console.WriteLine();

                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                userResponse = Console.ReadLine().ToLower();
                

                while (userResponse != "yes" && userResponse != "no")
                {
                    Console.WriteLine("Please indicate if you would like to add any activities to the list by typing 'yes' or 'no'");
                    userResponse = Console.ReadLine().ToLower();
                }
                Console.WriteLine();

                while (userResponse == "yes")
                {
                    Console.WriteLine("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();

                    Console.WriteLine("Would you like to add more? yes/no: ");
                    userResponse = Console.ReadLine(). ToLower();
                    
                    while (userResponse != "yes" && userResponse!= "no")
                    {
                        Console.WriteLine("Please indicate if you would like to add more activities to the list by typing 'yes' or 'no'");
                        userResponse = Console.ReadLine().ToLower();
                    }
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Please choose something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}!\n  Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();

                userResponse = Console.ReadLine().ToLower();

                while (userResponse != "keep" && userResponse != "redo")
                {
                    Console.WriteLine("Please indicate if you would like to add more activities to the list by typing 'keep' or 'redo'");
                    userResponse = Console.ReadLine().ToLower();
                }
                if(userResponse == "keep")
                {
                    cont = false;
                }
            }
        }
    }
}