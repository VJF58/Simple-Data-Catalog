using System.Dynamic;
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
                //rep.WriteWorkerToConsole(rep.GetAllWorkers());
                //Console.ReadLine();

                //Worker Daniel = new Worker("Joe", 24, 183, new DateTime(2003, 07, 28), "Pitsburg");
                //rep.AddWorker(Daniel);

                rep.WriteWorkerToConsole(rep.GetAllWorkers());
                //Console.ReadLine();

                rep.WriteWorkerToConsole(rep.GetWorkerById(99));
                //Console.ReadLine();

                //rep.DeleteWorker(3);
                //rep.WriteWorkerToConsole(rep.GetAllWorkers());
                //Console.ReadLine();

                //rep.WriteWorkerToConsole(rep.GetWorkersBetweenTwoDates(new DateTime(2023, 01, 01), DateTime.Now));
                //Console.ReadLine();
                
            }


        }
    }
}