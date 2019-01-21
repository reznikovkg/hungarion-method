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


            matrix.init();
            matrix.set();
            matrix.update();
            matrix.toCorrect();

            matrix.toLine();


            matrix.print();


            Console.ReadKey();
        }
    }
}


