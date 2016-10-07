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
    }
}
