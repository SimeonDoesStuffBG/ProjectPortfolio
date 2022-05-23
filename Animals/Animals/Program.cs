using System;


    class Program
    {
        static Random rand = new Random();

    static void Main(string[] args)
    {


        int amountOfFoods = Enum.GetNames(typeof(Food)).Length;//Defining the possible number of possible foods because I don't need to look it up everytime I want to feed someone

        Console.Write("How many Animals Do you wish the simulation to have: ");
        int amountOfAnimals = Math.Max(Convert.ToInt32(Console.ReadLine()), 0);//negative values are assumed to be zero;

        Animal[] animals = CreateAnimalPopulation(amountOfAnimals);

        while (SimulationStep(animals,amountOfFoods));
    }

    static bool SimulationStep(Animal[] animals, int amountOfFoods)
    {
        int amountOfAnimals = animals.Length;
        Console.WriteLine("In this Pass: ");
        bool animalsAreAlive = false;
        for (int i = 0; i < amountOfAnimals; i++)
        {
            Console.Write(animals[i].ToString() + " " + i);
            if (animals[i].eat((Food)rand.Next(1, amountOfFoods)))
            {
                animalsAreAlive = true;
            }
        }
        Console.WriteLine("\n");

        return animalsAreAlive;
    }

     static Animal[] CreateAnimalPopulation(int populationSize)
    {
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

