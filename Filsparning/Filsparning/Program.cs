using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Filsparning
{
    class Program
    {
        static string path = "C:\\C# Filer\\";

        static void Main(string[] args)
        {
            WriteTextToFile("Hellu", "text.txt");
            WriteTextToFile("På dig", "text.txt", true);

            //ReadTextFromFile("text.txt");


            SaveToFile("Dogs.blabla");
            ReadFromFile("Dogs.blabla");

            Console.ReadLine();
        }

        static void WriteTextToFile(string text, string fileName, bool append = false)
        {
            using (StreamWriter writer = new StreamWriter(path + fileName, append))
            {
                writer.WriteLine(text);
            }
        }

        static void ReadTextFromFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(path + fileName))
            {
                string text;
                while ((text = reader.ReadLine()) != null)
                    Console.WriteLine(text);

                // text = read.ReadToEnd();
            }
        }

        /*--------------------------------------*/
        static void SaveToFile(string fileName)
        {
            List<Dog> dogs = new List<Dog>() {
                    new Dog("Fluffy","Chow Chow"),
                    new Dog("Steven", "Jack Russel"),
                    new Dog("Penny", "Shiba Inu")};

            try
            {
                using (Stream stream = File.Open(path + fileName, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    bf.Serialize(stream, dogs);
                }
            }
            catch (IOException) { }
        }

        static void ReadFromFile(string fileName)
        {
            try
            {
                using (Stream stream = File.Open(path + fileName, FileMode.Open))
                { 
                    BinaryFormatter bf = new BinaryFormatter();
                    List<Dog> dogs = (List<Dog>)bf.Deserialize(stream);

                    foreach (Dog dog in dogs)
                    {
                        Console.WriteLine($"{dog.Name} is a {dog.Breed}");
                    }
                }
            }
            catch (IOException) { }
        }
    }

    [Serializable]
    public class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public Dog(string name, string breed) { Name = name; Breed = breed; }
    }
}
