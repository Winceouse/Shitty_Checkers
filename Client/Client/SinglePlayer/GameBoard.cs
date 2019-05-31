using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * -1 - ошибочка
 * 0 - пусте місце
 * 1 - червона
 * 2 - біла
 * 3 - червоний король
 * 4 - білий король
 */

namespace Client.SinglePlayer
{
    class GameBoard
    {
        public int[,] field = new int[8, 8];
        public GameBoard()
        {
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    field[a, b] = -1;
                }
            }
        }
        public int GetState(int a, int b) //перевірка місця шашкі
        {
            if ((a > 7) || (a < 0) || (b > 7) || (b < 0))
                return -1;

            return field[a, b];
        }
        public bool SetState(int a, int b, int temp)//встановлення місця
        {
            if ((temp > 4) || (temp < -1))
                return false;
            field[a, b] = temp;
            return true;
        }
        public List<FigureMove> CheckMove(string figureColour)
        {
            List<FigureMove> temp = new List<FigureMove>();
            for (int a = 0; a < 8; a++)
            {
                for (int b = 0; b < 8; b++)
                {
                    if (figureColour == "Black")
                    {
                        if (GetState(a, b) == 3)//для короля
                        {
                            if ((GetState(a - 2, b - 2) == 0) && ((GetState(a - 1, b - 1) == 2) || (GetState(a - 1, b - 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b - 2)));
                            }
                            if ((GetState(a - 2, b + 2) == 0) && ((GetState(a - 1, b + 1) == 2) || (GetState(a - 1, b + 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b + 2)));
                            }
                            if ((GetState(a + 2, b - 2) == 0) && ((GetState(a + 1, b - 1) == 2) || (GetState(a + 1, b - 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b - 2)));
                            }
                            if ((GetState(a + 2, b + 2) == 0) && ((GetState(a + 1, b + 1) == 2) || (GetState(a + 1, b + 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b + 2)));
                            }
                        }
                        if (GetState(a, b) == 1)//звичайна шашка
                        {
                            if ((GetState(a + 2, b - 2) == 0) && ((GetState(a + 1, b - 1) == 2) || (GetState(a + 1, b - 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b - 2)));
                            }
                            if ((GetState(a + 2, b + 2) == 0) && ((GetState(a + 1, b + 1) == 2) || (GetState(a + 1, b + 1) == 4)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b + 2)));
                            }
                        }
                    }
                    if (figureColour == "White")
                    {
                        if (GetState(a, b) == 4)//король
                        {
                            if ((GetState(a - 2, b - 2) == 0) && ((GetState(a - 1, b - 1) == 1) || (GetState(a - 1, b - 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b - 2)));
                            }
                            if ((GetState(a - 2, b + 2) == 0) && ((GetState(a - 1, b + 1) == 1) || (GetState(a - 1, b + 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b + 2)));
                            }
                            if ((GetState(a + 2, b - 2) == 0) && ((GetState(a + 1, b - 1) == 1) || (GetState(a + 1, b - 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b - 2)));
                            }
                            if ((GetState(a + 2, b + 2) == 0) && ((GetState(a + 1, b + 1) == 1) || (GetState(a + 1, b + 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a + 3, b + 2)));
                            }
                        }
                        if (GetState(a, b) == 2)//звичайна
                        {
                            if ((GetState(a - 2, b - 2) == 0) && ((GetState(a - 1, b - 1) == 1) || (GetState(a - 1, b - 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b - 2)));
                            }
                            if ((GetState(a - 2, b + 2) == 0) && ((GetState(a - 1, b + 1) == 1) || (GetState(a - 1, b + 1) == 3)))
                            {
                                temp.Add(new FigureMove(new Figure(a + 1, b), new Figure(a - 1, b + 2)));
                            }
                        }
                    }
                }
            }
            return temp;
        }
    }
}
