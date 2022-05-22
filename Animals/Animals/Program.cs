using System;


    class Program
    {

       
        static void Main(string[] args)
        {
            int amountOfFoods = Enum.GetNames(typeof(Food)).Length;//Defining the possible number of possible foods because I don't need to look it up everytime I want to feed someone

            Animal[] animals = new Animal[15];
        
            Console.WriteLine("Hello World!");
        }
    }

