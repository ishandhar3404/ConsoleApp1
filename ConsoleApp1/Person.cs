using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Activity { get; set; }

        public Person(string name, int age, double height, double weight, double activity)
        {
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            Activity = activity;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Height: {Height} cm, Weight: {Weight} kg, Activity Level: {Activity}";
        }

        public static Person Dialogue()
        {
            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            Console.Write("Hi " + name + "! How old are you?: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("What is your height in inches?: ");
            double height = Convert.ToDouble(Console.ReadLine()) * 2.54; // Convert inches to centimeters
            Console.Write("How much do you weigh in pounds?: ");
            double weight = Convert.ToDouble(Console.ReadLine()) * 0.453592; // Convert pounds to kilograms
            Console.Write("What is your activity level (1-6)?: ");
            int activity = Convert.ToInt32(Console.ReadLine());

            return new Person(name, age, height, weight, activity);
        }

        private double CalculateTDEE()
        {
            double bmr = (10 * Weight) + (6.25 * Height) - (5 * Age) + 5;
            double multiplier = 1.2 + (Activity - 1) * 0.175;
            double maintain = bmr * multiplier;
            return Math.Round(maintain, MidpointRounding.AwayFromZero);
        }

        public void DisplayCalorieGoals()
        {
            double tdee = CalculateTDEE();
            Console.WriteLine($"Maintenance Calories: {tdee:N2} kcal/day");
            Console.WriteLine($"Mild Weight Loss (0.5 lb/week): {tdee * 0.93:N2} kcal/day");
            Console.WriteLine($"Weight Loss (1 lb/week): {tdee * 0.85:N2} kcal/day");
            Console.WriteLine($"Extreme Weight Loss (2 lb/week): {tdee * 0.71:N2} kcal/day");
        }
    }
}



