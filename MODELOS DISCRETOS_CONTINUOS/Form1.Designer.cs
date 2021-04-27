namespace MODELOS_DISCRETOS_CONTINUOS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea10 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend10 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtX = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorN = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorP = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorX = new System.Windows.Forms.ErrorProvider(this.components);
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtX1 = new System.Windows.Forms.TextBox();
            this.txtX2 = new System.Windows.Forms.TextBox();
            this.txtX5 = new System.Windows.Forms.TextBox();
            this.txtX6 = new System.Windows.Forms.TextBox();
            this.txtX3 = new System.Windows.Forms.TextBox();
            this.txtX4 = new System.Windows.Forms.TextBox();
            this.radioX = new System.Windows.Forms.RadioButton();
            this.radioX1 = new System.Windows.Forms.RadioButton();
            this.radioX2 = new System.Windows.Forms.RadioButton();
            this.radioX3 = new System.Windows.Forms.RadioButton();
            this.radioX4 = new System.Windows.Forms.RadioButton();
            this.radioX5 = new System.Windows.Forms.RadioButton();
            this.labelRes = new System.Windows.Forms.Label();
            this.listRespuestas = new System.Windows.Forms.ListBox();
            this.radioX7 = new System.Windows.Forms.RadioButton();
            this.txtX7 = new System.Windows.Forms.TextBox();
            this.txtX8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPoblacion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.radioSI = new System.Windows.Forms.RadioButton();
            this.radioNO = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPorTole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "n (numero de eventos)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "P (probabilidad de exito)";
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(229, 99);
            this.txtN.Margin = new System.Windows.Forms.Padding(4);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(132, 22);
            this.txtN.TabIndex = 3;
            this.txtN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtN_KeyPress);
            this.txtN.Validated += new System.EventHandler(this.textN_Validated);
            // 
            // txtP
            // 
            this.txtP.Location = new System.Drawing.Point(229, 140);
            this.txtP.Margin = new System.Windows.Forms.Padding(4);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(132, 22);
            this.txtP.TabIndex = 4;
            this.txtP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtP_KeyPress);
            this.txtP.Validated += new System.EventHandler(this.textP_Validated);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(513, 66);
            this.txtX.Margin = new System.Windows.Forms.Padding(4);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(39, 22);
            this.txtX.TabIndex = 5;
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtX_KeyPress);
            this.txtX.Validated += new System.EventHandler(this.textX_Validated);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(171, 263);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Calcular";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorN
            // 
            this.errorN.ContainerControl = this;
            // 
            // errorP
            // 
            this.errorP.ContainerControl = this;
            // 
            // errorX
            // 
            this.errorX.ContainerControl = this;
            // 
            // chart1
            // 
            chartArea12.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chart1.Legends.Add(legend12);
            this.chart1.Location = new System.Drawing.Point(24, 329);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(452, 454);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // txtX1
            // 
            this.txtX1.Location = new System.Drawing.Point(514, 96);
            this.txtX1.Margin = new System.Windows.Forms.Padding(4);
            this.txtX1.Name = "txtX1";
            this.txtX1.Size = new System.Drawing.Size(38, 22);
            this.txtX1.TabIndex = 11;
            // 
            // txtX2
            // 
            this.txtX2.Location = new System.Drawing.Point(514, 128);
            this.txtX2.Margin = new System.Windows.Forms.Padding(4);
            this.txtX2.Name = "txtX2";
            this.txtX2.Size = new System.Drawing.Size(38, 22);
            this.txtX2.TabIndex = 12;
            // 
            // txtX5
            // 
            this.txtX5.Location = new System.Drawing.Point(514, 166);
            this.txtX5.Margin = new System.Windows.Forms.Padding(4);
            this.txtX5.Name = "txtX5";
            this.txtX5.Size = new System.Drawing.Size(38, 22);
            this.txtX5.TabIndex = 16;
            // 
            // txtX6
            // 
            this.txtX6.Location = new System.Drawing.Point(514, 205);
            this.txtX6.Margin = new System.Windows.Forms.Padding(4);
            this.txtX6.Name = "txtX6";
            this.txtX6.Size = new System.Drawing.Size(39, 22);
            this.txtX6.TabIndex = 17;
            // 
            // txtX3
            // 
            this.txtX3.Location = new System.Drawing.Point(693, 99);
            this.txtX3.Margin = new System.Windows.Forms.Padding(4);
            this.txtX3.Name = "txtX3";
            this.txtX3.Size = new System.Drawing.Size(24, 22);
            this.txtX3.TabIndex = 18;
            // 
            // txtX4
            // 
            this.txtX4.Location = new System.Drawing.Point(730, 100);
            this.txtX4.Margin = new System.Windows.Forms.Padding(4);
            this.txtX4.Name = "txtX4";
            this.txtX4.Size = new System.Drawing.Size(29, 22);
            this.txtX4.TabIndex = 19;
            // 
            // radioX
            // 
            this.radioX.AutoSize = true;
            this.radioX.Location = new System.Drawing.Point(437, 70);
            this.radioX.Margin = new System.Windows.Forms.Padding(4);
            this.radioX.Name = "radioX";
            this.radioX.Size = new System.Drawing.Size(60, 21);
            this.radioX.TabIndex = 20;
            this.radioX.TabStop = true;
            this.radioX.Text = "P(X=";
            this.radioX.UseVisualStyleBackColor = true;
            this.radioX.CheckedChanged += new System.EventHandler(this.radioX_CheckedChanged);
            // 
            // radioX1
            // 
            this.radioX1.AutoSize = true;
            this.radioX1.Location = new System.Drawing.Point(437, 100);
            this.radioX1.Margin = new System.Windows.Forms.Padding(4);
            this.radioX1.Name = "radioX1";
            this.radioX1.Size = new System.Drawing.Size(60, 21);
            this.radioX1.TabIndex = 21;
            this.radioX1.TabStop = true;
            this.radioX1.Text = "P(X>";
            this.radioX1.UseVisualStyleBackColor = true;
            this.radioX1.CheckedChanged += new System.EventHandler(this.radioX1_CheckedChanged);
            // 
            // radioX2
            // 
            this.radioX2.AutoSize = true;
            this.radioX2.Location = new System.Drawing.Point(437, 128);
            this.radioX2.Margin = new System.Windows.Forms.Padding(4);
            this.radioX2.Name = "radioX2";
            this.radioX2.Size = new System.Drawing.Size(60, 21);
            this.radioX2.TabIndex = 22;
            this.radioX2.TabStop = true;
            this.radioX2.Text = "P(X<";
            this.radioX2.UseVisualStyleBackColor = true;
            this.radioX2.CheckedChanged += new System.EventHandler(this.radioX2_CheckedChanged);
            // 
            // radioX3
            // 
            this.radioX3.AutoSize = true;
            this.radioX3.Location = new System.Drawing.Point(598, 100);
            this.radioX3.Margin = new System.Windows.Forms.Padding(4);
            this.radioX3.Name = "radioX3";
            this.radioX3.Size = new System.Drawing.Size(80, 21);
            this.radioX3.TabIndex = 23;
            this.radioX3.TabStop = true;
            this.radioX3.Text = "P(   ≤   )";
            this.radioX3.UseVisualStyleBackColor = true;
            this.radioX3.CheckedChanged += new System.EventHandler(this.radioX3_CheckedChanged);
            // 
            // radioX4
            // 
            this.radioX4.AutoSize = true;
            this.radioX4.Location = new System.Drawing.Point(437, 167);
            this.radioX4.Margin = new System.Windows.Forms.Padding(4);
            this.radioX4.Name = "radioX4";
            this.radioX4.Size = new System.Drawing.Size(57, 21);
            this.radioX4.TabIndex = 24;
            this.radioX4.TabStop = true;
            this.radioX4.Text = "P(x≥";
            this.radioX4.UseVisualStyleBackColor = true;
            this.radioX4.CheckedChanged += new System.EventHandler(this.radioX4_CheckedChanged);
            // 
            // radioX5
            // 
            this.radioX5.AutoSize = true;
            this.radioX5.Location = new System.Drawing.Point(437, 206);
            this.radioX5.Margin = new System.Windows.Forms.Padding(4);
            this.radioX5.Name = "radioX5";
            this.radioX5.Size = new System.Drawing.Size(64, 21);
            this.radioX5.TabIndex = 25;
            this.radioX5.TabStop = true;
            this.radioX5.Text = "P(X ≤";
            this.radioX5.UseVisualStyleBackColor = true;
            this.radioX5.CheckedChanged += new System.EventHandler(this.radioX5_CheckedChanged);
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Location = new System.Drawing.Point(651, 100);
            this.labelRes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(0, 17);
            this.labelRes.TabIndex = 26;
            // 
            // listRespuestas
            // 
            this.listRespuestas.FormattingEnabled = true;
            this.listRespuestas.ItemHeight = 16;
            this.listRespuestas.Location = new System.Drawing.Point(484, 331);
            this.listRespuestas.Margin = new System.Windows.Forms.Padding(4);
            this.listRespuestas.Name = "listRespuestas";
            this.listRespuestas.Size = new System.Drawing.Size(388, 212);
            this.listRespuestas.TabIndex = 27;
            // 
            // radioX7
            // 
            this.radioX7.AutoSize = true;
            this.radioX7.Location = new System.Drawing.Point(608, 149);
            this.radioX7.Margin = new System.Windows.Forms.Padding(4);
            this.radioX7.Name = "radioX7";
            this.radioX7.Size = new System.Drawing.Size(80, 21);
            this.radioX7.TabIndex = 28;
            this.radioX7.TabStop = true;
            this.radioX7.Text = "P(   <   )";
            this.radioX7.UseVisualStyleBackColor = true;
            this.radioX7.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtX7
            // 
            this.txtX7.Location = new System.Drawing.Point(687, 146);
            this.txtX7.Margin = new System.Windows.Forms.Padding(4);
            this.txtX7.Name = "txtX7";
            this.txtX7.Size = new System.Drawing.Size(33, 22);
            this.txtX7.TabIndex = 29;
            // 
            // txtX8
            // 
            this.txtX8.Location = new System.Drawing.Point(729, 146);
            this.txtX8.Margin = new System.Windows.Forms.Padding(4);
            this.txtX8.Name = "txtX8";
            this.txtX8.Size = new System.Drawing.Size(35, 22);
            this.txtX8.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 188);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "N (Poblacion):";
            // 
            // txtPoblacion
            // 
            this.txtPoblacion.Location = new System.Drawing.Point(229, 179);
            this.txtPoblacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtPoblacion.Name = "txtPoblacion";
            this.txtPoblacion.Size = new System.Drawing.Size(132, 22);
            this.txtPoblacion.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1175, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 17);
            this.label6.TabIndex = 34;
            this.label6.Text = "Movimiento Sesgo del Grafico";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(1190, 96);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(241, 165);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 35;
            this.pictureBox.TabStop = false;
            // 
            // radioSI
            // 
            this.radioSI.AutoSize = true;
            this.radioSI.Location = new System.Drawing.Point(756, 263);
            this.radioSI.Margin = new System.Windows.Forms.Padding(4);
            this.radioSI.Name = "radioSI";
            this.radioSI.Size = new System.Drawing.Size(41, 21);
            this.radioSI.TabIndex = 36;
            this.radioSI.TabStop = true;
            this.radioSI.Text = "SI";
            this.radioSI.UseVisualStyleBackColor = true;
            this.radioSI.CheckedChanged += new System.EventHandler(this.radioSI_CheckedChanged);
            // 
            // radioNO
            // 
            this.radioNO.AutoSize = true;
            this.radioNO.Location = new System.Drawing.Point(756, 292);
            this.radioNO.Margin = new System.Windows.Forms.Padding(4);
            this.radioNO.Name = "radioNO";
            this.radioNO.Size = new System.Drawing.Size(50, 21);
            this.radioNO.TabIndex = 37;
            this.radioNO.TabStop = true;
            this.radioNO.Text = "NO";
            this.radioNO.UseVisualStyleBackColor = true;
            this.radioNO.CheckedChanged += new System.EventHandler(this.radioNO_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(651, 263);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "¿Calcular x?";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 63);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(293, 24);
            this.comboBox1.TabIndex = 40;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(883, 37);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(594, 506);
            this.dataGridView1.TabIndex = 41;
            // 
            // chart2
            // 
            chartArea11.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart2.Legends.Add(legend11);
            this.chart2.Location = new System.Drawing.Point(484, 564);
            this.chart2.Margin = new System.Windows.Forms.Padding(4);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(482, 218);
            this.chart2.TabIndex = 42;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea10.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea10);
            legend10.Name = "Legend1";
            this.chart3.Legends.Add(legend10);
            this.chart3.Location = new System.Drawing.Point(974, 564);
            this.chart3.Margin = new System.Windows.Forms.Padding(4);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(503, 218);
            this.chart3.TabIndex = 43;
            this.chart3.Text = "chart3";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 754);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 44;
            this.button2.Text = "Zoom";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1340, 742);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 28);
            this.button3.TabIndex = 45;
            this.button3.Text = "Zoom";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1053, 754);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 28);
            this.button4.TabIndex = 46;
            this.button4.Text = "Zoom";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 217);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 17);
            this.label7.TabIndex = 47;
            this.label7.Text = "Porcentaje de Tolerancia:";
            // 
            // txtPorTole
            // 
            this.txtPorTole.Location = new System.Drawing.Point(229, 220);
            this.txtPorTole.Margin = new System.Windows.Forms.Padding(4);
            this.txtPorTole.Name = "txtPorTole";
            this.txtPorTole.Size = new System.Drawing.Size(132, 22);
            this.txtPorTole.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(295, 25);
            this.label3.TabIndex = 49;
            this.label3.Text = "Seleccione la opcion que desee:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(593, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 50;
            this.label5.Text = "Rango de Valores";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(333, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 25);
            this.button5.TabIndex = 51;
            this.button5.Text = "Regresar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 798);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPorTole);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.radioNO);
            this.Controls.Add(this.radioSI);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPoblacion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtX8);
            this.Controls.Add(this.txtX7);
            this.Controls.Add(this.radioX7);
            this.Controls.Add(this.listRespuestas);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.radioX5);
            this.Controls.Add(this.radioX4);
            this.Controls.Add(this.radioX3);
            this.Controls.Add(this.radioX2);
            this.Controls.Add(this.radioX1);
            this.Controls.Add(this.radioX);
            this.Controls.Add(this.txtX4);
            this.Controls.Add(this.txtX3);
            this.Controls.Add(this.txtX6);
            this.Controls.Add(this.txtX5);
            this.Controls.Add(this.txtX2);
            this.Controls.Add(this.txtX1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.txtP);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.errorN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorN;
        private System.Windows.Forms.ErrorProvider errorP;
        private System.Windows.Forms.ErrorProvider errorX;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox txtX6;
        private System.Windows.Forms.TextBox txtX5;
        private System.Windows.Forms.TextBox txtX2;
        private System.Windows.Forms.TextBox txtX1;
        private System.Windows.Forms.TextBox txtX4;
        private System.Windows.Forms.TextBox txtX3;
        private System.Windows.Forms.RadioButton radioX5;
        private System.Windows.Forms.RadioButton radioX4;
        private System.Windows.Forms.RadioButton radioX3;
        private System.Windows.Forms.RadioButton radioX2;
        private System.Windows.Forms.RadioButton radioX1;
        private System.Windows.Forms.RadioButton radioX;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.ListBox listRespuestas;
        private System.Windows.Forms.RadioButton radioX7;
        private System.Windows.Forms.TextBox txtX8;
        private System.Windows.Forms.TextBox txtX7;
        private System.Windows.Forms.TextBox txtPoblacion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioNO;
        private System.Windows.Forms.RadioButton radioSI;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtPorTole;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
    }
}

