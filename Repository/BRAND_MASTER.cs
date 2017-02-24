using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class BRAND_MASTER
    {
        public static List<Entities.BRAND_MASTER> getAll()
        {
            return (List<Entities.BRAND_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.BRAND_MASTER);
        }
        public static Entities.BRAND_MASTER getById(int _id)
        {
            return ((List<Entities.BRAND_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.BRAND_MASTER)
                    ).Where(m=>m.ID == (decimal)_id).FirstOrDefault();
        }

        public static int Save(Entities.BRAND_MASTER item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                Entities.BRAND_MASTER itemtmp = db.BRAND_MASTER.Where(m => m.ID == item.ID).FirstOrDefault();
                if (itemtmp != null)
                {
                    itemtmp.NAME = item.NAME != null ? item.NAME : itemtmp.NAME;
                    itemtmp.MARKET = item.MARKET != null ? item.MARKET : itemtmp.MARKET;
                    itemtmp.CHANNEL = item.CHANNEL != null ? item.CHANNEL : itemtmp.CHANNEL;
                    itemtmp.GROUP = item.GROUP != null ? item.GROUP : itemtmp.GROUP;
                    itemtmp.KEYBRANDS = item.KEYBRANDS != null ? item.KEYBRANDS : itemtmp.KEYBRANDS;
                    itemtmp.FRANCHISE = item.FRANCHISE != null ? item.FRANCHISE : itemtmp.FRANCHISE;
                    ret = 1;
                }
                else
                {
                    db.BRAND_MASTER.AddObject(item);
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
