using System;
using System.Data;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace test
{
    internal class Program
    {
        public static Repository rep = new Repository();
        static void Main(string[] args)
        {            
            rep.GetAllWorkers();
            while (DoAgain()) { } 
        }


        private static bool DoAgain()
        {
            while (true)
            {
                Console.WriteLine("\n1 - Создать запись\n");
                Console.WriteLine("2 - Просмотреть все записи\n");
                Console.WriteLine("3 - Просмотреть 1 запись\n");
                Console.WriteLine("4 - Удаление записи\n");
                Console.WriteLine("5 - Просмотреть записи в диапозоне\n");
                Console.WriteLine("Выйти любой другой ввод");

                string userChoose = Console.ReadLine();
                
                switch (userChoose)
                {
                    case "1": rep.AddWorker(); break;
                    case "2": rep.PrintWorkers(); break;
                    case "3": PrintById(); break;
                    case "4": rep.DeleteWorker(); break;
                    case "5": rep.GetWorkersBetweenTwoDates(); break;
                    default: return false;
                }
            }
        }

        private static void PrintById()
        {
            int id;
            Console.WriteLine("Введите айди");
            while (!int.TryParse(Console.ReadLine(), out id)){ }
            rep.PrintWorker(rep.GetWorkerById(id));
        }
    }
}