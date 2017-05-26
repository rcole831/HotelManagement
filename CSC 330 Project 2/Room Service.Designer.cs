namespace CSC_330_Project_2
{
    partial class Room_Service
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
            this.listBoxGuest = new System.Windows.Forms.ListBox();
            this.labelRoomService = new System.Windows.Forms.Label();
            this.listViewFood = new System.Windows.Forms.ListView();
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonAddFood = new System.Windows.Forms.Button();
            this.textBoxFood = new System.Windows.Forms.TextBox();
            this.textBoxCost = new System.Windows.Forms.TextBox();
            this.buttonChangeCost = new System.Windows.Forms.Button();
            this.buttonEditFood = new System.Windows.Forms.Button();
            this.buttonDeleteFood = new System.Windows.Forms.Button();
            this.buttonOrderFood = new System.Windows.Forms.Button();
            this.listBoxOrderedFood = new System.Windows.Forms.ListBox();
            this.labelOrderedFood = new System.Windows.Forms.Label();
            this.buttonRemoveFood = new System.Windows.Forms.Button();
            this.buttonPlaceOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxGuest
            // 
            this.listBoxGuest.FormattingEnabled = true;
            this.listBoxGuest.Location = new System.Drawing.Point(12, 49);
            this.listBoxGuest.Name = "listBoxGuest";
            this.listBoxGuest.Size = new System.Drawing.Size(120, 95);
            this.listBoxGuest.TabIndex = 22;
            // 
            // labelRoomService
            // 
            this.labelRoomService.AutoSize = true;
            this.labelRoomService.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelRoomService.Location = new System.Drawing.Point(115, 9);
            this.labelRoomService.Name = "labelRoomService";
            this.labelRoomService.Size = new System.Drawing.Size(123, 19);
            this.labelRoomService.TabIndex = 23;
            this.labelRoomService.Text = "ROOM SERVICE";
            // 
            // listViewFood
            // 
            this.listViewFood.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Item,
            this.Cost});
            this.listViewFood.GridLines = true;
            this.listViewFood.Location = new System.Drawing.Point(138, 49);
            this.listViewFood.Name = "listViewFood";
            this.listViewFood.Size = new System.Drawing.Size(206, 135);
            this.listViewFood.TabIndex = 24;
            this.listViewFood.UseCompatibleStateImageBehavior = false;
            this.listViewFood.View = System.Windows.Forms.View.Details;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 96;
            // 
            // Cost
            // 
            this.Cost.Text = "Cost";
            this.Cost.Width = 105;
            // 
            // buttonAddFood
            // 
            this.buttonAddFood.Location = new System.Drawing.Point(151, 217);
            this.buttonAddFood.Name = "buttonAddFood";
            this.buttonAddFood.Size = new System.Drawing.Size(75, 23);
            this.buttonAddFood.TabIndex = 25;
            this.buttonAddFood.Text = "Add Food";
            this.buttonAddFood.UseVisualStyleBackColor = true;
            this.buttonAddFood.Click += new System.EventHandler(this.buttonAddFood_Click);
            // 
            // textBoxFood
            // 
            this.textBoxFood.Location = new System.Drawing.Point(138, 190);
            this.textBoxFood.Name = "textBoxFood";
            this.textBoxFood.Size = new System.Drawing.Size(100, 21);
            this.textBoxFood.TabIndex = 26;
            // 
            // textBoxCost
            // 
            this.textBoxCost.Location = new System.Drawing.Point(244, 190);
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(100, 21);
            this.textBoxCost.TabIndex = 28;
            // 
            // buttonChangeCost
            // 
            this.buttonChangeCost.Location = new System.Drawing.Point(244, 217);
            this.buttonChangeCost.Name = "buttonChangeCost";
            this.buttonChangeCost.Size = new System.Drawing.Size(100, 23);
            this.buttonChangeCost.TabIndex = 29;
            this.buttonChangeCost.Text = "Change Cost";
            this.buttonChangeCost.UseVisualStyleBackColor = true;
            this.buttonChangeCost.Click += new System.EventHandler(this.buttonChangeCost_Click);
            // 
            // buttonEditFood
            // 
            this.buttonEditFood.Location = new System.Drawing.Point(151, 246);
            this.buttonEditFood.Name = "buttonEditFood";
            this.buttonEditFood.Size = new System.Drawing.Size(75, 23);
            this.buttonEditFood.TabIndex = 30;
            this.buttonEditFood.Text = "Edit Food";
            this.buttonEditFood.UseVisualStyleBackColor = true;
            this.buttonEditFood.Click += new System.EventHandler(this.buttonEditFood_Click);
            // 
            // buttonDeleteFood
            // 
            this.buttonDeleteFood.Location = new System.Drawing.Point(244, 246);
            this.buttonDeleteFood.Name = "buttonDeleteFood";
            this.buttonDeleteFood.Size = new System.Drawing.Size(100, 23);
            this.buttonDeleteFood.TabIndex = 31;
            this.buttonDeleteFood.Text = "Delete Food";
            this.buttonDeleteFood.UseVisualStyleBackColor = true;
            this.buttonDeleteFood.Click += new System.EventHandler(this.buttonDeleteFood_Click);
            // 
            // buttonOrderFood
            // 
            this.buttonOrderFood.Location = new System.Drawing.Point(12, 150);
            this.buttonOrderFood.Name = "buttonOrderFood";
            this.buttonOrderFood.Size = new System.Drawing.Size(84, 23);
            this.buttonOrderFood.TabIndex = 32;
            this.buttonOrderFood.Text = "Order Food";
            this.buttonOrderFood.UseVisualStyleBackColor = true;
            this.buttonOrderFood.Click += new System.EventHandler(this.buttonOrderFood_Click);
            // 
            // listBoxOrderedFood
            // 
            this.listBoxOrderedFood.FormattingEnabled = true;
            this.listBoxOrderedFood.Location = new System.Drawing.Point(12, 234);
            this.listBoxOrderedFood.Name = "listBoxOrderedFood";
            this.listBoxOrderedFood.Size = new System.Drawing.Size(120, 95);
            this.listBoxOrderedFood.TabIndex = 33;
            // 
            // labelOrderedFood
            // 
            this.labelOrderedFood.AutoSize = true;
            this.labelOrderedFood.Location = new System.Drawing.Point(12, 218);
            this.labelOrderedFood.Name = "labelOrderedFood";
            this.labelOrderedFood.Size = new System.Drawing.Size(74, 13);
            this.labelOrderedFood.TabIndex = 34;
            this.labelOrderedFood.Text = "Ordered Food";
            // 
            // buttonRemoveFood
            // 
            this.buttonRemoveFood.Location = new System.Drawing.Point(12, 179);
            this.buttonRemoveFood.Name = "buttonRemoveFood";
            this.buttonRemoveFood.Size = new System.Drawing.Size(84, 23);
            this.buttonRemoveFood.TabIndex = 35;
            this.buttonRemoveFood.Text = "Remove Food";
            this.buttonRemoveFood.UseVisualStyleBackColor = true;
            this.buttonRemoveFood.Click += new System.EventHandler(this.buttonRemoveFood_Click);
            // 
            // buttonPlaceOrder
            // 
            this.buttonPlaceOrder.Location = new System.Drawing.Point(151, 306);
            this.buttonPlaceOrder.Name = "buttonPlaceOrder";
            this.buttonPlaceOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonPlaceOrder.TabIndex = 36;
            this.buttonPlaceOrder.Text = "Place Order";
            this.buttonPlaceOrder.UseVisualStyleBackColor = true;
            this.buttonPlaceOrder.Click += new System.EventHandler(this.buttonPlaceOrder_Click);
            // 
            // Room_Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 339);
            this.Controls.Add(this.buttonPlaceOrder);
            this.Controls.Add(this.buttonRemoveFood);
            this.Controls.Add(this.labelOrderedFood);
            this.Controls.Add(this.listBoxOrderedFood);
            this.Controls.Add(this.buttonOrderFood);
            this.Controls.Add(this.buttonDeleteFood);
            this.Controls.Add(this.buttonEditFood);
            this.Controls.Add(this.buttonChangeCost);
            this.Controls.Add(this.textBoxCost);
            this.Controls.Add(this.textBoxFood);
            this.Controls.Add(this.buttonAddFood);
            this.Controls.Add(this.listViewFood);
            this.Controls.Add(this.labelRoomService);
            this.Controls.Add(this.listBoxGuest);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Room_Service";
            this.Text = "Room_Service";
            this.Load += new System.EventHandler(this.Room_Service_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGuest;
        private System.Windows.Forms.Label labelRoomService;
        private System.Windows.Forms.ListView listViewFood;
        private System.Windows.Forms.ColumnHeader Item;
        private System.Windows.Forms.ColumnHeader Cost;
        private System.Windows.Forms.Button buttonAddFood;
        private System.Windows.Forms.TextBox textBoxFood;
        private System.Windows.Forms.TextBox textBoxCost;
        private System.Windows.Forms.Button buttonChangeCost;
        private System.Windows.Forms.Button buttonEditFood;
        private System.Windows.Forms.Button buttonDeleteFood;
        private System.Windows.Forms.Button buttonOrderFood;
        private System.Windows.Forms.ListBox listBoxOrderedFood;
        private System.Windows.Forms.Label labelOrderedFood;
        private System.Windows.Forms.Button buttonRemoveFood;
        private System.Windows.Forms.Button buttonPlaceOrder;
    }
}