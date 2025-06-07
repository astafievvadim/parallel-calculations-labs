using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab6
{
    public partial class Form1 : Form
    {
        GAparallel temp;
        PSSconsecutive pss;
        int test_counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private int GetValidatedValue(string input, string parameterName, int max, int min)
        {
            if (int.TryParse(input, out int value))
            {
                if (value <= min || value > max)
                {
                    MessageBox.Show($"{parameterName} должен быть больше {min} и меньше {max}", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 1;
                }
                return value;
            }
            else
            {
                MessageBox.Show($"Введите корректное значение параметра {parameterName}.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int? MAXaccumulationSpeed = GetValidatedValue(MAXaccumulationSpeedTextBox.Text, "Максимальная скорость получения заявки", 1000, 10);
            int? MAXprocessingSpeed = GetValidatedValue(MAXprocessingSpeedTextBox.Text, "Максимальная скорость обработки заявки", 1000, 10);
            int? MAXnumberOfServers = GetValidatedValue(MAXnumberOfServersTextBox.Text, "Максимальное количество серверов", 1000, 10);
            int? MAXqueueSize = GetValidatedValue(MAXqueueSizeTextBox.Text, "Максимальный размер очереди", 1000, 10);

            int? threadCount = GetValidatedValue(threadTextBox.Text, "К-во потоков", 10, 1);
            int? populationSize = GetValidatedValue(MAXpopulationSizeTextBox.Text, "Размер популяции", 200, 20);
            int? generationsCount = GetValidatedValue(MAXgenerationsCountTextBox.Text, "Число поколений", 300, 30);

            // If any value is invalid, stop here
            if (populationSize == null || generationsCount == null || MAXaccumulationSpeed == null ||
                MAXprocessingSpeed == null || MAXnumberOfServers == null || MAXqueueSize == null || threadCount == null)
            {
                return;
            }

            temp = new GAparallel(threadCount.Value, populationSize.Value, generationsCount.Value,
                                  MAXaccumulationSpeed.Value, MAXprocessingSpeed.Value,
                                  MAXnumberOfServers.Value, MAXqueueSize.Value);

            List<GenerationalResult> results = temp.getResults();

            resultDataGrid.ColumnCount = 7;
            resultDataGrid.Columns[0].HeaderText = "№";
            resultDataGrid.Columns[1].HeaderText = "Сред. фитнес";
            resultDataGrid.Columns[2].HeaderText = "Лучший фитнес";
            resultDataGrid.Columns[3].HeaderText = "Лучш. скорость поступл.";
            resultDataGrid.Columns[4].HeaderText = "Лучш. скорость обработ.";
            resultDataGrid.Columns[5].HeaderText = "Лучш. кол-во серверов";
            resultDataGrid.Columns[6].HeaderText = "Лучш. размер очереди";

            for (int i = 0; i < results.Count; i++)
            {
                DataGridViewRow tempRow = new DataGridViewRow();
                tempRow.CreateCells(this.resultDataGrid);

                tempRow.Cells[0].Value = test_counter + "-" + (i);
                tempRow.Cells[1].Value = results[i].getAvgFitness();

                int[] values = results[i].getBestSpecimen().extractValues();
                tempRow.Cells[2].Value = temp.getFitness(results[i].getBestSpecimen());

                tempRow.Cells[3].Value = values[0];
                tempRow.Cells[4].Value = values[1];
                tempRow.Cells[5].Value = values[2];
                tempRow.Cells[6].Value = values[3];

                resultDataGrid.Rows.Add(tempRow);
            }

            Series s = new Series("Запуск " + test_counter)
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 3
            };

            for (int i = 0; i < results.Count; i++)
            {
                s.Points.AddXY(i + 1, results[i].getAvgFitness());
            }

            chart1.Series.Add(s);
            test_counter++;
        }

        private void fitnessLabel_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? accumulationSpeed = GetValidatedValue(accumulationSpeedTextBox.Text, "Скорость получения заявки", 1000, 10);
            int? processingSpeed = GetValidatedValue(processingSpeedTextBox.Text, "Скорость обработки заявки", 1000, 10);
            int? numberOfServers = GetValidatedValue(numberOfServersTextBox.Text, "Количество серверов", 1000, 10);
            int? queueSize = GetValidatedValue(queueSizeTextBox.Text, "Размер очереди", 1000, 10);

            if (accumulationSpeed == null || processingSpeed == null || numberOfServers == null || queueSize == null)
            {
                return;
            }

            int hours = 5;
            pss = new PSSconsecutive(accumulationSpeed.Value, processingSpeed.Value, numberOfServers.Value, queueSize.Value);
            double fitness = pss.Simulate(hours);

            fitnessLabel.Text = pss.GetStats() + "\nФитнес: " + fitness;
            UpdateChart(pss);
        }


        private void UpdateChart(PSSconsecutive pss)
        {
            chart2.Series.Clear();

            var series = chart2.Series.Add("Среднее время ожидания");

            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;

            for (int i = 0; i < pss.WaitTimesPerHour.Count; i++)
            {
                series.Points.AddXY(i + 1, pss.WaitTimesPerHour[i]);
            }

            chart2.ChartAreas[0].AxisX.Title = "Час";
            chart2.ChartAreas[0].AxisY.Title = "Среднее время ожидания";
        }
    }
}
