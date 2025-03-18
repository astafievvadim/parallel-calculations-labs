using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace lab2
{
    public partial class Form1 : Form
    {

        //double e = Math.E;
        Stopwatch timer = new Stopwatch();
        double a;
        double b;
        int N;

        public Form1()
        {
            InitializeComponent();
        }

        private void parallelCalc()
        {
            ResultWithTime[] parallelResults = new ResultWithTime[3];

            parallelResults[0] = parallelRectangle();
            parallelResults[1] = parallelTrapezoid();
            parallelResults[2] = parallelMonteCarlo();

            for (int i = 0; i < parallelResults.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = parallelResults[i].getType();
                row.Cells[1].Value = parallelResults[i].getOpt();
                row.Cells[2].Value = parallelResults[i].getNonopt();
                row.Cells[3].Value = parallelResults[i].getResult();

                dataGridView1.Rows.Add(row);
            }

        }

        private void consecutiveCalc()
        {
            ResultWithTime[] consecutiveResults = new ResultWithTime[3];

            consecutiveResults[0] = consecutiveRectangle();
            consecutiveResults[1] = consecutiveTrapezoid();
            consecutiveResults[2] = consecutiveMonteCarlo();

            for (int i = 0; i < consecutiveResults.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView1);
                row.Cells[0].Value = consecutiveResults[i].getType();
                row.Cells[1].Value = consecutiveResults[i].getOpt();
                row.Cells[2].Value = consecutiveResults[i].getNonopt();
                row.Cells[3].Value = consecutiveResults[i].getResult();

                dataGridView1.Rows.Add(row);

            }
        }

        private ResultWithTime consecutiveMonteCarlo()
        {
            Int64 opt;
            Int64 nonOpt;

            Random rnd = new Random();
            double xDelta = (b - a) / (N-1);
            double result = 0;
            double xi;

            double[] functionResults = new double[N];

            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                xi = rnd.NextDouble() * (b - a) + a;
                functionResults[i] = (Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5)));

            }

            timer.Stop();

            opt = timer.ElapsedTicks;

            timer.Restart();

            for (int i = 0; i < functionResults.Length; i++)
            {
                result += functionResults[i];
            }

            result = result * xDelta;

            timer.Stop();

            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Consecutive Monte Carlo", opt, nonOpt, result);
        }

        private ResultWithTime parallelMonteCarlo()
        {
            Int64 opt;
            Int64 nonOpt;

            Random rnd = new Random();
            double xDelta = (b - a) / (N-1);
            double result = 0;
            double xi;

            double[] functionResults = new double[N];

            Task[] tasks = new Task[N];

            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                var locali = i;
                tasks[locali] = Task.Run(() =>
                {
                    xi = rnd.NextDouble() * (b - a) + a;
                    functionResults[locali] = (Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5)));
                });
            }

            Task.WaitAll(tasks);

            timer.Stop();

            opt = timer.ElapsedTicks;

            timer.Restart();

            for (int i = 0; i < functionResults.Length; i++)
            {
                result += functionResults[i];
            }

            result = result * xDelta;

            timer.Stop();

            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Parallel Monte Carlo", opt, nonOpt, result);
        }

        private ResultWithTime consecutiveTrapezoid()
        {
            Int64 opt;
            Int64 nonOpt;

            double[] functionResults = new double[N];

            double xDelta = (b - a) / (N-1);
            double result = 0;
            double xi;
            double[] results = new double[N];

            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                xi = a + xDelta * i;
                functionResults[i] = (Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5)));

            }

            timer.Stop();

            opt = timer.ElapsedTicks;

            timer.Restart();

            for (int i = 0; i < functionResults.Length -1; i++)
            {

                result += xDelta * (functionResults[i] + functionResults[i + 1]) / 2;

            }

            timer.Stop();

            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Consecutive trapezoid", opt, nonOpt, result);
        }

        private ResultWithTime parallelTrapezoid()
        {
            Int64 opt;
            Int64 nonOpt;

            double[] functionResults = new double[N];

            double xDelta = (b - a) / (N-1);
            double result = 0;
            double xi;
            double[] results = new double[N];

            Task[] tasks = new Task[N];

            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                var locali = i;
                tasks[locali] = Task.Run(() =>
                {
                    xi = a + xDelta * locali;
                    functionResults[locali] = (Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5)));
                });
            }

            Task.WaitAll(tasks);

            timer.Stop();

            opt = timer.ElapsedTicks;

            timer.Restart();

            for (int i = 0; i < functionResults.Length - 1; i++)
            {

                result += xDelta * (functionResults[i] + functionResults[i + 1]) / 2;

            }

            timer.Stop();

            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Parallel trapezoid", opt,nonOpt, result);
        }

        private ResultWithTime consecutiveRectangle()
        {
            Int64 opt;
            Int64 nonOpt;

            double xDelta = (b - a) / (N-1);
            double result = 0;
            double[] results = new double[N];
            double xi;

            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                xi = a + xDelta * i;
                results[i] = (Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5))) * xDelta;
            }

            timer.Stop();
            opt = timer.ElapsedTicks;

            timer.Restart();
            for (int i = 0; i <N; i++)
            {
                result += results[i];
            }
            timer.Stop();
            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Consecutive rectangle", opt, nonOpt, result);
        }

        private ResultWithTime parallelRectangle()
        {
            Int64 opt;
            Int64 nonOpt;

            double result = 0;
            double[] results = new double[N];

            double xi;
            double xDelta = (b - a) / (N-1);
            Task[] tasks = new Task[N];
            Console.WriteLine("(" + b + " - " + a + ") / " + (N-1) + " = " + xDelta);

            Console.WriteLine(xDelta + xDelta);
            timer.Restart();

            for (int i = 0; i < N; i++)
            {
                var locali = i;

                tasks[i] = Task.Run(() =>
                {
                    xi = a + xDelta * locali;
                    results[locali] = Math.Sin(xi ) * Math.Pow(Math.E, (-xi / 5)) * xDelta;
                    Console.WriteLine(locali + " " + xi + " " + results[locali]);
                });
            }

            Task.WaitAll(tasks);

            timer.Stop();
            opt = timer.ElapsedTicks;

            timer.Restart();

            for (int i = 0; i < results.Length; i++)
            {
                result += results[i];
            }

            timer.Stop();
            nonOpt = timer.ElapsedTicks;

            return new ResultWithTime("Parallel rectangle", opt, nonOpt, result);
        }

        private void calculate_Button(object sender, EventArgs e)
        {
            if (double.TryParse(aTextBox.Text, out a) &&
                double.TryParse(bTextBox.Text, out b) &&
                int.TryParse(nTextBox.Text, out N))
            {
                N++;
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 4;

                dataGridView1.Columns[0].HeaderText = "Тип";
                dataGridView1.Columns[1].HeaderText = "Оптимизируемое время";
                dataGridView1.Columns[2].HeaderText = "Неоптимизируемое время";
                dataGridView1.Columns[3].HeaderText = "Результат";

                if (parallelCheckBox.Checked)
                {
                    parallelCalc();
                }

                if (consecutiveCheckBox.Checked)
                {
                    consecutiveCalc();
                }
            }
            else
            {
                MessageBox.Show("N, a и b должны быть заданы числами");
            }
        }

        private void aTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }

    public class ResultWithTime
    {
        String type;
        Int64 optimizableTime;
        Int64 nonoptimizableTime;
        double res;

        public ResultWithTime(String type, Int64 optimizableTime, Int64 nonoptimizableTime, double result)
        {
            this.type = type;
            this.optimizableTime = optimizableTime;
            this.nonoptimizableTime = nonoptimizableTime;
            this.res = result;
        }

        internal String getType()
        {
            return type;
        }

        internal Int64 getNonopt()
        {
            return nonoptimizableTime;
        }

        internal Int64 getOpt()
        {
            return optimizableTime;
        }

        internal double getResult()
        {
            return res;
        }
    }
}
