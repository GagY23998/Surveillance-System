using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ColumnOptions columnOptions = new ColumnOptions();
            //columnOptions.AdditionalColumns = new Collection<SqlColumn>();
            //columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "UserId", DataType = System.Data.SqlDbType.Int, AllowNull = true });
            //columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "Entered", DataType = System.Data.SqlDbType.Bit, AllowNull = false });
            //columnOptions.AdditionalColumns.Add(new SqlColumn { ColumnName = "Left", DataType = System.Data.SqlDbType.Bit, AllowNull = false });
            

            //Log.Logger = new LoggerConfiguration().WriteTo.MSSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;", "Log",
            //                                                           columnOptions: columnOptions)
            //                                                           .CreateLogger();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
