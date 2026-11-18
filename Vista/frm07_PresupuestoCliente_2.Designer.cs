namespace AluSoftPresentacion16_6
{
    partial class frm07_PresupuestoCliente_2
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
            this.bita_exportar = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txbCantidades = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.af_nro_intento = new System.Windows.Forms.Label();
            this.txbSubtotal = new System.Windows.Forms.TextBox();
            this.af_id_materia = new System.Windows.Forms.Label();
            this.txbPlazoEntrega = new System.Windows.Forms.TextBox();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.af_nota = new System.Windows.Forms.Label();
            this.txbFormaPago = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.af_id_carrera = new System.Windows.Forms.Label();
            this.txbImpuestos = new System.Windows.Forms.TextBox();
            this.txbEstado = new System.Windows.Forms.TextBox();
            this.af_fecha = new System.Windows.Forms.Label();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbDescuento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bita_exportar);
            this.panel5.Controls.Add(this.af_tabla);
            this.panel5.Controls.Add(this.af_limpiar);
            this.panel5.Controls.Add(this.af_modificar);
            this.panel5.Controls.Add(this.af_buscar);
            this.panel5.Controls.Add(this.af_eliminar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 524);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1240, 65);
            this.panel5.TabIndex = 2;
            // 
            // bita_exportar
            // 
            this.bita_exportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bita_exportar.Location = new System.Drawing.Point(829, 4);
            this.bita_exportar.Name = "bita_exportar";
            this.bita_exportar.Size = new System.Drawing.Size(91, 57);
            this.bita_exportar.TabIndex = 5;
            this.bita_exportar.Text = "Exportar";
            this.bita_exportar.UseVisualStyleBackColor = true;
            this.bita_exportar.Click += new System.EventHandler(this.bita_exportar_Click);
            // 
            // af_tabla
            // 
            this.af_tabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_tabla.AutoSize = true;
            this.af_tabla.Location = new System.Drawing.Point(720, 4);
            this.af_tabla.Name = "af_tabla";
            this.af_tabla.Size = new System.Drawing.Size(91, 57);
            this.af_tabla.TabIndex = 4;
            this.af_tabla.Text = "Ver tabla";
            this.af_tabla.UseVisualStyleBackColor = true;
            this.af_tabla.Click += new System.EventHandler(this.af_tabla_Click);
            // 
            // af_limpiar
            // 
            this.af_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_limpiar.Location = new System.Drawing.Point(608, 4);
            this.af_limpiar.Name = "af_limpiar";
            this.af_limpiar.Size = new System.Drawing.Size(91, 57);
            this.af_limpiar.TabIndex = 3;
            this.af_limpiar.Text = "Borrar";
            this.af_limpiar.UseVisualStyleBackColor = true;
            this.af_limpiar.Click += new System.EventHandler(this.af_limpiar_Click);
            // 
            // af_modificar
            // 
            this.af_modificar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_modificar.Location = new System.Drawing.Point(382, 4);
            this.af_modificar.Name = "af_modificar";
            this.af_modificar.Size = new System.Drawing.Size(91, 57);
            this.af_modificar.TabIndex = 1;
            this.af_modificar.Text = "Guardar";
            this.af_modificar.UseVisualStyleBackColor = true;
            this.af_modificar.Click += new System.EventHandler(this.af_modificar_Click);
            // 
            // af_buscar
            // 
            this.af_buscar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_buscar.Location = new System.Drawing.Point(268, 4);
            this.af_buscar.Name = "af_buscar";
            this.af_buscar.Size = new System.Drawing.Size(91, 57);
            this.af_buscar.TabIndex = 0;
            this.af_buscar.Text = "Buscar";
            this.af_buscar.UseVisualStyleBackColor = true;
            this.af_buscar.Click += new System.EventHandler(this.af_buscar_Click);
            // 
            // af_eliminar
            // 
            this.af_eliminar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_eliminar.Location = new System.Drawing.Point(496, 4);
            this.af_eliminar.Name = "af_eliminar";
            this.af_eliminar.Size = new System.Drawing.Size(91, 57);
            this.af_eliminar.TabIndex = 2;
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
            this.panel3.Size = new System.Drawing.Size(1240, 78);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1187, 41);
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
            this.comboBox1.Location = new System.Drawing.Point(1107, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1058, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Idiomas";
            this.label6.Visible = false;
            // 
            // af_Titulo_Gestion
            // 
            this.af_Titulo_Gestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.af_Titulo_Gestion.AutoSize = true;
            this.af_Titulo_Gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(145, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(625, 46);
            this.af_Titulo_Gestion.TabIndex = 1;
            this.af_Titulo_Gestion.Text = "Gestión de presupuesto de cliente";
            // 
            // af_volver
            // 
            this.af_volver.Location = new System.Drawing.Point(30, 12);
            this.af_volver.Name = "af_volver";
            this.af_volver.Size = new System.Drawing.Size(91, 57);
            this.af_volver.TabIndex = 0;
            this.af_volver.Text = "Volver";
            this.af_volver.UseVisualStyleBackColor = true;
            this.af_volver.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxIdPresupuestoCliente);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxIdPresupuestoCliente
            // 
            this.cbxIdPresupuestoCliente.FormattingEnabled = true;
            this.cbxIdPresupuestoCliente.Location = new System.Drawing.Point(237, 13);
            this.cbxIdPresupuestoCliente.Name = "cbxIdPresupuestoCliente";
            this.cbxIdPresupuestoCliente.Size = new System.Drawing.Size(259, 28);
            this.cbxIdPresupuestoCliente.TabIndex = 1;
            this.cbxIdPresupuestoCliente.TextUpdate += new System.EventHandler(this.cbxIdPresupuestoCliente_TextUpdate);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nro presupuesto:";
            // 
            // af_id_af
            // 
            this.af_id_af.AutoSize = true;
            this.af_id_af.Location = new System.Drawing.Point(5, 39);
            this.af_id_af.Name = "af_id_af";
            this.af_id_af.Size = new System.Drawing.Size(77, 20);
            this.af_id_af.TabIndex = 7;
            this.af_id_af.Text = "Catálogo:";
            // 
            // cbxIdCatalogo
            // 
            this.cbxIdCatalogo.FormattingEnabled = true;
            this.cbxIdCatalogo.Location = new System.Drawing.Point(236, 31);
            this.cbxIdCatalogo.Name = "cbxIdCatalogo";
            this.cbxIdCatalogo.Size = new System.Drawing.Size(259, 28);
            this.cbxIdCatalogo.TabIndex = 16;
            // 
            // cbxIdCliente
            // 
            this.cbxIdCliente.FormattingEnabled = true;
            this.cbxIdCliente.Location = new System.Drawing.Point(236, 1);
            this.cbxIdCliente.Name = "cbxIdCliente";
            this.cbxIdCliente.Size = new System.Drawing.Size(259, 28);
            this.cbxIdCliente.TabIndex = 15;
            // 
            // af_id_alumno
            // 
            this.af_id_alumno.AutoSize = true;
            this.af_id_alumno.Location = new System.Drawing.Point(3, 9);
            this.af_id_alumno.Name = "af_id_alumno";
            this.af_id_alumno.Size = new System.Drawing.Size(62, 20);
            this.af_id_alumno.TabIndex = 0;
            this.af_id_alumno.Text = "Cliente:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 409);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.AutoScroll = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.txbPrecio);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txbCantidades);
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.cbxIdCliente);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbTotal);
            this.panel1.Controls.Add(this.af_id_af);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.af_nro_intento);
            this.panel1.Controls.Add(this.af_id_alumno);
            this.panel1.Controls.Add(this.txbSubtotal);
            this.panel1.Controls.Add(this.af_id_materia);
            this.panel1.Controls.Add(this.cbxIdCatalogo);
            this.panel1.Controls.Add(this.txbPlazoEntrega);
            this.panel1.Controls.Add(this.txbObservaciones);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.af_nota);
            this.panel1.Controls.Add(this.txbFormaPago);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.af_id_carrera);
            this.panel1.Controls.Add(this.txbImpuestos);
            this.panel1.Controls.Add(this.txbEstado);
            this.panel1.Controls.Add(this.af_fecha);
            this.panel1.Controls.Add(this.txbDescripcion);
            this.panel1.Controls.Add(this.txbDescuento);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 321);
            this.panel1.TabIndex = 0;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(236, 230);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(259, 26);
            this.txbPrecio.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Precio:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "Cantidad:";
            // 
            // txbCantidades
            // 
            this.txbCantidades.Location = new System.Drawing.Point(236, 202);
            this.txbCantidades.Name = "txbCantidades";
            this.txbCantidades.Size = new System.Drawing.Size(259, 26);
            this.txbCantidades.TabIndex = 22;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(236, 287);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(258, 26);
            this.dateTimePicker2.TabIndex = 25;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(236, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(258, 26);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Visible = false;
            this.label1.Location = new System.Drawing.Point(3, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Descripción:";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(236, 173);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(259, 26);
            this.txbTotal.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Plazo de entrega:";
            // 
            // af_nro_intento
            // 
            this.af_nro_intento.AutoSize = true;
            this.af_nro_intento.Location = new System.Drawing.Point(5, 124);
            this.af_nro_intento.Name = "af_nro_intento";
            this.af_nro_intento.Size = new System.Drawing.Size(118, 20);
            this.af_nro_intento.TabIndex = 10;
            this.af_nro_intento.Text = "Observaciones:";
            // 
            // txbSubtotal
            // 
            this.txbSubtotal.Visible = false;
            this.txbSubtotal.Location = new System.Drawing.Point(236, 361);
            this.txbSubtotal.Name = "txbSubtotal";
            this.txbSubtotal.Size = new System.Drawing.Size(259, 26);
            this.txbSubtotal.TabIndex = 27;
            // 
            // af_id_materia
            // 
            this.af_id_materia.AutoSize = true;
            this.af_id_materia.Location = new System.Drawing.Point(5, 181);
            this.af_id_materia.Name = "af_id_materia";
            this.af_id_materia.Size = new System.Drawing.Size(48, 20);
            this.af_id_materia.TabIndex = 12;
            this.af_id_materia.Text = "Total:";
            // 
            // txbPlazoEntrega
            // 
            this.txbPlazoEntrega.Location = new System.Drawing.Point(236, 259);
            this.txbPlazoEntrega.Name = "txbPlazoEntrega";
            this.txbPlazoEntrega.Size = new System.Drawing.Size(259, 26);
            this.txbPlazoEntrega.TabIndex = 24;
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(236, 117);
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(259, 26);
            this.txbObservaciones.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Visible = false;
            this.label7.Location = new System.Drawing.Point(3, 440);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Forma de pago:";
            // 
            // af_nota
            // 
            this.af_nota.AutoSize = true;
            this.af_nota.Location = new System.Drawing.Point(5, 96);
            this.af_nota.Name = "af_nota";
            this.af_nota.Size = new System.Drawing.Size(64, 20);
            this.af_nota.TabIndex = 9;
            this.af_nota.Text = "Estado:";
            // 
            // txbFormaPago
            // 
            this.txbFormaPago.Visible = false;
            this.txbFormaPago.Location = new System.Drawing.Point(236, 433);
            this.txbFormaPago.Name = "txbFormaPago";
            this.txbFormaPago.Size = new System.Drawing.Size(259, 26);
            this.txbFormaPago.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Visible = false;
            this.label4.Location = new System.Drawing.Point(3, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Subtotal:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de validéz:";
            // 
            // af_id_carrera
            // 
            this.af_id_carrera.AutoSize = true;
            this.af_id_carrera.Location = new System.Drawing.Point(5, 153);
            this.af_id_carrera.Name = "af_id_carrera";
            this.af_id_carrera.Size = new System.Drawing.Size(91, 20);
            this.af_id_carrera.TabIndex = 11;
            this.af_id_carrera.Text = "Descuento:";
            // 
            // txbImpuestos
            // 
            this.txbImpuestos.Visible = false;
            this.txbImpuestos.Location = new System.Drawing.Point(236, 397);
            this.txbImpuestos.Name = "txbImpuestos";
            this.txbImpuestos.Size = new System.Drawing.Size(259, 26);
            this.txbImpuestos.TabIndex = 28;
            // 
            // txbEstado
            // 
            this.txbEstado.Location = new System.Drawing.Point(236, 89);
            this.txbEstado.Name = "txbEstado";
            this.txbEstado.Size = new System.Drawing.Size(259, 26);
            this.txbEstado.TabIndex = 18;
            // 
            // af_fecha
            // 
            this.af_fecha.AutoSize = true;
            this.af_fecha.Location = new System.Drawing.Point(5, 68);
            this.af_fecha.Name = "af_fecha";
            this.af_fecha.Size = new System.Drawing.Size(144, 20);
            this.af_fecha.TabIndex = 8;
            this.af_fecha.Text = "Fecha de creación:";
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Visible = false;
            this.txbDescripcion.Location = new System.Drawing.Point(236, 326);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(259, 26);
            this.txbDescripcion.TabIndex = 26;
            // 
            // txbDescuento
            // 
            this.txbDescuento.Location = new System.Drawing.Point(236, 145);
            this.txbDescuento.Name = "txbDescuento";
            this.txbDescuento.Size = new System.Drawing.Size(259, 26);
            this.txbDescuento.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Visible = false;
            this.label2.Location = new System.Drawing.Point(3, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Impuestos:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Location = new System.Drawing.Point(623, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(614, 440);
            this.panel7.TabIndex = 1;
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
            this.dataGridView1.Size = new System.Drawing.Size(580, 411);
            this.dataGridView1.TabIndex = 135;
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1240, 446);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 440);
            this.panel2.TabIndex = 0;
            // 
            // frm07_PresupuestoCliente_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 589);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox txbPlazoEntrega;
        private System.Windows.Forms.TextBox txbSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxIdPresupuestoCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button bita_exportar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbCantidades;
    }
}