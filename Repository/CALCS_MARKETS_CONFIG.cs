﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class CALCS_MARKETS_CONFIG
    {
        public static List<StrawmanDBLibray.Entities.CALCS_MARKETS_CONFIG> getAll() 
        {
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                return db.CALCS_MARKETS_CONFIG.Select(m => m).ToList();
            }
        }
        public static int Save(Entities.CALCS_MARKETS_CONFIG item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                Entities.CALCS_MARKETS_CONFIG itemaux = db.CALCS_MARKETS_CONFIG.Where(m => m.ID == item.ID).FirstOrDefault();
                if (itemaux != null)
                {
                    itemaux.GROUPCFG = item.GROUPCFG ?? itemaux.GROUPCFG;
                    itemaux.SUPERCFG = item.SUPERCFG ?? itemaux.SUPERCFG;
                    itemaux.CHANNELCFG = item.CHANNELCFG ?? itemaux.CHANNELCFG;
                    itemaux.FRANCHISECFG = item.FRANCHISECFG ?? itemaux.FRANCHISECFG;
                    itemaux.KEYBRANDSCFG = item.KEYBRANDSCFG ?? itemaux.KEYBRANDSCFG;
                    ret = 1;
                }
                else
                {
                    db.CALCS_MARKETS_CONFIG.AddObject(item);
                    ret = 1;
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
    }
}
