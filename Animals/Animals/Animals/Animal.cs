using System;
using System.Collections.Generic;
using System.Text;

/*enum Food
{
    cow = 1, chicken, rabbit, deer, whale, shark, carp, pike, moose, plankton, squid,//meat
    carrot, letuce, grass, cucumber, potato, peanut, almond,//plants
    honey, eggs, milk, caviar, mushrooms//other
        //I may have gone a bit overkill with the foods
}*/

enum Food
{
    rabbit ,chicken, deer, carp,cow,
    carrot, letuce, grass,cucumber,
    honey,eggs,milk,mushrooms
}


class Animal
{
    int health;
    Food[] foods;
    readonly int maxHealth;

    public Animal(int health, Food[] foods)
    {
        this.maxHealth = health;
        this.health = health;
        this.foods = new Food[foods.Length];
        for (int i = 0; i < foods.Length; i++)
        {
            this.foods[i] = foods[i];
        }
        Array.Sort(this.foods);
    }

    public bool eat(Food food)
    {
        if (health > 0)
        {
            if (isEdible(food))
            {
                health += (health < maxHealth) ? 1 : 0;
                Console.Write(" ate a " + food + ".");
            }
            else
            {
                health--;
                Console.Write(" did not eat a " + food + ".");
            }
            Console.WriteLine("  health = " + health);
            return true;
        }

        Console.WriteLine(" is dead.");
        return false;
    }


    bool isEdible(Food testedFood)
    {//uses Binary search to find if a piece of food is edible
        int left = 0;
        int right = this.foods.Length - 1;


        do
        {
            int middle = (left + right) / 2;
            if (testedFood == this.foods[middle] || testedFood == this.foods[left] || testedFood == this.foods[right])
                return true;
            if (testedFood > foods[middle])
            {
                left = middle;
                right--;
            }
            else
            {
                right = middle;
                left++;
            }


        } while (left < right);

        return false;

    }
}

