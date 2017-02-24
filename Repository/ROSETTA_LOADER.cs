using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class ROSETTA_LOADER
    {
        public static StrawmanDBLibray.Entities.ROSETTA_LOADER getById(int? _id)
        {
            return getAll().Where(m => m.ID == _id).FirstOrDefault();
        }
        public static StrawmanDBLibray.Entities.ROSETTA_LOADER get(int _channel, int _market, int _brand)
        {
            return getAll().Where(m => m.CHANNEL_ID == _channel && m.MARKET_ID == _market && m.BRAND_ID == _brand).FirstOrDefault();
        }

        public static List<StrawmanDBLibray.Entities.ROSETTA_LOADER> getAll()
        {
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                return db.ROSETTA_LOADER.Select(m => m).ToList();
            }
        }
        public static int SaveItem(StrawmanDBLibray.Entities.ROSETTA_LOADER item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.ROSETTA_LOADER.ToList().Exists(m => m.MARKET_ID == item.MARKET_ID && m.BRAND_ID == item.BRAND_ID && m.CHANNEL_ID == item.CHANNEL_ID))
                {
                    foreach (Entities.ROSETTA_LOADER mst in db.ROSETTA_LOADER.Where(m => m.MARKET_ID == item.MARKET_ID && m.BRAND_ID == item.BRAND_ID && m.CHANNEL_ID == item.CHANNEL_ID).Select(m => m))
                    {
                        mst.EXCEL_ROW = item.EXCEL_ROW;
                    }
                    ret = 1;
                }
                else
                {
                    db.ROSETTA_LOADER.AddObject(item);
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
        public static int DeleteItem(StrawmanDBLibray.Entities.ROSETTA_LOADER item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.ROSETTA_LOADER.ToList().Exists(m => m.MARKET_ID == item.MARKET_ID && m.BRAND_ID == item.BRAND_ID && m.CHANNEL_ID == item.CHANNEL_ID))
                {
                    foreach (Entities.ROSETTA_LOADER mst in db.ROSETTA_LOADER.Where(m => m.MARKET_ID == item.MARKET_ID && m.BRAND_ID == item.BRAND_ID && m.CHANNEL_ID == item.CHANNEL_ID).Select(m => m))
                    {
                        db.ROSETTA_LOADER.DeleteObject(mst);
                    }
                    ret = 1;
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
    }
}
