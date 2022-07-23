namespace FinanceManager
{
    partial class MainMenu
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
            this.btnAddFinance = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnSearchFinance = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnGeneratePrediction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddFinance
            // 
            this.btnAddFinance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddFinance.Location = new System.Drawing.Point(12, 12);
            this.btnAddFinance.Name = "btnAddFinance";
            this.btnAddFinance.Size = new System.Drawing.Size(260, 41);
            this.btnAddFinance.TabIndex = 0;
            this.btnAddFinance.Text = "Add Finance";
            this.btnAddFinance.UseVisualStyleBackColor = true;
            this.btnAddFinance.Click += new System.EventHandler(this.btnAddFinance_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEvent.Location = new System.Drawing.Point(12, 70);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(260, 41);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnAddContact
            // 
            this.btnAddContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddContact.Location = new System.Drawing.Point(12, 128);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(260, 41);
            this.btnAddContact.TabIndex = 2;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnSearchFinance
            // 
            this.btnSearchFinance.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchFinance.Location = new System.Drawing.Point(12, 186);
            this.btnSearchFinance.Name = "btnSearchFinance";
            this.btnSearchFinance.Size = new System.Drawing.Size(260, 41);
            this.btnSearchFinance.TabIndex = 3;
            this.btnSearchFinance.Text = "Search Finance";
            this.btnSearchFinance.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(12, 244);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(260, 41);
            this.btnGenerateReport.TabIndex = 4;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // btnGeneratePrediction
            // 
            this.btnGeneratePrediction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneratePrediction.Location = new System.Drawing.Point(12, 302);
            this.btnGeneratePrediction.Name = "btnGeneratePrediction";
            this.btnGeneratePrediction.Size = new System.Drawing.Size(260, 41);
            this.btnGeneratePrediction.TabIndex = 5;
            this.btnGeneratePrediction.Text = "Generate Prediction";
            this.btnGeneratePrediction.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 362);
            this.Controls.Add(this.btnGeneratePrediction);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnSearchFinance);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.btnAddFinance);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFinance;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnSearchFinance;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnGeneratePrediction;
    }
}