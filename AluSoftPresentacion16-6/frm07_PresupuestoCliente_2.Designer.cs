namespace AluSoftPresentacion16_6
{
    partial class frm07_PresupuestoCliente_2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel5 = new System.Windows.Forms.Panel();
            this.af_tabla = new System.Windows.Forms.Button();
            this.af_limpiar = new System.Windows.Forms.Button();
            this.af_modificar = new System.Windows.Forms.Button();
            this.af_buscar = new System.Windows.Forms.Button();
            this.af_eliminar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.af_Titulo_Gestion = new System.Windows.Forms.Label();
            this.af_volver = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxIdPresupuestoCliente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.af_id_af = new System.Windows.Forms.Label();
            this.cbxIdCatalogo = new System.Windows.Forms.ComboBox();
            this.cbxIdCliente = new System.Windows.Forms.ComboBox();
            this.af_id_alumno = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txbFormaPago = new System.Windows.Forms.TextBox();
            this.txbImpuestos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbFechaValidez = new System.Windows.Forms.TextBox();
            this.txbPlazoEntrega = new System.Windows.Forms.TextBox();
            this.txbSubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.af_nro_intento = new System.Windows.Forms.Label();
            this.af_id_materia = new System.Windows.Forms.Label();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.af_nota = new System.Windows.Forms.Label();
            this.af_id_carrera = new System.Windows.Forms.Label();
            this.txbEstado = new System.Windows.Forms.TextBox();
            this.txbFechaCreacion = new System.Windows.Forms.TextBox();
            this.txbDescuento = new System.Windows.Forms.TextBox();
            this.af_fecha = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.af_tabla);
            this.panel5.Controls.Add(this.af_limpiar);
            this.panel5.Controls.Add(this.af_modificar);
            this.panel5.Controls.Add(this.af_buscar);
            this.panel5.Controls.Add(this.af_eliminar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 514);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 75);
            this.panel5.TabIndex = 175;
            // 
            // af_tabla
            // 
            this.af_tabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_tabla.AutoSize = true;
            this.af_tabla.Location = new System.Drawing.Point(212, 10);
            this.af_tabla.Name = "af_tabla";
            this.af_tabla.Size = new System.Drawing.Size(91, 57);
            this.af_tabla.TabIndex = 139;
            this.af_tabla.Text = "Tabla";
            this.af_tabla.UseVisualStyleBackColor = true;
            this.af_tabla.Click += new System.EventHandler(this.af_tabla_Click);
            // 
            // af_limpiar
            // 
            this.af_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_limpiar.Location = new System.Drawing.Point(660, 10);
            this.af_limpiar.Name = "af_limpiar";
            this.af_limpiar.Size = new System.Drawing.Size(91, 57);
            this.af_limpiar.TabIndex = 99;
            this.af_limpiar.Text = "Limpiar";
            this.af_limpiar.UseVisualStyleBackColor = true;
            this.af_limpiar.Click += new System.EventHandler(this.af_limpiar_Click);
            // 
            // af_modificar
            // 
            this.af_modificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_modificar.Location = new System.Drawing.Point(434, 10);
            this.af_modificar.Name = "af_modificar";
            this.af_modificar.Size = new System.Drawing.Size(91, 57);
            this.af_modificar.TabIndex = 96;
            this.af_modificar.Text = "Modificar";
            this.af_modificar.UseVisualStyleBackColor = true;
            this.af_modificar.Click += new System.EventHandler(this.af_modificar_Click);
            // 
            // af_buscar
            // 
            this.af_buscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_buscar.Location = new System.Drawing.Point(320, 10);
            this.af_buscar.Name = "af_buscar";
            this.af_buscar.Size = new System.Drawing.Size(91, 57);
            this.af_buscar.TabIndex = 98;
            this.af_buscar.Text = "Buscar";
            this.af_buscar.UseVisualStyleBackColor = true;
            this.af_buscar.Click += new System.EventHandler(this.af_buscar_Click);
            // 
            // af_eliminar
            // 
            this.af_eliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_eliminar.Location = new System.Drawing.Point(548, 10);
            this.af_eliminar.Name = "af_eliminar";
            this.af_eliminar.Size = new System.Drawing.Size(91, 57);
            this.af_eliminar.TabIndex = 97;
            this.af_eliminar.Text = "Eliminar";
            this.af_eliminar.UseVisualStyleBackColor = true;
            this.af_eliminar.Click += new System.EventHandler(this.af_eliminar_Click);
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
            this.panel3.TabIndex = 176;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(920, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 28);
            this.button2.TabIndex = 187;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(840, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 141;
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(791, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 140;
            this.label6.Text = "Idiomas";
            this.label6.Visible = false;
            // 
            // af_Titulo_Gestion
            // 
            this.af_Titulo_Gestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.af_Titulo_Gestion.AutoSize = true;
            this.af_Titulo_Gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(11, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(499, 46);
            this.af_Titulo_Gestion.TabIndex = 137;
            this.af_Titulo_Gestion.Text = "Gestión de Acta de Finales";
            // 
            // af_volver
            // 
            this.af_volver.Location = new System.Drawing.Point(30, 12);
            this.af_volver.Name = "af_volver";
            this.af_volver.Size = new System.Drawing.Size(91, 57);
            this.af_volver.TabIndex = 95;
            this.af_volver.Text = "Volver";
            this.af_volver.UseVisualStyleBackColor = true;
            this.af_volver.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxIdPresupuestoCliente);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 50);
            this.groupBox1.TabIndex = 182;
            this.groupBox1.TabStop = false;
            // 
            // cbxIdPresupuestoCliente
            // 
            this.cbxIdPresupuestoCliente.FormattingEnabled = true;
            this.cbxIdPresupuestoCliente.Location = new System.Drawing.Point(244, 13);
            this.cbxIdPresupuestoCliente.Name = "cbxIdPresupuestoCliente";
            this.cbxIdPresupuestoCliente.Size = new System.Drawing.Size(216, 28);
            this.cbxIdPresupuestoCliente.TabIndex = 106;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 20);
            this.label8.TabIndex = 105;
            this.label8.Text = "Nro Pedido:";
            // 
            // af_id_af
            // 
            this.af_id_af.AutoSize = true;
            this.af_id_af.Location = new System.Drawing.Point(14, 53);
            this.af_id_af.Name = "af_id_af";
            this.af_id_af.Size = new System.Drawing.Size(77, 20);
            this.af_id_af.TabIndex = 88;
            this.af_id_af.Text = "Catálogo:";
            // 
            // cbxIdCatalogo
            // 
            this.cbxIdCatalogo.FormattingEnabled = true;
            this.cbxIdCatalogo.Location = new System.Drawing.Point(245, 45);
            this.cbxIdCatalogo.Name = "cbxIdCatalogo";
            this.cbxIdCatalogo.Size = new System.Drawing.Size(216, 28);
            this.cbxIdCatalogo.TabIndex = 89;
            // 
            // cbxIdCliente
            // 
            this.cbxIdCliente.FormattingEnabled = true;
            this.cbxIdCliente.Location = new System.Drawing.Point(245, 15);
            this.cbxIdCliente.Name = "cbxIdCliente";
            this.cbxIdCliente.Size = new System.Drawing.Size(216, 28);
            this.cbxIdCliente.TabIndex = 104;
            // 
            // af_id_alumno
            // 
            this.af_id_alumno.AutoSize = true;
            this.af_id_alumno.Location = new System.Drawing.Point(12, 23);
            this.af_id_alumno.Name = "af_id_alumno";
            this.af_id_alumno.Size = new System.Drawing.Size(62, 20);
            this.af_id_alumno.TabIndex = 97;
            this.af_id_alumno.Text = "Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxIdCliente);
            this.groupBox2.Controls.Add(this.af_id_af);
            this.groupBox2.Controls.Add(this.af_id_alumno);
            this.groupBox2.Controls.Add(this.cbxIdCatalogo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txbFormaPago);
            this.groupBox2.Controls.Add(this.txbImpuestos);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txbDescripcion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbFechaValidez);
            this.groupBox2.Controls.Add(this.txbPlazoEntrega);
            this.groupBox2.Controls.Add(this.txbSubtotal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txbTotal);
            this.groupBox2.Controls.Add(this.af_nro_intento);
            this.groupBox2.Controls.Add(this.af_id_materia);
            this.groupBox2.Controls.Add(this.txbObservaciones);
            this.groupBox2.Controls.Add(this.af_nota);
            this.groupBox2.Controls.Add(this.af_id_carrera);
            this.groupBox2.Controls.Add(this.txbEstado);
            this.groupBox2.Controls.Add(this.txbFechaCreacion);
            this.groupBox2.Controls.Add(this.txbDescuento);
            this.groupBox2.Controls.Add(this.af_fecha);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 119);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 391);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 363);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 120;
            this.label7.Text = "Forma de pago:";
            // 
            // txbFormaPago
            // 
            this.txbFormaPago.Location = new System.Drawing.Point(245, 356);
            this.txbFormaPago.Name = "txbFormaPago";
            this.txbFormaPago.Size = new System.Drawing.Size(214, 26);
            this.txbFormaPago.TabIndex = 121;
            // 
            // txbImpuestos
            // 
            this.txbImpuestos.Location = new System.Drawing.Point(245, 327);
            this.txbImpuestos.Name = "txbImpuestos";
            this.txbImpuestos.Size = new System.Drawing.Size(214, 26);
            this.txbImpuestos.TabIndex = 118;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 114;
            this.label1.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 117;
            this.label2.Text = "Impuestos:";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(245, 271);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(214, 26);
            this.txbDescripcion.TabIndex = 115;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 112;
            this.label3.Text = "Fecha de validéz:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 307);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 116;
            this.label4.Text = "Subtotal:";
            // 
            // txbFechaValidez
            // 
            this.txbFechaValidez.Location = new System.Drawing.Point(245, 243);
            this.txbFechaValidez.Name = "txbFechaValidez";
            this.txbFechaValidez.Size = new System.Drawing.Size(214, 26);
            this.txbFechaValidez.TabIndex = 113;
            // 
            // txbPlazoEntrega
            // 
            this.txbPlazoEntrega.Location = new System.Drawing.Point(245, 215);
            this.txbPlazoEntrega.Name = "txbPlazoEntrega";
            this.txbPlazoEntrega.Size = new System.Drawing.Size(214, 26);
            this.txbPlazoEntrega.TabIndex = 110;
            // 
            // txbSubtotal
            // 
            this.txbSubtotal.Location = new System.Drawing.Point(245, 299);
            this.txbSubtotal.Name = "txbSubtotal";
            this.txbSubtotal.Size = new System.Drawing.Size(214, 26);
            this.txbSubtotal.TabIndex = 111;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 109;
            this.label5.Text = "Plazo de entrega:";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(245, 187);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(216, 26);
            this.txbTotal.TabIndex = 108;
            // 
            // af_nro_intento
            // 
            this.af_nro_intento.AutoSize = true;
            this.af_nro_intento.Location = new System.Drawing.Point(14, 138);
            this.af_nro_intento.Name = "af_nro_intento";
            this.af_nro_intento.Size = new System.Drawing.Size(118, 20);
            this.af_nro_intento.TabIndex = 92;
            this.af_nro_intento.Text = "Observaciones:";
            // 
            // af_id_materia
            // 
            this.af_id_materia.AutoSize = true;
            this.af_id_materia.Location = new System.Drawing.Point(14, 195);
            this.af_id_materia.Name = "af_id_materia";
            this.af_id_materia.Size = new System.Drawing.Size(48, 20);
            this.af_id_materia.TabIndex = 105;
            this.af_id_materia.Text = "Total:";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(245, 131);
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(216, 26);
            this.txbObservaciones.TabIndex = 93;
            // 
            // af_nota
            // 
            this.af_nota.AutoSize = true;
            this.af_nota.Location = new System.Drawing.Point(14, 110);
            this.af_nota.Name = "af_nota";
            this.af_nota.Size = new System.Drawing.Size(64, 20);
            this.af_nota.TabIndex = 90;
            this.af_nota.Text = "Estado:";
            // 
            // af_id_carrera
            // 
            this.af_id_carrera.AutoSize = true;
            this.af_id_carrera.Location = new System.Drawing.Point(14, 167);
            this.af_id_carrera.Name = "af_id_carrera";
            this.af_id_carrera.Size = new System.Drawing.Size(91, 20);
            this.af_id_carrera.TabIndex = 94;
            this.af_id_carrera.Text = "Descuento:";
            // 
            // txbEstado
            // 
            this.txbEstado.Location = new System.Drawing.Point(245, 103);
            this.txbEstado.Name = "txbEstado";
            this.txbEstado.Size = new System.Drawing.Size(216, 26);
            this.txbEstado.TabIndex = 91;
            // 
            // txbFechaCreacion
            // 
            this.txbFechaCreacion.Location = new System.Drawing.Point(245, 75);
            this.txbFechaCreacion.Name = "txbFechaCreacion";
            this.txbFechaCreacion.Size = new System.Drawing.Size(216, 26);
            this.txbFechaCreacion.TabIndex = 76;
            // 
            // txbDescuento
            // 
            this.txbDescuento.Location = new System.Drawing.Point(245, 159);
            this.txbDescuento.Name = "txbDescuento";
            this.txbDescuento.Size = new System.Drawing.Size(216, 26);
            this.txbDescuento.TabIndex = 89;
            // 
            // af_fecha
            // 
            this.af_fecha.AutoSize = true;
            this.af_fecha.Location = new System.Drawing.Point(14, 82);
            this.af_fecha.Name = "af_fecha";
            this.af_fecha.Size = new System.Drawing.Size(144, 20);
            this.af_fecha.TabIndex = 57;
            this.af_fecha.Text = "Fecha de creación:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Location = new System.Drawing.Point(492, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(472, 418);
            this.panel7.TabIndex = 184;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(438, 389);
            this.dataGridView1.TabIndex = 135;
            // 
            // frm07_PresupuestoCliente_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 589);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "frm07_PresupuestoCliente_2";
            this.Text = "frm07_PresupuestoCliente_2";
            this.Load += new System.EventHandler(this.frm07_PresupuestoCliente_2_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Button af_tabla;
        private System.Windows.Forms.Button af_limpiar;
        private System.Windows.Forms.Button af_modificar;
        private System.Windows.Forms.Button af_buscar;
        private System.Windows.Forms.Button af_eliminar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label af_Titulo_Gestion;
        private System.Windows.Forms.Button af_volver;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label af_id_af;
        private System.Windows.Forms.ComboBox cbxIdCatalogo;
        private System.Windows.Forms.ComboBox cbxIdCliente;
        private System.Windows.Forms.Label af_id_alumno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Label af_nro_intento;
        private System.Windows.Forms.Label af_id_materia;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.Label af_nota;
        private System.Windows.Forms.Label af_id_carrera;
        private System.Windows.Forms.TextBox txbEstado;
        private System.Windows.Forms.TextBox txbFechaCreacion;
        private System.Windows.Forms.TextBox txbDescuento;
        private System.Windows.Forms.Label af_fecha;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbFormaPago;
        private System.Windows.Forms.TextBox txbImpuestos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbFechaValidez;
        private System.Windows.Forms.TextBox txbPlazoEntrega;
        private System.Windows.Forms.TextBox txbSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxIdPresupuestoCliente;
        private System.Windows.Forms.Label label8;
    }
}