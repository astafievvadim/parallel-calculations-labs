using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1
{
    public partial class Form1 : Form
    {

        int[,] matrixA;

        int[,] matrixB;

        int[,] resultMatrix;

        Stopwatch concurrentWatch = new Stopwatch();
        Stopwatch parallelWatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void FillMatrixesButton_Click(object sender, EventArgs e)
        {
            int aRowsResult, aColsResult, bColsResult;

            if (int.TryParse(aRowsTextBox.Text, out (aRowsResult)) &&
                int.TryParse(aColumnsTextBox.Text, out (aColsResult)) &&
                int.TryParse(bColumnsTextBox.Text, out (bColsResult))
                )
            {
                matrixA = generateMatrix(aRowsResult, aColsResult);
                matrixB = generateMatrix(aColsResult, bColsResult);

                fillDataGrids();
            }
            else
            {
                MessageBox.Show("Столбцы и строки должны быть заданы числами");
            }
        }

        private void fillDataGrids()
        {
            matrixAGrid.Rows.Clear();
            matrixBGrid.Rows.Clear();

            matrixAGrid.ColumnCount = matrixA.GetLength(1);

            for (int ax = 0; ax < matrixA.GetLength(0); ax++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.matrixAGrid);

                for (int ay = 0; ay < matrixA.GetLength(1); ay++)
                {
                    row.Cells[ay].Value = matrixA[ax, ay];
                }

                this.matrixAGrid.Rows.Add(row);
            }

            matrixBGrid.ColumnCount = matrixB.GetLength(1);

            for (int bx = 0; bx < matrixB.GetLength(0); bx++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.matrixBGrid);

                for (int by = 0; by < matrixB.GetLength(1); by++)
                {
                    row.Cells[by].Value = matrixB[bx, by];
                }

                this.matrixBGrid.Rows.Add(row);
            }
        }

        private int[,] generateMatrix(int rows, int columns)
        {
            int[,] result = new int[rows, columns];

            Random random = new Random();

            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    result[x, y] = random.Next(0, 10);
                }
            }

            return result;
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            runtimeResultGrid.Rows.Clear();
            matrixCGrid.Rows.Clear();


            if (matrixA == null || matrixB == null)
            {
                MessageBox.Show("Заполните матрицы");
                return;
            }
            else if (
                (matrixA.GetLength(1) != matrixB.GetLength(0)))
            {
                MessageBox.Show("Столбцы матрицы А должны соответсвовать строкам матрицы B");
                return;
            }


            if (ConcurrentCheckBox.Checked)
            {
                concurrentMultiplication();
            }

            if (ParallelCheckBox.Checked)
            {
                parallelMultiplication();
            }

            matrixCGrid.ColumnCount = resultMatrix.GetLength(1);

            for (int bx = 0; bx < resultMatrix.GetLength(0); bx++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.matrixCGrid);

                for (int by = 0; by < resultMatrix.GetLength(1); by++)
                {
                    row.Cells[by].Value = resultMatrix[bx, by];
                }

                this.matrixCGrid.Rows.Add(row);
            }

            cRowsValueLabel.Text = "" + resultMatrix.GetLength(0);
            cColumnsValueLabel.Text = "" + resultMatrix.GetLength(1);

            TimeSpan concurrent = concurrentWatch.Elapsed;
            TimeSpan parallel = parallelWatch.Elapsed;

            runtimeResultGrid.ColumnCount = 2;

            DataGridViewRow row1 = new DataGridViewRow();
            row1.CreateCells(this.runtimeResultGrid);
            row1.Cells[0].Value = "Однозадачно";
            row1.Cells[1].Value = concurrent.Ticks;
            this.runtimeResultGrid.Rows.Add(row1);

            DataGridViewRow row2 = new DataGridViewRow();
            row2.CreateCells(this.runtimeResultGrid);
            row2.Cells[0].Value = "Многозадачно";
            row2.Cells[1].Value = parallel.Ticks;
            this.runtimeResultGrid.Rows.Add(row2);
        }

        private void parallelMultiplication()
        {

            parallelWatch.Reset();
            parallelWatch.Start();

            int aHeight = matrixA.GetLength(0);
            int bHeight = matrixB.GetLength(0);
            int aWidth = matrixA.GetLength(1);
            int bWidth = matrixB.GetLength(1);

            resultMatrix = new int[aHeight, bWidth];

            Task[] tasks = new Task[aHeight];


            for (int i = 0; i < aHeight; i++)
            {
                int rowIndex = i;
                tasks[i] = Task.Run(() =>
                {
                    for (int j = 0; j < bWidth; j++)
                    {
                        for (int k = 0; k < aWidth; k++)
                        {
                            resultMatrix[rowIndex, j] += matrixA[rowIndex, k] * matrixB[k, j];
                        }
                    }
                });
            }

            Task.WaitAll(tasks);

            parallelWatch.Stop();
        }

        private void concurrentMultiplication()
        {
            concurrentWatch.Reset();
            concurrentWatch.Start();

            int aHeight = matrixA.GetLength(0);
            int bHeight = matrixB.GetLength(0);
            int aWidth = matrixA.GetLength(1);
            int bWidth = matrixB.GetLength(1);

            resultMatrix = new int[aHeight, bWidth];


            for (int ay = 0; ay < aHeight; ay++)
            {
                for (int by = 0; by < bHeight; by++)
                {
                    for (int bx = 0; bx < bWidth; bx++)
                    {
                        int a = matrixA[ay, by];
                        int b = matrixB[by, bx];
                        resultMatrix[ay, bx] += a * b;
                    }
                }
            }

            concurrentWatch.Stop();

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            matrixA = null;
            matrixB = null;
            resultMatrix = null;

            matrixAGrid.Rows.Clear();
            matrixBGrid.Rows.Clear();
            matrixCGrid.Rows.Clear();
        }
    }
}