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

    public partial class Colas : Form
    {

        
        private int muE;
        private int lambdaE;
        private int n;
        private int t;
        private double CxH;
        private double clientes;

        //Resultado Finales
        private double Ls;
        private double Ws;
        private double Lq;
        private double Wq;
        private double p;
        private double P0;
        private double[] Pn;
        private double PnFinal;
        private double P1;
        private double P2;
        private double Wsa;
        private double Wqa;

        private decimal muD;
        private decimal lambdaD;

        private double mu;
        private double lambda;
        Series serie;

        private bool entero = true;
        private string tiempo;
        private string tiempo1;
        private string tiempoR;
        private string opcionN;
        CultureInfo culture = new CultureInfo("en-US");

        public Colas()
        {
            InitializeComponent();
            btn1.Visible = false;
            btn2.Visible = false;
            comboBox4.Enabled = false;
            comboBox1.Items.Add("Clientes/Año");
            comboBox1.Items.Add("Clientes/Mes");
            comboBox1.Items.Add("Clientes/Semana");
            comboBox1.Items.Add("Clientes/Hora");
            comboBox1.Items.Add("Clientes/Minuto");
            comboBox1.Items.Add("Clientes/Segundo");
            comboBox1.SelectedIndex = 3;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.Items.Add("Clientes/Año");
            comboBox2.Items.Add("Clientes/Mes");
            comboBox2.Items.Add("Clientes/Semana");
            comboBox2.Items.Add("Clientes/Hora");
            comboBox2.Items.Add("Clientes/Minuto");
            comboBox2.Items.Add("Clientes/Segundo");
            comboBox2.SelectedIndex = 3;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.Items.Add("M/M/1");
            comboBox3.SelectedIndex = 0;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox4.Items.Add("Clientes/Año");
            comboBox4.Items.Add("Clientes/Mes");
            comboBox4.Items.Add("Clientes/Semana");
            comboBox4.Items.Add("Clientes/Hora");
            comboBox4.Items.Add("Clientes/Minuto");
            comboBox4.Items.Add("Clientes/Segundo");
            comboBox4.SelectedIndex = 4;
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox5.Items.Add("n=");
            comboBox5.Items.Add("n>");
            comboBox5.Items.Add("n<");
            comboBox5.Items.Add("n≥");
            comboBox5.Items.Add("n≤");
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.SelectedIndex = 0;

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            chart2.Titles.Clear();
            chart2.Series.Clear();


            muE =0;
        lambdaE=0;
        muD=0;
        lambdaD=0;
        mu=0;
        lambda=0;
            Ls = 0;
            Ws = 0;
            Lq = 0;
            Wq = 0;
            p = 0;
            P0 = 0;
            Pn = null;
            P1 = 0;
            P2 = 0;
            PnFinal = 0;
            listBox1.Items.Clear();

            ValidarDatos();
        }


        //Validar Datos
        public void ValidarDatos()
        {
            int cont = 0;
            if (txt1.Text.Trim() == "")
            {
                error1.SetError(txt1, "Introduce λ");
                cont++;
            }
           

            if (txtn.Text.Trim()!="")
            {
                n= Convert.ToInt32(txtn.Text.Trim(), culture);
            }

            if (txtt.Text.Trim()!="")
            {
                t = Convert.ToInt32(txtt.Text.Trim(),culture);   
            }

            if (txt2.Text.Trim() == "")
            {
                error2.SetError(txt2, "Introduce μ");
                cont++;
            }
            

            if(cont==0)
            {
                Datos();
                Operacion();
                //  MessageBox.Show(N + " - " + P + " - " + X1 + " - " + X2);
            }

        }

        //Recepcion de Datos
        public void Datos()
        {
            
            try
            {
                //Lambda
                if (esEntero(txt1.Text.Trim())==true)
                {
                    lambdaE = Convert.ToInt32(txt1.Text.Trim(), culture);
                    lambda=conversionMinutos(tiempo,lambdaE,0);
                }
                else
                {
                    lambdaD = Convert.ToDecimal(txt1.Text.Trim(), culture);
                    lambda=conversionMinutos(tiempo, 0, lambdaD);
                }


                //MU
                if (esEntero(txt2.Text.Trim()) == true)
                {
                    muE = Convert.ToInt32(txt2.Text.Trim(), culture);
                    mu=conversionMinutos(tiempo1, muE, 0);
                }
                else
                {
                    muD = Convert.ToDecimal(txt2.Text.Trim(), culture);
                    mu=conversionMinutos(tiempo1, 0, muD);
                }
               // MessageBox.Show("lambda: "+lambda+" "+"mU: "+mu);
                

            }
            catch (Exception ex)
            {

            }

        }

        public void Operacion()
        {
            
            Formula calculo = new Formula();
            Ls = calculo.LS(lambda, mu);
            Ws = calculo.WS(lambda, mu);
            Lq = calculo.Lq(lambda, mu);
            Wq = calculo.Wq(lambda, mu);
            p = calculo.Porcentaje(lambda, mu);
            P0 = calculo.ProbabilidadDesocupado(calculo.Porcentaje(lambda, mu));

            CxH = conversionCliente("Minutos", lambda);
            Pn = calculo.probabilidaN(lambda, mu, (int)CxH);
            PnFinal = calculo.resultadoN(opcionN,Pn,n,CxH);

            P1 = calculo.esperarCola(mu, calculo.Porcentaje(lambda, mu), t);
            P2 = calculo.esperarSistema(mu, calculo.Porcentaje(lambda, mu), t);



            listBox1.Items.Add("Ls: "+Ls);
            listBox1.Items.Add("Ws: " +Ws);
            listBox1.Items.Add("Lq: " +Lq);
            listBox1.Items.Add("Wq: " +Wq);
            listBox1.Items.Add("ρ: " +p);
            listBox1.Items.Add("P0: " +P0);

            if (txtn.Text.Trim()!="")
            {
              
                listBox1.Items.Add("Pn: " + PnFinal);
                       
            }

            if (txtt.Text.Trim()!="")
            {
                listBox1.Items.Add("P(Wq>"+t+"): "+P1);
                listBox1.Items.Add("P(Ws>" + t + "): " +P2);
            }
            comboBox4.Enabled = true;
            grafica();
            btn1.Visible = true;
            btn2.Visible = true;
        }

        public void Operacion2()
        {
            listBox1.Items.Clear();
            listBox1.Items.Add("Ls: " + Ls);
            listBox1.Items.Add("Ws: " + Wsa);
            listBox1.Items.Add("Lq: " + Lq);
            listBox1.Items.Add("Wq: " + Wqa);
            listBox1.Items.Add("ρ: " + p);
            listBox1.Items.Add("P0: " + P0);
            listBox1.Items.Add("Pn: " + PnFinal);


            if (txtt.Text.Trim() != "")
            {
                listBox1.Items.Add("P(Wq>" + t + "): " + P1);
                listBox1.Items.Add("P(Ws>" + t + "): " + P2);
            }

            

        }

        public void grafica()
        {
            chart1.Palette = ChartColorPalette.Pastel;
            chart2.Palette = ChartColorPalette.Berry;
            chart1.Titles.Add("Representacion Grafica Tasa de Llegada");
            chart2.Titles.Add("Representacion Grafica Tasa de Salida");


            //Titulos
            serie = chart1.Series.Add(""+lambda+"Clientes/minuto");
            serie = chart2.Series.Add("" + mu + "Clientes/minuto");

            //Cantidades
            // serie.Label = resultados[i].ToString();
            chart1.Series[0].Points.AddXY("minutos",lambda);
                chart2.Series[0].Points.AddXY("minutos",mu);
               // chart1.Series[0].Points.AddXY(contador, resultados[i] * 100);
               // contador++;

        }

        public bool esEntero(string dato)
        {
            char[] P0 = dato.ToCharArray();
            for (int i = 0; i < P0.Length; i++)
            {
                if (P0[i] == '.')
                {
                    return false;
                }
            }

            return true;
        }

        //Convertir a Minutos
        public double conversionMinutos(string opcion1, int dato, decimal dato1)
        {
            double minutos = 0;
            if (dato!=0)
            {
                if (opcion1 == "Años")
                {
                    minutos = ((double)dato / (double)525600);

                }
                else if (opcion1 == "Meses")
                {
                    minutos = ((double)dato / (double)43800);

                }
                else if (opcion1 == "Semanas")
                {
                    minutos = ((double)dato / (double)10080);
                }
                else if (opcion1 == "Horas")
                {
                    minutos = ((double)dato / (double)60);
                }
                else if (opcion1 == "Minutos")
                {
                    minutos = dato;
                }
                else if (opcion1 == "Segundos")
                {
                    minutos = ((double)dato * (double)60);
                }
             //   MessageBox.Show("" + minutos);
                return minutos;
            }else if (dato1!=0)
            {
                if (opcion1 == "Años")
                {
                    minutos = ((double)dato1 / (double)525600);

                }
                else if (opcion1 == "Meses")
                {
                    minutos = ((double)dato1 / (double)43800);

                }
                else if (opcion1 == "Semanas")
                {
                    minutos = ((double)dato1 / (double)10080);
                }
                else if (opcion1 == "Horas")
                {
                    minutos = ((double)dato1 / (double)60);
                }
                else if (opcion1 == "Minutos")
                {
                    minutos = (double)dato1;
                }
                else if (opcion1 == "Segundos")
                {
                    minutos = ((double)dato1 * (double)60);
                }
             //   MessageBox.Show("" + minutos);
                return minutos;
            }

            return minutos;
            
        }


        public double conversionCliente(string opcion1, double dato)
        {
            double minutos = 0;
            if (dato != 0)
            {
                if (opcion1 == "Años")
                {
                    minutos = ((double)dato / (double)525600);

                }
                else if (opcion1 == "Meses")
                {
                    minutos = ((double)dato / (double)43800);

                }
                else if (opcion1 == "Semanas")
                {
                    minutos = ((double)dato / (double)10080);
                }
                else if (opcion1 == "Horas")
                {
                    minutos = dato;
                }
                else if (opcion1 == "Minutos")
                {
                    minutos = (double)dato*60;
                }
                else if (opcion1 == "Segundos")
                {
                    minutos = ((double)dato * (double)60);
                }
                //   MessageBox.Show("" + minutos);
                return minutos;
            }
            return minutos;
        }

        public double conversionFinal(string opcion1, double dato)
        {
            double minutos = 0;
            if (dato != 0)
            {
                if (opcion1 == "Años")
                {
                    minutos = ((double)dato / (double)525600);

                }
                else if (opcion1 == "Meses")
                {
                    minutos = ((double)dato / (double)43800);

                }
                else if (opcion1 == "Semanas")
                {
                    minutos = ((double)dato / (double)10080);
                }
                else if (opcion1 == "Horas")
                {
                    minutos = ((double)dato / (double)60);
                }
                else if (opcion1 == "Minutos")
                {
                    minutos = dato;
                }
                else if (opcion1 == "Segundos")
                {
                    minutos = ((double)dato * (double)60);
                }
                //   MessageBox.Show("" + minutos);
                return minutos;
            }
            return minutos;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (item != null)
            {
                if (item.Equals("Clientes/Año"))
                {
                    tiempo = "Años";   
                }
                else if (item.Equals("Clientes/Mes"))
                {
                    tiempo = "Meses";
                }
                else if (item.Equals("Clientes/Semana"))
                {
                    tiempo = "Semanas";
                }
                else if (item.Equals("Clientes/Hora"))
                {
                    tiempo = "Horas";
                }
                else if (item.Equals("Clientes/Minuto"))
                {
                    tiempo = "Minutos";
                }
                else if (item.Equals("Clientes/Segundo"))
                {
                    tiempo = "Segundos";
                }
                
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox2.GetItemText(this.comboBox2.SelectedItem);
            if (item != null)
            {
                if (item.Equals("Clientes/Año"))
                {
                    tiempo1 = "Años";
                }
                else if (item.Equals("Clientes/Mes"))
                {
                    tiempo1 = "Meses";
                }
                else if (item.Equals("Clientes/Semana"))
                {
                    tiempo1 = "Semanas";
                }
                else if (item.Equals("Clientes/Hora"))
                {
                    tiempo1 = "Horas";
                }
                else if (item.Equals("Clientes/Minuto"))
                {
                    tiempo1 = "Minutos";
                }
                else if (item.Equals("Clientes/Segundo"))
                {
                    tiempo1 = "Segundos";
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox4.GetItemText(this.comboBox4.SelectedItem);
            if (item != null)
            {
                if (item.Equals("Clientes/Año"))
                {
                    tiempoR = "Años";
                }
                else if (item.Equals("Clientes/Mes"))
                {
                    tiempoR = "Meses";
                }
                else if (item.Equals("Clientes/Semana"))
                {
                    tiempoR = "Semanas";
                }
                else if (item.Equals("Clientes/Hora"))
                {
                    tiempoR = "Horas";
                }
                else if (item.Equals("Clientes/Minuto"))
                {
                    tiempoR = "Minutos";
                }
                else if (item.Equals("Clientes/Segundo"))
                {
                    tiempoR = "Segundos";
                }

                Wsa=conversionFinal(tiempoR, Ws);
                Wqa=conversionFinal(tiempoR, Wq);
                Operacion2();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox5.GetItemText(this.comboBox5.SelectedItem);
            if (item != null)
            {
                if (item.Equals("n="))
                {
                    opcionN = "n";
                }
                else if (item.Equals("n>"))
                {
                    opcionN = "n>";
                }
                else if (item.Equals("n<"))
                {
                    opcionN = "n<";
                }
                else if (item.Equals("n≥"))
                {
                    opcionN = "n≥";
                }
                else if (item.Equals("n≤"))
                {
                    opcionN = "n≤";
                }
                
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveFileDialog1.Title = "Guardar Grafico en Imagen";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.chart1.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        this.chart1.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        this.chart1.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveFileDialog1.Title = "Guardar Grafico en Imagen";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.chart2.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        this.chart2.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        this.chart2.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            this.Hide();
            form.Show();
        }
    }
}
