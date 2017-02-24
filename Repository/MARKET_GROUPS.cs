using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class MARKET_GROUPS
    {
        public static List<Entities.MARKET_GROUPS> getAll()
        {
            return (List<Entities.MARKET_GROUPS>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_GROUPS);
        }

        public static Entities.MARKET_GROUPS getById(int id)
        {
            return ((List<Entities.MARKET_GROUPS>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_GROUPS))
                .Where(m => m.ID == id).FirstOrDefault();
        }

        public static int Save(Entities.MARKET_GROUPS item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                Entities.MARKET_GROUPS _aux = db.MARKET_GROUPS.Where(m => m.ID == item.ID).FirstOrDefault();
                if (_aux != null)
                {
                    _aux.NAME = item.NAME?? _aux.NAME;
                    _aux.ORDER = item.ORDER?? _aux.ORDER;
                    _aux.CHANNEL = item.CHANNEL?? _aux.CHANNEL;
                    ret = 1;
                }
                else
                {
                    db.MARKET_GROUPS.AddObject(new Entities.MARKET_GROUPS
                    {
                        NAME = item.NAME,
                        ORDER = item.ORDER,
                        CHANNEL = item.CHANNEL
                    });
                }

                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
    }
}
