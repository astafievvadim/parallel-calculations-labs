using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class Form1 : Form
    {
        BinarySearchTree tree;

        List<int> dynamicArray;
        SortManager sortManager = new SortManager();
        int minValue = 0;
        int maxValue = 10000;

        int N, treeSize, arraySize, searchFor;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Тип";
            dataGridView1.Columns[1].HeaderText = "Параллельно";
            dataGridView1.Columns[2].HeaderText = "Однопоточно";
        }

        private void pushToDataGridView()
        {
            if(mergeCheckBox.Checked && !String.IsNullOrEmpty(label7.Text) && (label7.Text != "0"))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = "Слиянием";
                row.Cells[1].Value = label7.Text;
                row.Cells[2].Value = label14.Text;

                dataGridView1.Rows.Add(row);
            }

            if (heapCheckBox.Checked && !String.IsNullOrEmpty(label8.Text) && (label8.Text != "0"))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = "Пирамидальная";
                row.Cells[1].Value = label8.Text;
                row.Cells[2].Value = label13.Text;

                dataGridView1.Rows.Add(row);
            }

            if (bubbleCheckBox.Checked && !String.IsNullOrEmpty(label9.Text) && (label9.Text != "0"))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = "Пузырьком";
                row.Cells[1].Value = label9.Text;
                row.Cells[2].Value = label12.Text;

                dataGridView1.Rows.Add(row);
            }

            if (searchCheckBox.Checked && !String.IsNullOrEmpty(label10.Text) && (label10.Text != "0"))
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = "Поиск";
                row.Cells[1].Value = label10.Text;
                row.Cells[2].Value = label11.Text;

                dataGridView1.Rows.Add(row);
            }

        }

        private List<int> generateArray(int size)
        {
            List<int> dynamicArray = new List<int>();
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                dynamicArray.Add(random.Next(minValue, maxValue));
            }

            return dynamicArray;
        }

        private BinarySearchTree generateTree(int size)
        {
            BinarySearchTree bst = new BinarySearchTree();

            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                int rnd = random.Next(minValue, maxValue);
                bst.Insert(rnd);
            }

            return bst;
        }

        private void nTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void bubbleSortCons()
        {
            List<int> copy = new List<int>(dynamicArray);
            bubbleConsProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                bubbleConsProgressBar.Value = Math.Min(value, 100);
            });

            await Task.Run(() => sortManager.BubbleSort(copy, progress));

            stopwatch.Stop();
            label12.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void bubbleSortPar()
        {
            List<int> copy = new List<int>(dynamicArray);
            bubbleParallelProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                bubbleParallelProgressBar.Value = Math.Min(value, 100);
            });

            await sortManager.BubbleSortParallel(copy, threads: N, progress: progress);

            stopwatch.Stop();
            label9.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void heapSortCon()
        {
            List<int> copy = new List<int>(dynamicArray);
            heapConsProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                heapConsProgressBar.Value = Math.Min(value, 100);
            });

            await Task.Run(() => sortManager.HeapSort(copy, progress));

            stopwatch.Stop();
            label13.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void heapSortPar()
        {
            List<int> copy = new List<int>(dynamicArray);
            heapParallelProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                heapParallelProgressBar.Value = Math.Min(value, 100);
            });

            await sortManager.HeapSortParallel(copy, threads: N, progress: progress);

            stopwatch.Stop();
            label8.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void mergeSortCons()
        {
            List<int> copy = new List<int>(dynamicArray);
            mergeConsProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                mergeConsProgressBar.Value = Math.Min(value, 100);
            });

            await Task.Run(() => sortManager.MergeSort(copy, progress));

            stopwatch.Stop();
            label14.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void mergeSortPar()
        {
            List<int> copy = new List<int>(dynamicArray);
            mergeParallelProgressBar.Value = 0;
            var stopwatch = Stopwatch.StartNew();

            var progress = new Progress<int>(value =>
            {
                value = Math.Max(0, Math.Min(100, value));
                mergeParallelProgressBar.Value = Math.Min(value, 100);
            });

            await sortManager.MergeSortParallel(copy, threads: N, progress: progress, maxDepth: (int)Math.Log(copy.Count,2));

            stopwatch.Stop();
            label7.Text = "" + stopwatch.ElapsedTicks;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (
                tree != null &&
                dynamicArray != null &&
                N >= minValue &&
                N <= (maxValue - 1)
                )
            {
                if (mergeCheckBox.Checked)
                {
                    mergeSortPar();
                    mergeSortCons();
                }
                if (heapCheckBox.Checked)
                {
                    heapSortPar();
                    heapSortCon();
                }
                if (bubbleCheckBox.Checked)
                {
                    bubbleSortPar();
                    bubbleSortCons();
                }
                if (searchCheckBox.Checked)
                    if(int.TryParse(searchTextBox.Text, out (searchFor)) &&
                        searchFor >= minValue &&
                        searchFor <= maxValue - 1
                        )
                    {
                        interpolationSearchCons();
                        interpolationSeatchPar();
                    }
                    else
                    {
                        MessageBox.Show("Искомое число не задано");
                    }

                await Task.Delay(100);
                pushToDataGridView();
            }
            else
            {
                MessageBox.Show("Дерево и массив не заданы");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (
                int.TryParse(nTextBox.Text, out (N)) &&
                int.TryParse(treeSizeTextBox.Text, out (treeSize)) &&
                int.TryParse(arraySizeTextBox.Text, out (arraySize)) &&
   

                treeSize >= minValue + 2 &&
                treeSize <= maxValue - 1 &&

                arraySize >= minValue + 2 &&
                arraySize <= maxValue - 1 &&

                N > minValue &&
                N <= 10
                )
            {
                tree = generateTree(treeSize);
                dynamicArray = generateArray(arraySize);

                label7.Text = "";
                label8.Text = "";
                label9.Text = "";
                label10.Text = "";
                label11.Text = "";
                label12.Text = "";
                label13.Text = "";
                label14.Text = "";
                label19.Text = "False";
                label20.Text = "False";

                bubbleConsProgressBar.Value = 0;
                bubbleParallelProgressBar.Value = 0;
                heapConsProgressBar.Value = 0;
                heapParallelProgressBar.Value = 0;
                mergeConsProgressBar.Value = 0;
                mergeParallelProgressBar.Value = 0;
            }
            else
            {
                MessageBox.Show("Ошибочные данные");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void interpolationSearchCons()
        {
            var stopwatch = Stopwatch.StartNew();

            bool found = tree.InterpolationSearch(searchFor);


            stopwatch.Stop();

            long ticks = stopwatch.ElapsedTicks;

            label11.Text = "" + ticks;
            label20.Text = "" + found;
        }

        private async void interpolationSeatchPar()
        {
            var stopwatch = Stopwatch.StartNew();

            bool found = await tree.InterpolationSearchParallel(searchFor, N);

            stopwatch.Stop();

            long ticks = stopwatch.ElapsedTicks;

            label10.Text = "" + ticks;
            label19.Text = "" + found;
        }

    }
}
