using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class GROUP_CONFIG
    {
        public static List<Entities.GROUP_CONFIG> getAll()
        {
            return (List<Entities.GROUP_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.GROUP_CONFIG);
        }
        public static Entities.GROUP_CONFIG getById(int _id)
        {
            return ((List<Entities.GROUP_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.GROUP_CONFIG)
                    ).Where(m => m.ID == (decimal)_id).FirstOrDefault();
        }
        public static int DeleteItemById(int id)
        {
            int ret = -1;
            using(Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.GROUP_CONFIG.DeleteObject(db.GROUP_CONFIG.Where(m => m.ID == id).FirstOrDefault());
                ret = 1;
                db.SaveChanges();
            }

            return ret;
        }
        public static int SaveItem(Entities.GROUP_CONFIG item)
        {
            int ret = -1;
            using(Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.GROUP_CONFIG.ToList().Exists(m => m.ID == item.ID))
                {
                    Entities.GROUP_CONFIG tmp = db.GROUP_CONFIG.Where(m => m.ID == item.ID).FirstOrDefault();
                    tmp.BRAND_NAME = item.BRAND_NAME;
                    tmp.CONFIG = item.CONFIG;
                    tmp.SOURCE = item.SOURCE;
                    ret = 1;
                }
                else
                {
                    db.GROUP_CONFIG.AddObject(new Entities.GROUP_CONFIG
                    {
                        MARKET = item.MARKET,
                        BRAND_NAME = item.BRAND_NAME,
                        BRAND = item.BRAND, 
                        SOURCE = item.SOURCE,
                        CONFIG = item.CONFIG,
                        TYPE_ID = item.TYPE_ID,
                        GROUP_ID = item.GROUP_ID
                    });
                    ret = 1;
                }
                if (ret > 0)
                {
                    db.SaveChanges();
                }
            }
            return ret;
        }
        public static int SaveGroupConfig(List<Entities.GROUP_CONFIG> list)
        {
            int ret = -1;
            using(Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                decimal? group_id = list.FirstOrDefault().GROUP_ID;
                foreach (Entities.GROUP_CONFIG item in list)
                {
                    if (db.GROUP_CONFIG.ToList().Exists(m => m.GROUP_ID == item.GROUP_ID && m.MARKET == item.MARKET && m.BRAND == item.BRAND))
                    {
                        Entities.GROUP_CONFIG tmp = db.GROUP_CONFIG.Where(m => m.GROUP_ID == item.GROUP_ID && m.MARKET == item.MARKET && m.BRAND == item.BRAND).FirstOrDefault();
                        tmp.CONFIG = item.CONFIG;
                        //tmp.SOURCE = item.SOURCE;
                    }
                    else
                    {
                        db.GROUP_CONFIG.AddObject(item);
                    }
                    ret = 1;

                }
                var lst = db.GROUP_CONFIG.Where(m => m.GROUP_ID == group_id).Select(m => m).ToList();
                foreach(Entities.GROUP_CONFIG item in lst)
                {
                    if (!list.Exists(m => m.GROUP_ID == item.GROUP_ID && m.MARKET == item.MARKET && m.BRAND == item.BRAND))
                    {
                        db.GROUP_CONFIG.DeleteObject(item);
                        ret = 1;
                    }
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
