using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class NTS_MASTER
    {
        public static StrawmanDBLibray.Entities.NTS_MASTER getById(int? _id)
        {
            return getAll().Where(m => m.ID == _id).FirstOrDefault();
        }
        public static StrawmanDBLibray.Entities.NTS_MASTER get(int _channel, int _market, int _brand)
        {
            string channel = _channel.ToString();
            string market = _market.ToString();
            string brand = _brand.ToString();
            return getAll().Where(m => m.CHANNEL == channel && m.MARKET == market && m.BRAND == brand).FirstOrDefault();
        }

        public static List<StrawmanDBLibray.Entities.NTS_MASTER> getAll()
        {
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                return db.NTS_MASTER.Select(m => m).ToList();
            }
        }

        public static int SaveItem(StrawmanDBLibray.Entities.NTS_MASTER item) 
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.NTS_MASTER.ToList().Exists(m => m.MARKET == item.MARKET && m.BRAND == item.BRAND && m.CHANNEL == item.CHANNEL))
                {
                    foreach (Entities.NTS_MASTER mst in db.NTS_MASTER.Where(m => m.MARKET == item.MARKET && m.BRAND == item.BRAND && m.CHANNEL == item.CHANNEL).Select(m => m))
                    {
                        mst.MARKET_NAME = item.MARKET_NAME;
                    }
                    ret = 1;
                }
                else
                {
                    db.NTS_MASTER.AddObject(item);
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
        public static int DeleteItem(StrawmanDBLibray.Entities.NTS_MASTER item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.NTS_MASTER.ToList().Exists(m => m.MARKET == item.MARKET && m.BRAND == item.BRAND && m.CHANNEL == item.CHANNEL))
                {
                    foreach (Entities.NTS_MASTER mst in db.NTS_MASTER.Where(m => m.MARKET == item.MARKET && m.BRAND == item.BRAND && m.CHANNEL == item.CHANNEL).Select(m => m))
                    {
                        db.NTS_MASTER.DeleteObject(mst);
                    }
                    ret = 1;
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
    }
}
