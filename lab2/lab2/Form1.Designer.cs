namespace lab2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.parallelCheckBox = new System.Windows.Forms.CheckBox();
            this.consecutiveCheckBox = new System.Windows.Forms.CheckBox();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.parallelCheckBox);
            this.panel1.Controls.Add(this.consecutiveCheckBox);
            this.panel1.Controls.Add(this.bTextBox);
            this.panel1.Controls.Add(this.calculateButton);
            this.panel1.Controls.Add(this.aTextBox);
            this.panel1.Controls.Add(this.nTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Name = "panel1";
            // 
            // parallelCheckBox
            // 
            resources.ApplyResources(this.parallelCheckBox, "parallelCheckBox");
            this.parallelCheckBox.Name = "parallelCheckBox";
            this.parallelCheckBox.UseVisualStyleBackColor = true;
            // 
            // consecutiveCheckBox
            // 
            resources.ApplyResources(this.consecutiveCheckBox, "consecutiveCheckBox");
            this.consecutiveCheckBox.Name = "consecutiveCheckBox";
            this.consecutiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // bTextBox
            // 
            resources.ApplyResources(this.bTextBox, "bTextBox");
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aTextBox_KeyPress);
            // 
            // calculateButton
            // 
            resources.ApplyResources(this.calculateButton, "calculateButton");
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculate_Button);
            // 
            // aTextBox
            // 
            resources.ApplyResources(this.aTextBox, "aTextBox");
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aTextBox_KeyPress);
            // 
            // nTextBox
            // 
            resources.ApplyResources(this.nTextBox, "nTextBox");
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.aTextBox_KeyPress);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Name = "panel2";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox parallelCheckBox;
        private System.Windows.Forms.CheckBox consecutiveCheckBox;
    }
}

