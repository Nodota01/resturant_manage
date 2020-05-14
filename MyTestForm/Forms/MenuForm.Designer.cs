namespace MyTestForm.Forms
{
    partial class MenuForm
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
            this.ConsumerButton = new System.Windows.Forms.Button();
            this.EmplyeeButton = new System.Windows.Forms.Button();
            this.DeskButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConsumerButton
            // 
            this.ConsumerButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ConsumerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsumerButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.ConsumerButton.Location = new System.Drawing.Point(99, 163);
            this.ConsumerButton.Name = "ConsumerButton";
            this.ConsumerButton.Size = new System.Drawing.Size(119, 105);
            this.ConsumerButton.TabIndex = 0;
            this.ConsumerButton.Text = "会员管理";
            this.ConsumerButton.UseVisualStyleBackColor = false;
            this.ConsumerButton.Click += new System.EventHandler(this.ConsumerButton_Click);
            // 
            // EmplyeeButton
            // 
            this.EmplyeeButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.EmplyeeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmplyeeButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmplyeeButton.Location = new System.Drawing.Point(432, 163);
            this.EmplyeeButton.Name = "EmplyeeButton";
            this.EmplyeeButton.Size = new System.Drawing.Size(121, 105);
            this.EmplyeeButton.TabIndex = 1;
            this.EmplyeeButton.Text = "雇员管理";
            this.EmplyeeButton.UseVisualStyleBackColor = false;
            // 
            // DeskButton
            // 
            this.DeskButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DeskButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeskButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.DeskButton.Location = new System.Drawing.Point(266, 163);
            this.DeskButton.Name = "DeskButton";
            this.DeskButton.Size = new System.Drawing.Size(118, 105);
            this.DeskButton.TabIndex = 2;
            this.DeskButton.Text = "餐桌管理";
            this.DeskButton.UseVisualStyleBackColor = false;
            this.DeskButton.Click += new System.EventHandler(this.DeskButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.ExitButton.Location = new System.Drawing.Point(601, 163);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(121, 105);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DeskButton);
            this.Controls.Add(this.EmplyeeButton);
            this.Controls.Add(this.ConsumerButton);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConsumerButton;
        private System.Windows.Forms.Button EmplyeeButton;
        private System.Windows.Forms.Button DeskButton;
        private System.Windows.Forms.Button ExitButton;
    }
}