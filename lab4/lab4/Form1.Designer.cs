namespace lab4
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
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.mergeCheckBox = new System.Windows.Forms.CheckBox();
            this.mergeParallelProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.treeSizeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.arraySizeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bubbleConsProgressBar = new System.Windows.Forms.ProgressBar();
            this.heapConsProgressBar = new System.Windows.Forms.ProgressBar();
            this.mergeConsProgressBar = new System.Windows.Forms.ProgressBar();
            this.searchCheckBox = new System.Windows.Forms.CheckBox();
            this.bubbleParallelProgressBar = new System.Windows.Forms.ProgressBar();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bubbleCheckBox = new System.Windows.Forms.CheckBox();
            this.heapCheckBox = new System.Windows.Forms.CheckBox();
            this.heapParallelProgressBar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(125, 20);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(100, 20);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // mergeCheckBox
            // 
            this.mergeCheckBox.AutoSize = true;
            this.mergeCheckBox.Location = new System.Drawing.Point(12, 182);
            this.mergeCheckBox.Name = "mergeCheckBox";
            this.mergeCheckBox.Size = new System.Drawing.Size(139, 17);
            this.mergeCheckBox.TabIndex = 3;
            this.mergeCheckBox.Text = "Сортировка слиянием";
            this.mergeCheckBox.UseVisualStyleBackColor = true;
            // 
            // mergeParallelProgressBar
            // 
            this.mergeParallelProgressBar.Location = new System.Drawing.Point(228, 176);
            this.mergeParallelProgressBar.Name = "mergeParallelProgressBar";
            this.mergeParallelProgressBar.Size = new System.Drawing.Size(100, 23);
            this.mergeParallelProgressBar.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество потоков";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.treeSizeTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.arraySizeTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.bubbleConsProgressBar);
            this.panel1.Controls.Add(this.heapConsProgressBar);
            this.panel1.Controls.Add(this.mergeConsProgressBar);
            this.panel1.Controls.Add(this.searchCheckBox);
            this.panel1.Controls.Add(this.bubbleParallelProgressBar);
            this.panel1.Controls.Add(this.searchTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bubbleCheckBox);
            this.panel1.Controls.Add(this.heapCheckBox);
            this.panel1.Controls.Add(this.heapParallelProgressBar);
            this.panel1.Controls.Add(this.nTextBox);
            this.panel1.Controls.Add(this.mergeCheckBox);
            this.panel1.Controls.Add(this.mergeParallelProgressBar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(551, 306);
            this.panel1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(360, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 46);
            this.button2.TabIndex = 24;
            this.button2.Text = "Сгенерировать массив и дерево";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Однопоточно";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(228, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Параллельно";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 46);
            this.button1.TabIndex = 21;
            this.button1.Text = "Запуск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeSizeTextBox
            // 
            this.treeSizeTextBox.Location = new System.Drawing.Point(125, 98);
            this.treeSizeTextBox.Name = "treeSizeTextBox";
            this.treeSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.treeSizeTextBox.TabIndex = 19;
            this.treeSizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Размер дерева";
            // 
            // arraySizeTextBox
            // 
            this.arraySizeTextBox.Location = new System.Drawing.Point(125, 72);
            this.arraySizeTextBox.Name = "arraySizeTextBox";
            this.arraySizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.arraySizeTextBox.TabIndex = 17;
            this.arraySizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Размер массива";
            // 
            // bubbleConsProgressBar
            // 
            this.bubbleConsProgressBar.Location = new System.Drawing.Point(399, 234);
            this.bubbleConsProgressBar.Name = "bubbleConsProgressBar";
            this.bubbleConsProgressBar.Size = new System.Drawing.Size(100, 23);
            this.bubbleConsProgressBar.TabIndex = 15;
            // 
            // heapConsProgressBar
            // 
            this.heapConsProgressBar.Location = new System.Drawing.Point(399, 205);
            this.heapConsProgressBar.Name = "heapConsProgressBar";
            this.heapConsProgressBar.Size = new System.Drawing.Size(100, 23);
            this.heapConsProgressBar.TabIndex = 14;
            // 
            // mergeConsProgressBar
            // 
            this.mergeConsProgressBar.Location = new System.Drawing.Point(399, 176);
            this.mergeConsProgressBar.Name = "mergeConsProgressBar";
            this.mergeConsProgressBar.Size = new System.Drawing.Size(100, 23);
            this.mergeConsProgressBar.TabIndex = 13;
            // 
            // searchCheckBox
            // 
            this.searchCheckBox.AutoSize = true;
            this.searchCheckBox.Location = new System.Drawing.Point(12, 269);
            this.searchCheckBox.Name = "searchCheckBox";
            this.searchCheckBox.Size = new System.Drawing.Size(158, 17);
            this.searchCheckBox.TabIndex = 11;
            this.searchCheckBox.Text = "Интерполяционный поиск";
            this.searchCheckBox.UseVisualStyleBackColor = true;
            // 
            // bubbleParallelProgressBar
            // 
            this.bubbleParallelProgressBar.Location = new System.Drawing.Point(228, 234);
            this.bubbleParallelProgressBar.Name = "bubbleParallelProgressBar";
            this.bubbleParallelProgressBar.Size = new System.Drawing.Size(100, 23);
            this.bubbleParallelProgressBar.TabIndex = 10;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(125, 46);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 20);
            this.searchTextBox.TabIndex = 8;
            this.searchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Искомое число";
            // 
            // bubbleCheckBox
            // 
            this.bubbleCheckBox.AutoSize = true;
            this.bubbleCheckBox.Location = new System.Drawing.Point(12, 240);
            this.bubbleCheckBox.Name = "bubbleCheckBox";
            this.bubbleCheckBox.Size = new System.Drawing.Size(146, 17);
            this.bubbleCheckBox.TabIndex = 7;
            this.bubbleCheckBox.Text = "Сортировка пузырьком";
            this.bubbleCheckBox.UseVisualStyleBackColor = true;
            // 
            // heapCheckBox
            // 
            this.heapCheckBox.AutoSize = true;
            this.heapCheckBox.Location = new System.Drawing.Point(12, 211);
            this.heapCheckBox.Name = "heapCheckBox";
            this.heapCheckBox.Size = new System.Drawing.Size(170, 17);
            this.heapCheckBox.TabIndex = 6;
            this.heapCheckBox.Text = "Пирамидальная сортировка";
            this.heapCheckBox.UseVisualStyleBackColor = true;
            // 
            // heapParallelProgressBar
            // 
            this.heapParallelProgressBar.Location = new System.Drawing.Point(228, 205);
            this.heapParallelProgressBar.Name = "heapParallelProgressBar";
            this.heapParallelProgressBar.Size = new System.Drawing.Size(100, 23);
            this.heapParallelProgressBar.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(335, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(505, 269);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 32;
            this.label11.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(505, 234);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(505, 205);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(505, 176);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 29;
            this.label14.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(232, 22);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 33;
            this.label15.Text = "1...10";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(232, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "0...9999";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(232, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 35;
            this.label17.Text = "2...9999";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Cursor = System.Windows.Forms.Cursors.Default;
            this.label18.Location = new System.Drawing.Point(232, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 13);
            this.label18.TabIndex = 36;
            this.label18.Text = "2...9999";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(228, 269);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 13);
            this.label19.TabIndex = 37;
            this.label19.Text = "False";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(396, 269);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(32, 13);
            this.label20.TabIndex = 38;
            this.label20.Text = "False";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(559, 332);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(551, 306);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Сортировка и поиск";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(566, 306);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "История запусков";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(556, 293);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 354);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(599, 393);
            this.MinimumSize = new System.Drawing.Size(599, 393);
            this.Name = "Form1";
            this.Text = "МПВ Лаб 4 Астафьев";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.CheckBox mergeCheckBox;
        private System.Windows.Forms.ProgressBar mergeParallelProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox bubbleCheckBox;
        private System.Windows.Forms.CheckBox heapCheckBox;
        private System.Windows.Forms.ProgressBar heapParallelProgressBar;
        private System.Windows.Forms.ProgressBar bubbleConsProgressBar;
        private System.Windows.Forms.ProgressBar heapConsProgressBar;
        private System.Windows.Forms.ProgressBar mergeConsProgressBar;
        private System.Windows.Forms.CheckBox searchCheckBox;
        private System.Windows.Forms.ProgressBar bubbleParallelProgressBar;
        private System.Windows.Forms.TextBox treeSizeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox arraySizeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

