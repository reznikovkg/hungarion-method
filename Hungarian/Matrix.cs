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

        List<int> result;

        public Matrix()
        {
            this.lineVertical = new List<bool>();
            this.lineHorizont = new List<bool>();
            this.result = new List<int>();
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

                this.lineHorizont.Add(false);
                this.result.Add(0);

                for (int j = 0; j < this.colNum; j++)
                {
                    this.values[i].Add(0);
                }
            }

            for (int j = 0; j < this.colNum; j++)
            {
                this.lineVertical.Add(false);
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
                Console.Write(this.getLineVertical(i) + "\t");
            }
            Console.WriteLine("");

            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    Console.Write(this.values[i][j].ToString() + "\t");
                }
                Console.Write(this.getLineHorizont(i));
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
            bool isEnd = true;

            int countRepeat = 0;

            while (isEnd)
            {
                isEnd = false;
                for (int i = 0; i < this.strNum; i++)
                {
                    if (this.lineHorizont[i] != true)
                    {
                        int zeroInStr = 0;
                        int zeroInStrPos = 0;

                        for (int j = 0; j < this.colNum; j++)
                        {
                            if ((0 == this.values[i][j]) && (this.lineVertical[j] != true))
                            {
                                zeroInStr++;
                                zeroInStrPos = j;
                            }
                        }

                        if (zeroInStr == 1)
                        {
                            this.lineVertical[zeroInStrPos] = true;
                            this.result[i] = zeroInStrPos;
                            isEnd = true;
                        }
                        else if (zeroInStr > 1)
                        {
                            countRepeat++;
                            isEnd = true;

                            if (countRepeat > 100)
                            {
                                this.lineVertical[zeroInStrPos] = true;
                                this.result[i] = zeroInStrPos;
                                this.upStr(i, zeroInStrPos);
                                isEnd = true;
                            }
                        }
                    }

                }
            }

            isEnd = true;
            countRepeat = 0;
            while (isEnd)
            {
                isEnd = false;
                for (int i = 0; i < this.colNum; i++)
                {
                    if (this.lineVertical[i] != true)
                    {
                        int zeroInCol = 0;
                        int zeroInColPos = 0;


                        for (int j = 0; j < this.strNum; j++)
                        {
                            if ((0 == this.values[j][i]) && (this.lineHorizont[j] != true))
                            {
                                zeroInCol++;
                                zeroInColPos = j;
                            }
                        }

                        if (zeroInCol == 1)
                        {
                            this.lineHorizont[zeroInColPos] = true;
                            isEnd = true;
                        }
                    }
                }
            }


        }

        public void upStr(int str,int zeroInStrPos)
        {
            for (int j = 0; j < this.colNum; j++)
            {
                this.values[str][j] += 5;
            }

            this.values[str][zeroInStrPos] -= 5;
        }

        /**
         * Сбросить линии
         */
        public void lineReset()
        {
            for (int i = 0; i< this.strNum; i++)
            {
                this.lineHorizont[i] = false;
            }

            for (int i = 0; i < this.colNum; i++)
            {
                this.lineVertical[i] = false;
            }

            this.toLine();
        }

        /**
         * Кол-во линий (K)
         */
        public int lineCount()
        {
            int count  = 0;
            for (int i = 0; i < this.strNum; i++)
            {
                if (this.lineHorizont[i]) count++;
            }

            for (int i = 0; i < this.colNum; i++)
            {
                if (this.lineVertical[i]) count++;
            }
            
            return count;
        }

        /**
         * Проверка на совпадение линий и размерности (k = n)
         */
        public void checkBeforeResult()
        {
            while (this.lineCount() != this.strNum)
            {
                this.lineReset();
                this.toLine();
                if (this.lineCount() != this.strNum)
                {
                    this.addZeros();
                }
            }
        }

        /**
         * Добавление новых нулей при случае K < N
         */
        public void addZeros()
        {
            int min = 9999;

            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    if ((min > this.values[i][j]) && (this.lineHorizont[i] != true) && (this.lineVertical[j] != true))
                    {
                        min = this.values[i][j];
                    }
                }
            }

            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    if (((this.lineHorizont[i]) && (this.lineVertical[j])) || ((this.lineHorizont[i] != true) && (this.lineVertical[j] != true)))
                    {
                        if ((this.lineHorizont[i]) && (this.lineVertical[j]))
                        {
                            this.values[i][j] += min;
                        }
                        else
                        {
                            this.values[i][j] -= min;
                        }
                    }
                }
            }
        }


        /**
         * Получить результат
         */
        public void toResult()
        {
            for (int i = 0; i < this.strNum; i++)
            {
                for (int j = 0; j < this.colNum; j++)
                {
                    if (this.result[i] == j)
                    {
                        this.values[i][j] = 1;
                    } else
                    {
                        this.values[i][j] = 0;
                    }
                }
            }
            
        }


        /**
         * Запустить метод автоматически
         */
        public void toResultAuto()
        {
            this.init();
            this.set();
            this.update();
            this.toCorrect();

            this.checkBeforeResult();

            this.toResult();

            this.print();
        }


    }
}
