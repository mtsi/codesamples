using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoFactory.GangOfFour.Abstract.RealWorld
{
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();
            world = new AnimalWorld(america);
            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
    }


    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
        public abstract Problem CreateProblem();
        public abstract Giant CreateGiant();
        public abstract Giant CreateSmallGiant();
    }

    /// <summary>
    /// The 'ConcreteFactory1' class
    /// </summary>
    class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
        public override Problem CreateProblem()
        {
            return new Trouble();
        }

        public override Giant CreateGiant()
        {
            return new Elephant();
        }

        public override Giant CreateSmallGiant()
        {
            return new SmallElephant();
        }
    }

    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
        public override Problem CreateProblem()
        {
            return new Trouble();
        }

        public override Giant CreateGiant()
        {
            return new Elephant();
        }

        public override Giant CreateSmallGiant()
        {
            return new SmallElephant();
        }
    }

    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    abstract class Herbivore
    {
    }

    abstract class Giant
    {
        public abstract void Stomp(Herbivore h);
        public abstract void MakeSound();
    }

    abstract class Problem
    {
        public abstract void Eat(Carnivore c);
    }

    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }

    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    class Wildebeest : Herbivore
    {
    }

    class Elephant : Giant
    {
        public override void Stomp(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
                " stomps on " + h.GetType().Name);
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.GetType().Name +
                " makes trumpet sound!");
        }
    }

    class SmallElephant : Giant
    {
        public override void Stomp(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name +
                " lightly stomps on " + h.GetType().Name);
        }

        public override void MakeSound()
        {
            Console.WriteLine(this.GetType().Name +
                " makes a small trumpet sound!");
        }
    }

    class Trouble : Problem
    {
        public override void Eat(Carnivore c)
        {
            Console.WriteLine(this.GetType().Name +
                " eats " + c.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    class Bison : Herbivore
    {
    }

    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
              " eats " + h.GetType().Name);
        }
    }

    /// <summary>
    /// The 'Client' class
    /// </summary>
    class AnimalWorld
    {
        private Herbivore _herbivore;
        private Carnivore _carnivore;
        private Problem _problem;
        private Giant _giant;
        private Giant _giant2;

        // Constructor
        public AnimalWorld(ContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
            _problem = factory.CreateProblem();
            _giant = factory.CreateGiant();
            _giant2 = factory.CreateSmallGiant();
        }

        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
            _problem.Eat(_carnivore);
            _giant.Stomp(_herbivore);
            _giant.MakeSound();
            _giant2.MakeSound();
            _giant2.Stomp(_herbivore);
        }
    }
}
