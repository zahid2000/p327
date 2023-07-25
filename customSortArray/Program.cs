namespace customSortArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //throw new CustomEx("exception");
            #region buuble sort
            //int[] numbers = { 1, 2, 4, 31, 32, 543, 43, 44, 432, 243, 42332432, 324, 324, 324, 3 };
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (numbers[i] > numbers[j])
            //        {
            //            int last = numbers[i];
            //            numbers[i] = numbers[j];
            //            numbers[j] = last;
            //        }
            //    }
            //}

            //foreach (var item in numbers)
            //{
            //    Console.Write(item + " , ");

            //}
            #endregion

            #region polimorphism
            //Shark shark = new Shark();
            //shark.Eat();
            //Eagle eagle = new Eagle();
            //eagle.Eat();
            //ProductService productService = new ProductService(new ProductRepositoryBySql());
            //productService.Add();
            //string name = "Fikret";

            //name[2] ='A';
            //Shark shark = new Shark();
            //Console.WriteLine(name[2]);
            //Library library = new Library();
            //library[2] = new Book();
            //Console.WriteLine(library[1].Name);
            #endregion


        }
        #region Indexer

        //public class Book
        //{
        //    public string Name { get; set; }
        //}
        //public class Library
        //{


        //    private List<Book> books = new List<Book>() { new Book { Name="LOTR"},new Book { Name="Sefiller"} };
        //    public Book this[int i]
        //    {
        //        get
        //        {
        //            if (books.Count<i)
        //            {
        //                return null;
        //            }
        //            return books[i];
        //        }
        //        set
        //        {
        //            if (value==null)
        //            {
        //                Console.WriteLine("Bu dogru deyer deyil");
        //                return;
        //            }
        //            if (books.Count<i)
        //            {
        //                books.Add(value);
        //            }
        //            books[i] = value;
        //        }
        //}
        //public Book this[int i,int k]
        //{
        //    get
        //    {
        //        if (books.Count < i)
        //        {
        //            return null;
        //        }
        //        return books[i];
        //    }
        //    set
        //    {
        //        if (value == null)
        //        {
        //            Console.WriteLine("Bu dogru deyer deyil");
        //            return;
        //        }
        //        if (books.Count < i)
        //        {
        //            books.Add(value);
        //        }
        //        books[i] = value;
        //    }
        //}
        #endregion

        class CustomEx : Exception
        { 
            
            public CustomEx(string message) : base(message)
            {
                
            }
            public CustomEx() : base("My Custom Exception")
            {
                
            }
        }
        

    


        public abstract class Animal
        {
            public Animal()
            {
                Console.WriteLine("Animal created");
            }
            public virtual void Eat()
            {
                Console.WriteLine("Eat as animal");
            }
        }
        public abstract class Fish : Animal
        {
            public Fish()
            {
                Console.WriteLine("Fish created");
            }
            public override void Eat()
            {
                Console.WriteLine("Eat as Fish");
            }
        }
        public abstract class Bird : Animal
        {
            public Bird()
            {
                Console.WriteLine("Bird created");

            }
        }

        public class Shark : Fish
        {
            public Shark()
            {
                Console.WriteLine("Shark created");

            }
            public override void Eat()
            {
                Console.WriteLine("Eat as shark");
            }
        }

        public class Eagle : Bird
        {
            public Eagle()
            {
                Console.WriteLine("Eagle created");

            }
            public override void Eat()
            {
                Console.WriteLine("Eat as Eagle");
            }
        }
    }
}