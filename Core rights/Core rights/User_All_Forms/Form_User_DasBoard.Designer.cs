namespace Core_rights.User_All_Forms
{
    partial class Form_User_DasBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User_DasBoard));
            this.panel_lawyer_infoes = new System.Windows.Forms.Panel();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Icn_BtN_Add_Lawyer = new FontAwesome.Sharp.IconButton();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Icn_BtN_Delete_Account = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // panel_lawyer_infoes
            // 
            this.panel_lawyer_infoes.AutoScroll = true;
            this.panel_lawyer_infoes.Location = new System.Drawing.Point(0, 0);
            this.panel_lawyer_infoes.Name = "panel_lawyer_infoes";
            this.panel_lawyer_infoes.Size = new System.Drawing.Size(557, 426);
            this.panel_lawyer_infoes.TabIndex = 123;
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
            this.Icn_BtN_Add_Lawyer.TabIndex = 122;
            this.Icn_BtN_Add_Lawyer.Text = "Update Informations";
            this.Icn_BtN_Add_Lawyer.UseVisualStyleBackColor = false;
            this.Icn_BtN_Add_Lawyer.Click += new System.EventHandler(this.Icn_BtN_Add_Lawyer_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.Icn_BtN_Delete_Account;
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
            this.Icn_BtN_Delete_Account.TabIndex = 124;
            this.Icn_BtN_Delete_Account.Text = "Delete account";
            this.Icn_BtN_Delete_Account.UseVisualStyleBackColor = false;
            this.Icn_BtN_Delete_Account.Click += new System.EventHandler(this.Icn_BtN_Delete_Account_Click);
            // 
            // Form_User_DasBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(557, 508);
            this.Controls.Add(this.panel_lawyer_infoes);
            this.Controls.Add(this.Icn_BtN_Add_Lawyer);
            this.Controls.Add(this.Icn_BtN_Delete_Account);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_User_DasBoard";
            this.Text = "Form_User_DasBoard";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel_lawyer_infoes;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private FontAwesome.Sharp.IconButton Icn_BtN_Add_Lawyer;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        private FontAwesome.Sharp.IconButton Icn_BtN_Delete_Account;
    }
}