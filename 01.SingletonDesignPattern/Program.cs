using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01.SingletonDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton tekil demek ilgili nesneden 1 tane oluşmasını istiyorsak singleton design patern i kullanabiliriz.(Creational design Patern)
            Singleton singleton1 = Singleton.GetSingleton();//
            Singleton singleton2 = Singleton.GetSingleton();//2 nesneninde referansı aynı! Yapılan tüm değişiklikler tek bir nesne altında oluyor.
            singleton1.Ad = "singlenton1";
            Console.WriteLine(singleton2.Ad);
            singleton2.Ad = "singleton2";
            Console.WriteLine(singleton1.Ad);

            for (int i = 0; i < 10; i++)
            {
                Singleton singleton3 = Singleton.GetSingleton(); //yukarda 1 kere oluştuğu için burda oluşmadı.
            }

            //Multithreading ile denendi diğer bir threadde de yeni singleton oluşmadı.
            Thread thread = new Thread(SingletonOlustur);
            thread.Start();

            Console.ReadKey();
        }
        static void SingletonOlustur()
        {
            Singleton singleton3 = Singleton.GetSingleton();
            singleton3.Ad = "singleton3";
            Console.WriteLine(singleton3.Ad);
        }
    }
}
