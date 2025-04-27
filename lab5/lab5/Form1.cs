using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class Form1 : Form
    {
        private static Mutex mut = new Mutex();
        private int N;
        private string inputText;
        private readonly int maxThreadCount = 15;
        private Dictionary<char, int> frequencies;
        private long totalTicks;

        public Form1()
        {
            InitializeComponent();
            nTextBox.Text = "3";
            inputTextBox.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi vehicula aliquam consectetur. Pellentesque nibh arcu, commodo a dui ut, blandit imperdiet ipsum. Morbi tincidunt porta urna eget hendrerit. Morbi faucibus at mi dictum lobortis. Donec molestie scelerisque turpis, a rhoncus nisl bibendum sed. Nunc porta neque in laoreet finibus. Mauris vestibulum dictum est, ut suscipit tortor sollicitudin et. Integer venenatis, neque eget hendrerit rhoncus, augue sapien maximus magna, id fermentum nunc erat ut augue. Cras gravida porttitor hendrerit. Aenean ac ipsum arcu.\r\n\r\nDonec sit amet porta nisl. Maecenas gravida sollicitudin nisi, eu dignissim mauris viverra ut. Pellentesque eu erat gravida magna faucibus vehicula. Sed commodo varius lectus, nec feugiat libero ullamcorper nec. Ut ornare rutrum iaculis. Integer condimentum ante felis, ut dapibus odio imperdiet eu. Suspendisse quis ligula condimentum, efficitur augue vitae, pulvinar urna. Pellentesque libero enim, bibendum ut cursus id, consectetur eget odio. Fusce sed nisl vitae nisl vulputate euismod. Nullam ac nisl sed enim semper tempor scelerisque sit amet nisl. Quisque interdum id neque nec euismod. ";  // Тестовый текст

            frequencies = new Dictionary<char, int>();
            totalTicks = 0;

            initializeGrid(partsDataGridView);
            initializeGrid(resultDataGridView);
        }

        private void initializeGrid(DataGridView grid)
        {
            grid.ColumnCount = 2;
            grid.RowHeadersVisible = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            grid.ScrollBars = ScrollBars.Vertical;
            grid.AllowUserToResizeRows = true;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;  

            if (grid == partsDataGridView)
            {
                grid.Columns[0].HeaderText = "№";
                grid.Columns[1].HeaderText = "Частота символов";
                grid.Columns[0].Width = 50;  
            }
            else if (grid == resultDataGridView)
            {
                grid.Columns[0].HeaderText = "Символ";
                grid.Columns[1].HeaderText = "Частота";
            }
        }

        private List<string[]> particify()
        {
            var chars = inputText.ToCharArray();

            int total = chars.Length;
            int chunkSize = total / N;
            int extra = total % N;
            int index = 0;

            var result = new List<string[]>();

            for (int i = 0; i < N; i++)
            {
                int size = chunkSize;
                if (i < extra)
                {
                    size += 1;  
                }
                result.Add(new[] { new string(chars.Skip(index).Take(size).ToArray()) });
                index += size;
            }
            return result;
        }

        private void getFrequency(string[] chunk)
        {
            var sw = Stopwatch.StartNew();  

            var temp = new Dictionary<char, int>();
            foreach (var str in chunk)
                foreach (var c in str)
                    temp[c] = temp.ContainsKey(c) ? temp[c] + 1 : 1;

            sw.Stop();  

            securedSection(temp, sw.ElapsedTicks);
        }

        private void securedSection(Dictionary<char, int> freq, long elapsedTicks)
        {
            partsDataGridView.Invoke(new Action(() => addRowToGrid(partsDataGridView, freq)));

            mut.WaitOne();

            foreach (var pair in freq)
                frequencies[pair.Key] = frequencies.ContainsKey(pair.Key) ? frequencies[pair.Key] + pair.Value : pair.Value;

            totalTicks += elapsedTicks;

            mut.ReleaseMutex();

            updateTicksLabel();
        }

        private void addRowToGrid(DataGridView grid, Dictionary<char, int> freq)
        {
            var row = new DataGridViewRow();
            row.CreateCells(grid);
            row.Cells[0].Value = grid.Rows.Count;

            var freqString = string.Join(Environment.NewLine, freq.Select(kv => $"{kv.Key}: {kv.Value}"));
            row.Cells[1].Value = freqString;

            grid.Rows.Add(row);
        }

        private void launchThreads()
        {
            var parts = particify();

            var tasks = parts.Select(part => Task.Run(() => getFrequency(part))).ToArray();

            Task.WhenAll(tasks).ContinueWith(_ =>
            {
                resultDataGridView.Invoke(new Action(updateResultGrid));
                updateTicksLabel(); 
            });
        }

        private void updateResultGrid()
        {
            resultDataGridView.DataSource = null;
            resultDataGridView.Columns.Clear();

            var resultList = frequencies
                .Select(kv => new { Символ = kv.Key, Частота = kv.Value })
                .OrderByDescending(r => r.Частота)
                .ToList();

            resultDataGridView.AutoGenerateColumns = true;
            resultDataGridView.DataSource = resultList;
        }

        private void updateTicksLabel()
        {
            if (ticksLabel.InvokeRequired)
            {
                ticksLabel.Invoke(new Action(() => ticksLabel.Text = $"{totalTicks} тиков"));
            }
            else
            {
                ticksLabel.Text = $"{totalTicks} тиков";
            }
        }

        private void nTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(nTextBox.Text, out N) && N >= 1 && N <= maxThreadCount && !string.IsNullOrWhiteSpace(inputTextBox.Text))
            {
                inputText = inputTextBox.Text;
                frequencies.Clear();
                partsDataGridView.Rows.Clear();
                resultDataGridView.DataSource = null;
                totalTicks = 0;

                Task.Run(launchThreads);
            }
            else
            {
                MessageBox.Show("Неверное количество потоков или текст");
            }
        }

        // Очистка данных
        private void clearButton_Click(object sender, EventArgs e)
        {
            N = 0;
            nTextBox.Text = "";
            inputTextBox.Text = "";
            partsDataGridView.Rows.Clear();
            resultDataGridView.DataSource = null;
            resultDataGridView.Rows.Clear();
        }
    }
}
