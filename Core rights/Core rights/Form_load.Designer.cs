namespace Core_rights
{
    partial class Form_load
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_load));
            this.bunifuElipse_Main_Form = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PnL_Load_Bar_background = new System.Windows.Forms.Panel();
            this.PnL_Load_Bar = new System.Windows.Forms.Panel();
            this.bunifuElipse_Load_Bar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PnL_Load_Bar_background.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse_Main_Form
            // 
            this.bunifuElipse_Main_Form.ElipseRadius = 20;
            this.bunifuElipse_Main_Form.TargetControl = this;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.Location = new System.Drawing.Point(141, 328);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 16);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(655, 328);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 16);
            this.panel2.TabIndex = 4;
            // 
            // PnL_Load_Bar_background
            // 
            this.PnL_Load_Bar_background.BackColor = System.Drawing.Color.Transparent;
            this.PnL_Load_Bar_background.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnL_Load_Bar_background.Controls.Add(this.PnL_Load_Bar);
            this.PnL_Load_Bar_background.ForeColor = System.Drawing.SystemColors.Desktop;
            this.PnL_Load_Bar_background.Location = new System.Drawing.Point(152, 323);
            this.PnL_Load_Bar_background.Name = "PnL_Load_Bar_background";
            this.PnL_Load_Bar_background.Size = new System.Drawing.Size(497, 29);
            this.PnL_Load_Bar_background.TabIndex = 3;
            // 
            // PnL_Load_Bar
            // 
            this.PnL_Load_Bar.BackColor = System.Drawing.Color.DimGray;
            this.PnL_Load_Bar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PnL_Load_Bar.Location = new System.Drawing.Point(14, 7);
            this.PnL_Load_Bar.Name = "PnL_Load_Bar";
            this.PnL_Load_Bar.Size = new System.Drawing.Size(50, 13);
            this.PnL_Load_Bar.TabIndex = 1;
            // 
            // bunifuElipse_Load_Bar
            // 
            this.bunifuElipse_Load_Bar.ElipseRadius = 4;
            this.bunifuElipse_Load_Bar.TargetControl = this.PnL_Load_Bar;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 8;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Core_rights.Properties.Resources.logo6;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.PnL_Load_Bar_background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_load";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.PnL_Load_Bar_background.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Main_Form;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel PnL_Load_Bar_background;
        private System.Windows.Forms.Panel PnL_Load_Bar;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Load_Bar;
        private System.Windows.Forms.Timer timer1;
    }
}

