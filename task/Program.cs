using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata;

namespace task
{
    internal class Program
    {
        //delegate void MyDelegate(string a, int b);
        delegate void Log(string Path);
        delegate bool Condition(int num);
        static void Main(string[] args)
        {
            #region Old
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

            //string sentence = "Salam,men,Huseynem";


            //static string[] customSplit(char separator,string sentence)
            //{
            //    string word = "";
            //    string[] words = { };
            //    for (int i = 0; i < sentence.Length; i++)
            //    {

            //        if (sentence[i] != separator)
            //        {
            //            word += sentence[i];
            //        }
            //        if (i+1==sentence.Length || sentence[i]==separator)
            //        {
            //            Array.Resize(ref words, words.Length + 1);
            //            words[words.Length - 1] = word;
            //            word = "";
            //        }
            //    }
            //    return words;
            //}
            //string[] arr = customSplit(',', sentence);
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}



            //Custom custom = new Custom();
            //  custom.Age=25;
            //  Console.WriteLine(custom.Age);
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //IExport export=new ExportToWord();
            //export.Export("d/test");
            //MyStatic.Age = 15;
            //Console.WriteLine(MyStatic.Age);
            //MyStatic myStatic = new MyStatic();
            //MyStatic myStatic2 = new MyStatic();
            //MyStatic myStatic3 = new MyStatic();
            //string word = "P327";
            //Console.WriteLine(word.CustomReverse());
            //double num = 5.2;
            //Console.WriteLine(num.CustomIntPow(3));
            //word.CustomIntPow(5);
            #endregion

            //MyDelegate myDelegate = new(Method);

            //myDelegate.Invoke("1", 2);
            //LogToDB("d/a/b");
            //LogToConsole("hjkhbj");
            //Log MyLogger = new Log(LogToDB);
            //MyLogger += LogToConsole;
            //MyLogger += LogToFile;
            //MyLogger("a/b/c");

            //int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 13, 14, 15, -1, -2, -3, -4, -5 };
            //Log log = LogToDB;
            //log += delegate (string path)
            //{
            //    Console.WriteLine(path);
            //};
            //log += (path) =>
            //{
            //    Console.WriteLine("arrow delegate " + path);
            //};
            //log("a/b/c");
            //ConsoleArr(arr,IsEven);
            //ConsoleArr(arr,IsOdd);
            Console.WriteLine(fact(5));

        }
        private static int fact(int num)
        {
            if (num <= 1) return 1;
            return num * fact(num - 1);
        }

        private static void ConsoleArr(int[] arr,Condition condition)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (condition(arr[i]))
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }
        public static bool IsEven(int num)
        {
            return num % 2==0;
        }
        public static bool IsOdd(int num)
        {
            return num % 2 != 0;
        }
        // static void Method(string d, int i)
        //{
        //    Console.WriteLine(d + i.ToString());
        //}


        public static void LogToDB(string Path)
        {
            Console.WriteLine("Logged to Db to" + Path);
        }
        //public static void LogToConsole(string test)
        //{
        //    Console.WriteLine("Logged to Console");
        //}
        //public static void LogToFile(string Path)
        //{
        //    Console.WriteLine("Logged to File to "+Path );
        //}
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
