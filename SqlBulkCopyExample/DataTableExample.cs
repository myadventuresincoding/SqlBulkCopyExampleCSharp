using System;
using System.Data;
using System.Data.SqlClient;

namespace DataTableExample
{
    class DataTableExample
    {
        static void Main(string[] args)
        {
            // Note: You will need to edit the connection string if not using localhost and SQLExpress
            String host = "localhost\\SQLExpress";
            String databaseName = "Examples";
            String connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=SSPI;", host, databaseName);

            // Create a datatable with three columns:
            DataTable dailySalesStats = new DataTable("DailySalesStats");

            // Create Column 1: Date
            DataColumn dateColumn = new DataColumn();
            dateColumn.DataType = Type.GetType("System.DateTime");
            dateColumn.ColumnName = "Date";

            // Create Column 2: SalesPersonId
            DataColumn salesPersonIdColumn = new DataColumn();
            salesPersonIdColumn.DataType = Type.GetType("System.Int32");
            salesPersonIdColumn.ColumnName = "SalesPersonId";

            // Create Column 3: TotalSales
            DataColumn totalSalesColumn = new DataColumn();
            totalSalesColumn.DataType = Type.GetType("System.Int32");
            totalSalesColumn.ColumnName = "TotalSales";

            // Add the columns to the dailySalesStats DataTable
            dailySalesStats.Columns.Add(dateColumn);
            dailySalesStats.Columns.Add(salesPersonIdColumn);
            dailySalesStats.Columns.Add(totalSalesColumn);

            // Let's populate the datatable with our stats.
            // You can add as many rows as you want here!

            // Create a new row
            DataRow dailySalesStatsRowOne = dailySalesStats.NewRow();
            dailySalesStatsRowOne["Date"] = DateTime.Now.ToString("yyyy-MM-dd");
            dailySalesStatsRowOne["SalesPersonId"] = 1;
            dailySalesStatsRowOne["TotalSales"] = 2;

            // Create a second row
            DataRow dailySalesStatsRowTwo = dailySalesStats.NewRow();
            dailySalesStatsRowTwo["Date"] = DateTime.Now.ToString("yyyy-MM-dd");
            dailySalesStatsRowTwo["SalesPersonId"] = 2;
            dailySalesStatsRowTwo["TotalSales"] = 3;

            // Add the new rows to the dailySalesStats DataTable
            dailySalesStats.Rows.Add(dailySalesStatsRowOne);
            dailySalesStats.Rows.Add(dailySalesStatsRowTwo);

            // Copy the DataTable to SQL Server
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                using (SqlBulkCopy s = new SqlBulkCopy(dbConnection))
                {
                    Console.WriteLine("Writing to database...");
                    s.DestinationTableName = dailySalesStats.TableName;
                    foreach (var column in dailySalesStats.Columns)
                        s.ColumnMappings.Add(column.ToString(), column.ToString());
                    s.WriteToServer(dailySalesStats);
                    Console.WriteLine("Done!");
                }
            }

            // That's it, we are done!
        }
    }
}