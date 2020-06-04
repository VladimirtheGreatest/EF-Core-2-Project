using EFCoreApp.Data;
using EFCoreApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertSamurai();
            InsertMultiple();
        }     

        private static void InsertSamurai()
        {
            var samurai = new Samurai { Name = "Vladimir" };
            using(var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
        private static void InsertMultiple()
        {
            var samurai = new Samurai { Name = "Vladimir" };
            var samurai2 = new Samurai { Name = "John" };
            //for each loop to generate many users and insert them into database??
            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samurai, samurai2);
                context.SaveChanges();
            }
        }
    }
}
