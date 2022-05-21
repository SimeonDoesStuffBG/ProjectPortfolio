using System;
using System.Collections.Generic;
using System.Text;

enum Food
{
    cow, chicken, rabbit, whale, shark, carp, pike, moose, plankton, squid,//meat
    carrot, letuce, grass, cucumber, potato, peanut, almond,//plants
    honey, eggs, milk, caviar, mushrooms//other
        //I may have gone a bit overkill with the foods
}

namespace Animals.Animals
{
    class Animal
    {
        int health;
        Food[] foods;

        public Animal(int health, Food[] foods)
        {
            this.health = health;
            this.foods = new Food[foods.Length];
            for (int i =0; i<foods.Length; i++)
            {
                this.foods[i] = foods[i];
            }
            Array.Sort(this.foods);
            /*for(int i =0; i < foods.Length; i++)
            {
                Console.WriteLine(foods[i].ToString(), '\n');
            }*/
        }

        public void eat(Food food)
        {
            if (isEdible(food, 0, this.foods.Length))

                health++;
            else
                health--;
        }


        bool isEdible(Food testedFood, int left, int right)
        {//uses Binary search to find if a piece of food is edible
            int middle = (left + right) / 2;

            if (testedFood == this.foods[middle])
                return true;
            if (left == right)
                return false;
            if (testedFood < this.foods[middle])
                return isEdible(testedFood, left, middle);
            //if (searchedValue > food[middle])
                return isEdible(testedFood, middle, right);
        }
    }
}
