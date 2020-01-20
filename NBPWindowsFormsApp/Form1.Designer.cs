namespace NBPWindowsFormsApp
{
    partial class Form1
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
            this.dateInput1 = new System.Windows.Forms.DateTimePicker();
            this.dateInput2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currencyCodeInput = new System.Windows.Forms.ComboBox();
            this.outputArea = new System.Windows.Forms.RichTextBox();
            this.downloadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateInput1
            // 
            this.dateInput1.Location = new System.Drawing.Point(141, 37);
            this.dateInput1.Name = "dateInput1";
            this.dateInput1.Size = new System.Drawing.Size(200, 20);
            this.dateInput1.TabIndex = 0;
            this.dateInput1.Value = new System.DateTime(2018, 9, 1, 0, 0, 0, 0);
            // 
            // dateInput2
            // 
            this.dateInput2.Location = new System.Drawing.Point(141, 63);
            this.dateInput2.Name = "dateInput2";
            this.dateInput2.Size = new System.Drawing.Size(200, 20);
            this.dateInput2.TabIndex = 1;
            this.dateInput2.Value = new System.DateTime(2018, 9, 20, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kod waluty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data początkowa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Data końcowa";
            // 
            // currencyCodeInput
            // 
            this.currencyCodeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.currencyCodeInput.FormattingEnabled = true;
            this.currencyCodeInput.Items.AddRange(new object[] {
            "USD",
            "EUR",
            "CHF",
            "GBP"});
            this.currencyCodeInput.Location = new System.Drawing.Point(141, 9);
            this.currencyCodeInput.Name = "currencyCodeInput";
            this.currencyCodeInput.Size = new System.Drawing.Size(200, 21);
            this.currencyCodeInput.TabIndex = 6;
            // 
            // outputArea
            // 
            this.outputArea.AccessibleName = "";
            this.outputArea.Location = new System.Drawing.Point(13, 133);
            this.outputArea.Name = "outputArea";
            this.outputArea.Size = new System.Drawing.Size(332, 245);
            this.outputArea.TabIndex = 7;
            this.outputArea.Text = "";
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(13, 87);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(328, 40);
            this.downloadButton.TabIndex = 8;
            this.downloadButton.Text = "Pobierz Informacje";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 390);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.outputArea);
            this.Controls.Add(this.currencyCodeInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateInput2);
            this.Controls.Add(this.dateInput1);
            this.Name = "Form1";
            this.Text = "NBPWindowsFormsApplication";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateInput1;
        private System.Windows.Forms.DateTimePicker dateInput2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox currencyCodeInput;
        private System.Windows.Forms.RichTextBox outputArea;
        private System.Windows.Forms.Button downloadButton;
    }
}

