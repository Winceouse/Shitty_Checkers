using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Server
{

    [ServiceContract]
    public interface ICallBack
    {
        [OperationContract(IsOneWay =true)]
        void move(int oldCoord_X,int oldCoord_Y,int newCoord_X,int newCoord_Y);
    }
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IChekkers
    {
        [OperationContract(IsOneWay = true)]
        void Join(string name);

        [OperationContract(IsOneWay = true)]
        void MoveMade(int oldCoord_X, int oldCoord_Y, int newCoord_X, int newCoord_Y);
       
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Chekkers : IChekkers
    {
        Dictionary<ICallBack, string> _users = new Dictionary<ICallBack, string>();

        public void MoveMade(int oldCoord_X, int oldCoord_Y, int newCoord_X, int newCoord_Y)
        {
            var connection = OperationContext.Current.GetCallbackChannel<ICallBack>();
            string user;
            if (!_users.TryGetValue(connection, out user))
                return;
            foreach(var other in _users.Keys)
            {
                if (other == connection)
                    continue;
            other.move(oldCoord_X,oldCoord_Y,newCoord_X,newCoord_Y);               
            }
        }

        public void Join(string name)
        {
            var connection = OperationContext.Current.GetCallbackChannel<ICallBack>();
            _users[connection] = name;
            Console.WriteLine(name+" joined");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Chekkers));
            sh.Open();
            Console.WriteLine("Host is ready");
            Console.ReadLine();
            sh.Close();
        }
    }
}