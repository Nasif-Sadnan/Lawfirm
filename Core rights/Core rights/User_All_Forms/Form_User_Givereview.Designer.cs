namespace Core_rights.User_All_Forms
{
    partial class Form_User_Givereview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User_Givereview));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Txt_Box_Message = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LbL_Rateing = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.Icon_Pic_Plus = new FontAwesome.Sharp.IconPictureBox();
            this.Icon_Pic_Minus = new FontAwesome.Sharp.IconPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Pic_Plus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Pic_Minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 20;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(42, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "User";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(33, 400);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 115);
            this.label2.TabIndex = 1;
            this.label2.Text = "REVIEW";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.IndianRed;
            this.panel1.Location = new System.Drawing.Point(53, 518);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 2);
            this.panel1.TabIndex = 3;
            // 
            // Txt_Box_Message
            // 
            this.Txt_Box_Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Box_Message.Location = new System.Drawing.Point(731, 220);
            this.Txt_Box_Message.Multiline = true;
            this.Txt_Box_Message.Name = "Txt_Box_Message";
            this.Txt_Box_Message.Size = new System.Drawing.Size(294, 280);
            this.Txt_Box_Message.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(607, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Message :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(542, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "Rating (out of 5):";
            // 
            // LbL_Rateing
            // 
            this.LbL_Rateing.AutoSize = true;
            this.LbL_Rateing.Font = new System.Drawing.Font("ISOCPEUR", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbL_Rateing.Location = new System.Drawing.Point(772, 158);
            this.LbL_Rateing.Name = "LbL_Rateing";
            this.LbL_Rateing.Size = new System.Drawing.Size(22, 27);
            this.LbL_Rateing.TabIndex = 7;
            this.LbL_Rateing.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.IndianRed;
            this.panel2.Location = new System.Drawing.Point(767, 188);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 2);
            this.panel2.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(731, 518);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(294, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update review";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(12, 12);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(32, 32);
            this.iconPictureBox1.TabIndex = 11;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // Icon_Pic_Plus
            // 
            this.Icon_Pic_Plus.BackColor = System.Drawing.SystemColors.Control;
            this.Icon_Pic_Plus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon_Pic_Plus.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.Icon_Pic_Plus.IconColor = System.Drawing.SystemColors.ControlText;
            this.Icon_Pic_Plus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icon_Pic_Plus.Location = new System.Drawing.Point(819, 162);
            this.Icon_Pic_Plus.Name = "Icon_Pic_Plus";
            this.Icon_Pic_Plus.Size = new System.Drawing.Size(32, 32);
            this.Icon_Pic_Plus.TabIndex = 10;
            this.Icon_Pic_Plus.TabStop = false;
            this.Icon_Pic_Plus.Click += new System.EventHandler(this.Icon_Pic_Plus_Click);
            // 
            // Icon_Pic_Minus
            // 
            this.Icon_Pic_Minus.BackColor = System.Drawing.SystemColors.Control;
            this.Icon_Pic_Minus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon_Pic_Minus.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.Icon_Pic_Minus.IconColor = System.Drawing.SystemColors.ControlText;
            this.Icon_Pic_Minus.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.Icon_Pic_Minus.Location = new System.Drawing.Point(731, 162);
            this.Icon_Pic_Minus.Name = "Icon_Pic_Minus";
            this.Icon_Pic_Minus.Size = new System.Drawing.Size(32, 32);
            this.Icon_Pic_Minus.TabIndex = 9;
            this.Icon_Pic_Minus.TabStop = false;
            this.Icon_Pic_Minus.Click += new System.EventHandler(this.Icon_Pic_Minus_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Core_rights.Properties.Resources.Feedback;
            this.pictureBox1.Location = new System.Drawing.Point(120, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(481, 366);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form_User_Givereview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 592);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.Icon_Pic_Plus);
            this.Controls.Add(this.Icon_Pic_Minus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.LbL_Rateing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Txt_Box_Message);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_User_Givereview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_User_Givereview";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Pic_Plus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Pic_Minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Txt_Box_Message;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LbL_Rateing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconPictureBox Icon_Pic_Plus;
        private FontAwesome.Sharp.IconPictureBox Icon_Pic_Minus;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}