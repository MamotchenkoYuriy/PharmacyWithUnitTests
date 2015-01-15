using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data;
using Data.Repository;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository<Pharmacy>(new DataContext());
            repository.Find(m => m.PhoneNumber == "");
            foreach (var item in repository.Find(m => m.PhoneNumber == ""))
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
