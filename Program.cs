using System.Dynamic;
using System.Globalization;
using System.Reflection.Metadata;


namespace Work6._6
{
    class Program
    {
        private static void Main(string[] args)
        {
            string note = @"note.txt";

            Repository rep = new Repository(note);

            while (true)
            {
                Console.WriteLine("0 - просмотреть все записи, \n" +
                    "1 - добавить запись, \n" +
                    "2 - удалить запись по id, \n" +
                    "3 - найти запись по id, \n" +
                    "4 - найти записи между двумя датами, \n" +
                    "9 - ВЫХОД \n");

                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (code) 
                {
                    case 0:
                        rep.WriteWorkerToConsole(rep.GetAllWorkers());
                        break;
                        
                    case 1:
                        Console.WriteLine("Введите ФИО, возраст, рост, дату и место рождения сотрудника: ");

                        string[] newWorker = new string[5];

                        for (int i = 0; i < newWorker.Length; i++)
                        {
                            newWorker[i] = Console.ReadLine();
                        }

                        rep.AddWorker(newWorker);
                        break; 

                    case 2:
                        Console.WriteLine("Введите id записи которую нужно удалить: ");

                        rep.DeleteWorker(Convert.ToInt32(Console.ReadLine()));

                        Console.WriteLine("Запись удалена!");
                        break; 

                    case 3:
                        rep.WriteWorkerToConsole(rep.GetWorkerById(Convert.ToInt32(Console.ReadLine())));
                        break;

                    case 4:
                        Console.WriteLine("Введите две даты, между которыми нужно произвести поиск: ");

                        Worker[] workers = rep.GetWorkersBetweenTwoDates(DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null), DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null));
                        rep.WriteWorkerToConsole(workers);
                        
                        break;
                    case 9: break;
                    default:
                        Console.WriteLine("Код операции введен неверно!");

                        break;
                }

                Console.WriteLine();

                if (code == 9) break;
            }


        }
    }
}