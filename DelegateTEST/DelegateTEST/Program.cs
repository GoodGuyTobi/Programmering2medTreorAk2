using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTEST
{
    class Program
    {
        delegate void Order();

        static void Main(string[] args)
        {
            Cashier();
        }
        
        static void  Cashier()
        {
            Order order = null;
            int choice = -1;
            Menu();

            while(choice !=0)
            {
                Console.Write("Your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        order += Burgers;
                        order += Fries;
                        order += Drinks;
                        break;

                    case 2:
                        order += Burgers;
                        break;

                    case 3:
                        order += Fries;
                        break;

                    case 4:
                        order += Drinks;
                        break;

                    case 5:
                        order = null;
                        break;

                    case 6:
                        choice = 0;
                        break;
                }
            }

            order.Invoke();

        }

        static void Menu()
        {
            Console.WriteLine("----------MENU----------");
            Console.WriteLine("1. Burgers & Stuff");
            Console.WriteLine("2. Burgers");
            Console.WriteLine("3. Fries");
            Console.WriteLine("4. Drink");
        }


        static void Burgers()
        {
            Console.WriteLine($"You ordered a burger.");
        }

        static void Fries()
        {
            Console.WriteLine($"You ordered fries.");
        }

        static void Drinks()
        {
            Console.WriteLine($"You ordered drink.");
        }

        static void Blabla()
        {
            // Retunerer void, 16 overloads.
            Action<int, int> tal = (x, y) => Console.WriteLine(x*y);

            // Returvärde, 17 overloads
            Func<int, string> talTillStr = x => $"Blabla {x}";


            List<int> siffror = new List<int>() { 1, 2, 3, 4, 5, 6 };

            siffror.FindAll(x => x%2 == 2);

        }
    }
}
