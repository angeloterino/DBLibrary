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
    }
}
