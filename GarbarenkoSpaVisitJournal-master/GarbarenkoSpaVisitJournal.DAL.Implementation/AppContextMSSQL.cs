using GarbarenkoSpaVisitJournal.DAL.Abstract;
using GarbarenkoSpaVisitJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbarenkoSpaVisitJournal.DAL.Implementation
{
    public class AppContextMSSQL : DbContext, IContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<VisitType> VisitType { get; set; }
        private string _connstring;
        public AppContextMSSQL(string connstring)
        {
            _connstring = connstring;
            Database.EnsureCreated();
            if (!this.Database.CanConnect())
            {
                throw new Exception($"Can't connect to database with connection string {connstring}");
            }
            if (VisitType == null || !VisitType.Any(t => t.id > 0))
            {
                VisitType.Add(new Models.VisitType("Стоунтерапія"));
                VisitType.Add(new Models.VisitType("SPA Шоколад"));
                VisitType.Add(new Models.VisitType("Гідромасаж"));
            }
            this.SaveChanges();
        }
        public AppContextMSSQL(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public List<Clients> GetClients()
        {
            return this.Clients.Include(client => client.VisitType).ToList();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connstring);
        }
    }
}
