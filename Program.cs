using Microsoft.Win32.SafeHandles;
using System.Xml.Serialization;

namespace DZ_CS_16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ex2_3_4();
        }
        static void Ex1()
        {
            int size;
            Console.WriteLine("Enter size of array");
            size = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("--------------------------------------------");

            double[]? arr = new double[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter {i + 1} element of array: ");
                arr[i] = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Entered array:");
            foreach (var item in arr)
                Console.Write(item + "  ");

            Console.WriteLine("\n--------------------------------------------");

            FileStream stream = new FileStream("text.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(double[]));

            serializer.Serialize(stream, arr);
            if (stream.CanWrite)
                Console.WriteLine("Array has been serialised succesfully)))");
            stream.Close();
            Console.WriteLine("--------------------------------------------");

            stream = new FileStream("text.xml", FileMode.Open, FileAccess.Read);
            if (stream.CanRead)
            {
                arr = (double[])serializer.Deserialize(stream);
                Console.WriteLine("Deserialize successfully");
                Console.WriteLine("--------------------------------------------");
            }

            stream.Close();
            stream.Dispose();

            Console.WriteLine("Array after deserialization:");
            foreach (var item in arr)
                Console.Write(item + "  ");
        }
        static void Ex2_3_4()
        {
            Journal[] journals =
            {
                new Journal("Wall street journal", "WallStreet", 15, new DateTime(2023,12,15), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("Wall street journal", "WallStreet", 15, new DateTime(2023,12,15), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("Wall street journal", "WallStreet", 15, new DateTime(2023,12,15), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("Wall street journal", "WallStreet", 15, new DateTime(2023,12,15),
                new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("Wall street journal", "WallStreet", 15, new DateTime(2023,12,15),
                new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                //new Journal().InputInfo()
            };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Before serialization:");
            Console.ResetColor();
            foreach (var item in journals)
                item.ShowAll();
            Console.WriteLine("-------------------------------------------");

            FileStream stream = new FileStream("journals.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Journal[]));
            if (stream.CanWrite)
            {
                serializer.Serialize(stream, journals);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Serialization successfully");
                stream.Close();
                stream.Dispose();
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }

            stream = new FileStream("journals.xml", FileMode.Open, FileAccess.Read);
            if (stream.CanRead)
            {
                journals = (Journal[])serializer.Deserialize(stream);
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Deserialization succesfully");
                stream.Close();
                stream.Dispose();
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("After deserialization:");
            Console.ResetColor();
            foreach (var item in journals)
                item.ShowAll();
                
        }
    }
}