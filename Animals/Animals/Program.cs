using System;


    class Program
    {

       
        static void Main(string[] args)
        {
            int foods = Enum.GetNames(typeof(Food)).Length;//Defining the possible number of possible foods because I don't need to look it up everytime I want to feed someone
            //Animals.Animal George = new Animals.Animal(10, (new Food[] { Food.cow, Food.almond, Food.carp, Food.caviar, Food.chicken }));
            Wolf George = new Wolf(); 
            Console.WriteLine("Hello World!");
        }
    }

