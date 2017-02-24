using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class GROUP_MASTER
    {
        public static List<Entities.GROUP_MASTER> getAll()
        {
            return (List<Entities.GROUP_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.GROUP_MASTER);
        }
        public static Entities.GROUP_MASTER getById(int _id)
        {
            return ((List<Entities.GROUP_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.GROUP_MASTER)
                    ).Where(m => m.ID == (decimal)_id).FirstOrDefault();
        }

        public static int DeleteItemById(int id)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                foreach (Entities.GROUP_CONFIG item in db.GROUP_CONFIG.Where(m => m.GROUP_ID == id).ToList())
                {
                    db.GROUP_CONFIG.DeleteObject(item);
                }
                db.GROUP_MASTER.DeleteObject(db.GROUP_MASTER.Where(m => m.ID == id).FirstOrDefault());
                ret = 1;
                db.SaveChanges();
            }
            return ret;
        }
        public static int SaveItem(Entities.GROUP_MASTER item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.GROUP_MASTER.ToList().Exists(m => m.ID == item.ID))
                {
                    Entities.GROUP_MASTER tmp = db.GROUP_MASTER.Where(m => m.ID == item.ID).FirstOrDefault();
                    tmp.NAME = item.NAME;
                    tmp.LEVEL= item.LEVEL;
                    tmp.BASE_ID = item.BASE_ID;
                    ret = 1;
                }
                else
                {
                    db.GROUP_MASTER.AddObject(new Entities.GROUP_MASTER
                    {
                        NAME = item.NAME,
                        LEVEL= item.LEVEL,
                        BASE_ID = item.BASE_ID,
                        TYPE = item.TYPE
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
    }
}
