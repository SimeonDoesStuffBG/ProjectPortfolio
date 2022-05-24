using System;


    class Program
    {
        static Random rand = new Random();
    //Defining the possible number of possible foods because I don't need to look it up everytime I want to feed someone
    static int amountOfFoods = Enum.GetNames(typeof(Food)).Length;
    static void Main(string[] args) 
    { 
        Animal[] animals = CreateAnimalPopulation();

        int passNumber = 0;
        while (SimulationStep(animals))
        {
            Console.WriteLine("Pass Number "+passNumber + ":");
            passNumber++;
        }
    }

    static bool SimulationStep(Animal[] animals)
    {
        int amountOfAnimals = animals.Length;
        bool animalsAreAlive = false;
        for (int i = 0; i < amountOfAnimals; i++)
        {
            Console.Write(animals[i].ToString() + " " + i);
            if (animals[i].eat((Food)rand.Next(0, amountOfFoods)))
            {
                animalsAreAlive = true;
            }
        }
        Console.WriteLine("\n");

        return animalsAreAlive;
    }

     static Animal[] CreateAnimalPopulation()
    {
        Console.Write("How many Animals Do you wish the simulation to have: ");
        int populationSize = Math.Max(Convert.ToInt32(Console.ReadLine()), 0);//negative values are assumed to be zero;

        Animal[] animals = new Animal[populationSize];

        for (int i = 0; i < populationSize; i++)
        {
            switch (rand.Next(0, 4))
            {
                case 0:
                    animals[i] = new Wolf();
                    break;
                case 1:
                    animals[i] = new Rabbit();
                    break;
                case 2:
                    animals[i] = new Bear();
                    break;
                default:
                    animals[i] = new Goat();
                    break;
            }
        }
        return animals;
    }
    }

