using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            double C2 = K * A2 -3 * A * C3;
            double C1 = K * A1 - 2 * A * C2;
            double C0 = K * A0 - A * C1;
            //Расчет D и округление
            double D1 = Math.Exp(-Tao/A);
            D1 = Math.Round(D1, 4);
            double D2 = A * K / Tao * (1-D1)-K*D1;
            D2 = Math.Round(D2, 4);
            double D3 = K - A * K / Tao*(1-D1);
            D3 = Math.Round(D3, 4);

            double D4 = 1 - (Tao/A);
            double D5 = K*Tao/A;
           
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
            }
            //Столбец X
            for (int i = 0; i < arrayX.Length; i++)
            {
                arrayX[i] = A0 + (A1 * arrayT[i]) + (A2 * Math.Pow(arrayT[i], 2)) + (A3 * Math.Pow(arrayT[i], 3)) + (A4 * Math.Pow(arrayT[i], 4));
            }
            //Столбец Ya
            for (int i = 0; i < arrayYa.Length; i++)
            {
                arrayYa[i] = (Yo - C0) * Math.Exp(-arrayT[i] / A) + C0 + C1 * arrayT[i] + C2 * Math.Pow(arrayT[i], 2) + C3 * Math.Pow(arrayT[i], 3) + C4 * Math.Pow(arrayT[i], 4);
            }
            //Столбец Y1
            int u = 0;
            arrayY1[0] = 0;
            for (int i = 1; i < 21; i++, u++)
            {
                arrayY1[i] = D1 * arrayY1[u] + D2 * arrayX[u] + D3 * arrayX[i];
            }
            //Столбец Y2
            int z = 1;
            arrayY2[0] = 0;
            for (int i = 0; i < 21; i++, z++)
            {
                arrayY2[z] = D4 * arrayY2[i] + D5 * arrayX[i];
            }
            //Расчет Ymin и Ymax
            double Ymin = arrayYa[0];
            double Ymax = arrayYa[0];
            for (int i = 0; i < arrayYa.Length; i++)
            {
                if (arrayYa[i] < arrayYa[0])
                {
                    Ymin = arrayYa[i];
                }
            }
            textBox20.Text = Convert.ToString(Ymin);
            for (int i = 0; i < arrayYa.Length; i++)
            {
                if (Ymax < arrayYa[i])
                {
                    Ymax = arrayYa[i];
                }
            }
            textBox21.Text = Convert.ToString(Ymax);
            //Столбец dY1
            for (int i = 0; i < 21; i++)
            {
                arraydY1[i] = arrayYa[i] - arrayY1[i];
            }
            //Столбец dY2
            for (int i = 0; i < arraydY2.Length; i++)
            {
                arraydY2[i] = arrayYa[i] - arrayY2[i];
            }
            //Столбец bY1
            for (int i = 0; i < arraysY1.Length; i++)
            {
                arraysY1[i] = arraydY1[i] / ((Ymax - Ymin)/100);
                arraysY1[i] = Math.Round(arraysY1[i], 3);
            }
            //Столбец bY2
            for (int i = 0; i < arraysY2.Length; i++)
            {
                arraysY2[i] = arraydY2[i] / ((Ymax - Ymin)/100);
                arraysY2[i] = Math.Round(arraysY2[i], 3);
            }
            //Запись в таблицу
            for (int i = 0; i < 21; i++)
            {
                dataGridView1.Rows.Add(arrayi[i], arrayT[i], arrayX[i], arrayYa[i], arrayY1[i], arrayY2[i], arraydY1[i], arraydY2[i], arraysY1[i]+"%", arraysY2[i]+"%");
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


            for (int i = 0; i < arrayX.Length; i++)
            {
                chart3.Series["Info"].Points.AddXY(arrayT[i], arrayX[i]);
                chart3.Series["Info"].Points.AddXY(arrayT[i], arrayYa[i]);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
