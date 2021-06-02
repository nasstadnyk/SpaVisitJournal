using GarbarenkoSpaVisitJournal.BL.Implementation;
using GarbarenkoSpaVisitJournal.DAL.Abstract;
using GarbarenkoSpaVisitJournal.DAL.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbarenkoSpaVisitJournal.ViewModel
{
    public class MainViewModel
    {
        //public AppContextMSSQL AppContext;
        public AppContextJson contextJson;
        public DataService dataService;
        public MainViewModel(string connstring)
        {
            //AppContext = new AppContextMSSQL(connstring);
            dataService = new DataService();
            contextJson = new AppContextJson();
        }
    }
}
