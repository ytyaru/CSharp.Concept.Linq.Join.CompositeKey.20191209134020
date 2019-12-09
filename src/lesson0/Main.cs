using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.Linq.Lesson0 {
    class Person
    {
        public string Name { get; set; }
        public int GenerateId { get; set; }
    }
    class Pet
    {
        public string Name { get; set; }
//        public Person Owner { get; set; }
        public string OwnerName { get; set; }
        public int GenerateId { get; set; }
    }
    class Main {
        private List<Person> persons;
        private List<Pet> pets;
        public void Run() {
            persons = CreatePersons();
            pets = CreatePets();
            Show(Query());
        }
        private List<Person> CreatePersons() {
            return new List<Person>() {
                new Person { Name="A", GenerateId=1 },
                new Person { Name="A", GenerateId=2 },
                new Person { Name="B", GenerateId=1 },
                new Person { Name="C", GenerateId=1 },
            };
        }
        private List<Pet> CreatePets() {
            return new List<Pet>() {
                new Pet { Name="a", OwnerName=persons[0].Name, GenerateId=1 },
                new Pet { Name="b", OwnerName=persons[0].Name, GenerateId=1 },
                new Pet { Name="c", OwnerName=persons[1].Name, GenerateId=1 },
                new Pet { Name="d", OwnerName=persons[0].Name, GenerateId=2 },
                new Pet { Name="z", OwnerName=null,            GenerateId=1 },
            };
        }
        private IEnumerable<dynamic> Query() {
            return  from person in persons
                    join pet in pets on new {person.Name, person.GenerateId} equals new {pet.OwnerName, pet.GenerateId} into gj
//                    join pet in pets on new {Name=person.Name, GenId=person.GenerateId} equals new {Name=pet.OwnerName, GenId=pet.GenerateId} into gj
                    from pet in gj
                    select new {
                        person.Name,
                        person.GenerateId,
                        PetName=pet.Name
//                        pet.GenId,
//                        PetName=pet.Name,
                    };
        }
        private void Show(in IEnumerable<dynamic> query) {
            foreach (var item in query) {
                Console.WriteLine($"Person.Name={item.Name}, GenId={item.GenId}, PetName={item.PetName}");
            }
        }
    }
}
