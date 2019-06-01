using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.SinglePlayer
{
    class FigureMove
    {
        public Figure figure1 { get; set; }
        public Figure figure2 { get; set; }
        public FigureMove()
        {
            figure1 = null;
            figure2 = null;
        }
        public FigureMove(Figure temp1, Figure temp2)
        {
            figure1 = temp1;
            figure2 = temp2;
        }
        public override bool Equals(Object temp)
        {
            if (temp == null)
            {
                return false;
            }
            FigureMove move = temp as FigureMove;
            if (move == null)
            {
                return false;
            }
            return figure1.Equals(move.figure1) && figure2.Equals(move.figure2);
        }
        public Figure IsPossibleToMove(string color)
        {
            if (color == "White")
            {
                if ((figure1.row + 2 == figure2.row) && (figure1.column - 2 == figure2.column))
                    return new Figure(figure1.row + 1, figure1.column - 1);
                if ((figure1.row + 2 == figure2.row) && (figure1.column + 2 == figure2.column))
                    return new Figure(figure1.row + 1, figure1.column + 1);
            }
            if (color == "Black")
            {
                if ((figure1.row - 2 == figure2.row) && (figure1.column - 2 == figure2.column))
                    return new Figure(figure1.row - 1, figure1.column - 1);
                if ((figure1.row - 2 == figure2.row) && (figure1.column + 2 == figure2.column))
                    return new Figure(figure1.row - 1, figure1.column + 1);
            }
            if (color == "King")
            {
                if ((figure1.row - 2 == figure2.row) && (figure1.column - 2 == figure2.column))
                    return new Figure(figure1.row - 1, figure1.column - 1);
                if ((figure1.row - 2 == figure2.row) && (figure1.column + 2 == figure2.column))
                    return new Figure(figure1.row - 1, figure1.column + 1);
                if ((figure1.row + 2 == figure2.row) && (figure1.column - 2 == figure2.column))
                    return new Figure(figure1.row + 1, figure1.column - 1);
                if ((figure1.row + 2 == figure2.row) && (figure1.column + 2 == figure2.column))
                    return new Figure(figure1.row + 1, figure1.column + 1);
            }
            return null;
        }
        public bool IsNear(string color)
        {
            if (color == "Black")
            {
                if ((figure1.row - 1 == figure2.row) && (figure1.column - 1 == figure2.column))
                    return true;
                if ((figure1.row - 1 == figure2.row) && (figure1.column + 1 == figure2.column))
                    return true;
            }
            if (color == "White")
            {
                if ((figure1.row + 1 == figure2.row) && (figure1.column - 1 == figure2.column))
                    return true;
                if ((figure1.row + 1 == figure2.row) && (figure1.column + 1 == figure2.column))
                    return true;
            }
            if (color == "King")
            {
                if ((figure1.row - 1 == figure2.row) && (figure1.column - 1 == figure2.column))
                    return true;
                if ((figure1.row - 1 == figure2.row) && (figure1.column + 1 == figure2.column))
                    return true;
                if ((figure1.row + 1 == figure2.row) && (figure1.column - 1 == figure2.column))
                    return true;
                if ((figure1.row + 1 == figure2.row) && (figure1.column + 1 == figure2.column))
                    return true;
            }
            return false;
        }
    }
}
