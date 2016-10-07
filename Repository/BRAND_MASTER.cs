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

    }
}
