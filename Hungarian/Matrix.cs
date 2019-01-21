using System;
using System.Collections.Generic;
using System.Text;

namespace Hungarian
{
    class Matrix
    {
        List<List<int>> values;

        int strNum;
        int colNum;

        List<bool> lineVertical;
        List<bool> lineHorizont;

        public Matrix()
        {
            lineVertical = new List<bool>();
            lineHorizont = new List<bool>();
        }

        public void setStrNum(int num)
        {
            this.strNum = num;
        }

        public void setColNum(int num)
        {
            this.colNum = num;
        }

        /**
         * Инициализация
         */
        public void init()
        {
            this.values = new List<List<int>>();
            for (int i = 0; i < this.strNum; i++)
            {
                this.values.Add(new List<int>());
                lineHorizont.Add(false);
                for (int j = 0; j < this.colNum; j++)
                {
                    this.values[i].Add(0);
                    lineVertical.Add(false);
                }
            }
        }

        /**
         * Печать
         */
        public void print()
        {
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 0; i < this.strNum; i++)
            {
                Console.Write(this.getLineHorizont(i)+"\t");
            }
            Console.WriteLine("");

            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    Console.Write(this.values[i][j].ToString() + "\t");
                }
                Console.Write(this.getLineVertical(i));
                Console.WriteLine("");
            }
        }

        public string getLineVertical(int i)
        {
            if (this.lineVertical[i])
            {
                return "+";
            } else
            {
                return "-";
            }
        }


        public string getLineHorizont(int i)
        {
            if (this.lineHorizont[i])
            {
                return "+";
            }
            else
            {
                return "-";
            }
        }


        /**
         * Присвоить значения 
         */
        public void set()
        {
            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    Console.Write("Элемент " + (i+1).ToString() + " строки " + (j + 1).ToString() + " столбца: ");
                    this.values[i][j] = Math.Abs( int.Parse(Console.ReadLine()) );
                }
            }
        }

        /**
         * Дополнить недостоющие строки и столбцы
         */
        public void update()
        {
            while (this.strNum != this.colNum)
            {
                if (this.strNum > this.colNum)
                {
                    this.colNum++;
                    lineVertical.Add(false);
                    for (int i = 0; i < this.strNum; i++)
                    {
                        this.values[i].Add(0);
                    }
                } else
                {
                    this.strNum++;
                    this.values.Add(new List<int>());
                    lineHorizont.Add(false);
                    for (int j = 0; j < this.colNum; j++)
                    {
                        this.values[this.strNum-1].Add(0);
                    }
                }
            }
        }

        /**
         * Привести матрицу
         */
        public void toCorrect()
        {
            for (int i = 0; i < this.strNum; i++)
            {
                int min = this.values[i][0];
                for (int j = 0; j < this.colNum; j++)
                {
                    if (min > this.values[i][j])
                    {
                        min = this.values[i][j];
                    }
                }

                for (int j = 0; j < this.colNum; j++)
                {
                    this.values[i][j] -= min;
                }

            }

            this.print();

            for (int i = 0; i < this.colNum; i++)
            {
                int min = this.values[0][i];
                for (int j = 0; j < this.strNum; j++)
                {
                    if (min > this.values[j][i])
                    {
                        min = this.values[j][i];
                    }
                }

                for (int j = 0; j < this.strNum; j++)
                {
                    this.values[j][i] -= min;
                }

            }

        }


        /**
         * Вычеркивание строк и слобцов
         */
        public void toLine()
        {
            for (int i = 0; i < this.strNum; i++)
            {
                int zeroInStr = 0;
                int zeroInStrPos = 0;
            


                for (int j = 0; j < this.colNum; j++)
                {
                    if ((0 == this.values[i][j]) && (this.lineHorizont[j] != true))
                    {
                        zeroInStr++;
                        zeroInStrPos = j;
                    }
                }

                if (zeroInStr == 1)
                {
                    this.lineHorizont[zeroInStrPos] = true;
                }

            }
        }
    }
}
