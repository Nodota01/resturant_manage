namespace MyTestForm.Forms
{
    partial class DeskList
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.desk_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desk_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_available = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertButton = new System.Windows.Forms.ToolStripButton();
            this.UpdateButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteButton = new System.Windows.Forms.ToolStripButton();
            this.ExitButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.OrderButton = new System.Windows.Forms.ToolStripButton();
            this.NewRecordButton = new System.Windows.Forms.ToolStripButton();
            this.LeaveDeskButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InsertButton,
            this.UpdateButton,
            this.DeleteButton,
            this.ExitButton,
            this.RefreshButton,
            this.OrderButton,
            this.NewRecordButton,
            this.LeaveDeskButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.desk_id,
            this.desk_name,
            this.is_available});
            this.dataGridView.Location = new System.Drawing.Point(12, 28);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(776, 410);
            this.dataGridView.TabIndex = 3;
            // 
            // desk_id
            // 
            this.desk_id.DataPropertyName = "desk_id";
            this.desk_id.HeaderText = "desk_id";
            this.desk_id.Name = "desk_id";
            this.desk_id.ReadOnly = true;
            this.desk_id.Visible = false;
            // 
            // desk_name
            // 
            this.desk_name.DataPropertyName = "desk_name";
            this.desk_name.HeaderText = "桌名";
            this.desk_name.Name = "desk_name";
            this.desk_name.ReadOnly = true;
            // 
            // is_available
            // 
            this.is_available.DataPropertyName = "is_available";
            this.is_available.HeaderText = "是否占用";
            this.is_available.Name = "is_available";
            this.is_available.ReadOnly = true;
            // 
            // InsertButton
            // 
            this.InsertButton.Image = global::MyTestForm.Properties.Resources.Insert;
            this.InsertButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InsertButton.Name = "InsertButton";
            this.InsertButton.Size = new System.Drawing.Size(52, 22);
            this.InsertButton.Text = "添加";
            this.InsertButton.Click += new System.EventHandler(this.InsertButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Image = global::MyTestForm.Properties.Resources.Update;
            this.UpdateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(52, 22);
            this.UpdateButton.Text = "更改";
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = global::MyTestForm.Properties.Resources.Delete;
            this.DeleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(52, 22);
            this.DeleteButton.Text = "删除";
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::MyTestForm.Properties.Resources.Exit;
            this.ExitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(52, 22);
            this.ExitButton.Text = "退出";
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Image = global::MyTestForm.Properties.Resources.Refresh;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(52, 22);
            this.RefreshButton.Text = "刷新";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Image = global::MyTestForm.Properties.Resources.Order;
            this.OrderButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(52, 22);
            this.OrderButton.Text = "点餐";
            // 
            // NewRecordButton
            // 
            this.NewRecordButton.Image = global::MyTestForm.Properties.Resources.Desk;
            this.NewRecordButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewRecordButton.Name = "NewRecordButton";
            this.NewRecordButton.Size = new System.Drawing.Size(52, 22);
            this.NewRecordButton.Text = "入座";
            this.NewRecordButton.Click += new System.EventHandler(this.NewRecordButton_Click);
            // 
            // LeaveDeskButton
            // 
            this.LeaveDeskButton.Image = global::MyTestForm.Properties.Resources.Delete;
            this.LeaveDeskButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LeaveDeskButton.Name = "LeaveDeskButton";
            this.LeaveDeskButton.Size = new System.Drawing.Size(52, 22);
            this.LeaveDeskButton.Text = "离座";
            this.LeaveDeskButton.Click += new System.EventHandler(this.LeaveDeskButton_Click);
            // 
            // DeskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DeskList";
            this.Text = "餐桌列表";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton InsertButton;
        private System.Windows.Forms.ToolStripButton UpdateButton;
        private System.Windows.Forms.ToolStripButton DeleteButton;
        private System.Windows.Forms.ToolStripButton ExitButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn desk_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn desk_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_available;
        private System.Windows.Forms.ToolStripButton OrderButton;
        private System.Windows.Forms.ToolStripButton NewRecordButton;
        private System.Windows.Forms.ToolStripButton LeaveDeskButton;
    }
}