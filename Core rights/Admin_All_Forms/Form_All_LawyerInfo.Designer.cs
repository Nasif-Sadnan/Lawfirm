namespace Core_rights.Admin_All_Forms
{
    partial class Form_All_LawyerInfo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_All_LawyerInfo));
            this.panel_lawyer_infoes = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Icn_BtN_Add_Lawyer = new FontAwesome.Sharp.IconButton();
            this.Icn_BtN_Delete_Account = new FontAwesome.Sharp.IconButton();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.CmboBox_LawyerType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel_lawyer_infoes
            // 
            this.panel_lawyer_infoes.AutoScroll = true;
            this.panel_lawyer_infoes.Location = new System.Drawing.Point(0, 40);
            this.panel_lawyer_infoes.Name = "panel_lawyer_infoes";
            this.panel_lawyer_infoes.Size = new System.Drawing.Size(557, 386);
            this.panel_lawyer_infoes.TabIndex = 124;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this.Icn_BtN_Add_Lawyer;
            // 
            // Icn_BtN_Add_Lawyer
            // 
            this.Icn_BtN_Add_Lawyer.BackColor = System.Drawing.Color.DarkGray;
            this.Icn_BtN_Add_Lawyer.FlatAppearance.BorderSize = 0;
            this.Icn_BtN_Add_Lawyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Icn_BtN_Add_Lawyer.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Icn_BtN_Add_Lawyer.IconColor = System.Drawing.Color.DimGray;
            this.Icn_BtN_Add_Lawyer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icn_BtN_Add_Lawyer.Location = new System.Drawing.Point(41, 446);
            this.Icn_BtN_Add_Lawyer.Name = "Icn_BtN_Add_Lawyer";
            this.Icn_BtN_Add_Lawyer.Size = new System.Drawing.Size(205, 50);
            this.Icn_BtN_Add_Lawyer.TabIndex = 123;
            this.Icn_BtN_Add_Lawyer.Text = "Add Lawyer";
            this.Icn_BtN_Add_Lawyer.UseVisualStyleBackColor = false;
            this.Icn_BtN_Add_Lawyer.Click += new System.EventHandler(this.Icn_BtN_Add_Lawyer_Click);
            // 
            // Icn_BtN_Delete_Account
            // 
            this.Icn_BtN_Delete_Account.BackColor = System.Drawing.Color.DarkGray;
            this.Icn_BtN_Delete_Account.FlatAppearance.BorderSize = 0;
            this.Icn_BtN_Delete_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Icn_BtN_Delete_Account.IconChar = FontAwesome.Sharp.IconChar.None;
            this.Icn_BtN_Delete_Account.IconColor = System.Drawing.Color.DimGray;
            this.Icn_BtN_Delete_Account.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icn_BtN_Delete_Account.Location = new System.Drawing.Point(286, 446);
            this.Icn_BtN_Delete_Account.Name = "Icn_BtN_Delete_Account";
            this.Icn_BtN_Delete_Account.Size = new System.Drawing.Size(205, 50);
            this.Icn_BtN_Delete_Account.TabIndex = 125;
            this.Icn_BtN_Delete_Account.Text = "Delete Lawyer";
            this.Icn_BtN_Delete_Account.UseVisualStyleBackColor = false;
            this.Icn_BtN_Delete_Account.Click += new System.EventHandler(this.Icn_BtN_Delete_Account_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.Icn_BtN_Delete_Account;
            // 
            // CmboBox_LawyerType
            // 
            this.CmboBox_LawyerType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmboBox_LawyerType.FormattingEnabled = true;
            this.CmboBox_LawyerType.Items.AddRange(new object[] {
            "Individual Lawyer",
            "Lawyer Under Firm",
            "All"});
            this.CmboBox_LawyerType.Location = new System.Drawing.Point(383, 10);
            this.CmboBox_LawyerType.Name = "CmboBox_LawyerType";
            this.CmboBox_LawyerType.Size = new System.Drawing.Size(145, 24);
            this.CmboBox_LawyerType.TabIndex = 0;
            this.CmboBox_LawyerType.Text = "Select Lawyer type";
            this.CmboBox_LawyerType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form_All_LawyerInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(557, 508);
            this.Controls.Add(this.CmboBox_LawyerType);
            this.Controls.Add(this.panel_lawyer_infoes);
            this.Controls.Add(this.Icn_BtN_Delete_Account);
            this.Controls.Add(this.Icn_BtN_Add_Lawyer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_All_LawyerInfo";
            this.Text = "Form_All_LawyerInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_lawyer_infoes;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private FontAwesome.Sharp.IconButton Icn_BtN_Add_Lawyer;
        private FontAwesome.Sharp.IconButton Icn_BtN_Delete_Account;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private System.Windows.Forms.ComboBox CmboBox_LawyerType;
    }
}