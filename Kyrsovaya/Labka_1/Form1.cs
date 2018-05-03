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

namespace Labka_1
{
    public partial class Form1 : Form
    {
        public object dataGridView2;

        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Обработчик нажатия на кнопку
        public void button1_Click(object sender, EventArgs e)
        {
            //Ввод значений уравнения
            string ia = textBox1.Text;
            string kyky = textBox2.Text;
            string you = textBox3.Text;
            string tango = textBox4.Text;

            string qwe = textBox5.Text;
            string rty = textBox6.Text;
            string uio = textBox7.Text;
            string poi = textBox8.Text;
            string asd = textBox9.Text;

            //Конвертация в числовой тип данных
            double A = Convert.ToDouble(ia);
            double K = Convert.ToDouble(kyky);
            double Yo = Convert.ToDouble(you);
            double Tao = Convert.ToDouble(tango);

            double A0 = Convert.ToDouble(qwe);
            double A1 = Convert.ToDouble(rty);
            double A2 = Convert.ToDouble(uio);
            double A3 = Convert.ToDouble(poi);
            double A4 = Convert.ToDouble(asd);

            //Расчет C
            double C4 = K * A4;
            double C3 = K * A3 - 4 * A * C4;
            double C2 = K * A2 - 3 * A * C3;
            double C1 = K * A1 - 2 * A * C2;
            double C0 = K * A0 - A * C1;
            //Расчет D и округление
            double D1 = Math.Exp(-Tao / A);
            D1 = Math.Round(D1, 4);
            double D2 = A * K / Tao * (1 - D1) - K * D1;
            D2 = Math.Round(D2, 4);
            double D3 = K - A * K / Tao * (1 - D1);
            D3 = Math.Round(D3, 4);

            double D4 = 1 - (Tao / A);
            double D5 = K * Tao / A;

            // ------РАССЧЕТ ТАБЛИЦЫ------

            // Обьявление массивов
            int[] arrayi = new int[21];
            double[] arrayT = new double[21];
            double[] arrayX = new double[21];
            double[] arrayYa = new double[21];
            double[] arrayY1 = new double[21];
            double[] arrayY2 = new double[22];
            double[] arraydY1 = new double[21];
            double[] arraydY2 = new double[21];
            double[] arraysY1 = new double[21];
            double[] arraysY2 = new double[21];
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
            //Столбец Y1
            int u = 0;
            arrayY1[0] = 0;
            for (int i = 1; i < 21; i++, u++)
            {
                arrayY1[i] = D1 * arrayY1[u] + D2 * arrayX[u] + D3 * arrayX[i];
                arrayY1[i] = Math.Round(arrayY1[i], 4);
            }
            //Столбец Y2
            int z = 1;
            arrayY2[0] = 0;
            for (int i = 0; i < 21; i++, z++)
            {
                arrayY2[z] = D4 * arrayY2[i] + D5 * arrayX[i];
                arrayY2[z] = Math.Round(arrayY2[z], 4);
            }
            //Расчет Ymin и Ymax
            double Ymin = arrayYa[0];
            double Ymax = arrayYa[0];
            for (int i = 0; i < arrayYa.Length; i++)
            {
                if (arrayYa[i] < arrayYa[0])
                {
                    Ymin = arrayYa[i];
                    Ymin = Math.Round(Ymin, 4);
                }
            }
            textBox20.Text = Convert.ToString(Ymin);
            for (int i = 0; i < arrayYa.Length; i++)
            {
                if (Ymax < arrayYa[i])
                {
                    Ymax = arrayYa[i];
                    Ymax = Math.Round(Ymax, 4);
                }
            }
            textBox21.Text = Convert.ToString(Ymax);
            //Столбец dY1
            for (int i = 0; i < 21; i++)
            {
                arraydY1[i] = arrayYa[i] - arrayY1[i];
                arraydY1[i] = Math.Round(arraydY1[i], 4);
            }
            //Столбец dY2
            for (int i = 0; i < arraydY2.Length; i++)
            {
                arraydY2[i] = arrayYa[i] - arrayY2[i];
                arraydY2[i] = Math.Round(arraydY2[i], 4);
            }
            //Столбец bY1
            for (int i = 0; i < arraysY1.Length; i++)
            {
                arraysY1[i] = arraydY1[i] / ((Ymax - Ymin) / 100);
                arraysY1[i] = Math.Round(arraysY1[i], 4);
            }
            //Столбец bY2
            for (int i = 0; i < arraysY2.Length; i++)
            {
                arraysY2[i] = arraydY2[i] / ((Ymax - Ymin) / 100);
                arraysY2[i] = Math.Round(arraysY2[i], 4);
            }
            //Запись в таблицу
            for (int i = 0; i < 21; i++)
            {
                dataGridView1.Rows.Add(arrayi[i], arrayT[i], arrayX[i], arrayYa[i], arrayY1[i], arrayY2[i], arraydY1[i], arraydY2[i], arraysY1[i] + "%", arraysY2[i] + "%");
            }


            //Вывод таблицы
            // ОКРУГЛЕНИЕ Pk1 = Math.Round(Pk1, 3);

            //Вывод значений
            textBox10.Text = C0.ToString();
            textBox11.Text = C1.ToString();
            textBox12.Text = C2.ToString();
            textBox13.Text = C3.ToString();
            textBox14.Text = C4.ToString();

            textBox15.Text = D1.ToString();
            textBox16.Text = D2.ToString();
            textBox17.Text = D3.ToString();

            textBox18.Text = D4.ToString();
            textBox19.Text = D5.ToString();

            //char lambda = '\u03BB'; HEX
            //Вывод гистограммы
            //chart3.Series["Info"].Points.AddXY("1", Pk);
            //for (int i = 0; i < arrayX.Length; i++)
            //{
            //    chart3.Series["Info"].Points.AddXY(arrayT[i], arrayX[i]);
            //}


            cartesianChart1.Series = new SeriesCollection
            {  
            new LineSeries
                {
                    Title = "Кривая X",
                    Values = new ChartValues<double> { arrayX[0], arrayX[1], arrayX[2], arrayX[3], arrayX[4], arrayX[5], arrayX[6], arrayX[7], arrayX[8], arrayX[9], arrayX[10], arrayX[11], arrayX[12], arrayX[13], arrayX[14], arrayX[15], arrayX[16], arrayX[17], arrayX[18], arrayX[19], arrayX[20] },
                    PointGeometry = null,
                    Fill = System.Windows.Media.Brushes.GhostWhite,
                    Stroke = System.Windows.Media.Brushes.DarkGray
                },
                new LineSeries
                {
                    Title = "Кривая Ya",
                    Values = new ChartValues<double> { arrayYa[0], arrayYa[1], arrayYa[2], arrayYa[3], arrayYa[4], arrayYa[5], arrayYa[6], arrayYa[7], arrayYa[8], arrayYa[9], arrayYa[10], arrayYa[11], arrayYa[12], arrayYa[13], arrayYa[14], arrayYa[15], arrayYa[16], arrayYa[17], arrayYa[18], arrayYa[19], arrayYa[20]},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 10,
                    Fill = System.Windows.Media.Brushes.GhostWhite,
                    Stroke = System.Windows.Media.Brushes.Black
                },
                new LineSeries
                {
                    Title = "Кривая Y1",
                    Values = new ChartValues<double> {arrayY1[0], arrayY1[1], arrayY1[2], arrayY1[3], arrayY1[4], arrayY1[5], arrayY1[6], arrayY1[7], arrayY1[8], arrayY1[9], arrayY1[10], arrayY1[11], arrayY1[12], arrayY1[13], arrayY1[14], arrayY1[15], arrayY1[16], arrayY1[17], arrayY1[18], arrayY1[19], arrayY1[20]},
                    PointGeometry = DefaultGeometries.Square,
                    // Fill = System.Windows.Media.Brushes.None,
                    PointGeometrySize = 8,
                    Fill = System.Windows.Media.Brushes.Snow,
                    Stroke = System.Windows.Media.Brushes.DarkGray
                },
                new LineSeries
                {
                    Title = "Кривая Y2",
                    Values = new ChartValues<double> {arrayY2[0], arrayY2[1], arrayY2[2], arrayY2[3], arrayY2[4], arrayY2[5], arrayY2[6], arrayY2[7], arrayY2[8], arrayY2[9], arrayY2[10], arrayY2[11], arrayY2[12], arrayY2[13], arrayY2[14], arrayY2[15], arrayY2[16], arrayY2[17], arrayY2[18], arrayY2[19], arrayY2[20]},
                    PointGeometry = DefaultGeometries.Triangle,
                    PointGeometrySize = 10,
                    Fill = System.Windows.Media.Brushes.Snow,
                    Stroke = System.Windows.Media.Brushes.Black
                    // Fill = System.Windows.Media.Brushes.White

                }
                    
        };

            cartesianChart2.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Кривая Y1",
                    Values = new ChartValues<double> { arraydY1[0], arraydY1[1], arraydY1[2], arraydY1[3], arraydY1[4], arraydY1[5], arraydY1[6], arraydY1[7], arraydY1[8], arraydY1[9], arraydY1[10], arraydY1[11], arraydY1[12], arraydY1[13], arraydY1[14], arraydY1[15], arraydY1[16], arraydY1[17], arraydY1[18], arraydY1[19], arraydY1[20]},
                    PointGeometry = DefaultGeometries.Circle,
                    PointGeometrySize = 3,
                    //Fill = System.Windows.Media.Brushes.GhostWhite,
                    Stroke = System.Windows.Media.Brushes.Black
                },
                new LineSeries
                {
                    Title = "Кривая Y2",
                    Values = new ChartValues<double> { arraydY2[0], arraydY2[1], arraydY2[2], arraydY2[3], arraydY2[4], arraydY2[5], arraydY2[6], arraydY2[7], arraydY2[8], arraydY2[9], arraydY2[10], arraydY2[11], arraydY2[12], arraydY2[13], arraydY2[14], arraydY2[15], arraydY2[16], arraydY2[17], arraydY2[18], arraydY2[19], arraydY2[20]},
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 3,
                    //Fill = System.Windows.Media.Brushes.GhostWhite,
                    Stroke = System.Windows.Media.Brushes.DarkGray
                },

            };

            cartesianChart1.LegendLocation = LegendLocation.Bottom;
            cartesianChart2.LegendLocation = LegendLocation.Bottom;



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

