using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;
using System.Text;
using System.Threading.Tasks;

namespace DZ_CS_16
{
    [Serializable]
    [DataContract]
    public class Journal
    {
        [DataMember]
        public string? Name { get; set; }
        [DataMember]
        public string? ProducerName { get; set; }
        [DataMember]
        public DateTime DateOfIssue;
        [DataMember]
        public int? NumberOfPages { get; set; }
        [DataMember]
        public List<Article> Articles;

        public Journal() { }
        public Journal(string name, string productName, int numberOfPages, DateTime dateOfIssue, List<Article> articles)
        {
            Name = name;
            ProducerName = productName;
            NumberOfPages = numberOfPages;
            DateOfIssue = dateOfIssue;
            Articles = articles;
        }
        public Journal InputInfo()
        {
            Console.WriteLine("Enter name of journal:");
            string? name = Console.ReadLine();

            Console.Write("Enter name of journal producer:");
            string? producerName = Console.ReadLine();

            Console.WriteLine("Enter date of creation:");
            int day;
            int month;
            int year;
            Console.Write("Day: ");
            day = Convert.ToInt32(Console.ReadLine());
            Console.Write("Month: ");
            month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Year: ");
            year = Convert.ToInt32(Console.ReadLine());
            DateTime dateOfIssue = new DateTime(year, month, day);

            Console.Write("Enter number of pages: ");
            int numberOfPages = Convert.ToInt32(Console.ReadLine());
            List<Article>? articles = new List<Article>();
            
            Console.Write("Enter how much articles you want add: ");
            int count = Convert.ToInt32(Console.ReadLine());
            while (count != 0) 
            {
                Article article = new Article();
                article.InputArticleData();
                articles.Add(article);
                count--;
            }
            Journal journal = new Journal(name, producerName, numberOfPages, dateOfIssue, articles);
            return journal;
        }
        public void ShowAll()
        {
            Console.WriteLine(this.ToString());
            Console.WriteLine("---------------------------------------");
            foreach (var item in Articles)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("---------------------------------------");
            Console.ResetColor();

        }


        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return $"Name of journal: {Name}\n" +
                   $"Name of producer: {ProducerName}\n" +
                   $"Number of pages: {NumberOfPages}\n" +
                   $"Date of issue: {DateOfIssue.ToShortDateString()}\n" +
                   $"*************************************";
        }
    }
    [Serializable]
    [DataContract]
    public class Article
    {
        [DataMember]
        public string? ArticleText { get; set; }
        [DataMember]
        public string? ArticleAnnouncement { get; set;}
        [DataMember]
        public int? SymbolsAmount;

        public Article() { }

        public Article(string? articleText, string? articleAnnouncement)
        {
            ArticleText = articleText;
            ArticleAnnouncement = articleAnnouncement;
            SymbolsAmount = articleText?.Length;            
        }
        public void InputArticleData()
        {
            Console.WriteLine("Enter article announcement: ");
            ArticleAnnouncement = Console.ReadLine();
            Console.WriteLine("Enter full article:");
            ArticleText = Console.ReadLine();
            SymbolsAmount = ArticleText?.Length;
        }
        public override string ToString() 
        {Console.ForegroundColor = ConsoleColor.Red;
            return $"#########################################\n" +
                $"Article announcement: {ArticleAnnouncement}\n" +
                $"Article text\n{ArticleText}\n" +
                $"Amount of symbols in article: {SymbolsAmount}\n";
            
        }
    }
}
