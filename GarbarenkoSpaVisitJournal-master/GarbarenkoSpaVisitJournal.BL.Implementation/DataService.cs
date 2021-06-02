using GarbarenkoSpaVisitJournal.BL.Abstract;
using GarbarenkoSpaVisitJournal.DAL.Implementation;
using GarbarenkoSpaVisitJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarbarenkoSpaVisitJournal.BL.Implementation
{
    public class DataService : IDataService<AppContextJson, Clients, VisitType>
    {
        public void Add(AppContextJson context, string fname, string sname, string tname, VisitType visitType, bool isclient, DateTime visitdateTime)
        {
            if (context.Clients.Count == 0)
            {
                context.Clients.Add(new Clients(1, fname, sname, tname, visitType, isclient, visitdateTime));
            }
            else
            {
                context.Clients.Add(new Clients(context.Clients.Last().id + 1, fname, sname, tname, visitType, isclient, visitdateTime));
                context.SaveChanges();
            }
            
        }

        public void Change(AppContextJson context, Clients client, string fname, string sname, string tname, VisitType visitType, bool isclient, DateTime visitdateTime)
        {
            var cl = context.Clients[context.Clients.IndexOf(client)];
            cl.FirstName = fname;
            cl.SecondName = sname;
            cl.ThirdName = tname;
            cl.VisitType = visitType;
            cl.IsClinet = isclient;
            cl.VisitDateTime = visitdateTime;
            context.SaveChanges();
        }

        public bool IsExists(AppContextJson context, Clients client)
        {
            return context.Clients.Any(cl => cl.id == client.id);
        }

        public void Remove(AppContextJson context, Clients client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }
    }
}
