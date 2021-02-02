using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SingletonDesignPattern
{
    public class Singleton
    {
        //Nesneyi kendi içinde oluşturuyoruz.
        //Nesneyi oluşturmadan metodunu kullanabilmek için metodu static yapıyoruz.
        private static Singleton singleton; // = new Singleton(); ////everloading kullanılmasa bile 1 tane oluşturuluyor.
        private static int sayi = 0;//Kaç kere oluşturmayı denediğimizi yazdırıyoruz.
        private static readonly object padlock = new object(); //multithreading işlemi için böyle bir nesne ürettik.
        public string Ad { get; set; }
        private Singleton()
        {
            Console.WriteLine("Ben oluştum.");
        }
        public static Singleton GetSingleton()//static metodlar içinde static dedişkenler kullanmaya izin verir.
        {
            //nesneye ihtiyaç duyulması demek GetSingleton() metodunun çağırılması demektir.
            if (singleton == null) //sadece null olduğu durumda multithreadi kitliyoruz.
            {
                lock (padlock) //multithread işlemlerdeki açığı önlemek için
                {
                    if (singleton == null)
                    {
                        singleton = new Singleton();//lazy loading
                    }
                }
            }
            //2'li null kontrol kalıbına Double Checked locking kalıbı denir. Bu kalıp sayesinde hem lazy loading hem thread safe çalıştık hemde maximum performans yapmış olduk.
            sayi++;
            Console.WriteLine(sayi + " kere Oluşturulmayı denendim.");
            return singleton;
        }
    }
}
