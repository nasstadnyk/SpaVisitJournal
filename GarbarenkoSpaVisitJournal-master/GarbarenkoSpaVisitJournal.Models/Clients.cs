using System;
using System.Collections.Generic;
using System.Text;

namespace GarbarenkoSpaVisitJournal.Models
{
    public class Clients
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public int? VisitTypeId { get; set; }
        public VisitType VisitType { get; set; }
        public bool IsClinet { get; set; }
        public DateTime VisitDateTime { get; set; }
        public Clients()
        {

        }
        public Clients(string fname, string sname, string tname, VisitType visitType, bool isclient, DateTime visitdateTime)
        {
            FirstName = fname;
            SecondName = sname;
            ThirdName = tname;
            VisitType = visitType;
            IsClinet = isclient;
            VisitDateTime = visitdateTime;
        }
        public Clients(int id, string fname, string sname, string tname, VisitType visitType, bool isclient, DateTime visitdateTime)
        {
            this.id = id;
            FirstName = fname;
            SecondName = sname;
            ThirdName = tname;
            VisitType = visitType;
            IsClinet = isclient;
            VisitDateTime = visitdateTime;
        }
        public Clients(int id, string fname, string sname, string tname,int visitid, VisitType visitType, bool isclient, DateTime visitdateTime)
        {
            this.id = id;
            FirstName = fname;
            SecondName = sname;
            ThirdName = tname;
            VisitTypeId = visitid;
            VisitType = visitType;
            IsClinet = isclient;
            VisitDateTime = visitdateTime;
        }
    }
    
}
