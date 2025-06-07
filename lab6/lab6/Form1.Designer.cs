namespace lab6
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.resultDataGrid = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.accumulationSpeedTextBox = new System.Windows.Forms.TextBox();
            this.processingSpeedTextBox = new System.Windows.Forms.TextBox();
            this.numberOfServersTextBox = new System.Windows.Forms.TextBox();
            this.queueSizeTextBox = new System.Windows.Forms.TextBox();
            this.fitnessLabel = new System.Windows.Forms.Label();
            this.MAXqueueSizeTextBox = new System.Windows.Forms.TextBox();
            this.MAXnumberOfServersTextBox = new System.Windows.Forms.TextBox();
            this.MAXprocessingSpeedTextBox = new System.Windows.Forms.TextBox();
            this.MAXaccumulationSpeedTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.threadTextBox = new System.Windows.Forms.TextBox();
            this.MAXpopulationSizeTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.MAXgenerationsCountTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // resultDataGrid
            // 
            this.resultDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGrid.Location = new System.Drawing.Point(9, 279);
            this.resultDataGrid.Name = "resultDataGrid";
            this.resultDataGrid.Size = new System.Drawing.Size(408, 328);
            this.resultDataGrid.TabIndex = 0;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(437, 15);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(678, 595);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(248, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start GA";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // accumulationSpeedTextBox
            // 
            this.accumulationSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.accumulationSpeedTextBox.Location = new System.Drawing.Point(274, 13);
            this.accumulationSpeedTextBox.MaxLength = 4;
            this.accumulationSpeedTextBox.Name = "accumulationSpeedTextBox";
            this.accumulationSpeedTextBox.Size = new System.Drawing.Size(100, 24);
            this.accumulationSpeedTextBox.TabIndex = 4;
            // 
            // processingSpeedTextBox
            // 
            this.processingSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.processingSpeedTextBox.Location = new System.Drawing.Point(274, 43);
            this.processingSpeedTextBox.MaxLength = 4;
            this.processingSpeedTextBox.Name = "processingSpeedTextBox";
            this.processingSpeedTextBox.Size = new System.Drawing.Size(100, 24);
            this.processingSpeedTextBox.TabIndex = 5;
            // 
            // numberOfServersTextBox
            // 
            this.numberOfServersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberOfServersTextBox.Location = new System.Drawing.Point(274, 73);
            this.numberOfServersTextBox.MaxLength = 4;
            this.numberOfServersTextBox.Name = "numberOfServersTextBox";
            this.numberOfServersTextBox.Size = new System.Drawing.Size(100, 24);
            this.numberOfServersTextBox.TabIndex = 6;
            // 
            // queueSizeTextBox
            // 
            this.queueSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.queueSizeTextBox.Location = new System.Drawing.Point(274, 104);
            this.queueSizeTextBox.MaxLength = 4;
            this.queueSizeTextBox.Name = "queueSizeTextBox";
            this.queueSizeTextBox.Size = new System.Drawing.Size(100, 24);
            this.queueSizeTextBox.TabIndex = 7;
            // 
            // fitnessLabel
            // 
            this.fitnessLabel.AutoSize = true;
            this.fitnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fitnessLabel.Location = new System.Drawing.Point(15, 198);
            this.fitnessLabel.Name = "fitnessLabel";
            this.fitnessLabel.Size = new System.Drawing.Size(0, 18);
            this.fitnessLabel.TabIndex = 8;
            this.fitnessLabel.Click += new System.EventHandler(this.fitnessLabel_Click);
            // 
            // MAXqueueSizeTextBox
            // 
            this.MAXqueueSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXqueueSizeTextBox.Location = new System.Drawing.Point(317, 105);
            this.MAXqueueSizeTextBox.MaxLength = 4;
            this.MAXqueueSizeTextBox.Name = "MAXqueueSizeTextBox";
            this.MAXqueueSizeTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXqueueSizeTextBox.TabIndex = 9;
            // 
            // MAXnumberOfServersTextBox
            // 
            this.MAXnumberOfServersTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXnumberOfServersTextBox.Location = new System.Drawing.Point(317, 75);
            this.MAXnumberOfServersTextBox.MaxLength = 4;
            this.MAXnumberOfServersTextBox.Name = "MAXnumberOfServersTextBox";
            this.MAXnumberOfServersTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXnumberOfServersTextBox.TabIndex = 10;
            // 
            // MAXprocessingSpeedTextBox
            // 
            this.MAXprocessingSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXprocessingSpeedTextBox.Location = new System.Drawing.Point(317, 45);
            this.MAXprocessingSpeedTextBox.MaxLength = 4;
            this.MAXprocessingSpeedTextBox.Name = "MAXprocessingSpeedTextBox";
            this.MAXprocessingSpeedTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXprocessingSpeedTextBox.TabIndex = 11;
            // 
            // MAXaccumulationSpeedTextBox
            // 
            this.MAXaccumulationSpeedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXaccumulationSpeedTextBox.Location = new System.Drawing.Point(317, 18);
            this.MAXaccumulationSpeedTextBox.MaxLength = 4;
            this.MAXaccumulationSpeedTextBox.Name = "MAXaccumulationSpeedTextBox";
            this.MAXaccumulationSpeedTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXaccumulationSpeedTextBox.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(6, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 37);
            this.button2.TabIndex = 13;
            this.button2.Text = "Start PSS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Скорость получения заявки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "Скорость обработки заявки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "Размер серверов";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "Размер очереди";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 18);
            this.label5.TabIndex = 21;
            this.label5.Text = "Максимальный размер очереди";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Максимальный размер серверов";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(313, 18);
            this.label7.TabIndex = 19;
            this.label7.Text = "Максимальная скорость обработки заявки";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(311, 18);
            this.label8.TabIndex = 18;
            this.label8.Text = "Максимальная скорость получения заявки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 18);
            this.label9.TabIndex = 25;
            this.label9.Text = "Популяция";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 18);
            this.label10.TabIndex = 24;
            this.label10.Text = "Кол-во потоков";
            // 
            // threadTextBox
            // 
            this.threadTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threadTextBox.Location = new System.Drawing.Point(317, 135);
            this.threadTextBox.MaxLength = 2;
            this.threadTextBox.Name = "threadTextBox";
            this.threadTextBox.Size = new System.Drawing.Size(100, 24);
            this.threadTextBox.TabIndex = 23;
            // 
            // MAXpopulationSizeTextBox
            // 
            this.MAXpopulationSizeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXpopulationSizeTextBox.Location = new System.Drawing.Point(317, 165);
            this.MAXpopulationSizeTextBox.MaxLength = 3;
            this.MAXpopulationSizeTextBox.Name = "MAXpopulationSizeTextBox";
            this.MAXpopulationSizeTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXpopulationSizeTextBox.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(3, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 18);
            this.label11.TabIndex = 27;
            this.label11.Text = "Количество поколений";
            // 
            // MAXgenerationsCountTextBox
            // 
            this.MAXgenerationsCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MAXgenerationsCountTextBox.Location = new System.Drawing.Point(317, 195);
            this.MAXgenerationsCountTextBox.MaxLength = 3;
            this.MAXgenerationsCountTextBox.Name = "MAXgenerationsCountTextBox";
            this.MAXgenerationsCountTextBox.Size = new System.Drawing.Size(100, 24);
            this.MAXgenerationsCountTextBox.TabIndex = 26;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1129, 639);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.resultDataGrid);
            this.tabPage1.Controls.Add(this.MAXgenerationsCountTextBox);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.MAXqueueSizeTextBox);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.threadTextBox);
            this.tabPage1.Controls.Add(this.MAXnumberOfServersTextBox);
            this.tabPage1.Controls.Add(this.MAXpopulationSizeTextBox);
            this.tabPage1.Controls.Add(this.MAXprocessingSpeedTextBox);
            this.tabPage1.Controls.Add(this.MAXaccumulationSpeedTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1121, 613);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Генетический алгоритм";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart2);
            this.tabPage2.Controls.Add(this.accumulationSpeedTextBox);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.processingSpeedTextBox);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.numberOfServersTextBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.queueSizeTextBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.fitnessLabel);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1121, 613);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Система массового обслуживания";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart2
            // 
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(437, 12);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(678, 595);
            this.chart2.TabIndex = 19;
            this.chart2.Text = "chart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1153, 663);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.Text = "МПВ № 6 Астафьев";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView resultDataGrid;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox accumulationSpeedTextBox;
        private System.Windows.Forms.TextBox processingSpeedTextBox;
        private System.Windows.Forms.TextBox numberOfServersTextBox;
        private System.Windows.Forms.TextBox queueSizeTextBox;
        private System.Windows.Forms.Label fitnessLabel;
        private System.Windows.Forms.TextBox MAXqueueSizeTextBox;
        private System.Windows.Forms.TextBox MAXnumberOfServersTextBox;
        private System.Windows.Forms.TextBox MAXprocessingSpeedTextBox;
        private System.Windows.Forms.TextBox MAXaccumulationSpeedTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox threadTextBox;
        private System.Windows.Forms.TextBox MAXpopulationSizeTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox MAXgenerationsCountTextBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
    }
}

