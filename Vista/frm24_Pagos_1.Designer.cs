namespace AluSoftPresentacion16_6
{
    partial class frm24_Pagos_1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel5 = new System.Windows.Forms.Panel();
            this.af_tabla = new System.Windows.Forms.Button();
            this.alum_limpiar = new System.Windows.Forms.Button();
            this.alum_guardar = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxIdCliente = new System.Windows.Forms.ComboBox();
            this.lblcbxIdCliente = new System.Windows.Forms.Label();
            this.cbxIdFactura = new System.Windows.Forms.ComboBox();
            this.lblcbxIdFactura = new System.Windows.Forms.Label();
            this.dtpFechaPago = new System.Windows.Forms.DateTimePicker();
            this.lbldtpFechaPago = new System.Windows.Forms.Label();
            this.nudImporte = new System.Windows.Forms.NumericUpDown();
            this.lblnudImporte = new System.Windows.Forms.Label();
            this.cbxFormaPago = new System.Windows.Forms.ComboBox();
            this.lblcbxFormaPago = new System.Windows.Forms.Label();
            this.txbNumeroComprobante = new System.Windows.Forms.TextBox();
            this.lbltxbNumeroComprobante = new System.Windows.Forms.Label();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.lbltxbObservaciones = new System.Windows.Forms.Label();
            this.chkAnulado = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.af_Titulo_Gestion = new System.Windows.Forms.Label();
            this.af_volver = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.af_tabla);
            this.panel5.Controls.Add(this.alum_limpiar);
            this.panel5.Controls.Add(this.alum_guardar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 514);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 75);
            this.panel5.TabIndex = 1;
            // 
            // af_tabla
            // 
            this.af_tabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_tabla.AutoSize = true;
            this.af_tabla.Location = new System.Drawing.Point(616, 6);
            this.af_tabla.Name = "af_tabla";
            this.af_tabla.Size = new System.Drawing.Size(91, 57);
            this.af_tabla.TabIndex = 2;
            this.af_tabla.Text = "Ver tabla";
            this.af_tabla.UseVisualStyleBackColor = true;
            this.af_tabla.Click += new System.EventHandler(this.af_tabla_Click);
            // 
            // alum_limpiar
            // 
            this.alum_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_limpiar.Location = new System.Drawing.Point(505, 6);
            this.alum_limpiar.Name = "alum_limpiar";
            this.alum_limpiar.Size = new System.Drawing.Size(91, 57);
            this.alum_limpiar.TabIndex = 1;
            this.alum_limpiar.Text = "Limpiar";
            this.alum_limpiar.UseVisualStyleBackColor = true;
            this.alum_limpiar.Click += new System.EventHandler(this.alum_limpiar_Click);
            // 
            // alum_guardar
            // 
            this.alum_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_guardar.Location = new System.Drawing.Point(392, 6);
            this.alum_guardar.Name = "alum_guardar";
            this.alum_guardar.Size = new System.Drawing.Size(91, 57);
            this.alum_guardar.TabIndex = 0;
            this.alum_guardar.Text = "Guardar";
            this.alum_guardar.UseVisualStyleBackColor = true;
            this.alum_guardar.Click += new System.EventHandler(this.alum_guardar_Click);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Location = new System.Drawing.Point(511, 84);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(450, 412);
            this.panel7.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(416, 383);
            this.dataGridView1.TabIndex = 135;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxIdCliente);
            this.groupBox2.Controls.Add(this.lblcbxIdCliente);
            this.groupBox2.Controls.Add(this.cbxIdFactura);
            this.groupBox2.Controls.Add(this.lblcbxIdFactura);
            this.groupBox2.Controls.Add(this.dtpFechaPago);
            this.groupBox2.Controls.Add(this.lbldtpFechaPago);
            this.groupBox2.Controls.Add(this.nudImporte);
            this.groupBox2.Controls.Add(this.lblnudImporte);
            this.groupBox2.Controls.Add(this.cbxFormaPago);
            this.groupBox2.Controls.Add(this.lblcbxFormaPago);
            this.groupBox2.Controls.Add(this.txbNumeroComprobante);
            this.groupBox2.Controls.Add(this.lbltxbNumeroComprobante);
            this.groupBox2.Controls.Add(this.txbObservaciones);
            this.groupBox2.Controls.Add(this.lbltxbObservaciones);
            this.groupBox2.Controls.Add(this.chkAnulado);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(9, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 340);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos del pago";
            // 
            // cbxIdCliente
            // 
            this.cbxIdCliente.Location = new System.Drawing.Point(190, 24);
            this.cbxIdCliente.Name = "cbxIdCliente";
            this.cbxIdCliente.Size = new System.Drawing.Size(265, 28);
            this.cbxIdCliente.TabIndex = 7;
            // 
            // lblcbxIdCliente
            // 
            this.lblcbxIdCliente.AutoSize = true;
            this.lblcbxIdCliente.Location = new System.Drawing.Point(15, 28);
            this.lblcbxIdCliente.Name = "lblcbxIdCliente";
            this.lblcbxIdCliente.Size = new System.Drawing.Size(62, 20);
            this.lblcbxIdCliente.TabIndex = 0;
            this.lblcbxIdCliente.Text = "Cliente:";
            // 
            // cbxIdFactura
            // 
            this.cbxIdFactura.Location = new System.Drawing.Point(190, 58);
            this.cbxIdFactura.Name = "cbxIdFactura";
            this.cbxIdFactura.Size = new System.Drawing.Size(265, 28);
            this.cbxIdFactura.TabIndex = 8;
            // 
            // lblcbxIdFactura
            // 
            this.lblcbxIdFactura.AutoSize = true;
            this.lblcbxIdFactura.Location = new System.Drawing.Point(15, 62);
            this.lblcbxIdFactura.Name = "lblcbxIdFactura";
            this.lblcbxIdFactura.Size = new System.Drawing.Size(92, 20);
            this.lblcbxIdFactura.TabIndex = 1;
            this.lblcbxIdFactura.Text = "Nro factura:";
            // 
            // dtpFechaPago
            // 
            this.dtpFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaPago.Location = new System.Drawing.Point(190, 92);
            this.dtpFechaPago.Name = "dtpFechaPago";
            this.dtpFechaPago.Size = new System.Drawing.Size(265, 26);
            this.dtpFechaPago.TabIndex = 9;
            // 
            // lbldtpFechaPago
            // 
            this.lbldtpFechaPago.AutoSize = true;
            this.lbldtpFechaPago.Location = new System.Drawing.Point(15, 96);
            this.lbldtpFechaPago.Name = "lbldtpFechaPago";
            this.lbldtpFechaPago.Size = new System.Drawing.Size(120, 20);
            this.lbldtpFechaPago.TabIndex = 2;
            this.lbldtpFechaPago.Text = "Fecha de pago:";
            // 
            // nudImporte
            // 
            this.nudImporte.DecimalPlaces = 2;
            this.nudImporte.Location = new System.Drawing.Point(190, 125);
            this.nudImporte.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudImporte.Minimum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            -2147483648});
            this.nudImporte.Name = "nudImporte";
            this.nudImporte.Size = new System.Drawing.Size(265, 26);
            this.nudImporte.TabIndex = 10;
            this.nudImporte.ThousandsSeparator = true;
            // 
            // lblnudImporte
            // 
            this.lblnudImporte.AutoSize = true;
            this.lblnudImporte.Location = new System.Drawing.Point(15, 129);
            this.lblnudImporte.Name = "lblnudImporte";
            this.lblnudImporte.Size = new System.Drawing.Size(68, 20);
            this.lblnudImporte.TabIndex = 3;
            this.lblnudImporte.Text = "Importe:";
            // 
            // cbxFormaPago
            // 
            this.cbxFormaPago.Location = new System.Drawing.Point(190, 161);
            this.cbxFormaPago.Name = "cbxFormaPago";
            this.cbxFormaPago.Size = new System.Drawing.Size(265, 28);
            this.cbxFormaPago.TabIndex = 11;
            // 
            // lblcbxFormaPago
            // 
            this.lblcbxFormaPago.AutoSize = true;
            this.lblcbxFormaPago.Location = new System.Drawing.Point(15, 165);
            this.lblcbxFormaPago.Name = "lblcbxFormaPago";
            this.lblcbxFormaPago.Size = new System.Drawing.Size(121, 20);
            this.lblcbxFormaPago.TabIndex = 4;
            this.lblcbxFormaPago.Text = "Forma de pago:";
            // 
            // txbNumeroComprobante
            // 
            this.txbNumeroComprobante.Location = new System.Drawing.Point(190, 196);
            this.txbNumeroComprobante.Name = "txbNumeroComprobante";
            this.txbNumeroComprobante.Size = new System.Drawing.Size(265, 26);
            this.txbNumeroComprobante.TabIndex = 12;
            // 
            // lbltxbNumeroComprobante
            // 
            this.lbltxbNumeroComprobante.AutoSize = true;
            this.lbltxbNumeroComprobante.Location = new System.Drawing.Point(15, 200);
            this.lbltxbNumeroComprobante.Name = "lbltxbNumeroComprobante";
            this.lbltxbNumeroComprobante.Size = new System.Drawing.Size(110, 20);
            this.lbltxbNumeroComprobante.TabIndex = 5;
            this.lbltxbNumeroComprobante.Text = "Comprobante:";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(190, 229);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObservaciones.Size = new System.Drawing.Size(265, 66);
            this.txbObservaciones.TabIndex = 13;
            // 
            // lbltxbObservaciones
            // 
            this.lbltxbObservaciones.AutoSize = true;
            this.lbltxbObservaciones.Location = new System.Drawing.Point(15, 233);
            this.lbltxbObservaciones.Name = "lbltxbObservaciones";
            this.lbltxbObservaciones.Size = new System.Drawing.Size(118, 20);
            this.lbltxbObservaciones.TabIndex = 6;
            this.lbltxbObservaciones.Text = "Observaciones:";
            // 
            // chkAnulado
            // 
            this.chkAnulado.AutoSize = true;
            this.chkAnulado.Location = new System.Drawing.Point(190, 305);
            this.chkAnulado.Name = "chkAnulado";
            this.chkAnulado.Size = new System.Drawing.Size(87, 24);
            this.chkAnulado.TabIndex = 14;
            this.chkAnulado.Text = "Anulado";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.af_Titulo_Gestion);
            this.panel3.Controls.Add(this.af_volver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 78);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(920, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 28);
            this.button2.TabIndex = 4;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(840, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(791, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Idiomas";
            this.label6.Visible = false;
            // 
            // af_Titulo_Gestion
            // 
            this.af_Titulo_Gestion.AutoSize = true;
            this.af_Titulo_Gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(11, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(308, 46);
            this.af_Titulo_Gestion.TabIndex = 0;
            this.af_Titulo_Gestion.Text = "Carga de Pagos";
            // 
            // af_volver
            // 
            this.af_volver.Location = new System.Drawing.Point(30, 12);
            this.af_volver.Name = "af_volver";
            this.af_volver.Size = new System.Drawing.Size(91, 57);
            this.af_volver.TabIndex = 1;
            this.af_volver.Text = "Volver";
            this.af_volver.UseVisualStyleBackColor = true;
            this.af_volver.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // frm24_Pagos_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 589);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "frm24_Pagos_1";
            this.Text = "frm24_Pagos_1";
            this.Load += new System.EventHandler(this.frm24_Pagos_1_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudImporte)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button alum_limpiar;
        private System.Windows.Forms.Button alum_guardar;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxIdCliente;
        private System.Windows.Forms.Label lblcbxIdCliente;
        private System.Windows.Forms.ComboBox cbxIdFactura;
        private System.Windows.Forms.Label lblcbxIdFactura;
        private System.Windows.Forms.DateTimePicker dtpFechaPago;
        private System.Windows.Forms.Label lbldtpFechaPago;
        private System.Windows.Forms.NumericUpDown nudImporte;
        private System.Windows.Forms.Label lblnudImporte;
        private System.Windows.Forms.ComboBox cbxFormaPago;
        private System.Windows.Forms.Label lblcbxFormaPago;
        private System.Windows.Forms.TextBox txbNumeroComprobante;
        private System.Windows.Forms.Label lbltxbNumeroComprobante;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.Label lbltxbObservaciones;
        private System.Windows.Forms.CheckBox chkAnulado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label af_Titulo_Gestion;
        private System.Windows.Forms.Button af_volver;
        internal System.Windows.Forms.Button af_tabla;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}