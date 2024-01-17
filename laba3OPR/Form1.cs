using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace laba3OPR
{
    public partial class Form1 : Form
    {

        List<int> a = new List<int> { 3,5,5,4,1,4,1,3,5,1 };
        List<int> b = new List<int> { 2,5,2,5,3,5,3,3,1,1};

        Form2 form2;

        public Form1()
        {
            InitializeComponent();
        }

        public void DGV_fill()
        {
            dataGridView1.Rows.Clear();

            int n = a.Count;
            string[] r = { "A(i)", "B(i)" };

            dataGridView1.RowCount = 6;
            dataGridView1.ColumnCount = n;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = a[j];
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = b[j];
                    }
                    dataGridView1.Columns[j].HeaderText = (j + 1).ToString();
                }

                dataGridView1.Rows[i].HeaderCell.Value = r[i];
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            DGV_fill();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;
            
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
                
        }

        public void buttonSolve_Click(object sender, EventArgs e)
        {
            int n = a.Count;
            List<int> Index = new List<int>();
            int[] firstind = new int[n];

            for (int i = 0; i < n; i++)
            {
                Index.Add(i + 1);
                firstind[i] = i + 1;
            }

            Jonson jonson = new Jonson(a, b);

            textBox1.Text += "Первичная последовательность поступления деталей:" + Environment.NewLine;
            for (int i = 0; i < n; i++)
            {
                textBox1.Text += firstind[i].ToString() + " ";
            }
            textBox1.Text += Environment.NewLine;

            jonson.solveJonson(firstind, a, b, out List<int> FLdowntimes, out int Fdowntimes, out int Fresult);

            textBox1.Text += "Минимальное время первичной обработки деталей: " + Fresult + Environment.NewLine + "При времени простоя: " + Fdowntimes + Environment.NewLine + Environment.NewLine;

            jonson.sort(Index, out int[] sortind);

            textBox1.Text += "Отсортированная последовательность поступления деталей:" + Environment.NewLine;

            for (int i = 0; i < n; i++)
            {
                textBox1.Text += sortind[i].ToString() + " ";
            }

            textBox1.Text += Environment.NewLine;

            jonson.solveJonson(sortind, a, b, out List<int> RLdowntimes, out int downtimes, out int result);

            textBox1.Text += "Минимальное время обработки деталей: " + result + Environment.NewLine + "При времени простоя: " + downtimes;

            string[] r = { "", "", "", "", "A(i)", "B(i)" };
            for (int i = 0; i < n; i++)
            {
                dataGridView1.Rows[3].Cells[i].Value = sortind[i];
                dataGridView1.Rows[3].Cells[i].Style.BackColor = Color.Aqua;
            }

            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 4)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = a[sortind[j] - 1];
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = b[sortind[j] - 1];
                    }
                }

                dataGridView1.Rows[i].HeaderCell.Value = r[i];
            }

            form2 = new Form2(FLdowntimes, RLdowntimes, a, b, firstind, sortind, Fdowntimes, downtimes);
        }

        public void buttonGangImba_Click(object sender, EventArgs e)
        {
            form2.Show();
        }
    }
}
