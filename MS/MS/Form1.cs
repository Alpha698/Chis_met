using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Controls;
using System.Windows.Media;

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

            double D1 = (A-B*Dt)/ (A + B * Dt); D1 = Math.Round(D1, 3);
            textBox20.Text = D1.ToString();
            double D2 = (Dt) / (A+B*Dt); D2 = Math.Round(D2, 3);
            textBox22.Text = D2.ToString();
            double D3 = (k1*Dt) / (A + B * Dt); D3 = Math.Round(D3, 3);
            textBox23.Text = D3.ToString();
            double D4 = (k2 * Dt) / (A + B * Dt); D4 = Math.Round(D4, 3);
            textBox24.Text = D4.ToString();
            double D5 = Dt; D5 = Math.Round(D5, 3);
            textBox25.Text = D5.ToString();
            double D6 = (C)/(C+Dt); D6 = Math.Round(D6, 3);
            textBox26.Text = D6.ToString();
            double D7 = (k3*Dt) / (C + Dt); D7 = Math.Round(D7, 3);
            textBox27.Text = D7.ToString();
            double D8 = k4/ (C + Dt); D8 = Math.Round(D8, 3);
            textBox28.Text = D8.ToString();

           // MessageBox.Show("Данные добавлены!");

            // ------РАССЧЕТ ТАБЛИЦЫ------

            // Обьявление массивов
            int[] arrayi = new int[51];
            double[] arrayT = new double[51];
            double[] arrayX = new double[51];
            double[] arrayG = new double[51];
            double[] arrayF = new double[51];
            double[] arrayY = new double[51];
            double[] arrayZ = new double[51];

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
                arrayT[i] = Math.Round(arrayT[i], 2);
            }
            //Столбец X
            for (int i = 0; i < arrayX.Length; i++)
            {
                arrayX[i] = a0 + (a1 * arrayT[i]) + (a2 * Math.Pow(arrayT[i], 2)) + (a3 * Math.Pow(arrayT[i], 3)) + (a4 * Math.Pow(arrayT[i], 4));
                arrayX[i] = Math.Round(arrayX[i], 2);
            }
            //Столбец G
            for (int i = 0; i < arrayG.Length; i++)
            {
                arrayG[i] = b0 + b1 * arrayT[i] + b2 * Math.Pow(arrayT[i], 2);
                arrayG[i] = Math.Round(arrayG[i], 2);
            }

            /////////////////
            arrayY[0] = Y0; arrayY[0] = Math.Round(arrayY[0], 2);
            arrayF[0] = F0; arrayF[0] = Math.Round(arrayF[0], 2);
            arrayZ[0] = Z0; arrayZ[0] = Math.Round(arrayZ[0], 2);
            //Столбец Y
            arrayY[1] = arrayY[0] + Dt * arrayF[0];
            //arrayY[1] = arrayY[0] + Dt * arrayF[0];
            arrayY[1] = Math.Round(arrayY[1], 2);
            arrayZ[1] = arrayZ[0] * D6 + arrayY[1] * (D7 + D8) + arrayG[1] * ((D7* -1) - D8) + D8 * ((arrayY[0] * -1) + arrayG[0]);
            arrayZ[1] = Math.Round(arrayZ[1], 2);
            arrayF[1] = D1 * arrayF[0] - D2 * arrayY[1] + D3 * arrayX[1] + D4 * arrayZ[1];
            arrayF[1] = Math.Round(arrayF[1], 2);
            for (int i = 2; i < arrayY.Length; i++)
            {
                arrayY[i] = arrayY[i-1] + Dt * arrayF[i-1];
                arrayY[i] = Math.Round(arrayY[i], 2);
                arrayZ[i] = arrayZ[i - 1] * D6 + arrayY[i] * (D7 + D8) + arrayG[i] * (-D7 - D8) + D8 * (-arrayY[i - 1] + arrayG[i - 1]);
                arrayZ[i] = Math.Round(arrayZ[i], 2);
                arrayF[i] = D1 * arrayF[i - 1] - D2 * arrayY[i] + D3 * arrayX[i] + D4 * arrayZ[i];
                arrayF[i] = Math.Round(arrayF[i], 2);
                // break;


            }
   
            //Запись в таблицу
            for (int i = 0; i < 51; i++)
            {
                dataGridView1.Rows.Add(arrayi[i], arrayT[i], arrayX[i], arrayG[i], arrayF[i], arrayY[i], arrayZ[i]);
            }



            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Кривая X",
                    Values = new ChartValues<double> { arrayX[0] , arrayX[1], arrayX[2], arrayX[3], arrayX[4], arrayX[5], arrayX[6], arrayX[7], arrayX[8], arrayX[9], arrayX[10], arrayX[11], arrayX[12], arrayX[13], arrayX[14], arrayX[15], arrayX[16], arrayX[17], arrayX[18], arrayX[19], arrayX[20], arrayX[21], arrayX[22],arrayX[23],arrayX[24],arrayX[25],arrayX[26],arrayX[27],arrayX[28],arrayX[29],arrayX[30],arrayX[31],arrayX[32],arrayX[33],arrayX[34],arrayX[35],arrayX[36],arrayX[37],arrayX[38],arrayX[39],arrayX[40],arrayX[41],arrayX[42],arrayX[43],arrayX[44],arrayX[45],arrayX[46],arrayX[47],arrayX[48],arrayX[49],arrayX[50] },
                    PointGeometry = null,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Black
                },
                new LineSeries
                {
                    Title = "Кривая Y",
                    Values = new ChartValues<double> {arrayY[0], arrayY[1], arrayY[2], arrayY[3], arrayY[4], arrayY[5], arrayY[6], arrayY[7], arrayY[8], arrayY[9], arrayY[10], arrayY[11], arrayY[12], arrayY[13], arrayY[14], arrayY[15], arrayY[16], arrayY[17], arrayY[18], arrayY[19], arrayY[20], arrayY[21], arrayY[22], arrayY[23], arrayY[24], arrayY[25], arrayY[26], arrayY[27], arrayY[28], arrayY[29], arrayY[30], arrayY[31], arrayY[32], arrayY[33], arrayY[34], arrayY[35], arrayY[36], arrayY[37], arrayY[38], arrayY[39], arrayY[40], arrayY[41], arrayY[42], arrayY[43], arrayY[44], arrayY[45], arrayY[46], arrayY[47], arrayY[48], arrayY[49], arrayY[50]},
                    PointGeometry = DefaultGeometries.Triangle,
                    PointGeometrySize = 8,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Black
                },
                new LineSeries
                {
                    Title = "Кривая G",
                    Values = new ChartValues<double> { arrayG[0] , arrayG[1], arrayG[2], arrayG[3], arrayG[4], arrayG[5], arrayG[6], arrayG[7], arrayG[8], arrayG[9], arrayG[10], arrayG[11], arrayG[12], arrayG[13], arrayG[14], arrayG[15], arrayG[16], arrayG[17], arrayG[18], arrayG[19], arrayG[20], arrayG[21], arrayG[22], arrayG[23], arrayG[24], arrayG[25], arrayG[26], arrayG[27], arrayG[28], arrayG[29], arrayG[30], arrayG[31], arrayG[32], arrayG[33], arrayG[34], arrayG[35], arrayG[36], arrayG[37], arrayG[38], arrayG[39], arrayG[40], arrayG[41], arrayG[42], arrayG[43], arrayG[44], arrayG[45], arrayG[46], arrayG[47], arrayG[48], arrayG[49], arrayG[50] },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 8,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.DarkGray
                },
                new LineSeries
                {
                    Title = "Кривая F",
                    Values = new ChartValues<double> { arrayF[0], arrayF[1], arrayF[2], arrayF[3], arrayF[4], arrayF[5], arrayF[6], arrayF[7], arrayF[8], arrayF[9], arrayF[10], arrayF[11], arrayF[12], arrayF[13], arrayF[14], arrayF[15], arrayF[16], arrayF[17], arrayF[18], arrayF[19], arrayF[20], arrayF[21], arrayF[22], arrayF[23], arrayF[24], arrayF[25], arrayF[26], arrayF[27], arrayF[28], arrayF[29], arrayF[30], arrayF[31], arrayF[32], arrayF[33], arrayF[34], arrayF[35], arrayF[36], arrayF[37], arrayF[38], arrayF[39], arrayF[40], arrayF[41], arrayF[42], arrayF[43], arrayF[44], arrayF[45], arrayF[46], arrayF[47], arrayF[48], arrayF[49], arrayF[50]},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 8,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Black
                },
                new LineSeries
                {
                    Title = "Кривая Z",
                    Values = new ChartValues<double> { arrayZ[0], arrayZ[1], arrayZ[2], arrayZ[3], arrayZ[4], arrayZ[5], arrayZ[6], arrayZ[7], arrayZ[8], arrayZ[9], arrayZ[10], arrayZ[11], arrayZ[12], arrayZ[13], arrayZ[14], arrayZ[15], arrayZ[16], arrayZ[17], arrayZ[18], arrayZ[19], arrayZ[20], arrayZ[21], arrayZ[22], arrayZ[23], arrayZ[24], arrayZ[25], arrayZ[26], arrayZ[27], arrayZ[28], arrayZ[29], arrayZ[30], arrayZ[31], arrayZ[32], arrayZ[33], arrayZ[34], arrayZ[35], arrayZ[36], arrayZ[37], arrayZ[38], arrayZ[39], arrayZ[40], arrayZ[41], arrayZ[42], arrayZ[43], arrayZ[44], arrayZ[45], arrayZ[46], arrayZ[47], arrayZ[48], arrayZ[49], arrayZ[50]},
                    PointGeometry = DefaultGeometries.Cross,
                    PointGeometrySize = 8,
                    Fill = System.Windows.Media.Brushes.Transparent,
                    Stroke = System.Windows.Media.Brushes.Black
                }
            };
        cartesianChart2.LegendLocation = LegendLocation.Bottom;


    }
    }
}
