using System.Reflection.Metadata;

internal class Program
{
    static void WriteToFile(string text, string fileName)
    {
        using (StreamWriter sw = new StreamWriter(fileName)) 
        { 
            sw.WriteLine(text);
        }
    }

    static void ReadFromFile(string fileName)
    {
        string[] text = new string[7];
        using (StreamReader sr = new StreamReader(fileName))
        {
            Console.WriteLine($"ID {"EntryDate", -16} {"FullName", -32} Age Height DateOfBirth PlaceOfBirth");
            while(!sr.EndOfStream)
            {
                text = sr.ReadLine().Split('#');
                Console.WriteLine($"{text[0], -2} {text[1]} {text[2], -32} {text[3], -3} {text[4], -6} {text[5], -11} {text[6]}");
            }
        }
    }



    private static void Main(string[] args)
    {
        int choise;
        ReadFromFile("note.txt");
        while (true) 
        {
            choise = int.Parse(Console.ReadLine());

            if (choise == 1)
            {
                
            }
            else if (choise == 2)
            {
                Console.WriteLine("Введите Ф.И.О., Возраст, Рост, Дату рождения, Место рождения");
                string newEntry = Console.ReadLine();

                WriteToFile(newEntry, "note.txt");
            }
            else Console.WriteLine("Введите '1' или '2' чтобы продолжить или '0' для выхода");

            if (choise == 0) break;
        }


    }
}