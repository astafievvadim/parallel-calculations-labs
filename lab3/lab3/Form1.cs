using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace lab3
{
    public partial class Form1 : Form
    {

        bool[] a;
        bool[] b;
        bool[] results;

        private static Mutex mut = new Mutex();

        int n;
        bool result;

        public Form1()
        {
            InitializeComponent();
        }

        private void MyThreadProc(int number)
        {
            Console.WriteLine(Thread.CurrentThread.Name + " " + number);
            bool aa = a[number];
            bool bb = b[number];
            bool temp = aa && bb;
            results[number] = temp;

            mut.WaitOne();

            result = result || temp;

            mut.ReleaseMutex();
        }

        private void generateRandomABButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(nTextBox.Text, out (n))){

                Random rand = new Random();

                aDataGridView.Rows.Clear();
                bDataGridView.Rows.Clear();

                a = new bool[n];
                b = new bool[n];

                aDataGridView.ColumnCount = 2;
                bDataGridView.ColumnCount = 2;


                for (int i = 0; i < n; i++)
                {

                    a[i] = rand.NextDouble() >= 0.5;
                    b[i] = rand.NextDouble() >= 0.5;

                    DataGridViewRow rowA = new DataGridViewRow();
                    rowA.CreateCells(this.aDataGridView);

                    rowA.Cells[0].Value = "a" + i;
                    rowA.Cells[1].Value = a[i];

                    this.aDataGridView.Rows.Add(rowA);

                    DataGridViewRow rowB = new DataGridViewRow();
                    rowB.CreateCells(this.bDataGridView);

                    rowB.Cells[0].Value = "b" + i;
                    rowB.Cells[1].Value = b[i];

                    this.bDataGridView.Rows.Add(rowB);
                }
            }
            else
            {
                MessageBox.Show("Ошибка, введите n");
                return;
            }

            
        }

        private void calculationButton(object sender, EventArgs e)
        {
            if (a == null || b == null)
            {
                MessageBox.Show("Ошибка, a и b не заданы");
                return;
            }
            else
            {
                result = false;

                results = new bool[a.Length];

                for (int i = 0; i < a.Length; i++)
                {
                    int temp = i;
                    Thread myNewThread = new Thread(() => MyThreadProc(temp));
                    myNewThread.Name = String.Format("Thread {0}", temp);
                    myNewThread.Start();
                }



                resultDataGridView.Rows.Clear();

                resultDataGridView.ColumnCount = 2;

                for (int i = 0; i < a.Length; i++)
                {
                    DataGridViewRow rowAnswer = new DataGridViewRow();
                    rowAnswer.CreateCells(this.resultDataGridView);

                    rowAnswer.Cells[0].Value = "c" + i;
                    rowAnswer.Cells[1].Value = results[i];

                    this.resultDataGridView.Rows.Add(rowAnswer);
                }

                answerLabel.Text = result + "";
            }
        }

        private void nTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            a = null;
            b = null;
            results = null;

            resultDataGridView.Rows.Clear();
            answerLabel.Text = "";
            aDataGridView.Rows.Clear();
            bDataGridView.Rows.Clear();
        }
    }
}
