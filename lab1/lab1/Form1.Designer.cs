namespace lab1
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
            this.aRowsTextBox = new System.Windows.Forms.TextBox();
            this.aColumnsTextBox = new System.Windows.Forms.TextBox();
            this.bColumnsTextBox = new System.Windows.Forms.TextBox();
            this.bRowsTextBox = new System.Windows.Forms.TextBox();
            this.matrixAGrid = new System.Windows.Forms.DataGridView();
            this.matrixBGrid = new System.Windows.Forms.DataGridView();
            this.matrixCGrid = new System.Windows.Forms.DataGridView();
            this.runtimeResultGrid = new System.Windows.Forms.DataGridView();
            this.cRowsValueLabel = new System.Windows.Forms.Label();
            this.cColumnsValueLabel = new System.Windows.Forms.Label();
            this.bColumnsLabel = new System.Windows.Forms.Label();
            this.bRowsLabel = new System.Windows.Forms.Label();
            this.aColumnsLabel = new System.Windows.Forms.Label();
            this.aRowsLabel = new System.Windows.Forms.Label();
            this.FillMatrixesButton = new System.Windows.Forms.Button();
            this.MultiplyButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ParallelCheckBox = new System.Windows.Forms.CheckBox();
            this.ConcurrentCheckBox = new System.Windows.Forms.CheckBox();
            this.cColumnsLabel = new System.Windows.Forms.Label();
            this.cRowsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matrixAGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixBGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixCGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.runtimeResultGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aRowsTextBox
            // 
            this.aRowsTextBox.Location = new System.Drawing.Point(112, 67);
            this.aRowsTextBox.Name = "aRowsTextBox";
            this.aRowsTextBox.Size = new System.Drawing.Size(100, 20);
            this.aRowsTextBox.TabIndex = 0;
            // 
            // aColumnsTextBox
            // 
            this.aColumnsTextBox.Location = new System.Drawing.Point(112, 94);
            this.aColumnsTextBox.Name = "aColumnsTextBox";
            this.aColumnsTextBox.Size = new System.Drawing.Size(100, 20);
            this.aColumnsTextBox.TabIndex = 1;
            // 
            // bColumnsTextBox
            // 
            this.bColumnsTextBox.Location = new System.Drawing.Point(287, 94);
            this.bColumnsTextBox.Name = "bColumnsTextBox";
            this.bColumnsTextBox.Size = new System.Drawing.Size(100, 20);
            this.bColumnsTextBox.TabIndex = 3;
            // 
            // bRowsTextBox
            // 
            this.bRowsTextBox.Location = new System.Drawing.Point(287, 68);
            this.bRowsTextBox.Name = "bRowsTextBox";
            this.bRowsTextBox.Size = new System.Drawing.Size(100, 20);
            this.bRowsTextBox.TabIndex = 2;
            // 
            // matrixAGrid
            // 
            this.matrixAGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.matrixAGrid.Location = new System.Drawing.Point(12, 140);
            this.matrixAGrid.Name = "matrixAGrid";
            this.matrixAGrid.Size = new System.Drawing.Size(249, 487);
            this.matrixAGrid.TabIndex = 6;
            // 
            // matrixBGrid
            // 
            this.matrixBGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.matrixBGrid.Location = new System.Drawing.Point(267, 140);
            this.matrixBGrid.Name = "matrixBGrid";
            this.matrixBGrid.Size = new System.Drawing.Size(249, 487);
            this.matrixBGrid.TabIndex = 7;
            // 
            // matrixCGrid
            // 
            this.matrixCGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.matrixCGrid.Location = new System.Drawing.Point(522, 140);
            this.matrixCGrid.Name = "matrixCGrid";
            this.matrixCGrid.Size = new System.Drawing.Size(249, 487);
            this.matrixCGrid.TabIndex = 8;
            // 
            // runtimeResultGrid
            // 
            this.runtimeResultGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runtimeResultGrid.Location = new System.Drawing.Point(813, 138);
            this.runtimeResultGrid.Name = "runtimeResultGrid";
            this.runtimeResultGrid.Size = new System.Drawing.Size(259, 489);
            this.runtimeResultGrid.TabIndex = 9;
            // 
            // cRowsValueLabel
            // 
            this.cRowsValueLabel.AutoSize = true;
            this.cRowsValueLabel.Location = new System.Drawing.Point(558, 68);
            this.cRowsValueLabel.Name = "cRowsValueLabel";
            this.cRowsValueLabel.Size = new System.Drawing.Size(13, 13);
            this.cRowsValueLabel.TabIndex = 10;
            this.cRowsValueLabel.Text = "0";
            this.cRowsValueLabel.Click += new System.EventHandler(this.cRowsValueLabel_Click);
            // 
            // cColumnsValueLabel
            // 
            this.cColumnsValueLabel.AutoSize = true;
            this.cColumnsValueLabel.Location = new System.Drawing.Point(559, 94);
            this.cColumnsValueLabel.Name = "cColumnsValueLabel";
            this.cColumnsValueLabel.Size = new System.Drawing.Size(13, 13);
            this.cColumnsValueLabel.TabIndex = 11;
            this.cColumnsValueLabel.Text = "0";
            // 
            // bColumnsLabel
            // 
            this.bColumnsLabel.AutoSize = true;
            this.bColumnsLabel.Location = new System.Drawing.Point(220, 93);
            this.bColumnsLabel.Name = "bColumnsLabel";
            this.bColumnsLabel.Size = new System.Drawing.Size(61, 13);
            this.bColumnsLabel.TabIndex = 13;
            this.bColumnsLabel.Text = "Столбцы B";
            // 
            // bRowsLabel
            // 
            this.bRowsLabel.AutoSize = true;
            this.bRowsLabel.Location = new System.Drawing.Point(219, 67);
            this.bRowsLabel.Name = "bRowsLabel";
            this.bRowsLabel.Size = new System.Drawing.Size(53, 13);
            this.bRowsLabel.TabIndex = 12;
            this.bRowsLabel.Text = "Строки B";
            // 
            // aColumnsLabel
            // 
            this.aColumnsLabel.AutoSize = true;
            this.aColumnsLabel.Location = new System.Drawing.Point(14, 93);
            this.aColumnsLabel.Name = "aColumnsLabel";
            this.aColumnsLabel.Size = new System.Drawing.Size(61, 13);
            this.aColumnsLabel.TabIndex = 15;
            this.aColumnsLabel.Text = "Столбцы А";
            // 
            // aRowsLabel
            // 
            this.aRowsLabel.AutoSize = true;
            this.aRowsLabel.Location = new System.Drawing.Point(13, 67);
            this.aRowsLabel.Name = "aRowsLabel";
            this.aRowsLabel.Size = new System.Drawing.Size(53, 13);
            this.aRowsLabel.TabIndex = 14;
            this.aRowsLabel.Text = "Строки А";
            // 
            // FillMatrixesButton
            // 
            this.FillMatrixesButton.Location = new System.Drawing.Point(4, 6);
            this.FillMatrixesButton.Name = "FillMatrixesButton";
            this.FillMatrixesButton.Size = new System.Drawing.Size(102, 49);
            this.FillMatrixesButton.TabIndex = 16;
            this.FillMatrixesButton.Text = "Заполнить матрицы A и B";
            this.FillMatrixesButton.UseVisualStyleBackColor = true;
            this.FillMatrixesButton.Click += new System.EventHandler(this.FillMatrixesButton_Click);
            // 
            // MultiplyButton
            // 
            this.MultiplyButton.Location = new System.Drawing.Point(154, 6);
            this.MultiplyButton.Name = "MultiplyButton";
            this.MultiplyButton.Size = new System.Drawing.Size(131, 41);
            this.MultiplyButton.TabIndex = 17;
            this.MultiplyButton.Text = "Умножить матрицы";
            this.MultiplyButton.UseVisualStyleBackColor = true;
            this.MultiplyButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Location = new System.Drawing.Point(956, 7);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(100, 40);
            this.ClearButton.TabIndex = 19;
            this.ClearButton.Text = "Очистить";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ParallelCheckBox);
            this.panel1.Controls.Add(this.ConcurrentCheckBox);
            this.panel1.Controls.Add(this.FillMatrixesButton);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.MultiplyButton);
            this.panel1.Location = new System.Drawing.Point(13, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1059, 58);
            this.panel1.TabIndex = 20;
            // 
            // ParallelCheckBox
            // 
            this.ParallelCheckBox.AutoSize = true;
            this.ParallelCheckBox.Location = new System.Drawing.Point(355, 30);
            this.ParallelCheckBox.Name = "ParallelCheckBox";
            this.ParallelCheckBox.Size = new System.Drawing.Size(105, 17);
            this.ParallelCheckBox.TabIndex = 21;
            this.ParallelCheckBox.Text = "Многозадачное";
            this.ParallelCheckBox.UseVisualStyleBackColor = true;
            // 
            // ConcurrentCheckBox
            // 
            this.ConcurrentCheckBox.AutoSize = true;
            this.ConcurrentCheckBox.Location = new System.Drawing.Point(355, 7);
            this.ConcurrentCheckBox.Name = "ConcurrentCheckBox";
            this.ConcurrentCheckBox.Size = new System.Drawing.Size(99, 17);
            this.ConcurrentCheckBox.TabIndex = 20;
            this.ConcurrentCheckBox.Text = "Однозадачное";
            this.ConcurrentCheckBox.UseVisualStyleBackColor = true;
            // 
            // cColumnsLabel
            // 
            this.cColumnsLabel.AutoSize = true;
            this.cColumnsLabel.Location = new System.Drawing.Point(499, 93);
            this.cColumnsLabel.Name = "cColumnsLabel";
            this.cColumnsLabel.Size = new System.Drawing.Size(61, 13);
            this.cColumnsLabel.TabIndex = 22;
            this.cColumnsLabel.Text = "Столбцы C";
            // 
            // cRowsLabel
            // 
            this.cRowsLabel.AutoSize = true;
            this.cRowsLabel.Location = new System.Drawing.Point(499, 68);
            this.cRowsLabel.Name = "cRowsLabel";
            this.cRowsLabel.Size = new System.Drawing.Size(53, 13);
            this.cRowsLabel.TabIndex = 21;
            this.cRowsLabel.Text = "Строки C";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 633);
            this.Controls.Add(this.cColumnsLabel);
            this.Controls.Add(this.cRowsLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.aColumnsLabel);
            this.Controls.Add(this.aRowsLabel);
            this.Controls.Add(this.bColumnsLabel);
            this.Controls.Add(this.bRowsLabel);
            this.Controls.Add(this.cColumnsValueLabel);
            this.Controls.Add(this.cRowsValueLabel);
            this.Controls.Add(this.runtimeResultGrid);
            this.Controls.Add(this.matrixCGrid);
            this.Controls.Add(this.matrixBGrid);
            this.Controls.Add(this.matrixAGrid);
            this.Controls.Add(this.bColumnsTextBox);
            this.Controls.Add(this.bRowsTextBox);
            this.Controls.Add(this.aColumnsTextBox);
            this.Controls.Add(this.aRowsTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.matrixAGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixBGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixCGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.runtimeResultGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox aRowsTextBox;
        private System.Windows.Forms.TextBox aColumnsTextBox;
        private System.Windows.Forms.TextBox bColumnsTextBox;
        private System.Windows.Forms.TextBox bRowsTextBox;
        private System.Windows.Forms.DataGridView matrixAGrid;
        private System.Windows.Forms.DataGridView matrixBGrid;
        private System.Windows.Forms.DataGridView matrixCGrid;
        private System.Windows.Forms.DataGridView runtimeResultGrid;
        private System.Windows.Forms.Label cRowsValueLabel;
        private System.Windows.Forms.Label cColumnsValueLabel;
        private System.Windows.Forms.Label bColumnsLabel;
        private System.Windows.Forms.Label bRowsLabel;
        private System.Windows.Forms.Label aColumnsLabel;
        private System.Windows.Forms.Label aRowsLabel;
        private System.Windows.Forms.Button FillMatrixesButton;
        private System.Windows.Forms.Button MultiplyButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ParallelCheckBox;
        private System.Windows.Forms.CheckBox ConcurrentCheckBox;
        private System.Windows.Forms.Label cColumnsLabel;
        private System.Windows.Forms.Label cRowsLabel;
    }
}

