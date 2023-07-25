using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;

namespace task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //int num = int.Parse(Console.ReadLine());

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int x;
            //    if (numbers[i] == num)
            //    {
            //        x = i;
            //        Console.WriteLine( i);
            //        return;
            //    }
            //}
            //throw new CustomNotFoundException("Item not found");
            //Person stu = new Student();
            //Person stu = new Student();
            //Student student = (Student)human;
            //Student student1 = human as Student;
            //stu.Eat();
            //if (stu is Developer dev)
            //{
            //    dev.RunC();
            //} else if (stu is Student stud)
            //{
            //    stud.SayHello();
            //}

            //test<int> test=new test<int>();
            //test.PrintArr(new int[] { 1, 2, 3 });
            //test<string> test = new test<string>();
            //test.PrintArr(new string[] { "Fikret", "Lutfi", "Semra" });
            //test<Person> test= new test<Person>();
            //List<int> ints = new List<int>() { };

            string sentence = "Salam,men,Huseynem";
         
           
            static string[] customSplit(char separator,string sentence)
            {
                string word = "";
                string[] words = { };
                for (int i = 0; i < sentence.Length; i++)
                {

                    if (sentence[i] != separator)
                    {
                        word += sentence[i];
                    }
                    if (i+1==sentence.Length || sentence[i]==separator)
                    {
                        Array.Resize(ref words, words.Length + 1);
                        words[words.Length - 1] = word;
                        word = "";
                    }
                }
                return words;
            }
            string[] arr = customSplit(',', sentence);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

           
            

        }

        public class test<T> 
            where T:class,new()
        {
            public void PrintArr(T[] arr)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }
            //public void PrintArr(object[] arr)
            //{
            //    foreach (var item in arr)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //public void PrintIntArr(int[] arr)
            //{
            //    foreach (var item in arr)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //public void PrintStrArr(string[] arr)

            //{
            //    foreach (var item in arr)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
        }


        public abstract class Person
        {
            public virtual void Eat()
            {
                Console.WriteLine("Eat food");
            }

    
        }

        public class Student:Person 
        {
            public override  void Eat()
            {
                Console.WriteLine("Eat C#");
            }
            public void SayHello()
            {
                Console.WriteLine("Hello World");
            }
        }
        public class Developer:Person
        {
            public void RunC()
            {
                Console.WriteLine("C# Is running");
            }
        }



    }
}
