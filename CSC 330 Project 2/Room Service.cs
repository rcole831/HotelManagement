//Room_Service.cs
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
    public partial class Room_Service : Form
    {
        //Declare connectionString and connection for use throughout GUI code
        string connectionString;
        SqlConnection connection;
        public Room_Service()
        {
            InitializeComponent();
            //Initialize connectionString
            connectionString = ConfigurationManager.ConnectionStrings["CSC_330_Project_2.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void Room_Service_Load(object sender, EventArgs e)
        {
            //Functions called when form loads
            populateGuests();
            populateFoods();
        }

        //Function to fill listBoxGuest
        private void populateGuests()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Guest", connection))
            {
                DataTable guestTable = new DataTable();
                adapter.Fill(guestTable);

                listBoxGuest.DataSource = guestTable;
                listBoxGuest.DisplayMember = "Name";
            }
        }

        //Function to fill listBoxFood
        private void populateFoods()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM Food", connection))
            {
                listViewFood.View = View.Details;
                DataTable foodTable = new DataTable();
                adapter.Fill(foodTable);

                for (int i = 0; i < foodTable.Rows.Count; i++)
                {
                    DataRow dr = foodTable.Rows[i];
                    ListViewItem listitem = new ListViewItem(dr["Name"].ToString());
                    listitem.SubItems.Add(dr["Cost"].ToString());
                    listViewFood.Items.Add(listitem);
                }
            }
        }

        //Button adds food to Food table
        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Food VALUES (@Name, 0)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if ( textBoxFood.Text == String.Empty)
                {
                    MessageBox.Show("Please Write a Name!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    command.Parameters.AddWithValue("@Name", textBoxFood.Text);
                    command.ExecuteNonQuery();
                }

            }

            //Clear & repopulate food 
            listViewFood.Items.Clear();
            populateFoods();
        }

        //Button to change the cost of any food
        private void buttonChangeCost_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Food Set Cost = @Cost WHERE Name = @Name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (listViewFood.SelectedItems.Count > 0)
                {
                    command.Parameters.AddWithValue("@Name", listViewFood.SelectedItems[0].SubItems[0].Text);
                    command.Parameters.AddWithValue("@Cost", textBoxCost.Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Food!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            //Clear and refill listViewFood
            listViewFood.Items.Clear();
            populateFoods();
        }

        //Edits food name if any food
        private void buttonEditFood_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Food Set Name = @NewName WHERE Name = @Name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (listViewFood.SelectedItems.Count > 0)
                {
                    command.Parameters.AddWithValue("@Name", listViewFood.SelectedItems[0].SubItems[0].Text);
                    command.Parameters.AddWithValue("@NewName", textBoxFood.Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Food!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            //Clear and refill listViewFood
            listViewFood.Items.Clear();
            populateFoods();
        }

        //Button deletes food from the Food table
        private void buttonDeleteFood_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Food WHERE Name = @Name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                if (listViewFood.SelectedItems.Count > 0)
                {
                    command.Parameters.AddWithValue("@Name", listViewFood.SelectedItems[0].SubItems[0].Text);
                    command.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Please Choose a Food!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

            listViewFood.Items.Clear();
            populateFoods();
        }

        //Button orders food and adds it to the "cart" listBoxOrderedFood
        private void buttonOrderFood_Click(object sender, EventArgs e)
        {
            if (listViewFood.SelectedItems.Count > 0)
            {
                listBoxOrderedFood.Items.Add(listViewFood.SelectedItems[0].SubItems[0].Text);
                
            }
            else
            {
                MessageBox.Show("Please Choose a Food!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //Button finalizes order and adds to selected guest's food
        private void buttonPlaceOrder_Click(object sender, EventArgs e)
        {
            double total = 0, partialCost = 0;
            string query1 = "UPDATE Guest Set [Food Bill] += @Bill WHERE Name = @Name";
            string query2 = "SELECT * FROM Food WHERE Name = @Name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command1 = new SqlCommand(query1, connection))
            using (SqlCommand command2 = new SqlCommand(query2, connection))
            {
                connection.Open();
                if (listBoxGuest.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Choose a Guest!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    command1.Parameters.AddWithValue("@Name", listBoxGuest.GetItemText(listBoxGuest.SelectedItem));
                    command2.Parameters.AddWithValue("@Name", listBoxOrderedFood.Items[0].ToString());
                    for (int i = 0; i < listBoxOrderedFood.Items.Count; i++)
                    {
                        command2.Parameters["@Name"].Value = listBoxOrderedFood.Items[i].ToString();
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                partialCost = Convert.ToDouble(reader["Cost"].ToString());
                            }
                        }

                        total += partialCost;
                    }

                    command1.Parameters.AddWithValue("@Bill", total.ToString());
                    command1.ExecuteNonQuery();
                }
            }
        }

        //Button removes food from "cart" listBoxOrderedFood
        private void buttonRemoveFood_Click(object sender, EventArgs e)
        {
            if (listBoxOrderedFood.SelectedIndex == -1)
            {
                MessageBox.Show("Please Choose a ordered food!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                listBoxOrderedFood.Items.Remove(listBoxOrderedFood.SelectedItem);
            }
        }
    }
}