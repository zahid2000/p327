namespace task
{
    public class random
    {
        private string[] stringArray = Array.Empty<string>();

        public string this[int i]
        {
            get
            {
                return stringArray[i];
            }
            set
            {
                if (i == stringArray.Length)
                {
                    Array.Resize(ref stringArray, stringArray.Length + 1);

                    stringArray[i] = value;
                }
                else if (i < stringArray.Length && i >= 0)
                {
                    stringArray[i] = value;

                }
                else
                {
                    throw new IndexOutOfRangeException();
                }

            }
        }
    }


    public class Custom
    {
        //private int _age;
        //public int GetAge()
        //{
        //    return _age;
        //}
        //public void SetAge(int age)
        //{
        //        _age = age;
        //}
        //public int _age;    
        //    public int Age
        //{
        //    get => _age;
        //    set
        //    {
        //        if (value > 0 && value <= 200)
        //        {
        //            _age = value;
        //            return;
        //        }
        //        throw new Exception("Age is not valid!!");
        //    }
        //}
        public string Name { get; set; }
        public int Age { get; set; }

    }
}





