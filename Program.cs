using System.Dynamic;
using System.Reflection.Metadata;


internal class Program
{
    static void WriteToFile(string[] text, string fileName)
    {
        
        string[] lastLine = new string[7];

        int id = 0;

        DateTime now = new DateTime();
        now = DateTime.Now;

        if (File.Exists(fileName))
        {
            using (StreamReader sr = new StreamReader(fileName)) 
            {
                while(!sr.EndOfStream) lastLine = sr.ReadLine().Split('#');
                id = lastLine[0] is null ? 1 : int.Parse(lastLine[0]) + 1;
            }
        }

        using (StreamWriter sw = new StreamWriter(fileName, true))
        {
            string newEntry = Convert.ToString(id) + '#' + now.ToString("dd.MM.yyyy hh:mm");
            foreach (var i in text)
            {
                newEntry += '#' + i.Trim();
            }

            sw.WriteLine(newEntry);
        }
    }

    static void ReadFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] text = new string[7];
            using (StreamReader sr = new StreamReader(fileName))
            {
                Console.WriteLine($"ID {"EntryDate",-16} {"FullName",-32} Age Height DateOfBirth PlaceOfBirth");
                while (!sr.EndOfStream)
                {
                    text = sr.ReadLine().Split('#');
                    Console.WriteLine($"{text[0],-2} {text[1]} {text[2],-32} {text[3],-3} {text[4],-6} {text[5],-11} {text[6]}");
                }
            }
        }
        else Console.WriteLine("Базы данных не существует, нажмите '2' для создания");
    }



    private static void Main(string[] args)
    {
        int choise;
        Console.WriteLine("Введите '1' или '2'");

        while (true) 
        {
            choise = int.Parse(Console.ReadLine());

            string[] newEntryInfo = new string[] { "Ф.И.О", "Возраст", "Рост", "Дата рождения", "Место рождения" };

            if (choise == 1)
            {
                ReadFromFile("note.txt");
            }
            else if (choise == 2)
            {
                Console.WriteLine("Введите следующие данные:");
                for (int i = 0; i < newEntryInfo.Length; i++)
                {
                    Console.Write($"\t - {newEntryInfo[i]}: ");
                    newEntryInfo[i] = Console.ReadLine();
                }

                WriteToFile(newEntryInfo, "note.txt");
            }
            else Console.WriteLine("Введите '1' или '2' чтобы продолжить или '0' для выхода");

            if (choise == 0) break;
        }


    }
}