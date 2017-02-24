using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class CHANNEL_MASTER
    {
        public static List<StrawmanDBLibray.Entities.CHANNEL_MASTER> getAll()
        {
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity())
            {
                return db.CHANNEL_MASTER.Select(m => m).ToList();
            }
        }
    }
}
