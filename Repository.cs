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
            this.workers = new Worker[1];
        } 

        #region Поля

        private Worker[] workers;
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
            return new Worker(int.Parse(strings[0]), Convert.ToDateTime(strings[1]), strings[2], int.Parse(strings[3]), Convert.ToDateTime(strings[4]), strings[5]);
        }

        /// <summary>
        /// Преобразует поля структуры Worker в массив строк
        /// </summary>
        /// <param name="workers">"Экземпляр структуры Worker</param>
        /// <returns>Экземпляр структуры Worker</returns>
        private string[] WorkerToStrArray(Worker workers)
        {
            string[] strings = new string[] {$"{workers.ID}", workers.EntryDate.ToString("dd.MM.yyyy hh:mm"), workers.fullName, $"{workers.Age}", workers.DateOfBirth.ToString("dd.MM.yyyy"), workers.PlaceOfBirth};
            return strings;
        }

        /// <summary>
        /// Сохраняет массив экземпляра Worker в файл
        /// </summary>
        /// <param name="workers">Массив Worker</param>
        private void SaveWorkers(Worker[] workers)
        {
            using (StreamWriter sw = new StreamWriter(this.path, true))
            {

                foreach (Worker worker in workers)
                {
                    string[] strings = WorkerToStrArray(worker);
                    sw.Write('#');
                    foreach (string str in strings)
                    {
                        sw.Write(str.Trim() + '#');
                    }
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
            using (StreamReader sr = new StreamReader(this.path))
            {
                workers.Add(StrArrayToWorker(sr.ReadLine().Split("#")));
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
            return new Worker(-1, new DateTime(0, 0, 0), "0", 0, new DateTime(0, 0, 0), "0");
        }

        /// <summary>
        /// Удаляет запись по ID
        /// </summary>
        /// <param name="id">ID записи</param>
        public void DeleteWorker(int id)
        {
            // считывается файл, находится нужный Worker
            // происходит запись в файл всех Worker,
            // кроме удаляемого

            Worker[] workers = GetAllWorkers();

            int jump = 0;

            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].ID != id)
                {
                    workers[i - jump] = workers[i];
                }
                else
                {
                    i++;
                    jump++;
                }
            }
            SaveWorkers(workers);
        }

        public void AddWorker(Worker worker)
        {
            List<Worker> workers = new List<Worker>(GetAllWorkers());  

            int ID = workers.Last<Worker>().ID + 1;
            


        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
            // здесь происходит чтение из файла
            // фильтрация нужных записей
            // и возврат массива считанных экземпляров
        }

        #endregion
    }
}
