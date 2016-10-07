using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class MARKET_MASTER
    {
        public static List<Entities.MARKET_MASTER> getAll()
        {
            return (List<Entities.MARKET_MASTER>) DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER);
        }

        public static List<Entities.MARKET_MASTER> getAllByName(string name)
        {
            return ((List<Entities.MARKET_MASTER>) DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER))
                .Where(m=>m.NAME == name).Select(m=>m).ToList();
        }
        public static Entities.MARKET_MASTER getById(int id)
        {
            return ((List<Entities.MARKET_MASTER>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MARKET_MASTER))
                .Where(m => m.ID == id).FirstOrDefault();
        }
    }
}
