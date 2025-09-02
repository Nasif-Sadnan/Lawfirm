namespace Core_rights.Lawyer_Under_Firm_All_Forms
{
    partial class Form_LawyerUnderFirm_CaseInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_LawyerUnderFirm_CaseInfo));
            this.panel_lawyer_infoes = new System.Windows.Forms.Panel();
            this.Cmbo_Box_lawFirmType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // panel_lawyer_infoes
            // 
            this.panel_lawyer_infoes.AutoScroll = true;
            this.panel_lawyer_infoes.Location = new System.Drawing.Point(0, 79);
            this.panel_lawyer_infoes.Name = "panel_lawyer_infoes";
            this.panel_lawyer_infoes.Size = new System.Drawing.Size(557, 415);
            this.panel_lawyer_infoes.TabIndex = 26;
            // 
            // Cmbo_Box_lawFirmType
            // 
            this.Cmbo_Box_lawFirmType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.Cmbo_Box_lawFirmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cmbo_Box_lawFirmType.FormattingEnabled = true;
            this.Cmbo_Box_lawFirmType.Items.AddRange(new object[] {
            "running case",
            "closed case",
            "All"});
            this.Cmbo_Box_lawFirmType.Location = new System.Drawing.Point(331, 29);
            this.Cmbo_Box_lawFirmType.Name = "Cmbo_Box_lawFirmType";
            this.Cmbo_Box_lawFirmType.Size = new System.Drawing.Size(183, 24);
            this.Cmbo_Box_lawFirmType.TabIndex = 25;
            this.Cmbo_Box_lawFirmType.Text = "Select Case Type";
            this.Cmbo_Box_lawFirmType.SelectedIndexChanged += new System.EventHandler(this.Cmbo_Box_lawFirmType_SelectedIndexChanged);
            // 
            // Form_LawyerUnderFirm_CaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.ClientSize = new System.Drawing.Size(557, 508);
            this.Controls.Add(this.panel_lawyer_infoes);
            this.Controls.Add(this.Cmbo_Box_lawFirmType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_LawyerUnderFirm_CaseInfo";
            this.Text = "Form_LawyerUnderFirm_CaseInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_lawyer_infoes;
        private System.Windows.Forms.ComboBox Cmbo_Box_lawFirmType;
    }
}