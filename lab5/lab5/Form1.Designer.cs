namespace lab5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.partsDataGridView = new System.Windows.Forms.DataGridView();
            this.nLabel = new System.Windows.Forms.Label();
            this.textLabel = new System.Windows.Forms.Label();
            this.partsLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.startButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.ticksLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(326, 88);
            this.nTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(150, 26);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(18, 58);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(296, 513);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.Text = "";
            // 
            // partsDataGridView
            // 
            this.partsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partsDataGridView.Location = new System.Drawing.Point(488, 58);
            this.partsDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.partsDataGridView.Name = "partsDataGridView";
            this.partsDataGridView.Size = new System.Drawing.Size(346, 515);
            this.partsDataGridView.TabIndex = 3;
            // 
            // nLabel
            // 
            this.nLabel.AutoSize = true;
            this.nLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nLabel.Location = new System.Drawing.Point(326, 63);
            this.nLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nLabel.Name = "nLabel";
            this.nLabel.Size = new System.Drawing.Size(112, 20);
            this.nLabel.TabIndex = 5;
            this.nLabel.Text = "К-во потоков:";
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLabel.Location = new System.Drawing.Point(18, 23);
            this.textLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(56, 20);
            this.textLabel.TabIndex = 6;
            this.textLabel.Text = "Текст:";
            // 
            // partsLabel
            // 
            this.partsLabel.AutoSize = true;
            this.partsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.partsLabel.Location = new System.Drawing.Point(483, 23);
            this.partsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.partsLabel.Name = "partsLabel";
            this.partsLabel.Size = new System.Drawing.Size(60, 20);
            this.partsLabel.TabIndex = 7;
            this.partsLabel.Text = "Части:";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(852, 23);
            this.resultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(93, 20);
            this.resultLabel.TabIndex = 8;
            this.resultLabel.Text = "Результат:";
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Location = new System.Drawing.Point(856, 58);
            this.resultDataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.Size = new System.Drawing.Size(226, 515);
            this.resultDataGridView.TabIndex = 9;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(326, 128);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(152, 60);
            this.startButton.TabIndex = 10;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(326, 197);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(152, 60);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // ticksLabel
            // 
            this.ticksLabel.AutoSize = true;
            this.ticksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticksLabel.Location = new System.Drawing.Point(326, 273);
            this.ticksLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ticksLabel.Name = "ticksLabel";
            this.ticksLabel.Size = new System.Drawing.Size(0, 20);
            this.ticksLabel.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 582);
            this.Controls.Add(this.ticksLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.resultDataGridView);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.partsLabel);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.nLabel);
            this.Controls.Add(this.partsDataGridView);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.nTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "МПВ №5 Астафьев В.П.";
            ((System.ComponentModel.ISupportInitialize)(this.partsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.RichTextBox inputTextBox;
        private System.Windows.Forms.DataGridView partsDataGridView;
        private System.Windows.Forms.Label nLabel;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label partsLabel;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label ticksLabel;
    }
}

