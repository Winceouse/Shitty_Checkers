using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client.MultiPlayer
{
    class CallBack : Proxy1.IChekkersCallback
    {
        public void move(int ioldCoord_X,int oldCoord_Y,int newCoord_X,int newCoord_Y)
        {
            Console.WriteLine("kek");
        }
    }
}
