using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class MARKET_MASTER
    {
        public static List<Entities.MARKET_MASTER> getAll()
        {
            return (List<Entities.MARKET_MASTER>) DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER);
        }

        public static List<Entities.MARKET_MASTER> getAllByName(string name)
        {
            return ((List<Entities.MARKET_MASTER>) DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER))
                .Where(m=>m.NAME == name).Select(m=>m).ToList();
        }
        public static Entities.MARKET_MASTER getById(int id)
        {
            return ((List<Entities.MARKET_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER))
                .Where(m => m.ID == id).FirstOrDefault();
        }
        public static int Save(Entities.MARKET_MASTER item)
        {
            int ret = -1;
            using(Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                Entities.MARKET_MASTER itemtmp = db.MARKET_MASTER.Where(m => m.ID == item.ID).FirstOrDefault();
                if (itemtmp != null)
                {
                    itemtmp.NAME = item.NAME != null?item.NAME:itemtmp.NAME;
                    itemtmp.CHANNEL = item.CHANNEL != null ? item.CHANNEL : itemtmp.CHANNEL;
                    itemtmp.GROUP = item.GROUP != null ? item.GROUP : itemtmp.GROUP;
                    itemtmp.KEYBRANDS = item.KEYBRANDS != null ? item.KEYBRANDS : itemtmp.KEYBRANDS;
                    itemtmp.FRANCHISE = item.FRANCHISE != null ? item.FRANCHISE : itemtmp.FRANCHISE;
                    ret = 1;
                }
                else
                {
                    db.MARKET_MASTER.AddObject(item);
                    ret = 1;
                }
                if (ret > 0)
                {
                    db.SaveChanges();
                }
            }
            return ret;
        }
    }
}
