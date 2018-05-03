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
            string A_ = textBox1.Text; double A = Convert.ToDouble(A_);
            string B_ = textBox2.Text; double B = Convert.ToDouble(B_);
            string k1_ = textBox3.Text; double k1 = Convert.ToDouble(k1_);
            string k2_ = textBox4.Text; double k2 = Convert.ToDouble(k2_);
            string F0_ = textBox5.Text; double F0 = Convert.ToDouble(F0_);
            string Dt_ = textBox6.Text; double Dt = Convert.ToDouble(Dt_);

            string C_ = textBox7.Text; double C = Convert.ToDouble(C_);
            string k3_ = textBox8.Text; double k3 = Convert.ToDouble(k3_);
            string k4_ = textBox9.Text; double k4 = Convert.ToDouble(k4_);
            string Z0_ = textBox10.Text; double Z0 = Convert.ToDouble(Z0_);
            string Y0_ = textBox11.Text; double Y0 = Convert.ToDouble(Y0_);

            string a0_ = textBox12.Text; double a0 = Convert.ToDouble(a0_);
            string a1_ = textBox13.Text; double a1 = Convert.ToDouble(a1_);
            string a2_ = textBox14.Text; double a2 = Convert.ToDouble(a2_);
            string a3_ = textBox15.Text; double a3 = Convert.ToDouble(a3_);
            string a4_ = textBox16.Text; double a4 = Convert.ToDouble(a4_);
            string b0_ = textBox17.Text; double b0 = Convert.ToDouble(b0_);
            string b1_ = textBox18.Text; double b1 = Convert.ToDouble(b1_);
            string b2_ = textBox21.Text; double b2 = Convert.ToDouble(b2_);

            MessageBox.Show("Данные добавлены!");

            // ------РАССЧЕТ ТАБЛИЦЫ------

            // Обьявление массивов
            int[] arrayi = new int[51];
            double[] arrayT = new double[51];
            double[] arrayX = new double[51];
            double[] arrayYa = new double[51];

            //Столбец i
            for (int i = 0; i < arrayi.Length; i++)
            {
                arrayi[i] = i + 1;
            }
            //Столбец τ
            double j = 0;
            for (int i = 0; i < arrayT.Length; i++, j += Dt)
            {
                arrayT[i] = j;
                arrayT[i] = Math.Round(arrayT[i], 3);
            }
            //Столбец X
            for (int i = 0; i < arrayX.Length; i++)
            {
                arrayX[i] = a0 + (a1 * arrayT[i]) + (a2 * Math.Pow(arrayT[i], 2)) + (a3 * Math.Pow(arrayT[i], 3)) + (a4 * Math.Pow(arrayT[i], 4));
                arrayX[i] = Math.Round(arrayX[i], 3);
            }
            //Столбец Ya
            //for (int i = 0; i < arrayYa.Length; i++)
            //{
            //    arrayYa[i] = (Yo - C0) * Math.Exp(-arrayT[i] / A) + C0 + C1 * arrayT[i] + C2 * Math.Pow(arrayT[i], 2) + C3 * Math.Pow(arrayT[i], 3) + C4 * Math.Pow(arrayT[i], 4);
            //    arrayYa[i] = Math.Round(arrayYa[i], 4);
            //}

            //Запись в таблицу
            for (int i = 0; i < 51; i++)
            {
                dataGridView1.Rows.Add(arrayi[i], arrayT[i], arrayX[i]);//, arrayYa[i], arrayY1[i], arrayY2[i], arraydY1[i], arraydY2[i], arraysY1[i] + "%", arraysY2[i] + "%");
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
// cartesianChart1.LegendLocation = LegendLocation.Bottom;
    }
}
