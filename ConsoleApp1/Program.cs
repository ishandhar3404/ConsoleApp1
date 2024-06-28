using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static List<Person> people = new List<Person>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter your name (or type 'exit' to quit): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                Person existingPerson = people.FirstOrDefault(p => p.Name.Equals(input, StringComparison.OrdinalIgnoreCase));
                if (existingPerson != null)
                {
                    
                    Console.WriteLine("Person found in the system:");
                    existingPerson.PersonStats();
                }
                else 
                {
                 
                    Console.WriteLine("No such person found, let's add a new one.");
                    Person newPerson = Person.Dialogue();
                    Console.WriteLine("Here are your results: ");
                    newPerson.CalorieGoals();
                    Console.Write("Would you like to save this person's information? (yes/no): ");
                    if (Console.ReadLine().ToLower() == "yes")
                    {
                        people.Add(newPerson);
                        Console.WriteLine("Person's information saved.");
                    }
                    newPerson.PersonStats();
                }

                Console.Write("Would you like to continue adding people? (yes/no): ");
                string continueAdding = Console.ReadLine();
                if (continueAdding.ToLower() != "yes")
                {
                    break;  
                }
            }
        }
    }
}

