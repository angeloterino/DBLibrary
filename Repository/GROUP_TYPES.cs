using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class GROUP_TYPES
    {
        public static List<Entities.GROUP_TYPES> getAll()
        {
            return (List<Entities.GROUP_TYPES>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.GROUP_TYPES);
        }
    }
}
