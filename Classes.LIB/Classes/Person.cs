﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.LIB.Modules
{
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public string Soname { get; set; }
        public string tel { get; set; }
        public string DateOfBirth { get; set; }

        [NonSerialized]
        public List<Person> person = new List<Person>();

        public Person[] persons;
        public void FilPerson()
        {
            persons = person.ToArray();
        }
    }
}
