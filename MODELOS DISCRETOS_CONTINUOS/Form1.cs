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
    public partial class Form1 : Form
    {
        Formula metodos = new Formula();
        private int n;
        private int X;
        private int X1;
        private int X2;
        private decimal P;
        private decimal PHP;
        private int N = 0;
        private decimal PT = 0;
        private string opcion = "";
        private string opcionRes = "";
        private string opcionDisitribucion = "";
        private string opcionDistribucion2 = "";

        private bool entero = true;
        //Respuestas
        private double Respuesta = 0;
        private double Respuesta2 = 0;
        private double Media = 0;
        private double DesviacionEstandar = 0;
        private double Varianza = 0;
        private double FC = 0;
        private double Sesgo = 0;
        private double Curtosis = 0;
        private double Mediana = 0;
        private String TipoSesgo = "";


        public double[] resultados;
        public double[] comparacion;
        public Form1()
        {
            InitializeComponent();
            button2.Visible =false;
            button3.Visible = false;
            button4.Visible = false;
            txtPorTole.Visible = false;
            label7.Visible = false;

            comboBox1.Items.Add("Distribucion Binomial");
            comboBox1.Items.Add("Distribucion Hipergeométrica");
            comboBox1.Items.Add("Comparacion Binomal vs Hipergeometrica");
            comboBox1.Items.Add("Muestreo para Aceptacion de Lotes");
            comboBox1.SelectedIndex=0;
            dataGridView1.Columns.Add("X","X");
            dataGridView1.Columns.Add("px","P(X)");
            dataGridView1.Columns.Add("pa", "Probabilidad Acumulada");
            dataGridView1.Columns.Add("por", "%");
            dataGridView1.Columns.Add("porA", "% Acumulado");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PT = 0;
            TipoSesgo = "";
            FC = 0;
            Sesgo = 0;
            Curtosis = 0;
            Mediana = 0;
            resultados = null;
            Respuesta = 0;
            Respuesta2 = 0;
            Media = 0;
            DesviacionEstandar = 0;
            Varianza = 0;
            listRespuestas.Items.Clear();
            X1 = 0;
            X1 = 0;
            X = 0;
            dataGridView1.Rows.Clear();
            

            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            chart2.Titles.Clear();
            chart2.Series.Clear();

            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }
            chart3.Titles.Clear();
            chart3.Series.Clear();


            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();
            
            ValidarDatos();
            Datos();

            if (!X.Equals(""))
            {
                Operacion();
            }
            else if (!X1.Equals("") && !X2.Equals(""))
            {
                Operacion();
            }
            else{
              
            }


            if (opcionDisitribucion =="Binomial")
            {
                Binomial();   
            }
            else if (opcionDisitribucion == "Hipergeometrica")
            {
                if (n>=(N*0.20))
                {
                    DH();
                }
                else
                {
                    if (entero)
                    {
                        P = P / 100;
                    }
                
                    Binomial();
                }

                
            }
            else if (opcionDisitribucion=="Comparacion")
            {
                if (n >= (N * 0.20))
                {
                    DH();
                }
                else
                {
                    if (entero)
                    {
                        P = P / 100;
                    }
                   
                    Binomial();
                }
            }
            
            MostrarDatos();
        }

        public void Binomial()
        {
            if (n <= (0.05 * N))
            {
                Operacion1();
            }
            else if (N == 0)
            {
                Operacion1();
            }
            else
            {
                
                Operacion2();
            }
            
        }

        public void ValidarDatos()
        {
            int cont = 0;
            if (txtN.Text.Trim() == "")
            {
                errorN.SetError(txtN, "Introduce N");
                cont++;
            }

            if (txtP.Text.Trim() == "")
            {
                errorP.SetError(txtP, "Introduce P");
                cont++;
            }
          
            if (cont != 0)
            {
                MessageBox.Show("LLene los campos requeridos", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                errorN.Clear();
                errorP.Clear();
                errorX.Clear();
           
            }
        }

        public void MostrarDatos() {
            double auxiliar = 0;
            if (Respuesta!=0 && opcionDisitribucion != "Comparacion")
            {
                listRespuestas.Items.Add("Probabilidad :            " + Respuesta);
            }
            else
            {
          
            }

            if (Respuesta != 0 && opcionDisitribucion == "Comparacion")
            {
                listRespuestas.Items.Add("Probabilidad Binomial:  " + Respuesta);
            }
            if (Respuesta2 != 0)
            {
                listRespuestas.Items.Add("Probabilidad Hipergeometrica :  " + Respuesta2);

                if (Respuesta>Respuesta2)
                {
                    auxiliar = Respuesta*100 - Respuesta2*100;
                }
                else
                {
                    auxiliar = Respuesta2*100 - Respuesta*100;
                }
                listRespuestas.Items.Add("Variacion Porcentual:  " + auxiliar);
            }
                
                listRespuestas.Items.Add("Media :                   " + Media);
            if (Varianza!=0)
            {
                listRespuestas.Items.Add("Varianza :                " + Varianza);
            }
            else
            {
             
            }
                

            if (FC!=0)
            {
                listRespuestas.Items.Add("Factor de Correccion :    " + FC);
            }
            else
            {
            
            }
               
                listRespuestas.Items.Add("Desviacion Estandar :     " + DesviacionEstandar);
                listRespuestas.Items.Add("Sesgo :                   " + Sesgo);
                listRespuestas.Items.Add("Curtosis :                " + Curtosis);
            if (Mediana!=0)
            {
                listRespuestas.Items.Add("Mediana :                 " + Mediana);
            }
            else
            {
           
            }
            if (TipoSesgo!="")
            {
                listRespuestas.Items.Add("--------Tipo de Sesgo---------");
                listRespuestas.Items.Add("--------" + TipoSesgo + "-------");
            }
                
            try
            {
                pictureBox.Image = Image.FromFile(TipoSesgo+".PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen valido");
            }

        }

        //Metodo de desviacion, media, varianza en la poblacion Infinita
        public void Operacion1()
        {
            listRespuestas.Items.Add("**************POBLACION INFINITA************");
            Media = metodos.Media(n,P);
            DesviacionEstandar = metodos.DesviacionEstandar(n,P);
            Varianza = metodos.Varianza(n,P);
            Sesgo = metodos.Sesgo(n,P);
            Curtosis = metodos.Curtosis(n,P);

        }

        //Metodo de deviacion, media, FC para la poblacion Finita
        public void Operacion2() {
            listRespuestas.Items.Add("**************POBLACION FINITA************");
            Media = metodos.Media(n,P);
            FC = metodos.FactorCorreccion(N,n);
            DesviacionEstandar = metodos.DesviacionPFinita(N,n,P);
            Sesgo = metodos.Sesgo(n, P);
            Curtosis = metodos.Curtosis(n, P);

        }


        public void DH()
        {
            if (entero)
            {
                Media = metodos.MediaHipergeometrica(n, (int)P, N);
                Sesgo = metodos.Sesgo(n, P/100);
                Curtosis = metodos.Curtosis(n, P/100);


            }
            else
            {
                Media = metodos.Media(n, PHP);
                Sesgo = metodos.Sesgo(n, P);
                Curtosis = metodos.Curtosis(n, P/100);
            }  
            DesviacionEstandar = metodos.DEHsinP(n,(int)P,N);
        }

        //Operacion para la Distribucion Binomial
        public void Operacion()
        {

            int auxiliar=0;
            Resultados datos = new Resultados();
            double PA = 0;
            int contador = 0;
            double UltimoResultado = 0;
            double UltimoResultado2 = 0;

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Representacion Grafica");
            ChartArea CA = chart1.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;


            chart2.Palette = ChartColorPalette.Pastel;
            chart2.Titles.Add("%");

            chart3.Palette = ChartColorPalette.Pastel;
            chart3.Titles.Add("% Acumulado");

            if (opcionDisitribucion=="Binomial")
            {
                resultados = metodos.DistribucionBinomial(P, n, X);
                if (opcionDistribucion2 != "Muestreo")
                {
                    PT = 0;
                }
            }
            else if(opcionDisitribucion == "Hipergeometrica")
            {
                if (n >= (N * 0.20))
                {
                    resultados = metodos.DistribucionHipergeometrica(n, (int)P, N, X);
                }
                else
                {
                    if (entero)
                    {
                        P = P / 100;
                    }
                    MessageBox.Show("Calculo con Distribucion Binomial");
                    resultados = metodos.DistribucionBinomial(P, n, X);
                }


                if (opcionDistribucion2 != "Muestreo")
                {
                    PT = 0;
                }
                
            }else if (opcionDisitribucion == "Comparacion")
            {
                if (opcionDistribucion2 != "Muestreo")
                {
                    PT = 0;
                }

                resultados = metodos.DistribucionBinomial((P/100), n, X);
                comparacion = metodos.DistribucionHipergeometrica(n, (int)P, N, X);
                //Aca nos quedamos   
            }


            //Aca incluimos lo de la comparacion
            if (opcionDisitribucion == "Comparacion")
            {
                datos = metodos.resultados(comparacion,opcionRes,X);
                UltimoResultado2 = datos.result;

            }

            if (X1 != 0 && X2 != 0)
            {
                datos = metodos.Resultado2(resultados, X1, X2, opcionRes);
                UltimoResultado = datos.result;
                Mediana = datos.mediana;
            }
            else
            {
                datos = metodos.resultados(resultados,opcionRes,X);
                UltimoResultado = datos.result;
                Mediana = datos.mediana;
               // UltimoResultado = metodos.resultados(resultados,opcionRes, X);
            }
            Media = metodos.Media(n, P);
            TipoSesgo = metodos.TipoSesgo(Media,Mediana);
            chart1.Series.Add("x"+"       "+"f(x)");
            chart2.Series.Add("x" + "       " + "%");
            chart3.Series.Add("x" + "       " + "% Acumulado");
            Respuesta = UltimoResultado;
            Respuesta2 = UltimoResultado2;
            bool res = Double.IsNaN(Respuesta);
            if (res)
            {
                
            }
            else{
                for (int i = 0; i < resultados.Length; i++)
                {
                    //Titulos

                    Series serie = chart1.Series.Add(i + " . " + resultados[i].ToString());
                    Series serie2 = chart2.Series.Add(i + " . " + (resultados[i]*100).ToString());
                    Series serie3;

                    //Cantidades
                    // serie.Label = resultados[i].ToString();
                    if (contador == 0)
                    {
                        PA = resultados[i];
                        if (PT!=0 && (PA * 100) <= ((double)PT * 100))
                        {
                            dataGridView1.Rows.Add(contador, resultados[i], resultados[i], resultados[i] * 100, resultados[i] * 100);
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        else
                        {
                            dataGridView1.Rows.Add(contador, resultados[i], resultados[i], resultados[i] * 100, resultados[i] * 100);
                        }
                        serie3 = chart3.Series.Add(i + " . " + (PA * 100).ToString());
                    }
                    else
                    {
                        PA = resultados[i]+PA;
                        serie3 = chart3.Series.Add(i + " . " + (PA*100).ToString());
                        if (PT != 0 && (PA*100)<=((double)PT*100))
                        {
                            dataGridView1.Rows.Add(contador, resultados[i], PA, resultados[i] * 100, PA * 100);
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                            auxiliar = i;
                        }
                        else
                        {
                            if (auxiliar!=0)
                            {
                                dataGridView1.Rows[auxiliar].DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                            dataGridView1.Rows.Add(contador, resultados[i], PA, resultados[i] * 100, PA * 100);
                        }
                        
                    }

                ///    auxiliar = 0;
                    chart1.Series[0].Points.AddXY(contador,resultados[i]);
                    // serie.Points.AddXY(contador, resultados[i]);
                    chart2.Series[0].Points.AddXY(contador,resultados[i]*100);
                    chart3.Series[0].Points.AddXY(contador, PA*100);
                    contador++;

                }

            }
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }
       
        public void Datos()
        {
            entero = true;
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                if (opcionDisitribucion == "Binomial")
                {
                    P = Convert.ToDecimal(txtP.Text.Trim(), culture);
                }
                else if(opcionDisitribucion == "Hipergeometrica" || opcionDisitribucion== "Comparacion")
                {
                    char[] P0 = txtP.Text.Trim().ToCharArray();
                    for (int i = 0; i < P0.Length; i++)
                    {
                        if (P0[i] == '.')
                        {
                            entero = false;
                        }
                    }
                    if (entero)
                    {
                        P = Convert.ToInt32(txtP.Text.Trim(), culture);
                    }
                    else
                    {
                        PHP = Convert.ToDecimal(txtP.Text.Trim(), culture);
                    }

                }

                n = Int32.Parse(txtN.Text.Trim());
                if (txtPoblacion.Text.Trim()!="")
                {
                    N = Int32.Parse(txtPoblacion.Text.Trim());
                }
                else
                {
                    N = 0;
                }
                
                if (txtPorTole.Text.Trim()!="")
                {
                    PT = Convert.ToDecimal(txtPorTole.Text.Trim(), culture);
                }
                
                AsignarValores(opcion);
                //X con un solo dato
                
               
           /*     
                X5 = Int32.Parse(txtX5.Text.Trim());
                X6 = Int32.Parse(txtX6.Text.Trim());

                //X rango de 2
                X3 = Int32.Parse(txtX3.Text.Trim());
                X4 = Int32.Parse(txtX4.Text.Trim());
           */
               
            }
            catch (Exception ex)
            {

            }

        }
        public void AsignarValores(string opcion)
        {
            switch (opcion)
            {
                case "X":
                    X = Int32.Parse(txtX.Text.Trim());
                    break;

                case "X1":
                    X = Int32.Parse(txtX1.Text.Trim());
                    break;

                case "X2":
                    X = Int32.Parse(txtX2.Text.Trim());
                    break;

                case "X3,4":
                    //Cambiar Aca
                    X1 = Int32.Parse(txtX3.Text.Trim());
                    X2 = Int32.Parse(txtX4.Text.Trim());
                    break;

                case "X5":
                    X = Int32.Parse(txtX5.Text.Trim());
                    break;

                case "X6":
                    X = Int32.Parse(txtX6.Text.Trim());
                    break;
                case "X7,8":
                    //Cambiar Aca
                    X1 = Int32.Parse(txtX7.Text.Trim());
                    X2 = Int32.Parse(txtX8.Text.Trim());
                    break;
            }
        }
        private void textN_Validated(object sender, EventArgs e)
        {
            //int num = 0;
            if (txtN.Text.Trim() == "")
            {
                errorN.SetError(txtN, "Introduce N");
            }
            else
            {
                errorN.Clear();
            }
            /*  if (!int.TryParse(txtN.Text.Trim(), out num))
              {
                  errorN.SetError(txtN, "Solo Numeros");
              }
              */


        }

        private void textP_Validated(object sender, EventArgs e)
        {
            if (txtP.Text.Trim() == "")
            {
                errorP.SetError(txtP, "Introduce P");
            }
            else
            {
                errorP.Clear();
            }
        }

        private void textX_Validated(object sender, EventArgs e)
        {
            if (txtX.Text.Trim() == "")
            {
                errorX.SetError(txtX, "Introduce X");
            }
            else
            {
                errorX.Clear();
            }
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosDecimal(e);

        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);

        }


        private void radioX_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X";
            opcionRes = "igual";
            this.txtX.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX1_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X1";
            opcionRes = "mayor";
            this.txtX1.Enabled = true;
            this.txtX.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX2_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X2";
            opcionRes = "menor";
            this.txtX2.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX3_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X3,4";
            opcionRes = "entre";
            this.txtX3.Enabled = true;
            this.txtX4.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX4_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X5";
            opcionRes = "mayorigual";
            this.txtX5.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX5_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X6";
            opcionRes = "menorigual";
            this.txtX6.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X7,8";
            opcionRes = "menorigualsinigual";
            this.txtX7.Enabled = true;
            this.txtX8.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX.Enabled = false;

        }

        private void radioSI_CheckedChanged(object sender, EventArgs e)
        {
            this.radioX.Enabled = true;
            this.radioX1.Enabled = true;
            this.radioX2.Enabled = true;
            this.radioX3.Enabled = true;
            this.radioX4.Enabled = true;
            this.radioX5.Enabled = true;
            this.radioX7.Enabled = true;
            this.txtX7.Enabled = true;
            this.txtX8.Enabled = true;
            this.txtX1.Enabled = true;
            this.txtX2.Enabled = true;
            this.txtX3.Enabled = true;
            this.txtX4.Enabled = true;
            this.txtX5.Enabled = true;
            this.txtX6.Enabled = true;
            this.txtX.Enabled = true;
        }

        private void radioNO_CheckedChanged(object sender, EventArgs e)
        {
            X = 0;
            X1 = 0;
            X2 = 0;
            opcion = "";
            opcionRes = "";
            this.radioX.Enabled = false;
            this.radioX1.Enabled = false;
            this.radioX2.Enabled = false;
            this.radioX3.Enabled = false;
            this.radioX4.Enabled = false;
            this.radioX5.Enabled = false;
            this.radioX7.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (item!=null)
            {
                if (item.Equals("Distribucion Binomial"))
                {
                    opcionDistribucion2 = "";
                    // MessageBox.Show("1 "+item);
                    txtPorTole.Visible = false;
                    label7.Visible = false;
                    label2.Text = "P (probabilidad de exito)";
                    label1.Text = "n (numero de eventos)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Binomial";
                }
                else if(item.Equals("Distribucion Hipergeométrica"))
                {
                    opcionDistribucion2 = "";
                    txtPorTole.Visible = false;
                    label7.Visible = false;
                    label2.Text = "K (Exitos en Poblacion)";
                    label1.Text = "n (Tamaño Muestra)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Hipergeometrica";
                }else if (item.Equals("Comparacion Binomal vs Hipergeometrica"))
                {
                    opcionDistribucion2 = "";
                    txtPorTole.Visible = false;
                    label7.Visible = false;
                    label2.Text = "K (Exitos en Poblacion)";
                    label1.Text = "n (Tamaño Muestra)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Comparacion";
                }else if (item.Equals("Muestreo para Aceptacion de Lotes"))
                {
                    
                    txtPorTole.Visible = true;
                    label7.Visible = true;
                    label2.Text = "P (probabilidad de exito)";
                    label1.Text = "n (numero de eventos)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Binomial";
                    opcionDistribucion2 = "Muestreo";
                }

            }
            else
            {
                MessageBox.Show("Elija una opcion");
            }
        }

  

 

   

        private void poissonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
        }

        private void binomialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Hide();
            form.Show();
        }
    }
}
