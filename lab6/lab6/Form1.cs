using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {

        GeneticAlg temp;

        public Form1()
        {
            InitializeComponent();
            temp = new GeneticAlg();

            List<int> ints = temp.getBest();

            resultDataGrid.ColumnCount = 2;

            for (int i = 0; i < ints.Count; i++)
            {
                DataGridViewRow temp = new DataGridViewRow();
                temp.CreateCells(this.resultDataGrid);

                temp.Cells[0].Value = i+1;
                temp.Cells[1].Value = ints[i];
                
                resultDataGrid.Rows.Add(temp);
            }
        }

        
    }
}
