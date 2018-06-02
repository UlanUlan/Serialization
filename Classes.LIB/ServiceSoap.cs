using Classes.LIB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Classes.LIB
{
    public class ServiceSoap
    {
        public string pathToCsv = "Person.csv";
        public string pathToSoap = "Person.soap";

        Person p = new Person();
        public void PersonService()
        {
            FileInfo file = new FileInfo(pathToCsv);

            using (StreamReader sr = new StreamReader(pathToCsv))
            {
                string temp = sr.ReadLine();
                var m = temp.Split(' ');
                p.Name = m[0];
                p.Soname = m[1];
                p.tel = m[2];
                p.DateOfBirth = m[3];
                p.person.Add(p);
            }
            SoapSerialize();
        }

        public void SoapSerialize()
        {
            SoapFormatter formater = new SoapFormatter();

            using (FileStream fs = new FileStream(pathToCsv, FileMode.OpenOrCreate))
            {
                Console.WriteLine();
                formater.Serialize(fs, p);
                Console.WriteLine();
            }
        }
    }
}