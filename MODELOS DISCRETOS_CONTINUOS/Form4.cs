using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    public partial class Form4 : Form
    {
        private int N;
        private decimal P;
        private int X1;
        private int X2;
        private int Mayor;
        private int Menor;
        private double Mediana;
        private double distribucion;
        public double[] resultados;
        public Form4()
        {
            InitializeComponent();

            comboBox1.Items.Add("x");
            comboBox1.Items.Add("x>");
            comboBox1.Items.Add("x<");
            comboBox1.Items.Add("x≥");
            comboBox1.Items.Add("x≤");
            comboBox1.Items.Add("x1≤x2");
            comboBox1.Items.Add("x1≥x2");
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;

            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("px", "P(X)");
            dataGridView1.Columns.Add("por", "%");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();

            int auxiliar = 0;
            N = 0;
            P = 0;
            X1 = 0;
            X2 = 0;
            Mayor = 0;
            Menor = 0;
            Mediana = 0;
            listRespuesta.Items.Clear();

            ValidarDatos();

            if ((double)P > 0.10)
            {
                auxiliar++;
            }
            if (P * N > 10)
            {
                auxiliar++;
            }
            if (auxiliar!=0)
            {
                MessageBox.Show(" Este problema lo puede resolver por medio de distribucion Binomial");
            }
        }

        public void ValidarDatos()
        {
            int cont = 0;
            if (textN.Text.Trim() == "")
            {
                errorN.SetError(textN, "Introduce N");
                cont++;
            }
            if (textX1.Text.Trim() == "")
            {
                errorN.SetError(textX1, "Introduce X");
                cont++;
            }
            if (textP.Text.Trim() == "")
            {
                errorN.SetError(textP, "Introduce P");
                cont++;
            }

            if (cont!=0)
            {
                MessageBox.Show("Ingrese los datos");
            }
            else
            {
                Datos();
                Operacion();
                
            }

        }

        public void Datos()
        {
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                P = Convert.ToDecimal(textP.Text.Trim(), culture);
                N = Convert.ToInt32(textN.Text.Trim(), culture);

                if (textX1.Text.Trim()!="")
                {
                    X1 = Convert.ToInt32(textX1.Text.Trim(), culture);
                    Mayor = X1;
                   
                }
                if (textX2.Text.Trim() != "")
                {
                    X2 = Convert.ToInt32(textX2.Text.Trim(), culture);
                    Mayor = X2;
                }

                if (X1 != 0 && X2 != 0)
                {
                    if (X1>X2)
                    {
                        Mayor = X1;
                        Menor = X2;
                    }
                    else
                    {
                        Mayor = X2;
                        Menor = X1;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void Operacion()
        {
            int contador = 0;
            chart1.Palette = ChartColorPalette.Chocolate;
            chart1.Titles.Add("Representacion Grafica");
            Formula calculo = new Formula();
            List<int> datos = new List<int>();
            resultados = calculo.DistribucionPoisson(N, Mayor, Menor, P);

            for (int i=0; i<resultados.Length;i++)
            {
                if (X1!=0 && X2!=0)
                {
                    dataGridView1.Rows.Add(Menor+i, resultados[i], resultados[i] * 100);
                }
                else
                {
                    dataGridView1.Rows.Add(contador, resultados[i], resultados[i] * 100);
                    distribucion = resultados[Mayor];   
                }
                

                Series serie = chart1.Series.Add(i + " . " + resultados[i].ToString());
                chart1.Series[0].Points.AddXY(contador, resultados[i]);
                contador++;
            }




           
            listRespuesta.Items.Add("Distribucion= "+distribucion);
            listRespuesta.Items.Add("Media = "+calculo.Media(N,P));
            listRespuesta.Items.Add("Desviacion Estandar = " + calculo.DesviacionEstandar(N, P));
            listRespuesta.Items.Add("Sesgo = " + calculo.Sesgo(N,P));
            listRespuesta.Items.Add("Curtosis = " + calculo.Curtosis(N, P));
            if (X1!=0 && X2!=0)
            {
                for (int i=Menor; i<=Mayor; i++)
                {
                    datos.Add(i);
                }
                Mediana = calculo.Mediana(datos);

                listRespuesta.Items.Add("Mediana = " + Mediana);
                
            }
            else
            {
                listRespuesta.Items.Add("Mediana = " + Mayor);
                Mediana = Mayor;
            }
            listRespuesta.Items.Add("Tipo de Sesgo = "+calculo.TipoSesgo(calculo.Media(N, P), Mediana));

        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var item = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (item != null)
            {
                if (item.Equals("x"))
                {
                    textX2.Enabled = false;
                    textX2.Text = "";
                }
                else if (item.Equals("x>"))
                {
                    textX2.Enabled = false;
                    textX2.Text = "";
                    X2 = 0;
                }
                else if (item.Equals("x<"))
                {
                    textX2.Enabled = false;
                    textX2.Text = "";
                    X2 = 0;
                }
                else if (item.Equals("x≥"))
                {
                    textX2.Enabled = false;
                    textX2.Text = "";
                    X2 = 0;
                }
                else if (item.Equals("x≤"))
                {
                    textX2.Enabled = false;
                    textX2.Text = "";
                    X2 = 0;
                }
                else if (item.Equals("x1≥x2"))
                {
                    textX2.Enabled = true;
                    textX2.Text = "";
                }
                else if (item.Equals("x1≤x2"))
                {
                    textX2.Enabled = true;
                    textX2.Text = "";
                }

            }
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }
    }
}