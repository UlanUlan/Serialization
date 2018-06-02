using Classes.LIB.Modules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;

namespace Classes.LIB
{
    public class Service
    {
        public string path = "books.dat";

        public void BookAddService()
        {
            List<Book> listBooks = new List<Book>()
            {  new Book() { Author = "Докинз", Name = "Эгоистичный ген", Price = 8000, Year = 19476 },
             new Book(){Author = "Оруэлл",Name ="1949", Price = 2000,Year = 2015},
             new Book() { Author="Гиляровский", Name="Москва и Москвичи", Price = 6000,Year = 2013 }
            };


            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, listBooks);
            }

            using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                var bookList = (List<Book>)formatter.Deserialize(stream);
                foreach (Book item in bookList)
                    Console.WriteLine("Author - {0} | Name - {1} | Price - {2} | Year - {3}",
                        item.Author, item.Name, item.Price, item.Year);

            }

            Console.WriteLine();
        }
    }
}