using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.SinglePlayer
{
    class Figure
    {
        public int column
        {
            get;
            set;
        }
        public int row
        {
            get;
            set;
        }
        public Figure(int _col, int _row)
        {
            column = _col;
            row = _row;
        }
        public override bool Equals(Object temp)
        {
            if (temp == null)
                return false;

            Figure figure = temp as Figure;
            if (figure == null)
            {
                return false;
            }
            return row == figure.row && column == figure.column;
        }
    }
}
