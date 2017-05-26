//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HotelBookingSystem;

namespace CSC_330_Project_2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HotelManagementSystem());
        }

        //Function produces Output.txt file containing data from RentingLog
        public static void produceOutput()
        {
            List<Log> output = new List<Log>(); //List to hold each Log entry
            Log temp = new Log(); //Log to store into
            string[] outputString; //Output String to write to file

            //Create connection string
            string connectionString = ConfigurationManager.ConnectionStrings["CSC_330_Project_2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            
            //Open connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            //Create DataAdapter
            using(SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM RentingLog", connection))
            {
                //Create DataTable and fill
                DataTable logTable = new DataTable();
                adapter.Fill(logTable);

                //Loop for as many entries as there are in the table
                for (int i = 0; i < logTable.Rows.Count; i++)
                {
                    //Create DataRow to hold an individual row
                    DataRow dr = logTable.Rows[i];
                    //Store each column value into temp
                    temp.Name = dr["Name"].ToString();
                    temp.RBegin = Convert.ToDateTime(dr["Reservation Begin"]);
                    temp.REnd = Convert.ToDateTime(dr["Reservation End"]);
                    temp.RoomRented = Convert.ToInt16(dr["Room Rented"]);
                    temp.Profit = Convert.ToDouble(dr["Profit"]);
                    //Add temp log to output list
                    output.Add(temp);
                    temp = new Log(); //Create new Log for reuse of temp
                }
            }

            //Initialize outputString to number of elements in List
            outputString = new string[output.Count];

            //Loop through list storing each Log into string form for display in file
            for ( int i = 0; i < output.Count; i++ )
            {
                outputString[i] = output[i].Name + ' ' + output[i].RBegin + ' ' + output[i].REnd + ' ' + output[i].RoomRented + ' ' + output[i].Profit;
            }

            //Write string array to file
            System.IO.File.WriteAllLines("Output.txt", outputString);
        }
    }
}
