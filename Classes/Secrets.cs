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

        //public const string CONN_STRING = @"metadata=res://*/Entites.Godzilla2Model.csdl|res://*/Entites.Godzilla2Model.ssdl|res://*/Entites.Godzilla2Model.msl;provider=System.Data.SqlClient;provider connection string=""data source=VM22078D0\SQLEXPRESS;initial catalog=godzillaV2;persist security info=True;user id=" + USER + @";password=" + PASSWORD + @";MultipleActiveResultSets=True;App=EntityFramework""";
        public const string CONN_STRING = @"metadata=res://*/;provider=System.Data.SqlClient;provider connection string=""data source=VM22078D0\SQLEXPRESS;initial catalog=godzilla;persist security info=True;user id=" + USER + @";password=" + PASSWORD + @";multipleactiveresultsets=True;App=EntityFramework""";
    }
}
