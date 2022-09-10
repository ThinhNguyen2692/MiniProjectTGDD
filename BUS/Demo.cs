using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{


    public class Singleton
    {
        private Singleton() { }
        private static Singleton _instance;

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;

            }
        }
        public void someBusinessLogic(string item)
        {
            Console.WriteLine("Demo demo"+ item);
        }
    }
}
