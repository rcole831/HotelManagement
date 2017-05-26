//HotelManagementSystem.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CSC_330_Project_2
{
    public partial class HotelManagementSystem : Form
    {
        //Declare connectionString and connection for usage throughout GUI code
        string connectionString;
        SqlConnection connection;
        public HotelManagementSystem()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["CSC_330_Project_2.Properties.Settings.Database1ConnectionString"].ConnectionString;
            this.FormClosing += HotelManagementSystem_FormClosing;
        }

        private void HotelManagementSystem_Load(object sender, EventArgs e)
        {
            //Call two functions when the form loads
            populateRooms();
            populateGuests();
        }

        //Function fills listViewRooms with data from Room Table
        private void populateRooms()
        {
            using(connection = new SqlConnection(connectionString))
            using(SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Room", connection))
            {
                listViewRoom.View = View.Details;
                DataTable roomTable = new DataTable();
                adapter.Fill(roomTable);

                for (int i = 0; i < roomTable.Rows.Count; i++)
                {
                    DataRow dr = roomTable.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["Room Number"].ToString());
                    listitem.SubItems.Add(dr["Rented"].ToString());
                    listitem.SubItems.Add(dr["Cost"].ToString());
                    listitem.SubItems.Add(dr["Rented By"].ToString());
                    listitem.SubItems.Add(dr["Reservation Begin"].ToString());
                    listitem.SubItems.Add(dr["Reservation End"].ToString());
                    listViewRoom.Items.Add(listitem);
                } 
            }
        }

        //Function fills listBoxGuests with data from Guest Table
        private void populateGuests()
        {
            using(connection = new SqlConnection(connectionString))
            using(SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Guest", connection))
            {
                DataTable guestTable = new DataTable();
                adapter.Fill(guestTable);

                listBoxGuest.DataSource = guestTable;
                listBoxGuest.DisplayMember = "Name";
            }
        }

        //Function calculates final bill for any selected Guest in listBoxGuest
        private void calculateFinalBill()
        {
            double roomBill, foodBill, finalBill;
            DateTime start = new DateTime(2016, 11, 26);
            DateTime end = new DateTime(2016, 11, 26);
            int total;
            roomBill = foodBill = finalBill = 0;
            string roomNum = String.Empty;
            string query1 = "SELECT * FROM Guest WHERE Name = @GuestName";
            string query2 = "SELECT * FROM Room WHERE [Room Number] = @RoomNum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            {
                command1.Parameters.AddWithValue("@GuestName", listBoxGuest.GetItemText(listBoxGuest.SelectedItem));
                connection.Open();
                using (SqlDataReader reader = command1.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roomBill = Convert.ToDouble(reader["Room Bill"].ToString());
                        foodBill = Convert.ToDouble(reader["Food Bill"].ToString());
                        roomNum = reader["Rented Room"].ToString();
                    }
                }

                if (roomNum != String.Empty && roomNum != null)
                {
                    command2.Parameters.AddWithValue("@RoomNum", roomNum);
                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Reservation Begin"] != null && reader["Reservation Begin"].ToString() != String.Empty)
                            {
                                start = DateTime.Parse(reader["Reservation Begin"].ToString());

                            }
                            if (reader["Reservation End"] != null && reader["Reservation End"].ToString() != String.Empty)
                            {
                                end = DateTime.Parse(reader["Reservation End"].ToString());
                            }
                        }
                    }
                    TimeSpan span = end.Subtract(start);

                    total = Convert.ToInt16(span.Days);

                    finalBill = foodBill + total * roomBill;

                    textBoxFinalBill.Text = '$' + finalBill.ToString();
                }
                else
                {
                    finalBill = foodBill + roomBill;

                    textBoxFinalBill.Text = '$' + finalBill.ToString();
                }
            }
        }

        //Activates when user presses the 'X' button to close program
        private void HotelManagementSystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Call Function to dump RentingLog into Text File here
            Program.produceOutput();
        }

        //Button adds a guest to Guest Table
        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Guest VALUES (@Name, NULL, 0, 0, 0)";
            using ( connection = new SqlConnection (connectionString))
            using ( SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@Name", textBoxGuestName.Text);
                command.ExecuteNonQuery();
            }

            //Refresh listBoxGuest
            populateGuests();
        }

        //If selected index in listBoxGuest is changed, calculate final bill
        private void listBoxGuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateFinalBill();
        }

        //Button checks out guest
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            //Reset room and add log to RentingLog
            string query1 = "DELETE FROM Guest WHERE Name = @GuestName";
            string query2 = "UPDATE Room SET Rented = 0 WHERE [Room Number] = @RoomNumber";
            string query3 = "UPDATE Room SET [Rented By] = NULL WHERE [Room Number] = @RoomNumber";
            string query4 = "UPDATE Room SET [Reservation Begin] = NULL WHERE [Room Number] = @RoomNumber";
            string query5 = "UPDATE Room SET [Reservation End] = NULL WHERE [Room Number] = @RoomNumber";
            string query6 = "SELECT * FROM Guest WHERE Name = @GuestName";
            string query7 = "INSERT INTO RentingLog VALUES (@GuestName, @RBegin, @REnd, @RoomNumber, @Profit)";
            string query8 = "SELECT * FROM Room WHERE [Room Number] = @RoomNumber";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            using (SqlCommand command3 = new SqlCommand(query3, connection))
            using (SqlCommand command4 = new SqlCommand(query4, connection))
            using (SqlCommand command5 = new SqlCommand(query5, connection))
            using (SqlCommand command6 = new SqlCommand(query6, connection))
            using (SqlCommand command7 = new SqlCommand(query7, connection))
            using (SqlCommand command8 = new SqlCommand(query8, connection))
            {
                connection.Open();
                string name, roomNum, dBegin, dEnd, profit;
                roomNum = dBegin = dEnd = profit = String.Empty;

                name = listBoxGuest.GetItemText(listBoxGuest.SelectedItem);
                profit = textBoxFinalBill.Text;

                command6.Parameters.AddWithValue("@GuestName", name);

                using (SqlDataReader reader = command6.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        roomNum = reader["Rented Room"].ToString();
                    }
                }

                command8.Parameters.AddWithValue("@RoomNumber", roomNum);

                using (SqlDataReader reader = command8.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        dBegin = reader["Reservation Begin"].ToString();
                        dEnd = reader["Reservation End"].ToString();
                    }
                }

                command1.Parameters.AddWithValue("@GuestName", name);
                command2.Parameters.AddWithValue("@RoomNumber", roomNum);
                command3.Parameters.AddWithValue("@RoomNumber", roomNum);
                command4.Parameters.AddWithValue("@RoomNumber", roomNum);
                command5.Parameters.AddWithValue("@RoomNumber", roomNum);
                command7.Parameters.AddWithValue("@GuestName", name);
                command7.Parameters.AddWithValue("@RoomNumber", roomNum);
                command7.Parameters.AddWithValue("@RBegin", dBegin);
                command7.Parameters.AddWithValue("@REnd", dEnd);
                command7.Parameters.AddWithValue("@Profit", profit);
                command1.ExecuteNonQuery();
                command2.ExecuteNonQuery();
                command3.ExecuteNonQuery();
                command4.ExecuteNonQuery();
                command5.ExecuteNonQuery();
                command7.ExecuteNonQuery();

                listViewRoom.Items.Clear();

                populateRooms();
            }

            populateGuests();
        }

        //Button to rent room
        private void buttonRentRoom_Click(object sender, EventArgs e)
        {
            //Connect Room and Guest via updating Rented by and Rented Room columns
            double roomBill = 0;
            string query1 = "UPDATE Room SET Rented = 1 WHERE [Room Number] = @RoomNumber";
            string query2 = "UPDATE Room SET [Rented By] = @GuestName WHERE [Room Number] = @RoomNumber";
            string query3 = "UPDATE Guest SET [Rented Room] = @RoomNumber WHERE Name = @GuestName";
            string query4 = "UPDATE Guest SET [Room Bill] = @Cost Where Name = @GuestName";
            string query5 = "SELECT * FROM Room WHERE [Room Number] = @RoomNumber";
            string query6 = "UPDATE Room SET [Reservation Begin] = @Date WHERE [Room Number] = @RoomNum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            using (SqlCommand command3 = new SqlCommand(query3, connection))
            using (SqlCommand command4 = new SqlCommand(query4, connection))
            using (SqlCommand command5 = new SqlCommand(query5, connection))
            using (SqlCommand command6 = new SqlCommand(query6, connection))
            {
                connection.Open();

                //Added to prevent errors when nothing was selected
                if (listViewRoom.SelectedItems.Count > 0)
                {
                    command5.Parameters.AddWithValue("@RoomNumber", listViewRoom.SelectedItems[0].SubItems[0].Text);
                    using (SqlDataReader reader = command5.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roomBill = Convert.ToDouble(reader["Cost"].ToString());
                        }
                    }

                    string name, roomNum, bDate;
                    name = listBoxGuest.GetItemText(listBoxGuest.SelectedItem);
                    roomNum = listViewRoom.SelectedItems[0].SubItems[0].Text;
                    bDate = dateTimePickerReservation.Value.ToString();

                    command1.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command2.Parameters.AddWithValue("@GuestName", name);
                    command2.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command3.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command3.Parameters.AddWithValue("@GuestName", name);
                    command4.Parameters.AddWithValue("@GuestName", name);
                    command4.Parameters.AddWithValue("@Cost", roomBill);
                    command6.Parameters.AddWithValue("@Date", bDate);
                    command6.Parameters.AddWithValue("@RoomNum", roomNum);
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    command6.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Room!", "Warning", MessageBoxButtons.OK ,MessageBoxIcon.Exclamation);
                }

                listViewRoom.Items.Clear();

                populateRooms();
                calculateFinalBill();
            }
        }

        //Button Deletes Reservation
        private void buttonDeleteReservation_Click(object sender, EventArgs e)
        {
            string query1 = "UPDATE Room SET Rented = 0 WHERE [Room Number] = @RoomNumber";
            string query2 = "UPDATE Room SET [Rented By] = NULL WHERE [Room Number] = @RoomNumber";
            string query3 = "UPDATE Room SET [Reservation Begin] = NULL WHERE [Room Number] = @RoomNumber";
            string query4 = "UPDATE Room SET [Reservation End] = NULL WHERE [Room Number] = @RoomNumber";
            string query5 = "UPDATE Guest SET [Room Bill] = 0 WHERE Name = @GuestName";
            string query6 = "UPDATE Guest SET [Rented Room] = NULL WHERE Name = @GuestName";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            using (SqlCommand command3 = new SqlCommand(query3, connection))
            using (SqlCommand command4 = new SqlCommand(query4, connection))
            using (SqlCommand command5 = new SqlCommand(query5, connection))
            using (SqlCommand command6 = new SqlCommand(query6, connection))
            {
                connection.Open();
                if (listViewRoom.SelectedItems.Count > 0)
                {
                    string name, roomNum;
                    name = listBoxGuest.GetItemText(listBoxGuest.SelectedItem);
                    roomNum = listViewRoom.SelectedItems[0].SubItems[0].Text;

                    command1.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command2.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command3.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command4.Parameters.AddWithValue("@RoomNumber", roomNum);
                    command5.Parameters.AddWithValue("@GuestName", name);
                    command6.Parameters.AddWithValue("@GuestName", name);
                    command1.ExecuteNonQuery();
                    command2.ExecuteNonQuery();
                    command3.ExecuteNonQuery();
                    command4.ExecuteNonQuery();
                    command5.ExecuteNonQuery();
                    command6.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                listViewRoom.Items.Clear();

                populateRooms();
                calculateFinalBill();
            }
        }

        //Button edits beginning reservation
        private void buttonEditBRes_Click(object sender, EventArgs e)
        {
            string bDate = String.Empty;
            string roomNum = String.Empty;
            string query = "UPDATE Room SET [Reservation Begin] = @Date WHERE [Room Number] = @RoomNum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (listViewRoom.SelectedItems.Count > 0)
                {
                    roomNum = listViewRoom.SelectedItems[0].SubItems[0].Text;
                    bDate = dateTimePickerReservation.Value.ToString();
                    command.Parameters.AddWithValue("@Date", bDate);
                    command.Parameters.AddWithValue("@RoomNum", roomNum );
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                listViewRoom.Items.Clear();

                populateRooms();
            }
        }

        //Button edits end reservation
        private void buttonEditERes_Click(object sender, EventArgs e)
        {
            string bDate = String.Empty;
            string roomNum = String.Empty;
            string query = "UPDATE Room SET [Reservation End] = @Date WHERE [Room Number] = @RoomNum";
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (listViewRoom.SelectedItems.Count > 0)
                {
                    roomNum = listViewRoom.SelectedItems[0].SubItems[0].Text;
                    bDate = dateTimePickerReservation.Value.ToString();
                    command.Parameters.AddWithValue("@Date", bDate);
                    command.Parameters.AddWithValue("@RoomNum", roomNum);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Room!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                listViewRoom.Items.Clear();

                populateRooms();
                calculateFinalBill();
            }
        }

        //If room service button is clicked, open Room Service form
        private void buttonRoomService_Click(object sender, EventArgs e)
        {
            Form roomService = new Room_Service();
            roomService.Show();
        }
    }
}