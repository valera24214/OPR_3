using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba3OPR
{
    public partial class Form2 : Form
    {
        List<int> Fdowntime;
        List<int> Rdowntime;
        List<int> a;
        List<int> b;
        int[] firstInd;
        int[] sortInd;
        int Fdowntimes;
        int Rdowntimes;
        
        public Form2(List<int> Fdowntime, List<int> Rdowntime, List<int> a, List<int> b, int[] firstInd, int[] sortInd, int Fdowntimes, int Rdowntimes)
        {
            InitializeComponent();
            int n = a.Count;
            this.firstInd = new int[n];
            this.firstInd = firstInd;
            this.sortInd = new int[n];
            this.sortInd = sortInd;
            this.a = new List<int>(a);
            this.b = new List<int>(b);
            this.Fdowntime = new List<int>(Fdowntime);
            this.Rdowntime = new List<int>(Rdowntime);
            this.Fdowntimes = Fdowntimes;
            this.Rdowntimes = Rdowntimes;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            int n = a.Count;
            int bdF = b.Count + Fdowntimes;
            int TimeA = 0;
            int TimeB = 0;
            int TimeA2 = 0;
            int TimeB2 = 0;

            Pen pen = new Pen(Brushes.Black, 2);
            Pen pen2 = new Pen(Brushes.Black, 5);
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            /*п оьанобепбрпаюшгнпво влад лох*/
            int weight = 20;

            int xa1f = 100;
            int ya1f = 100;

            int xb1f = 100;
            int yb1f = 150;

            int xa2R = 100;
            int ya2R = 250;

            int xb2R = 100;
            int yb2R = 300;

            g.DrawString("Станок 1", new Font("Roboto", 14), Brushes.Black, xa1f - 100, ya1f);
            g.DrawString("Станок 2", new Font("Roboto", 14), Brushes.Black, xb1f - 100, yb1f);
            g.DrawString("Станок 1", new Font("Roboto", 14), Brushes.Black, xa2R - 100, ya2R);
            g.DrawString("Станок 2", new Font("Roboto", 14), Brushes.Black, xb2R - 100, yb2R);

            for (int i = 0; i < n; i++)
            {
                g.DrawString(firstInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xa1f + 2, ya1f - 25);
                for (int ganta1 = 1; ganta1 <= a[i]; ganta1++) 
                {
                    g.DrawEllipse(pen, xa1f, ya1f, weight, weight);
                    g.FillEllipse(Brushes.Green, xa1f, ya1f, weight, weight);
                    xa1f += 25; 
                }
                g.DrawLine(pen2, xa1f, ya1f - 8, xa1f, ya1f + 28);
                xa1f += 5;
               
                TimeA += a[firstInd[i] - 1];

                if ((TimeA - TimeB) > 0)
                {
                        for (int gantb1 = 1; gantb1 <= (TimeA - TimeB); gantb1++)
                        {
                            g.DrawEllipse(pen, xb1f, yb1f, weight, weight);
                            g.FillEllipse(Brushes.Red, xb1f, yb1f, weight, weight);
                            xb1f += 25;
                        }
                    TimeB += TimeA - TimeB;
                    g.DrawLine(pen2, xb1f, yb1f - 8, xb1f, yb1f + 28);
                    xb1f += 5;
                    TimeB += b[firstInd[i] - 1];

                    g.DrawString(firstInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xb1f + 2, yb1f - 25);
                    for (int gantb1 = 1; gantb1 <= b[firstInd[i] - 1]; gantb1++)
                    {
                        g.DrawEllipse(pen, xb1f, yb1f, weight, weight);
                        g.FillEllipse(Brushes.Green, xb1f, yb1f, weight, weight);
                        xb1f += 25;
                    }
                    g.DrawLine(pen2, xb1f, yb1f - 8, xb1f, yb1f + 28);
                    xb1f += 5;
                }
                else
                {
                    TimeB += b[firstInd[i] - 1];
                    g.DrawString(firstInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xb1f + 2, yb1f - 25);
                    for (int gantb1 = 1; gantb1 <= b[firstInd[i] - 1]; gantb1++)
                    {
                        g.DrawEllipse(pen, xb1f, yb1f, weight, weight);
                        g.FillEllipse(Brushes.Green, xb1f, yb1f, weight, weight);
                        xb1f += 25;
                    }
                    g.DrawLine(pen2, xb1f, yb1f - 8, xb1f, yb1f + 28);
                    xb1f += 5;
                }
            }

            for (int i = 0; i < n; i++)
            {
                g.DrawString(sortInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xa2R + 2, ya2R - 25);
                for (int ganta2 = 1; ganta2 <= a[sortInd[i] - 1]; ganta2++)
                {
                    g.DrawEllipse(pen, xa2R, ya2R, weight, weight);
                    g.FillEllipse(Brushes.Green, xa2R, ya2R, weight, weight);
                    xa2R += 25;
                }
                g.DrawLine(pen2, xa2R, ya2R - 8, xa2R, ya2R + 28);
                xa2R += 5;

                TimeA2 += a[sortInd[i] - 1];

                if ((TimeA2 - TimeB2) > 0)
                {
                    for (int gantb2 = 1; gantb2 <= (TimeA2 - TimeB2); gantb2++)
                    {
                        g.DrawEllipse(pen, xb2R, yb2R, weight, weight);
                        g.FillEllipse(Brushes.Red, xb2R, yb2R, weight, weight);
                        xb2R += 25;
                    }
                    TimeB2 += TimeA2 - TimeB2;
                    g.DrawLine(pen2, xb2R, yb2R - 8, xb2R, yb2R + 28);
                    xb2R += 5;
                    TimeB2 += b[sortInd[i] - 1];

                    g.DrawString(sortInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xb2R + 2, yb2R - 25);
                    for (int gantb2 = 1; gantb2 <= b[sortInd[i] - 1]; gantb2++)
                    {
                        g.DrawEllipse(pen, xb2R, yb2R, weight, weight);
                        g.FillEllipse(Brushes.Green, xb2R, yb2R, weight, weight);
                        xb2R += 25;
                    }
                    g.DrawLine(pen2, xb2R, yb2R - 8, xb2R, yb2R + 28);
                    xb2R += 5;
                }
                else
                {
                    TimeB2 += b[sortInd[i] - 1];
                    g.DrawString(sortInd[i].ToString(), new Font("Roboto", 14), Brushes.Black, xb2R + 2, yb2R - 25);
                    for (int gantb2 = 1; gantb2 <= b[sortInd[i] - 1]; gantb2++)
                    {
                        g.DrawEllipse(pen, xb2R, yb2R, weight, weight);
                        g.FillEllipse(Brushes.Green, xb2R, yb2R, weight, weight);
                        xb2R += 25;
                    }
                    g.DrawLine(pen2, xb2R, yb2R - 8, xb2R, yb2R + 28);
                    xb2R += 5;
                }
            }


        }
    }
}
