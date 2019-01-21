using System;

namespace Hungarian
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();

            Console.WriteLine("Ко-во строк: ");
            int strNum = int.Parse(Console.ReadLine());
            matrix.setStrNum(strNum);

            Console.WriteLine("Ко-во столбцов: ");
            int colNum = int.Parse(Console.ReadLine());
            matrix.setColNum(colNum);
            
            matrix.toResultAuto();

            Console.ReadKey();
        }
    }
}


