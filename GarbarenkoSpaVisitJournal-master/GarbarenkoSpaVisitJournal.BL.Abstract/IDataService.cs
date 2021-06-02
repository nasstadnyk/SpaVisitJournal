using System;
using System.Collections.Generic;
using System.Text;

namespace GarbarenkoSpaVisitJournal.BL.Abstract
{
    public interface IDataService <TContext, TClient, TType> 
        where TContext : class
        where TClient : class
        where TType : class
    {
        void Add(TContext context, string fname, string sname, string tname, TType visitType, bool isclient, DateTime visitdateTime);
        void Remove(TContext context, TClient client);
        void Change(TContext context, TClient client, string fname, string sname, string tname, TType visitType, bool isclient, DateTime visitdateTime);
        bool IsExists(TContext context, TClient client);
    }
}
