using GarbarenkoSpaVisitJournal.DAL.Abstract;
using GarbarenkoSpaVisitJournal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GarbarenkoSpaVisitJournal.DAL.Implementation
{
    public class AppContextJson : IContext
    {
        public List<Clients> Clients;
        public List<VisitType> VisitType;
        private string _appdatapath = @"" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/GarbarenkoSpaVisitJournal/Backups/";
        public AppContextJson()
        {
            EnsureCreated();
            LoadData();
        }
        public void LoadData()
        {
            Clients = JsonConvert.DeserializeObject<List<Clients>>(File.ReadAllText(_appdatapath + "LotusClientVisitLogBackup.json"));
            VisitType = JsonConvert.DeserializeObject<List<VisitType>>(File.ReadAllText(_appdatapath + "VisitTypeLogBackup.json"));
        }
        public void EnsureCreated()
        {
            Clients = new List<Clients>();
            VisitType = new List<VisitType>();
            if (!Directory.Exists(_appdatapath))
            {
                Directory.CreateDirectory(_appdatapath);

            }
            if (!File.Exists(_appdatapath + "LotusClientVisitLogBackup.json"))
            {
                FileStream FileCreate = File.Create(_appdatapath + "LotusClientVisitLogBackup.json");
                FileCreate.Close();
            }
            if (!File.Exists(_appdatapath + "VisitTypeLogBackup.json"))
            {
                FileStream FileCreate = File.Create(_appdatapath + "VisitTypeLogBackup.json");
                FileCreate.Close();
                VisitType.Add(new Models.VisitType(1, "Стоунтерапія"));
                VisitType.Add(new Models.VisitType(2, "SPA Шоколад"));
                VisitType.Add(new Models.VisitType(3, "Гідромасаж"));
                SaveChanges();
            }
            LoadData();

        }
        public void SaveChanges()
        {
            File.WriteAllText(_appdatapath + "LotusClientVisitLogBackup.json", JsonConvert.SerializeObject(Clients));
            File.WriteAllText(_appdatapath + "VisitTypeLogBackup.json", JsonConvert.SerializeObject(VisitType));
        }
    }
}
