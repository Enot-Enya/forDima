using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Repository
    {

        List<Workers> workers { get; set; }


        public void PrintWorkers()
        {
            foreach (var worker in workers)
            {
                PrintWorker(worker);
            }            
        }
        public void PrintWorker(Workers worker)
        {
            Console.Write($"{worker.Id,4}\t");
            Console.Write($"{worker.SetTime,15}\t");
            Console.Write($"{worker.FullName,25}\t");
            Console.Write($"{worker.Age,5} \t");
            Console.Write($"{worker.Height,5} \t");
            Console.Write($"{worker.BirthdayDate:d}\t");
            Console.Write($"{worker.BirthdayPlace,15}\t\n");
        }

        public void GetAllWorkers()
        {
            workers = new List<Workers>();
            if (File.Exists("result.txt")) 
            {
                using (StreamReader sr = new StreamReader("result.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        workers.Add(ConvertToWorker(sr.ReadLine()));

                    }
                }
            }
        }

        private static Workers ConvertToWorker(string v)
        {
            Workers workers = new Workers();
            string[] tempArray = v.Split("#");
            workers.Id = int.Parse(tempArray[0].ToString());
            workers.SetTime = DateTime.Parse(tempArray[1].ToString());
            workers.FullName = tempArray[2].ToString();
            workers.Age = uint.Parse(tempArray[3].ToString());
            workers.Height = uint.Parse(tempArray[4].ToString());
            workers.BirthdayDate = DateTime.Parse(tempArray[5].ToString());
            workers.BirthdayPlace = tempArray[6].ToString();

            return workers; 
        }

        public Workers GetWorkerById(int id)
        {
            for (int i = 0; i < workers.Count; i++)
            {
                if (id == workers[i].Id)
                {
                    return workers[i];
                }
            }
            Console.WriteLine("Нет такого айди");
            return new Workers();
        }

        public void DeleteWorker()
        {
            int id;
            Console.WriteLine("Введите айди кого хотите удалить");
            while (true)
            {
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out id)) break;
            }
            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].Id == id)
                {
                    workers.RemoveAt(i);
                    break;
                }
            }
            ReWriteWorkers();
        }

        public void AddWorker()
        {
            uint age, height;
            DateTime BD;
            int id = (workers.Count == 0 ) ? 1 : workers[workers.Count - 1].Id + 1;
            string fullname = InputToWorkers("Введите ФИО");
            while(!uint.TryParse(InputToWorkers("Введите возраст"), out age)) { };
            while (!uint.TryParse(InputToWorkers("Введите рост"), out height)) { };
            while (!DateTime.TryParse(InputToWorkers("Введите Дату рождения"), out BD)) { };
            string BP = InputToWorkers("Введите место рождения");

            Workers result = new Workers(id, DateTime.Now, fullname, age, height, BD, BP);
            workers.Add(result);
            ReWriteWorkers();
            
        }

        private void ReWriteWorkers()
        {
            File.Delete("result.txt");
            using (StreamWriter sw = new StreamWriter("result.txt", true))
            {
                for (int i = 0; i < workers.Count; i++)
                {
                    sw.WriteLine($"{workers[i].Id}#{workers[i].SetTime}#{workers[i].FullName}#{workers[i].Age}#{workers[i].Height}#{workers[i].BirthdayDate}#{workers[i].BirthdayPlace}#");
                }                
            }
        }

        private string InputToWorkers(string v)
        {
            Console.WriteLine(v);
            return Console.ReadLine();
        }



        public void GetWorkersBetweenTwoDates()
        {
            DateTime dateA, dateB;
            Console.WriteLine("Введите начальную дату");
            dateA = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную дату");
            dateB = DateTime.Parse(Console.ReadLine());

            foreach (var item in workers)
            {
                if (item.SetTime >= dateA && item.SetTime <= dateB) PrintWorker(item);
            }
        }
    }
}
