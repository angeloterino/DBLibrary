using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Repository
{
    public class BRAND_CONTRIBUTION
    {
        public static List<Entities.BRAND_CONTRIBUTION> getAll()
        {
            return (List<Entities.BRAND_CONTRIBUTION>)DBLibrary.GetKPIData(Classes.StrawmanDataTables.BRAND_CONTRIBUTION);
        }
        public static Entities.BRAND_CONTRIBUTION getById(int _id)
        {
            return ((List<Entities.BRAND_CONTRIBUTION>)DBLibrary.GetKPIData(Classes.StrawmanDataTables.BRAND_CONTRIBUTION)
                    ).Where(m => m.ID == (decimal)_id).FirstOrDefault();
        }
        public static int save(Entities.BRAND_CONTRIBUTION item)
        {
            int ret = -1;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity(Classes.Secrets.CONN_STRING))
            {
                if (db.BRAND_CONTRIBUTION.ToList().Exists(m => m.KPI_ID == item.KPI_ID && m.YEAR_PERIOD == item.YEAR_PERIOD && m.MONTH_PERIOD == item.MONTH_PERIOD))
                {
                    Entities.BRAND_CONTRIBUTION aux = db.BRAND_CONTRIBUTION.Where(m => m.KPI_ID == item.KPI_ID && m.YEAR_PERIOD == item.YEAR_PERIOD && m.MONTH_PERIOD == item.MONTH_PERIOD).First();
                    aux.COL1 = item.COL1;
                    aux.COL2 = item.COL2;
                    aux.COL3 = item.COL3;
                    aux.YEAR_PERIOD = item.YEAR_PERIOD;
                    aux.MONTH_PERIOD = item.MONTH_PERIOD;
                    ret = 1;
                }
                else
                {
                    db.BRAND_CONTRIBUTION.AddObject(new Entities.BRAND_CONTRIBUTION
                    {
                        COL1 = item.COL1,
                        COL2 = item.COL2,
                        COL3 = item.COL3,
                        YEAR_PERIOD = item.YEAR_PERIOD,
                        MONTH_PERIOD = item.MONTH_PERIOD,
                        KPI_ID = item.KPI_ID
                    });
                    ret = 1;
                }
                if(ret>0)
                    db.SaveChanges();
            }
            return ret;
        }

        public static int saveList(List<Entities.BRAND_CONTRIBUTION> lst)
        {
            int ret = 0;

            foreach (Entities.BRAND_CONTRIBUTION item in lst)
            {
                ret += save(item);
            }
            return ret;
        }
    }
}
