using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaScreening.Application.Notes
{
    public  sealed class SingleTon
    {
        private static SingleTon instance = null;

        public static SingleTon GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new SingleTon();

                return instance;
            }
        }

        public void PrintData()
        {
            Console.WriteLine("Print SingleTon class");
        }
    }

    public  class Test
    {
        public  void method1()
        {
            //var s = SingleTon.GetInstance;
            SingleTon s = SingleTon.GetInstance;
            s.PrintData();

            //OR
            SingleTon.GetInstance.PrintData();


        }
    }
}
