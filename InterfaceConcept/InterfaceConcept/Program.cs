using System;

namespace InterfaceConcept
{
    static class Program
    {
        public static void Main(string[] args)

        {
            ChineseChef chefXi = new ChineseChef();
            KoreanChef chefKimJong = new KoreanChef();

            /**If chef Kim Jong is on leave then waiter can pass the order to chef chef Xi as he also knows to prepare noodle.
             * Here we have achieved loose coupliing
             * **/

            Waiter waiter = new Waiter();
            waiter.instructChefToCook(chefXi);
        }
    }

    interface IChef
    {
        void makeNoodles();
    }


    class ChineseChef : IChef
    {
        public void makeNoodles()
        {
            Console.WriteLine("Noodles ready!!");
        }
    }

    class KoreanChef : IChef
    {
        public void makeNoodles()
        {
            Console.WriteLine("Noodles ready!!");

        }
    }

    class Waiter
    {
        public void instructChefToCook(IChef chef)
        {
            Console.WriteLine("Instruction passed to chef. Food is getting ready!");
            chef.makeNoodles();
        }
    }


}
