using System;
using System.Collections.Generic;
using System.Text;

namespace GarbarenkoSpaVisitJournal.Models
{
    public class VisitType
    {
        public int id { get; set; }
        public string VisitTypeName { get; set; }
        public VisitType(int ID, string VisitTypeName)
        {
            this.id = ID;
            this.VisitTypeName = VisitTypeName;
        }
        public VisitType(string VisitTypeName)
        {
            this.VisitTypeName = VisitTypeName;
        }
        public VisitType()
        {

        }
    }
}
