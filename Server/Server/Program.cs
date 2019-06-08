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
        void move(int x,int y);
    }
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IChekkers
    {
        [OperationContract(IsOneWay = true)]
        void Join(string name);
    }
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class Chekkers : IChekkers
    {
        Dictionary<ICallBack, string> _users = new Dictionary<ICallBack, string>();

        public void Join(string name)
        {
            var connection = OperationContext.Current.GetCallbackChannel<ICallBack>();
            _users[connection] = name;

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