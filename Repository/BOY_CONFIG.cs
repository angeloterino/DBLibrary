using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class BOY_CONFIG
    {
        public static List<Entities.BOY_CONFIG> getAll()
        {
            return (List<Entities.BOY_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.BOY_CONFIG);
        }

        public static Entities.BOY_CONFIG getById(int id)
        {
            return ((List<Entities.BOY_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.BOY_CONFIG))
                .Where(m => m.ID == id).FirstOrDefault();
        }
        public static Entities.BOY_CONFIG getByColumn(string column, string value)
        {
            List<Entities.BOY_CONFIG> lst = (List<Entities.BOY_CONFIG>)DBLibrary.GetStrawmanConfig(Classes.StrawmanDataTables.BOY_CONFIG);
            switch (column)
            {
                case Columns.CHANNEL:
                    return lst.Where(m => m.CHANNEL == decimal.Parse(value)).FirstOrDefault();
                case Columns.MARKET:
                    return lst.Where(m => m.MARKET == decimal.Parse(value)).FirstOrDefault();
                case Columns.BRAND:
                    return lst.Where(m => m.BRAND == decimal.Parse(value)).FirstOrDefault();
                case Columns.NTS_ORDER:
                    return lst.Where(m => m.NTS_ORDER == decimal.Parse(value)).FirstOrDefault();
                case Columns.NTS_NAME:
                    return lst.Where(m => m.NTS_NAME == value).FirstOrDefault();
                case Columns.MARKET_CONFIG:
                    return lst.Where(m => m.MARKET_CONFIG == decimal.Parse(value)).FirstOrDefault();
                case Columns.SELLOUT_CONFIG:
                    return lst.Where(m => m.SELLOUT_CONFIG == decimal.Parse(value)).FirstOrDefault();
                case Columns.SELLIN_CONFIG:
                    return lst.Where(m => m.SELLIN_CONFIG == decimal.Parse(value)).FirstOrDefault();
                case Columns.CONSOLIDATE:
                    return lst.Where(m => m.CONSOLIDATE == decimal.Parse(value)).FirstOrDefault();
                default:
                    return lst.Where(m => m.ID == int.Parse(value)).FirstOrDefault();
            }
        }

        public class Columns
        {
            public const string
                ID = "ID",
                CHANNEL = "CHANNEL",
                BRAND = "BRAND",
                MARKET ="MARKET",
                NTS_NAME = "NTS_NAME",
                NTS_ORDER = "NTS_ORDER",
                MARKET_CONFIG = "MARKET_CONFIG",
                SELLOUT_CONFIG = "SELLOUT_CONFIG",
                SELLIN_CONFIG = "SELLIN_CONFIG",
                CONSOLIDATE  = "CONSOLIDATE"
                ;
        }
        public static string GetCalcStatus(decimal? _status, string _column)
        {
            _status = _status == null?1:_status;
            switch (_column) 
            { 
                case Columns.CONSOLIDATE:
                    switch ((int)_status)
                    {
                        case 1:
                        default:
                            return Classes.Constants.YES;
                        case 0:
                            return Classes.Constants.NO;
                    }
                default: //MARKET_CONFIG, SELLOUT_CONFIG, SELLIN_CONFIG
                    switch ((int)_status)
                    {
                        case 1:
                        default:
                            return Classes.Constants.ADD;
                        case 0:
                            return Classes.Constants.NO_ADD;
                        case -1:
                            return Classes.Constants.SUBSTRACT;
                            
                    }
                    break;
            }
            return null;
        }
    }
}
