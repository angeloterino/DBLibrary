using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray
{
    public class Upload
    {
        public static int NTSData(string table, int transaction, List<Classes.ExcelLoader> lst)
        {
            int ret = 0;
            using (Entities.godzillaDBLibraryEntity db = new Entities.godzillaDBLibraryEntity())
            {
                db.ExecuteStoreCommand("exec sp_TRUNCATE_TMP_DATA @TABLE = {0}", table);

                foreach (Classes.ExcelLoader loader in lst)
                {
                    db.TMP_NTS_DATA.AddObject(new Entities.TMP_NTS_DATA
                    {
                        Country = loader.col1,
                        Local_CustGrp_1_name = loader.col2,
                        Mat_Local_Class_2 = loader.col3,
                        Mat_Local_Class_3 = loader.col4,
                        Mat_Local_Class_4 = loader.col5,
                        Fiscal_year_period = loader.col6,
                        C_NTS_ = loader.col7,
                        PLATAFORMA = loader.col8,
                        BRAND = loader.col9,
                        SUB_BRAND = loader.col10,
                        Marca = loader.col11,
                        Submarca = loader.col12,
                        MARKET = loader.col13,
                        YTD = loader.col14,
                        TRANSACTION_ID = transaction
                    });
                }
                db.SaveChanges();
            }

            return ret;
        }
    }
}
