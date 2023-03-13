using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Work6._6
{
    class Repository
    {
        /// <summary>
        /// Конструктор класса Repository
        /// </summary>
        /// <param name="Path">Путь к файлу</param>
        public Repository(string Path)
        {
            this.path = Path;
            if (!File.Exists(Path))
            {
                using (File.Create(Path));
                Console.WriteLine("Файлы локального справочника созданы");
            }
        } 

        #region Поля

        private string path;

        #endregion

        #region Методы

        /// <summary>
        /// Преобразует данные из массива строк в поля структуры Worker
        /// </summary>
        /// <param name="strings">Массив прочитанных из репозитория строк</param>
        /// <returns>Экземпляр структуры Worker</returns>
        private Worker StrArrayToWorker(string[] strings)
        {
            if (strings.Length == 5 )
            {
                return new Worker(strings[0], int.Parse(strings[1]), int.Parse(strings[2]), DateTime.ParseExact(strings[3], "dd.MM.yyyy", null), strings[4]);
            }
            else
            {
                return new Worker(int.Parse(strings[0]), DateTime.ParseExact(strings[1], "dd.MM.yyyy hh:mm", null), strings[2], int.Parse(strings[3]), int.Parse(strings[4]), DateTime.ParseExact(strings[5], "dd.MM.yyyy", null), strings[6]);
            }

        }

        /// <summary>
        /// Преобразует поля структуры Worker в массив строк
        /// </summary>
        /// <param name="workers">"Экземпляр структуры Worker</param>
        /// <returns>Массив строк содержащих поля структуры Worker</returns>
        private string[] WorkerToStrArray(Worker workers)
        {
            string[] strings = new string[] {$"{workers.ID}", workers.EntryDate.ToString("dd.MM.yyyy hh:mm"), workers.FullName, $"{workers.Age}", $"{workers.Height}", workers.DateOfBirth.ToString("dd.MM.yyyy"), workers.PlaceOfBirth};
            return strings;
        }

        /// <summary>
        /// Сохраняет массив экземпляра Worker в файл
        /// </summary>
        /// <param name="workers">Массив Worker</param>
        private void SaveWorkers(Worker[] workers)
        {
            using (StreamWriter sw = new StreamWriter(this.path, false))
            {
                foreach (Worker worker in workers)
                {
                    string[] strings = WorkerToStrArray(worker);
                    string str = strings[0].Trim();
  
                    for (int i = 1; i < strings.Length; i++)
                    {
                        str += '#' + strings[i].Trim();
                    }

                    sw.Write(str);
                    sw.WriteLine();
                }
            }
        }

        /// <summary>
        /// Чтение из файла и возврат полученных результатов
        /// </summary>
        /// <returns>Массив рузультатов</returns>
        public Worker[] GetAllWorkers()
        {
            List<Worker> workers = new List<Worker>();
            using (StreamReader sr = new StreamReader(@"note.txt"))
            {
                while(!sr.EndOfStream) workers.Add(StrArrayToWorker(sr.ReadLine().Split("#")));
            }
            return workers.ToArray();
        }

        /// <summary>
        /// Возвращает экземпляр структуры Worker по указанному ID
        /// </summary>
        /// <param name="id">ID записи</param>
        /// <returns>Worker с запрашиваеммы ID</returns>
        public Worker GetWorkerById(int id)
        {
            Worker[] workers = GetAllWorkers();

            foreach(Worker worker in workers) 
            {
                if (worker.ID == id)
                {
                    return worker;
                }
            }
            return new Worker(-1, new DateTime(1111, 01, 01), "0", 0, 0, new DateTime(1111, 01, 01), "0");
        }

        /// <summary>
        /// Удаляет запись по ID
        /// </summary>
        /// <param name="id">ID записи</param>
        public void DeleteWorker(int id)
        {
            Worker[] workers = GetAllWorkers();
            List<Worker> updatedWorkers = new List<Worker>();

            foreach(Worker worker in workers)
            {
                if(id != worker.ID)
                {
                    updatedWorkers.Add(worker);
                }
            }
            SaveWorkers(updatedWorkers.ToArray());
        }

        /// <summary>
        /// Добавляет рабочего в файл и сохраняет его
        /// </summary>
        /// <param name="worker">Экземпляр структуры Worker</param>
        public void AddWorker(string[] strings)
        {
            Worker worker = StrArrayToWorker(strings);
            List<Worker> workers = new List<Worker>(GetAllWorkers());

            int id;

            if (workers.Count == 0) id = 0;
            else id = workers.Last<Worker>().ID + 1;
            
            worker.ID = id;

            workers.Add(worker);

            SaveWorkers(workers.ToArray());

        }

        /// <summary>
        /// Возвращает массив экземпляров структуры Worker, для которых дата добавления соответсвует диапазону дат
        /// </summary>
        /// <param name="dateFrom">dateFrom < entrDate < dateTo</param>
        /// <param name="dateTo">dateFrom < entrDate < dateTo</param>
        /// <returns>Массив экземпляров стуктуры Worker</returns>
        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            Worker[] workers = GetAllWorkers();

            List<Worker> result = new List<Worker>();

            for (int i = 0; i < workers.Length; i++)
            {

                if (workers[i].EntryDate >= dateFrom)
                {
                    if (workers[i].EntryDate > dateTo) break;
                    result.Add(workers[i]);
                }
                
            }
            return result.ToArray();
        }

        /// <summary>
        /// Выводит в консоль таблицу Worker содержащую 1 запись
        /// </summary>
        /// <param name="worker">Экземпляр структуры рабочий</param>
        public void WriteWorkerToConsole(Worker worker)
        {
            Console.WriteLine($"ID {"EntryDate",-16} {"FullName",-32} Age Height DateOfBirth PlaceOfBirth");

            string[] text = WorkerToStrArray(worker);
            Console.WriteLine($"{text[0],-2} {text[1]} {text[2],-32} {text[3],-3} {text[4],-6} {text[5],-11} {text[6]}");
        }

        /// <summary>
        /// Выводит в консоль таблицу Worker содержащую записи о всех экземплярах массива структуры Worker 
        /// </summary>
        /// <param name="worker">Массив экземпляров структуры Worker</param>
        public void WriteWorkerToConsole(Worker[] workers)
        {
            Console.WriteLine($"ID {"EntryDate",-16} {"FullName",-32} Age Height DateOfBirth PlaceOfBirth");

            foreach (Worker worker in workers)
            {
                string[] text = WorkerToStrArray(worker);
                Console.WriteLine($"{text[0],-2} {text[1]} {text[2],-32} {text[3],-3} {text[4],-6} {text[5],-11} {text[6]}");
            }
        }

        #endregion
    }
}
