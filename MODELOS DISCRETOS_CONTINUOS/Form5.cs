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
    public partial class Form5 : Form
    {
        int numMuestras;
        int numMuestras2;

        double totalMuestras;
        double[] resultadosXY;
        double[] resultadosXalCuadrado;
        double[] resultadosYalCuadrado;
        double[] NuevosDatos;
        double[] NuevosDatos1;
        double[] restaNuevosDatos;
        double[] restaNuevosDatosalCuadrado;

        double[] zoomDatosX;
        double[] zoomDatosY;

        double errorEstandar;
        double sumatoriaXY;
        double sumatoriaX;
        double sumatoriaY;
        double sumatoriaXCuadrado;
        double sumatoriaYCuadrado;
        double m;
        double b;
        double coeficienteCorrelacion;

        CultureInfo culture = new CultureInfo("en-US");
        Formula calculo = new Formula();
        public Form5()
        {
            InitializeComponent();
            btnCalcular.Visible = false;
            btnCalcular2.Visible = false;
            btnGenerar2.Visible = false;
            btnZoom2.Visible = false;
            btnZoom1.Visible = false;
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("Y", "Y");

            dataGridView2.Columns.Add("X", "X");
            dataGridView2.Columns.Add("Y", "Y");
            dataGridView2.Columns.Add("XY", "XY");
            dataGridView2.Columns.Add("X^2", "X^2");
            dataGridView2.Columns.Add("Y^2", "Y^2");

            dataGridView3.Columns.Add("X", "X");
            dataGridView3.Columns.Add("Y'", "Y'");
            dataGridView3.Columns.Add("Y-Y'", "Y-Y'");
            dataGridView3.Columns.Add("(Y-Y')^2", "(Y-Y')^2");

            dataGridView4.Columns.Add("X", "X");

            dataGridView5.Columns.Add("X", "X");
            dataGridView5.Columns.Add("Y", "Y");

            labelERecta.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarDatos();
            Calcular();
            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ValidarDatos();  
        }

        public void LimpiarDatos()
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

            numMuestras=0;
            totalMuestras=0;
            resultadosXY=null;
            resultadosXalCuadrado = null;
            resultadosYalCuadrado = null;
            NuevosDatos = null;
            restaNuevosDatos = null;
            restaNuevosDatosalCuadrado = null;
            zoomDatosX=null;
            zoomDatosY=null;

            errorEstandar =0;
            sumatoriaXY = 0;
            sumatoriaX = 0;
            sumatoriaY = 0;
            sumatoriaXCuadrado = 0;
            sumatoriaYCuadrado = 0;
            m = 0;
            b = 0;
            coeficienteCorrelacion = 0;
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            listRespuestas.Items.Clear();

        }

        public void ValidarDatos()
        {
            int cont = 0;
            if (textnumMuestras.Text.Trim() == "")
            {
               // errorNumero.SetError(textnumMuestras, "Introduce un numero");
                cont++;
            }
            if (cont != 0)
            {
                MessageBox.Show("Ingrese los datos");
                errorNumero.Clear();
            }
            else
            {
                GenerarTabla();
                btnCalcular.Visible = true;
                //  MessageBox.Show(N + " - " + P + " - " + X1 + " - " + X2);
            }

        }

        public void GenerarTabla()
        {
            numMuestras = Convert.ToInt32(textnumMuestras.Text.Trim(), culture);
            for (int i=0; i<numMuestras; i++)
            {
                dataGridView1.Rows.Add(i,0);
            }
        }

        public void Calcular()
        {
            List<double> datosX = new List<double>();
            List<double> datosY = new List<double>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                datosX.Add(Convert.ToDouble(row.Cells["X"].Value.ToString(), culture));
                datosY.Add(Convert.ToDouble(row.Cells["Y"].Value.ToString(), culture));
            }
            totalMuestras = datosX.Count;
            resultadosXY =calculo.XY(datosX, datosY);
            resultadosXalCuadrado = calculo.XCuadrado(datosX);
            resultadosYalCuadrado = calculo.XCuadrado(datosY);

            sumatoriaXY = calculo.SumatoriasXY(resultadosXY);
            sumatoriaY = calculo.Sumatorias(datosY);
            sumatoriaX = calculo.Sumatorias(datosX);
            sumatoriaXCuadrado = calculo.SumatoriasXY(resultadosXalCuadrado);
            sumatoriaYCuadrado = calculo.SumatoriasXY(resultadosYalCuadrado);

            m = calculo.pendienteRecta(totalMuestras, sumatoriaXY, sumatoriaX, sumatoriaY, sumatoriaXCuadrado);
            b = calculo.coeficientePosicion(totalMuestras,sumatoriaXY,sumatoriaX,sumatoriaY,sumatoriaXCuadrado);
            coeficienteCorrelacion = calculo.coeficienteCorrelacion(totalMuestras,sumatoriaXY,sumatoriaX,sumatoriaY,sumatoriaXCuadrado,sumatoriaYCuadrado);
            NuevosDatos = calculo.NuevosDatos(datosX,m,b);

            restaNuevosDatos = calculo.restaNuevosDatos(datosY,NuevosDatos);
            restaNuevosDatosalCuadrado = calculo.restaNuevosDatosCuadrado(restaNuevosDatos);
            errorEstandar = calculo.errorEstandar(restaNuevosDatosalCuadrado);

            zoomDatosX = new double [datosX.Count];
            zoomDatosY = new double[datosX.Count];
            for (int i=0; i<datosX.Count; i++)
            {
                
                zoomDatosX[i] = datosX[i];
                zoomDatosY[i] = datosY[i];
            }

            mostrarDatos(datosX,datosY);
            btnGenerar2.Visible = true;
            btnZoom1.Visible = true;
            btnZoom2.Visible = true;


        }

        public void mostrarDatos(List<double> datosX, List<double> datosY)
        {

            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Representacion Grafica");

            chart2.Palette = ChartColorPalette.Pastel;
            chart2.Titles.Add("Representacion Grafica");


            ChartArea CA = chart1.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
            chart1.Series.Add("x" + "       " + "f(x)");

            ChartArea CA1 = chart2.ChartAreas[0];
            CA1.AxisX.ScaleView.Zoomable = true;
            CA1.CursorX.AutoScroll = true;
            CA1.CursorX.IsUserSelectionEnabled = true;
            chart2.Series.Add("x" + "       " + "f(x)");

            for (int i=0; i<datosX.Count; i++)
            {
                
                chart1.Series[0].Points.AddXY(datosX[i], datosY[i]);
                chart1.Series[0].ChartType = SeriesChartType.Line;

                chart2.Series[0].Points.AddXY(datosX[i], NuevosDatos[i]);
                chart2.Series[0].ChartType = SeriesChartType.Line;
            }

            if (b.ToString().Contains("-"))
            {
                labelERecta.Text = "y= " + Math.Round(m * 100d) / 100d + "x" + "  " + Math.Round(b * 100d) / 100d;
            }
            else
            {
                labelERecta.Text = "y= " + Math.Round(m * 100d) / 100d + "x" + " + " + Math.Round(b * 100d) / 100d;
            }
            
            
            
            labelERecta.Visible = true;
            listRespuestas.Items.Add("m: "+m);
            listRespuestas.Items.Add("b: " + b);
            listRespuestas.Items.Add("r: " + coeficienteCorrelacion);
            listRespuestas.Items.Add("Syx: " + errorEstandar);

            for (int i=0; i<datosX.Count; i++)
            {
                dataGridView2.Rows.Add(datosX[i], datosY[i], resultadosXY[i],resultadosXalCuadrado[i], resultadosYalCuadrado[i]);
                dataGridView3.Rows.Add(datosX[i],NuevosDatos[i],restaNuevosDatos[i],restaNuevosDatosalCuadrado[i]);
            }



        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView4.Rows.Clear();
            ValidarDatos2();
        }

        public void ValidarDatos2()
        {
            int cont = 0;
            if (textnumMuestras1.Text.Trim() == "")
            {
                // errorNumero.SetError(textnumMuestras, "Introduce un numero");
                cont++;
            }
            if (cont != 0)
            {
                MessageBox.Show("Ingrese los datos");
                errorNumero.Clear();
            }
            else
            {
                btnCalcular2.Visible = true;
                GenerarTabla2();
                //  MessageBox.Show(N + " - " + P + " - " + X1 + " - " + X2);
            }

        }

        public void GenerarTabla2()
        {
            numMuestras2 = Convert.ToInt32(textnumMuestras1.Text.Trim(), culture);
            for (int i = 0; i < numMuestras2; i++)
            {
                dataGridView4.Rows.Add(i, 0);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LimpiarDatos2();
            calcular2();
        }

        public void LimpiarDatos2()
        {
            numMuestras2 = 0;
            NuevosDatos1 = null;
            dataGridView5.Rows.Clear();
        }
        public void calcular2()
        {
            List<double> datosX = new List<double>();

            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                datosX.Add(Convert.ToDouble(row.Cells["X"].Value.ToString(), culture));
            }

            
            NuevosDatos1 = calculo.NuevosDatos(datosX, m, b);

            

            for (int i = 0; i < datosX.Count; i++)
            {
                dataGridView5.Rows.Add(datosX[i], NuevosDatos1[i]);
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            this.Hide();
            form.Show();
        }
    }
}
