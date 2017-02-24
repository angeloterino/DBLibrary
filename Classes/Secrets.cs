using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StrawmanDBLibray.Classes
{
    public static class Secrets
    {
        private const string USER = "sa";
        private const string PASSWORD = "M3rcurio";
        private const string BBDD_DEV = "PARKINGPC04";
        private const string BBDD_PRO = "VM22078D0\\SQLEXPRESS";

        private static string _env = BBDD_DEV;//Desarrollo
        //private static string _env = BBDD_PRO;//Producción
        //public const string CONN_STRING = @"metadata=res://*/Entites.Godzilla2Model.csdl|res://*/Entites.Godzilla2Model.ssdl|res://*/Entites.Godzilla2Model.msl;provider=System.Data.SqlClient;provider connection string=""data source=VM22078D0\SQLEXPRESS;initial catalog=godzillaV2;persist security info=True;user id=" + USER + @";password=" + PASSWORD + @";MultipleActiveResultSets=True;App=EntityFramework""";
        public static string CONN_STRING = @"metadata=res://*/;provider=System.Data.SqlClient;provider connection string=""data source="+_env+";initial catalog=godzilla;persist security info=True;user id=" + USER + @";password=" + PASSWORD + @";multipleactiveresultsets=True;App=EntityFramework""";
    }
}
