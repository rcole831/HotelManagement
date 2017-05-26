namespace CSC_330_Project_2
{
    partial class HotelManagementSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDeleteReservation = new System.Windows.Forms.Button();
            this.buttonEditBRes = new System.Windows.Forms.Button();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.labelFinalBill = new System.Windows.Forms.Label();
            this.textBoxFinalBill = new System.Windows.Forms.TextBox();
            this.dateTimePickerReservation = new System.Windows.Forms.DateTimePicker();
            this.textBoxGuestName = new System.Windows.Forms.TextBox();
            this.buttonAddGuest = new System.Windows.Forms.Button();
            this.buttonRentRoom = new System.Windows.Forms.Button();
            this.listBoxGuest = new System.Windows.Forms.ListBox();
            this.buttonRoomService = new System.Windows.Forms.Button();
            this.listViewRoom = new System.Windows.Forms.ListView();
            this.roomNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rented = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.roomRented = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rBegin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonEditERes = new System.Windows.Forms.Button();
            this.labelFrontDesk = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDeleteReservation
            // 
            this.buttonDeleteReservation.Location = new System.Drawing.Point(575, 178);
            this.buttonDeleteReservation.Name = "buttonDeleteReservation";
            this.buttonDeleteReservation.Size = new System.Drawing.Size(107, 23);
            this.buttonDeleteReservation.TabIndex = 32;
            this.buttonDeleteReservation.Text = "Delete Reservation";
            this.buttonDeleteReservation.UseVisualStyleBackColor = true;
            this.buttonDeleteReservation.Click += new System.EventHandler(this.buttonDeleteReservation_Click);
            // 
            // buttonEditBRes
            // 
            this.buttonEditBRes.Location = new System.Drawing.Point(408, 178);
            this.buttonEditBRes.Name = "buttonEditBRes";
            this.buttonEditBRes.Size = new System.Drawing.Size(132, 23);
            this.buttonEditBRes.TabIndex = 31;
            this.buttonEditBRes.Text = "Edit Reservation Begin";
            this.buttonEditBRes.UseVisualStyleBackColor = true;
            this.buttonEditBRes.Click += new System.EventHandler(this.buttonEditBRes_Click);
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(117, 266);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(95, 23);
            this.buttonCheckOut.TabIndex = 29;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // labelFinalBill
            // 
            this.labelFinalBill.AutoSize = true;
            this.labelFinalBill.Location = new System.Drawing.Point(11, 250);
            this.labelFinalBill.Name = "labelFinalBill";
            this.labelFinalBill.Size = new System.Drawing.Size(44, 13);
            this.labelFinalBill.TabIndex = 28;
            this.labelFinalBill.Text = "Final Bill";
            // 
            // textBoxFinalBill
            // 
            this.textBoxFinalBill.Location = new System.Drawing.Point(11, 266);
            this.textBoxFinalBill.Name = "textBoxFinalBill";
            this.textBoxFinalBill.Size = new System.Drawing.Size(100, 21);
            this.textBoxFinalBill.TabIndex = 27;
            this.textBoxFinalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateTimePickerReservation
            // 
            this.dateTimePickerReservation.CustomFormat = "  MM/dd/yyyy HH:mm:ss";
            this.dateTimePickerReservation.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerReservation.Location = new System.Drawing.Point(135, 180);
            this.dateTimePickerReservation.Name = "dateTimePickerReservation";
            this.dateTimePickerReservation.Size = new System.Drawing.Size(146, 21);
            this.dateTimePickerReservation.TabIndex = 26;
            this.dateTimePickerReservation.Value = new System.DateTime(2016, 11, 25, 20, 15, 0, 0);
            // 
            // textBoxGuestName
            // 
            this.textBoxGuestName.Location = new System.Drawing.Point(11, 151);
            this.textBoxGuestName.Name = "textBoxGuestName";
            this.textBoxGuestName.Size = new System.Drawing.Size(120, 21);
            this.textBoxGuestName.TabIndex = 25;
            // 
            // buttonAddGuest
            // 
            this.buttonAddGuest.Location = new System.Drawing.Point(11, 178);
            this.buttonAddGuest.Name = "buttonAddGuest";
            this.buttonAddGuest.Size = new System.Drawing.Size(75, 23);
            this.buttonAddGuest.TabIndex = 24;
            this.buttonAddGuest.Text = "Add Guest";
            this.buttonAddGuest.UseVisualStyleBackColor = true;
            this.buttonAddGuest.Click += new System.EventHandler(this.buttonAddGuest_Click);
            // 
            // buttonRentRoom
            // 
            this.buttonRentRoom.Location = new System.Drawing.Point(302, 178);
            this.buttonRentRoom.Name = "buttonRentRoom";
            this.buttonRentRoom.Size = new System.Drawing.Size(75, 23);
            this.buttonRentRoom.TabIndex = 23;
            this.buttonRentRoom.Text = "Rent Room";
            this.buttonRentRoom.UseVisualStyleBackColor = true;
            this.buttonRentRoom.Click += new System.EventHandler(this.buttonRentRoom_Click);
            // 
            // listBoxGuest
            // 
            this.listBoxGuest.FormattingEnabled = true;
            this.listBoxGuest.Location = new System.Drawing.Point(11, 50);
            this.listBoxGuest.Name = "listBoxGuest";
            this.listBoxGuest.Size = new System.Drawing.Size(120, 95);
            this.listBoxGuest.TabIndex = 21;
            this.listBoxGuest.SelectedIndexChanged += new System.EventHandler(this.listBoxGuest_SelectedIndexChanged);
            // 
            // buttonRoomService
            // 
            this.buttonRoomService.Location = new System.Drawing.Point(575, 266);
            this.buttonRoomService.Name = "buttonRoomService";
            this.buttonRoomService.Size = new System.Drawing.Size(100, 25);
            this.buttonRoomService.TabIndex = 20;
            this.buttonRoomService.Text = "Room Service";
            this.buttonRoomService.UseVisualStyleBackColor = true;
            this.buttonRoomService.Click += new System.EventHandler(this.buttonRoomService_Click);
            // 
            // listViewRoom
            // 
            this.listViewRoom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.roomNumber,
            this.rented,
            this.cost,
            this.roomRented,
            this.rBegin,
            this.rEnd});
            this.listViewRoom.Location = new System.Drawing.Point(135, 50);
            this.listViewRoom.Name = "listViewRoom";
            this.listViewRoom.Size = new System.Drawing.Size(547, 122);
            this.listViewRoom.TabIndex = 34;
            this.listViewRoom.UseCompatibleStateImageBehavior = false;
            this.listViewRoom.View = System.Windows.Forms.View.Details;
            // 
            // roomNumber
            // 
            this.roomNumber.Text = "Room Number";
            this.roomNumber.Width = 80;
            // 
            // rented
            // 
            this.rented.Text = "Rented";
            this.rented.Width = 48;
            // 
            // cost
            // 
            this.cost.Text = "Cost";
            // 
            // roomRented
            // 
            this.roomRented.Text = "Rented By";
            this.roomRented.Width = 73;
            // 
            // rBegin
            // 
            this.rBegin.Text = "Reservation Begin";
            this.rBegin.Width = 140;
            // 
            // rEnd
            // 
            this.rEnd.Text = "Reservation End";
            this.rEnd.Width = 140;
            // 
            // buttonEditERes
            // 
            this.buttonEditERes.Location = new System.Drawing.Point(408, 207);
            this.buttonEditERes.Name = "buttonEditERes";
            this.buttonEditERes.Size = new System.Drawing.Size(132, 23);
            this.buttonEditERes.TabIndex = 35;
            this.buttonEditERes.Text = "Edit Reservation End";
            this.buttonEditERes.UseVisualStyleBackColor = true;
            this.buttonEditERes.Click += new System.EventHandler(this.buttonEditERes_Click);
            // 
            // labelFrontDesk
            // 
            this.labelFrontDesk.AutoSize = true;
            this.labelFrontDesk.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelFrontDesk.Location = new System.Drawing.Point(298, 9);
            this.labelFrontDesk.Name = "labelFrontDesk";
            this.labelFrontDesk.Size = new System.Drawing.Size(103, 19);
            this.labelFrontDesk.TabIndex = 33;
            this.labelFrontDesk.Text = "FRONT DESK";
            // 
            // HotelManagementSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 301);
            this.Controls.Add(this.labelFrontDesk);
            this.Controls.Add(this.buttonEditERes);
            this.Controls.Add(this.listViewRoom);
            this.Controls.Add(this.buttonDeleteReservation);
            this.Controls.Add(this.buttonEditBRes);
            this.Controls.Add(this.buttonCheckOut);
            this.Controls.Add(this.labelFinalBill);
            this.Controls.Add(this.textBoxFinalBill);
            this.Controls.Add(this.dateTimePickerReservation);
            this.Controls.Add(this.textBoxGuestName);
            this.Controls.Add(this.buttonAddGuest);
            this.Controls.Add(this.buttonRentRoom);
            this.Controls.Add(this.listBoxGuest);
            this.Controls.Add(this.buttonRoomService);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HotelManagementSystem";
            this.Text = "Hotel Management System";
            this.Load += new System.EventHandler(this.HotelManagementSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteReservation;
        private System.Windows.Forms.Button buttonEditBRes;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.Label labelFinalBill;
        private System.Windows.Forms.TextBox textBoxFinalBill;
        private System.Windows.Forms.DateTimePicker dateTimePickerReservation;
        private System.Windows.Forms.TextBox textBoxGuestName;
        private System.Windows.Forms.Button buttonAddGuest;
        private System.Windows.Forms.Button buttonRentRoom;
        private System.Windows.Forms.ListBox listBoxGuest;
        private System.Windows.Forms.Button buttonRoomService;
        private System.Windows.Forms.ListView listViewRoom;
        private System.Windows.Forms.ColumnHeader roomNumber;
        private System.Windows.Forms.ColumnHeader rented;
        private System.Windows.Forms.ColumnHeader cost;
        private System.Windows.Forms.ColumnHeader rBegin;
        private System.Windows.Forms.ColumnHeader rEnd;
        private System.Windows.Forms.ColumnHeader roomRented;
        private System.Windows.Forms.Button buttonEditERes;
        private System.Windows.Forms.Label labelFrontDesk;
    }
}

