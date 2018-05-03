using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int A = Convert.ToInt32(textBox1.Text);
            int B = Convert.ToInt32(textBox2.Text);
            int k1 = Convert.ToInt32(textBox3.Text);
            int k2 = Convert.ToInt32(textBox4.Text);
            int F0 = Convert.ToInt32(textBox5.Text);
            int Dt = Convert.ToInt32(textBox6.Text);

            int C = Convert.ToInt32(textBox7.Text);
            int k3 = Convert.ToInt32(textBox8.Text);
            int k4 = Convert.ToInt32(textBox9.Text);
            int Z0 = Convert.ToInt32(textBox10.Text);
            int Y0 = Convert.ToInt32(textBox11.Text);

            int a0 = Convert.ToInt32(textBox12.Text);
            int a1 = Convert.ToInt32(textBox13.Text);
            int a2 = Convert.ToInt32(textBox14.Text);
            int a3 = Convert.ToInt32(textBox15.Text);
            int a4 = Convert.ToInt32(textBox16.Text);
            int b0 = Convert.ToInt32(textBox17.Text);
            int b1 = Convert.ToInt32(textBox18.Text);
            int b2 = Convert.ToInt32(textBox21.Text);


            MessageBox.Show("Данные добавлены!");

            // ------РАССЧЕТ ТАБЛИЦЫ------

            // Обьявление массивов
            int[] arrayi = new int[21];
            double[] arrayT = new double[21];
            double[] arrayX = new double[21];
            double[] arrayYa = new double[21];

            //Столбец i
            for (int i = 0; i < arrayi.Length; i++)
            {
                arrayi[i] = i + 1;
            }
            //Столбец τ
            double j = 0;
            for (int i = 0; i < arrayT.Length; i++, j += Tao)
            {
                arrayT[i] = j;
                arrayT[i] = Math.Round(arrayT[i], 4);
            }
            //Столбец X
            for (int i = 0; i < arrayX.Length; i++)
            {
                arrayX[i] = A0 + (A1 * arrayT[i]) + (A2 * Math.Pow(arrayT[i], 2)) + (A3 * Math.Pow(arrayT[i], 3)) + (A4 * Math.Pow(arrayT[i], 4));
                arrayX[i] = Math.Round(arrayX[i], 4);
            }
            //Столбец Ya
            for (int i = 0; i < arrayYa.Length; i++)
            {
                arrayYa[i] = (Yo - C0) * Math.Exp(-arrayT[i] / A) + C0 + C1 * arrayT[i] + C2 * Math.Pow(arrayT[i], 2) + C3 * Math.Pow(arrayT[i], 3) + C4 * Math.Pow(arrayT[i], 4);
                arrayYa[i] = Math.Round(arrayYa[i], 4);
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }



        //        cartesianChart1.Series = new SeriesCollection
        //            {  
        //            new LineSeries
        //                {
        //                    Title = "Кривая X",
        //                    Values = new ChartValues<double> { arrayX[0], arrayX[1], arrayX[2], arrayX[3], arrayX[4], arrayX[5], arrayX[6], arrayX[7], arrayX[8], arrayX[9], arrayX[10], arrayX[11], arrayX[12], arrayX[13], arrayX[14], arrayX[15], arrayX[16], arrayX[17], arrayX[18], arrayX[19], arrayX[20]
        //    },
        //                    PointGeometry = null,
        //                    Fill = System.Windows.Media.Brushes.GhostWhite,
        //                    Stroke = System.Windows.Media.Brushes.DarkGray
        //},
        //                new LineSeries
        //                {
        //                    Title = "Кривая Ya",
        //                    Values = new ChartValues<double> { arrayYa[0], arrayYa[1], arrayYa[2], arrayYa[3], arrayYa[4], arrayYa[5], arrayYa[6], arrayYa[7], arrayYa[8], arrayYa[9], arrayYa[10], arrayYa[11], arrayYa[12], arrayYa[13], arrayYa[14], arrayYa[15], arrayYa[16], arrayYa[17], arrayYa[18], arrayYa[19], arrayYa[20]},
        //                    PointGeometry = DefaultGeometries.Circle,
        //                    PointGeometrySize = 10,
        //                    Fill = System.Windows.Media.Brushes.GhostWhite,
        //                    Stroke = System.Windows.Media.Brushes.Black
        //                },
        //                new LineSeries
        //                {
        //                    Title = "Кривая Y1",
        //                    Values = new ChartValues<double> {arrayY1[0], arrayY1[1], arrayY1[2], arrayY1[3], arrayY1[4], arrayY1[5], arrayY1[6], arrayY1[7], arrayY1[8], arrayY1[9], arrayY1[10], arrayY1[11], arrayY1[12], arrayY1[13], arrayY1[14], arrayY1[15], arrayY1[16], arrayY1[17], arrayY1[18], arrayY1[19], arrayY1[20]},
        //                    PointGeometry = DefaultGeometries.Square,
        //                    // Fill = System.Windows.Media.Brushes.None,
        //                    PointGeometrySize = 8,
        //                    Fill = System.Windows.Media.Brushes.Snow,
        //                    Stroke = System.Windows.Media.Brushes.DarkGray
        //                },
        //                new LineSeries
        //                {
        //                    Title = "Кривая Y2",
        //                    Values = new ChartValues<double> {arrayY2[0], arrayY2[1], arrayY2[2], arrayY2[3], arrayY2[4], arrayY2[5], arrayY2[6], arrayY2[7], arrayY2[8], arrayY2[9], arrayY2[10], arrayY2[11], arrayY2[12], arrayY2[13], arrayY2[14], arrayY2[15], arrayY2[16], arrayY2[17], arrayY2[18], arrayY2[19], arrayY2[20]},
        //                    PointGeometry = DefaultGeometries.Triangle,
        //                    PointGeometrySize = 10,
        //                    Fill = System.Windows.Media.Brushes.Snow,
        //                    Stroke = System.Windows.Media.Brushes.Black
        //                    // Fill = System.Windows.Media.Brushes.White

        //                }

        //        };

    }
}
