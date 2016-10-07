using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class MENU_CONFIG
    {
        public static List<Entities.MENU_CONFIG> getAll()
        {
            return (List<Entities.MENU_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MENU_CONFIG);
        }

        public static List<Entities.MENU_CONFIG> getAllByUserName(string name)
        {
            return ((List<Entities.MENU_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MENU_CONFIG))
                .Where(m => m.USER == name).Select(m => m).ToList();
        }
        public static Entities.MENU_CONFIG getById(int id)
        {
            return ((List<Entities.MENU_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.MENU_CONFIG))
                .Where(m => m.ID == id).FirstOrDefault();
        }
    }
}
