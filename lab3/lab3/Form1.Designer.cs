namespace lab3
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
            this.aDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bDataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.answerLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.generateRandomABButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.aDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // aDataGridView
            // 
            this.aDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.aDataGridView.Location = new System.Drawing.Point(3, 3);
            this.aDataGridView.Name = "aDataGridView";
            this.aDataGridView.Size = new System.Drawing.Size(236, 349);
            this.aDataGridView.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.aDataGridView);
            this.panel1.Location = new System.Drawing.Point(13, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 355);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bDataGridView);
            this.panel2.Location = new System.Drawing.Point(261, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 355);
            this.panel2.TabIndex = 2;
            // 
            // bDataGridView
            // 
            this.bDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bDataGridView.Location = new System.Drawing.Point(3, 3);
            this.bDataGridView.Name = "bDataGridView";
            this.bDataGridView.Size = new System.Drawing.Size(236, 349);
            this.bDataGridView.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.resultDataGridView);
            this.panel3.Location = new System.Drawing.Point(510, 83);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(242, 355);
            this.panel3.TabIndex = 3;
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(3, 3);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(236, 349);
            this.resultDataGridView.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.clearButton);
            this.panel4.Controls.Add(this.answerLabel);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.calculateButton);
            this.panel4.Controls.Add(this.generateRandomABButton);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.nTextBox);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(740, 65);
            this.panel4.TabIndex = 4;
            // 
            // answerLabel
            // 
            this.answerLabel.AutoSize = true;
            this.answerLabel.Location = new System.Drawing.Point(298, 25);
            this.answerLabel.Name = "answerLabel";
            this.answerLabel.Size = new System.Drawing.Size(25, 13);
            this.answerLabel.TabIndex = 5;
            this.answerLabel.Text = "___";
            this.answerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ответ:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(628, 15);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(109, 41);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Расчёт";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculationButton);
            // 
            // generateRandomABButton
            // 
            this.generateRandomABButton.Location = new System.Drawing.Point(501, 15);
            this.generateRandomABButton.Name = "generateRandomABButton";
            this.generateRandomABButton.Size = new System.Drawing.Size(124, 41);
            this.generateRandomABButton.TabIndex = 2;
            this.generateRandomABButton.Text = "Сгенерировать a и b";
            this.generateRandomABButton.UseVisualStyleBackColor = true;
            this.generateRandomABButton.Click += new System.EventHandler(this.generateRandomABButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "n";
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(66, 19);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(100, 20);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(394, 15);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 41);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(780, 489);
            this.MinimumSize = new System.Drawing.Size(780, 489);
            this.Name = "Form1";
            this.Text = "Астафьев В.П. МПВ 3";
            ((System.ComponentModel.ISupportInitialize)(this.aDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView aDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView bDataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Button generateRandomABButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clearButton;
    }
}

