using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StrawmanDBLibray
{
    public class DBLibrary
    {
        #region BOYS Functions
        public static object GetBoyData(string key)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.CommandTimeout = 50000;
                switch (key)
                {
                    case "v_WRK_BOY_BY_CHANNEL_DATA_INT":
                        var bci = db.v_WRK_BOY_BY_CHANNEL_DATA_INT
                            .Select(m => m);
                        tmp = bci.ToList();
                        break;
                    case "v_WRK_BOY_BY_CHANNEL_DATA_LE":
                        var bcl = db.v_WRK_BOY_BY_CHANNEL_DATA_LE
                            .Select(m => m);
                        tmp = bcl.ToList();
                        break;
                    case "v_WRK_BOY_BY_CHANNEL_DATA_PBP":
                        var bcp = db.v_WRK_BOY_BY_CHANNEL_DATA_PBP
                            .Select(m => m);
                        tmp = bcp.ToList();
                        break;
                    case "v_WRK_BOY_CALC_DATA":
                        var cd = db.v_WRK_BOY_CALC_DATA
                            .Select(m => m);
                        tmp = cd.ToList();
                        break;
                    case "WRK_BOY_CALC_DATA_INT":
                        var cdi = db.WRK_BOY_CALC_DATA_INT
                            .Select(m => m);
                        tmp = cdi.ToList();
                        break;
                    case "WRK_BOY_CALC_DATA_LE":
                        var cdl = db.WRK_BOY_CALC_DATA_LE
                            .Select(m => m);
                        tmp = cdl.ToList();
                        break;
                    case "WRK_BOY_CALC_DATA_PBP":
                        var cdp = db.WRK_BOY_CALC_DATA_PBP
                            .Select(m => m);
                        tmp = cdp.ToList();
                        break;
                    case "WRK_BOY_BASIC_DATA":
                        var bbd = db.WRK_BOY_BASIC_DATA
                            .Select(m => m);
                        tmp = bbd.ToList();
                        break;
                    case "v_WRK_BOY_BY_CHANNEL_DATA":
                        var def = db.v_WRK_BOY_BY_CHANNEL_DATA
                            .Select(m => m);
                        tmp = def.ToList();
                        break;
                    //case "WRK_BOY_BY_CHANNEL_CALC":
                    //    var ccal = db.WRK_BOY_BY_CHANNEL_CALC
                    //        .Select(m => m);
                    //    tmp = ccal.ToList();
                    //    break;
                    case "v_WRK_BOY_BY_CHANNEL_CALC":
                        var vccal = db.v_WRK_BOY_BY_CHANNEL_CALC
                            .Select(m => m);
                        tmp = vccal.ToList();
                        break;
                    case "WRK_BOY_BY_CHANNEL_GENERAL":
                        var cgen = db.WRK_BOY_BY_CHANNEL_GENERAL
                            .Select(m => m);
                        tmp = cgen.ToList();
                        break;
                    case "v_WRK_BOY_BY_CHANNEL_GENERAL":
                        var vgen = db.v_WRK_BOY_BY_CHANNEL_GENERAL
                            .Select(m => m);
                        tmp = vgen.ToList();
                        break;
                }
            }
            return tmp;
        }
        public static object GetBoyData()
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity())
            {
                db.CommandTimeout = 50000;
                var data = db.WRK_BOY_DATA.Select(m => m);
                tmp = data.ToList();
            }
            return tmp;
        }
        #endregion

        #region Data Tables
        public static object GetMarketData(string view, int _year, int _month)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.CommandTimeout = 50000;
                switch (view)
                {
                    case "WRK_MARKET_BOY":
                        tmp = db.v_WRK_MARKET_BOY_DATA.Where(m=>m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "v_STRWM_MARKET_DATA":
                        tmp = db.v_STRWM_MARKET_DATA.ToList()
                            .Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month || (m.YEAR_PERIOD == null && m.MONTH_PERIOD == null) && !m.SOURCE.Contains("BRAND")).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_MONTH":
                        tmp = db.v_WRK_MARKET_MONTH_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_YTD":
                        tmp = db.v_WRK_MARKET_YTD_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_MAT":
                        tmp = db.v_WRK_MARKET_MAT_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_BTG":
                        tmp = db.v_WRK_MARKET_BTG_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_TOTAL_CUSTOM":
                        tmp = db.v_WRK_MARKET_TOTAL_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_MARKET_PCVSPY":
                        tmp = db.v_WRK_MARKET_PCVSPY_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                }
            }
            return tmp;

        }

        public static object GetBrandData(string view, int _year, int _month)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.CommandTimeout = 50000;
                switch (view)
                {
                    case "WRK_BRAND_BOY":
                        tmp = db.v_WRK_BRAND_BOY_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "v_STRWM_BRAND_DATA":
                        tmp = db.v_STRWM_MARKET_DATA.ToList()
                            .Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month || (m.YEAR_PERIOD == null && m.MONTH_PERIOD == null) && !m.SOURCE.Contains("MARKET")).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_MONTH":
                        tmp = db.v_WRK_BRAND_MONTH_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_YTD":
                        tmp = db.v_WRK_BRAND_YTD_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_MAT":
                        tmp = db.v_WRK_BRAND_MAT_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_BTG":
                        tmp = db.v_WRK_BRAND_BTG_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_TOTAL_CUSTOM":
                        tmp = db.v_WRK_BRAND_TOTAL_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                    case "WRK_BRAND_PCVSPY":
                        tmp = db.v_WRK_BRAND_PCVSPY_DATA.Where(m => m.YEAR_PERIOD == _year && m.MONTH_PERIOD == _month).Select(m => m).ToList();
                        break;
                }
            }
            return tmp;

        }
        public static object GetNTSData(string view)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.CommandTimeout = 50000;
                switch (view)
                {
                    case Classes.NTSTables.WRK_NTS_VIEW_DATA:
                        tmp = db.WRK_NTS_VIEW_DATA.Select(m => m).ToList();
                        break;
                    case Classes.NTSTables.v_WRK_NTS_DATA_CHANNEL:
                        tmp = db.v_WRK_NTS_DATA_CHANNEL.Where(m => m.YEAR_PERIOD != null && m.MONTH_PERIOD != null).Select(m => m).ToList();
                        break;
                    case Classes.NTSTables.v_WRK_NTS_DATA_FRANCHISE:
                        tmp = db.v_WRK_NTS_DATA_FRANCHISE.Where(m => m.YEAR_PERIOD != null && m.MONTH_PERIOD != null).Select(m => m).ToList();
                        break;
                    case Classes.NTSTables.v_WRK_NTS_DATA_KEYBRANDS:
                        tmp = db.v_WRK_NTS_DATA_KEYBRANDS.Where(m => m.YEAR_PERIOD != null && m.MONTH_PERIOD != null).Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_STRWM_MARKET_DATA:
                        tmp = db.v_STRWM_MARKET_DATA.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_WRK_CHANNEL_DATA:
                        tmp = db.v_WRK_CHANNEL_DATA.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_WRK_FRANCHISE_DATA:
                        tmp = db.v_WRK_FRANCHISE_DATA.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_ENTITY_WRK_KEYBRANDS_BASE:
                        tmp = db.v_ENTITY_WRK_KEYBRANDS_BASE.Select(m => m).ToList();
                        break;
                }
            }
            return tmp;

        }

        public static object GetChannelData(string view)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (view)
                {
                    case "v_WRK_CHANNEL_DATA":
                        tmp = db.v_WRK_CHANNEL_DATA.Select(m => m).ToList();
                        break;
                }
            }
            return tmp;
        }

        public static object GetFrachiseData(string view)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (view)
                {
                    case Classes.StrawmanDataTables.v_WRK_FRANCHISE_DATA:
                        tmp = db.v_WRK_FRANCHISE_DATA.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_WRK_FRANCHISE_MASTER:
                        tmp = db.v_WRK_FRANCHISE_MASTER.Select(m => m).ToList();
                        break;
                }
            }
            return tmp;
        }

        public static object GetKeybrandsData(string view)
        {
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (view)
                {
                    default:
                        return db.v_KEYBRANDS_MASTER.ToList();
                }
            }
        }
        
        public static object GetShareBoardData(string view)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.CommandTimeout = 50000;
                switch (view)
                {
                    case Classes.StrawmanDataTables.v_SHAREBOARD_MAT:
                        tmp = db.v_SHAREBOARD_MAT.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_SHAREBOARD_MONTH:
                        tmp = db.v_SHAREBOARD_MONTH.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_SHAREBOARD_YTD:
                        tmp = db.v_SHAREBOARD_YTD.Select(m => m).ToList();
                        break;
                }
            }
            return tmp;
        }

        #endregion

        #region Config
        public static object GetStrawmanConfig(string type)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (type)
                {
                    case Classes.StrawmanDataTables.GROUP_TYPES:
                        tmp = db.GROUP_TYPES.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.GROUP_CONFIG:
                        tmp = db.GROUP_CONFIG.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.GROUP_MASTER:
                        tmp = db.GROUP_MASTER.Select(m => m).ToList();
                        break;

                    case Classes.StrawmanDataTables.MARKET_GROUPS:
                        tmp = db.MARKET_GROUPS.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.MARKET_MASTER:
                        tmp = db.MARKET_MASTER.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.BRAND_MASTER:
                        tmp = db.BRAND_MASTER.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.CHANNEL_MASTER:
                        tmp = db.CHANNEL_MASTER.Select(m => m).ToList();
                        break;

                    case Classes.StrawmanDataTables.USER_ROLE_TYPES:
                        tmp = db.USER_ROLE_TYPES.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.USERS_ROLES:
                        tmp = db.USERS_ROLES.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.USERS_PERMISSIONS:
                        tmp = db.USERS_PERMISSIONS.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.MENU_MASTER:
                        tmp = db.MENU_MASTER.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.MENU_CONFIG:
                        tmp = db.MENU_CONFIG.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.ROSETTA_LOADER:
                        tmp = db.ROSETTA_LOADER.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.BOY_CONFIG:
                        tmp = db.BOY_CONFIG.Select(m => m).ToList();
                        break;

                }
            }
            return tmp;
        }
        public static object GetStrawmanVariables(string type)
        {
            object obj = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (type)
                {
                    case Classes.StrawmanDataTables.WRK_VIEWS_VARIABLES:
                        obj = db.WRK_VIEWS_VARIABLES.Select(m => m).ToList();
                        break;
                }
            }
            return obj;
        }
        #endregion

        #region Comments
        public static object GetComments(string type)
        {
            object ret = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (type)
                {
                    case Classes.StrawmanDataTables.MANAGEMENT_LETTERS_MASTER:
                        ret = db.MANAGEMENT_LETTERS_MASTER.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.MANAGEMENT_LETTERS_REL:
                        ret = db.MANAGEMENT_LETTERS_REL.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.LETTERS_COMMENT_DATA:
                        ret = db.LETTERS_COMMENT_DATA.Select(m => m).ToList();
                        break;
                    case Classes.StrawmanDataTables.v_WRK_MANAGEMENT_LETTERS_DATA:
                        ret = db.v_WRK_MANAGEMENT_LETTERS_DATA.Select(m => m).ToList();
                        break;
                }
            }
            return ret;
        }

        public static object GetCommentsByMasterId(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.LETTERS_COMMENT_DATA.Where(m => m.LETTER_ID == _id).Select(m => m).ToList();
            }

            return ret;
        }
        public static object GetCommentsByMasterIdAsEntityList(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.MANAGEMENT_LETTERS_MASTER.Where(m => m.ID == _id).FirstOrDefault().LETTERS_COMMENT_DATA;
            }
            return ret;
        }
        public static object GetCommentsMasterById(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.MANAGEMENT_LETTERS_MASTER.Where(m => m.ID == _id).Select(m => m).FirstOrDefault();
            }

            return ret;
        }

        public static object GetCommentsById(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.LETTERS_COMMENT_DATA.Where(m => m.ID == _id).Select(m => m).FirstOrDefault();
            }

            return ret;
        }
        public static object GetMasterRelById(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.MANAGEMENT_LETTERS_REL.Where(m => m.ID == _id).Select(m => m).FirstOrDefault();
            }

            return ret;
        }
        public static object GetMasterRelByLetterId(string id)
        {
            object ret = null;
            int _id = int.Parse(id);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.MANAGEMENT_LETTERS_REL.Where(m => m.MANAGEMENT_LETTER_ID == _id).Select(m => m).FirstOrDefault();
            }

            return ret;
        }
        public static object GetMasterRel(string channel, string market, string brand)
        {
            object ret = null;
            decimal _channel = decimal.Parse(channel);
            decimal _market = decimal.Parse(market);
            decimal _brand = decimal.Parse(brand);
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                ret = db.MANAGEMENT_LETTERS_REL.Where(m => m.CHANNEL == _channel && m.MARKET == _market && m.BRAND == _brand).FirstOrDefault();
            }
            return ret;
        }

        public static int SaveComment(StrawmanDBLibray.Entities.LETTERS_COMMENT_DATA letter, Entities.MANAGEMENT_LETTERS_MASTER master, Entities.MANAGEMENT_LETTERS_REL rel)
        {
            int ret = -1;
            using(Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (master != null)
                {
                    var _rel = db.MANAGEMENT_LETTERS_REL.Where(m => m.ID == rel.ID).FirstOrDefault();
                    if (_rel == null)
                    {
                        db.MANAGEMENT_LETTERS_REL.AddObject(rel);
                        _rel = rel;
                    }
                    if (_rel.MANAGEMENT_LETTER_ID == 0)
                    {
                        db.MANAGEMENT_LETTERS_MASTER.AddObject(master);
                        db.SaveChanges();
                        _rel.MANAGEMENT_LETTER_ID = master.ID;
                    }
                    var _master = db.MANAGEMENT_LETTERS_MASTER.Where(m => m.ID == _rel.MANAGEMENT_LETTER_ID).FirstOrDefault();
                    _master.LETTERS_COMMENT_DATA.Add(letter);
                }
                else
                {
                    db.LETTERS_COMMENT_DATA.AddObject(letter);
                }

                db.SaveChanges();
                ret = 1;
            }

            return ret;
        }

        public static int SaveCommentData(string table, object obj)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.LETTERS_COMMENT_DATA.Context.AcceptAllChanges();
                bool save = false;
                switch (table)
                {
                    case Classes.StrawmanDataTables.LETTERS_COMMENT_DATA:
                        Entities.LETTERS_COMMENT_DATA obj_letter = (Entities.LETTERS_COMMENT_DATA) obj;
                        Entities.LETTERS_COMMENT_DATA letter = db.LETTERS_COMMENT_DATA.Where(m => m.ID == obj_letter.ID).FirstOrDefault();
                        if (letter != null)
                        {
                            letter.COMMENT = obj_letter.COMMENT;
                            letter.LETTER_ID = obj_letter.LETTER_ID;
                            letter.USER = obj_letter.USER;
                            letter.YEAR_PERIOD = obj_letter.YEAR_PERIOD;
                            letter.MONTH_PERIOD = obj_letter.MONTH_PERIOD;
                            letter.TYPE = obj_letter.TYPE;
                            letter.DATE = obj_letter.DATE;
                        }
                        else
                            db.LETTERS_COMMENT_DATA.AddObject(obj_letter);
                        save = true;
                        break;

                    case Classes.StrawmanDataTables.MANAGEMENT_LETTERS_REL:
                        Entities.MANAGEMENT_LETTERS_REL obj_rel = (Entities.MANAGEMENT_LETTERS_REL)obj;
                        Entities.MANAGEMENT_LETTERS_REL rel = db.MANAGEMENT_LETTERS_REL.Where(m => m.ID == obj_rel.ID).FirstOrDefault();
                        if (rel != null ) 
                            rel = obj_rel;
                        else
                            db.MANAGEMENT_LETTERS_REL.AddObject(obj_rel);
                        save = true;
                        break;
                }
                if (save)
                {
                    db.SaveChanges();
                    ret = 1;
                }
            }
            return ret;
        }

        public static int RemoveComment(string table, object obj)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                db.LETTERS_COMMENT_DATA.Context.AcceptAllChanges();
                bool deleted = false;
                switch (table)
                {
                    case Classes.StrawmanDataTables.LETTERS_COMMENT_DATA:
                        Entities.LETTERS_COMMENT_DATA obj_letter = (Entities.LETTERS_COMMENT_DATA)obj;
                        Entities.LETTERS_COMMENT_DATA letter = db.LETTERS_COMMENT_DATA.Where(m => m.ID == obj_letter.ID).FirstOrDefault();
                        if (letter != null)
                        {
                            db.LETTERS_COMMENT_DATA.DeleteObject(letter);
                        }
                        deleted = true;
                        break;

                    case Classes.StrawmanDataTables.MANAGEMENT_LETTERS_REL:
                        Entities.MANAGEMENT_LETTERS_REL obj_rel = (Entities.MANAGEMENT_LETTERS_REL)obj;
                        Entities.MANAGEMENT_LETTERS_REL rel = db.MANAGEMENT_LETTERS_REL.Where(m => m.ID == obj_rel.ID).FirstOrDefault();
                        if (rel != null)
                            db.MANAGEMENT_LETTERS_REL.DeleteObject(rel);
                        deleted = true;
                        break;
                }
                if (deleted)
                {
                    db.SaveChanges();
                    ret = 1;
                }
            }
            return ret;
        }
        #endregion

        #region GetLoaderData
        public static object GetLoaderData(string table)
        {
            object tmp = null;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (table)
                {
                    case Classes.StrawmanDataTables.STRWM_NTS_DATA_BCK:
                        tmp = db.STRWM_NTS_DATA_BCK.Select(m=>m).ToList();
                        break;
                    case Classes.StrawmanDataTables.STRWM_MARKET_DATA_BCK:
                        tmp = db.STRWM_MARKET_DATA_BCK.Select(m=>m).ToList();
                        break;
                    case Classes.StrawmanDataTables.STRWM_BRAND_DATA_BCK:
                        tmp = db.STRWM_BRAND_DATA_BCK.Select(m=>m).ToList();
                        break;
                }
            }
            return tmp;
        }
        #endregion

        #region SaveData
        public static int SaveData(string table, object obj)
        {
            int ret = -1;
            bool is_entity = false; //Permite distinguir si el objeto es una entidad (trae datos vinculados de otras tablas) o es una tabla en sí. Por defecto, tabla.
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (table)
                {
                    case Classes.StrawmanDataTables.USERS_ROLES:
                        Entities.USERS_ROLES rol_tmp = (Entities.USERS_ROLES)obj;
                        Entities.USERS_ROLES rol = db.USERS_ROLES.Where(m => m.ID == rol_tmp.ID).FirstOrDefault();
                        if (rol != null)
                        {
                            rol.USER = rol_tmp.USER;
                            rol.ROLE = rol_tmp.ROLE;
                        }
                        else
                        {
                            db.USERS_ROLES.AddObject(rol_tmp);
                        }
                        ret = 1;
                        break;
                    case Classes.StrawmanDataTables.MENU_CONFIG:
                        ret = 0;
                        Entities.MENU_CONFIG menu_tmp = (Entities.MENU_CONFIG)obj;
                        Entities.MENU_CONFIG menu = db.MENU_CONFIG.Where(m => m.MENU_ID == menu_tmp.MENU_ID && m.USER == menu_tmp.USER).FirstOrDefault();
                        if (menu == null)
                        {
                            db.MENU_CONFIG.AddObject(menu_tmp);
                            ret = 1;
                        }
                        else
                        {
                            if (menu.PERMISSION != menu_tmp.PERMISSION)
                            {
                                menu.PERMISSION = menu_tmp.PERMISSION;
                                ret = 1;
                            }
                        }
                        break;
                    case Classes.StrawmanDataTables.USERS_PERMISSIONS:
                        ret = 0;
                        Entities.USERS_PERMISSIONS perm_tmp = (Entities.USERS_PERMISSIONS)obj;
                        Entities.USERS_ROLES perm_rol = db.USERS_ROLES.Where(m => m.USER == perm_tmp.USERS_ROLES.USER).FirstOrDefault();
                        if (perm_rol == null)
                        {
                            db.USERS_ROLES.AddObject(perm_tmp.USERS_ROLES);
                            db.SaveChanges();
                            perm_rol = db.USERS_ROLES.Where(m => m.USER == perm_tmp.USERS_ROLES.USER).FirstOrDefault();
                        }
                        perm_tmp.USERS_ROLES = null;
                        if (perm_tmp.USER <= 0) perm_tmp.USER = perm_rol.ID;
                        List<Entities.USERS_PERMISSIONS> perms = db.USERS_PERMISSIONS.Where(m => m.USER == perm_rol.ID && m.VIEW == perm_tmp.VIEW).ToList();
                        bool addObject = true;
                        if (perms != null)
                        {
                            Entities.USERS_PERMISSIONS perm = perms.Find(m => m.MARKET == perm_tmp.MARKET && m.BRAND == perm_tmp.BRAND && m.CHANNEL == perm_tmp.CHANNEL);
                            if (perm != null) addObject = false;
                            ret = 1;
                        }
                        if (addObject)
                        {
                            try
                            {
                                db.USERS_PERMISSIONS.AddObject(perm_tmp);
                            }
                            catch (Exception ex)
                            {
                                ret = -1;
                            }
                        }
                        break;
                    case Classes.StrawmanDataTables.MARKET_MASTER:
                        Entities.MARKET_MASTER master = (Entities.MARKET_MASTER) obj;
                        Entities.MARKET_MASTER market_master = db.MARKET_MASTER.Where(m => m.ID == master.ID).FirstOrDefault();
                        if(market_master == null) master.ID = db.MARKET_MASTER.Select(m => m.ID).Max() + 1;
                        //Comprobamos si trae datos de BRAND_MASTER vinculados
                        if (master.BRAND_MASTER != null)
                        {
                            is_entity = true;//Es una entidad ya que arrastra datos de otra tabla.

                            if (master.BRAND_MASTER.ToList().Exists(m => m.ID == 0 || m.ID == null))
                            {
                                //Primero actualizar el ID si son nulos
                                foreach (Entities.BRAND_MASTER bs in master.BRAND_MASTER.ToList().Where(m => m.ID == 0 || m.ID == null).Select(m => m))
                                {

                                    bs.ID = db.BRAND_MASTER.Select(m => m.ID).Max() + 1;
                                }
                            }
                            //Si el market viene a nulo actualizamos el market
                            if (master.BRAND_MASTER.ToList().Exists(m => m.MARKET == 0 || m.MARKET == null))
                            {
                                //Primero actualizar el ID
                                foreach (Entities.BRAND_MASTER bs in master.BRAND_MASTER.ToList().Where(m => m.MARKET == 0 || m.MARKET == null).Select(m => m))
                                {

                                    bs.MARKET = master.ID;
                                }
                            }
                        }
                        if (market_master == null)
                        {
                            //Insert
                            
                            db.MARKET_MASTER.AddObject(master);

                        }else
                        {
                            //Hay que distinguir la actualización de la entidad (con BRAND_MASTER asociado) de la de la tabla
                            if (market_master.NAME != master.NAME && master.NAME != null) market_master.NAME = master.NAME;
                            if (market_master.GROUP != master.GROUP) market_master.GROUP = master.GROUP;
                            if (market_master.CHANNEL != master.CHANNEL) market_master.CHANNEL = master.CHANNEL;
                            //Esto solo se actualiza en caso de tabla
                            if (!is_entity)
                            {
                                if (market_master.KEYBRANDS != master.KEYBRANDS) market_master.KEYBRANDS = master.KEYBRANDS;
                                if (market_master.FRANCHISE != master.FRANCHISE) market_master.FRANCHISE = master.FRANCHISE;
                            }
                            else
                            {
                                //Si es entidad arrastra brand
                                foreach (Entities.BRAND_MASTER bmaster in master.BRAND_MASTER)
                                {
                                    Entities.BRAND_MASTER baux = new Entities.BRAND_MASTER
                                    {
                                        ID = bmaster.ID,
                                        NAME = bmaster.NAME,
                                        GROUP = bmaster.GROUP,
                                        MARKET = bmaster.MARKET,
                                        CHANNEL = bmaster.CHANNEL
                                    };
                                    //Comprobamos que existe
                                    if (db.BRAND_MASTER.ToList().Exists(m => m.ID == bmaster.ID))
                                    {
                                        //Si existe actualizamos el dato 
                                        Entities.BRAND_MASTER aux = db.BRAND_MASTER.FirstOrDefault(m => m.ID == bmaster.ID);
                                        if (aux.NAME != bmaster.NAME) aux.NAME = baux.NAME;
                                        if (aux.GROUP != bmaster.GROUP) aux.GROUP = baux.GROUP;
                                        if (aux.MARKET != bmaster.MARKET) aux.MARKET = baux.MARKET;
                                        if (aux.CHANNEL != bmaster.CHANNEL) aux.CHANNEL = baux.CHANNEL;
                                    }
                                    else
                                    {
                                        //Si no existe lo añadimos a la colección
                                        db.BRAND_MASTER.AddObject(baux);
                                    }
                                }
                            }
                        }
                        //Comprobamos que existe el nuevo registro en la tabla Rosetta
                        List<Entities.ROSETTA_LOADER> loader = db.ROSETTA_LOADER.Select(m => m).ToList();
                        foreach (Entities.BRAND_MASTER bs in master.BRAND_MASTER.ToList().Select(m => m))
                        {
                            if (!loader.Exists(m => m.BRAND_ID == bs.ID && m.MARKET_ID == bs.MARKET))
                            {
                                //Si no existe añadimos la configuración
                                db.ROSETTA_LOADER.AddObject(new Entities.ROSETTA_LOADER
                                {
                                     MARKET_ID = bs.MARKET,
                                     BRAND = bs.NAME,
                                     BRAND_ID = bs.ID,
                                     CHANNEL_ID = bs.CHANNEL,
                                     GROUP_ID = bs.MARKET_MASTER.GROUP,
                                     DESCRIPTION = bs.MARKET_MASTER.NAME,
                                     STATUS = "P" //Ni Activo (A) ni baja (B), pedinente (P)
                                });
                            }

                        }
                        ret = 1;
                        break;
                        case Classes.StrawmanDataTables.BRAND_MASTER:
                        Entities.BRAND_MASTER baster = (Entities.BRAND_MASTER) obj;
                        Entities.BRAND_MASTER brand_master = db.BRAND_MASTER.Where(m => m.ID == baster.ID).FirstOrDefault();
                        if (brand_master == null)
                        {
                            //Insert
                            baster.ID = db.BRAND_MASTER.Select(m => m.ID).Max() + 1;
                            baster.GROUP = db.MARKET_MASTER.Where(m => m.ID == baster.MARKET).FirstOrDefault().GROUP;
                            db.BRAND_MASTER.AddObject(baster);

                        }else
                        {
                            //Update
                            //if (brand_master.ID == 0) brand_master.ID = db.BRAND_MASTER.Select(m => m.ID).Max() + 1;
                            if (brand_master.NAME != baster.NAME && baster.NAME != null) brand_master.NAME = baster.NAME;
                            if (brand_master.MARKET != baster.MARKET) brand_master.MARKET = baster.MARKET;
                            if (brand_master.GROUP != baster.GROUP) brand_master.GROUP = baster.GROUP;
                            if (brand_master.KEYBRANDS != baster.KEYBRANDS) brand_master.KEYBRANDS = baster.KEYBRANDS;
                            if (brand_master.CHANNEL != baster.CHANNEL) brand_master.CHANNEL = baster.CHANNEL;
                            if (brand_master.FRANCHISE != baster.FRANCHISE) brand_master.FRANCHISE = baster.FRANCHISE;
                        }
                        ret = 1;
                        break;
                }
                if (ret>0)
                    db.SaveChanges();

            }

            return ret;
        }
        #endregion

        #region DeleteData
        public static int DeleteData(string table, object obj)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                switch (table)
                {
                    case Classes.StrawmanDataTables.MENU_CONFIG:
                        Entities.MENU_CONFIG menu_tmp = (Entities.MENU_CONFIG)obj;
                        if (menu_tmp != null)
                        {
                            Entities.MENU_CONFIG menu = db.MENU_CONFIG.Where(m => m.ID == menu_tmp.ID).FirstOrDefault();
                            if (menu != null)
                            {
                                db.MENU_CONFIG.DeleteObject(menu);
                                ret = 1;
                            }
                        }
                        break;

                    case Classes.StrawmanDataTables.USERS_PERMISSIONS:
                        Entities.USERS_PERMISSIONS perm_tmp = (Entities.USERS_PERMISSIONS)obj;
                        if (perm_tmp != null)
                        {
                            Entities.USERS_ROLES perm_rol = db.USERS_ROLES.Where(m=>m.USER == perm_tmp.USERS_ROLES.USER).FirstOrDefault();
                            if(perm_rol != null){
                                Entities.USERS_PERMISSIONS perm_del= db.USERS_PERMISSIONS.Where(m => m.USER == perm_rol.ID && m.VIEW == perm_tmp.VIEW && m.MARKET == perm_tmp.MARKET && m.BRAND == perm_tmp.BRAND && m.CHANNEL == perm_tmp.CHANNEL).FirstOrDefault();
                                if (perm_del != null) { db.USERS_PERMISSIONS.DeleteObject(perm_del); ret = 1; }
                            }
                        }
                        break;
                }
                if (ret > 0) db.SaveChanges();
            }
            return ret;
        }
        #endregion
    }
}
