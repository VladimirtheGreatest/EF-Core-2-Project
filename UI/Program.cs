using EFCoreApp.Data;
using EFCoreApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    class Program
    {
        private static SamuraiContext _context = new SamuraiContext();
        static void Main(string[] args)
        {
            // InsertSamurai();
            // InsertMultiple();
            // SamuraiQuery();
            //  RetrieveAndUpdateSamurai();
            //  RetrieveAndUpdateMultipleSamurai();
            //  QueryAndUpdateBattle_Disconnected();
            //DeleteSamuraiTracked();
            InsertNewPkFkGraphMultipleChildren();
        }     
        //adding some extra content for masters branch
        //this is not going to appear on development

        //creating conflict from github from masters

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
        private static void SamuraiQuery ()
        {
            var name = "Vladimir";
            var samurais = _context.Samurais.FirstOrDefault(x => x.Name == name);
            var samuraiJ = _context.Samurais.Where(x => EF.Functions.Like(x.Name, "J%")).ToList();
        }
        private static void RetrieveAndUpdateSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "VladimirTheGreatest";
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleSamurai()
        {
            var samurais = _context.Samurais.ToList();
            samurais.ForEach(x => x.Name += "$$$");
            _context.SaveChanges();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.FirstOrDefault();
            battle.EndDate = new DateTime(1990, 07, 17);
            using(var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
        private static void DeleteSamuraiTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault(x => x.Name == "VladimirVladimirTheGreatest$$$");
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();         
        }
        private static void InsertNewPkFkGraphMultipleChildren()
        {
            var samurai = new Samurai
            {
                Name = "Vladimir",
                Quotes = new List<Quote>
                {
                    new Quote {Text = "Hustle harder hustle smarter"},
                     new Quote {Text = "This is a quote"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
    }
}
