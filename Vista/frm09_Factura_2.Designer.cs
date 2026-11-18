namespace AluSoftPresentacion16_6
{
    partial class frm09_Factura_2
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
            this.cbxIdFactura = new System.Windows.Forms.ComboBox();
            this.af_id_alumno = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.txbCAE = new System.Windows.Forms.TextBox();
            this.txbFormaPago = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txbSubtotal = new System.Windows.Forms.TextBox();
            this.txbIVA = new System.Windows.Forms.TextBox();
            this.txbCondicionIVA = new System.Windows.Forms.TextBox();
            this.cbxIdCliente = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txbEstado = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbDescuento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbDireccionFiscal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxIdPedido = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTipofactura = new System.Windows.Forms.TextBox();
            this.af_id_if = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel5.Location = new System.Drawing.Point(0, 514);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(950, 75);
            this.panel5.TabIndex = 2;
            // 
            // bita_exportar
            // 
            this.bita_exportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bita_exportar.Location = new System.Drawing.Point(711, 10);
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
            this.af_tabla.Location = new System.Drawing.Point(600, 10);
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
            this.af_limpiar.Location = new System.Drawing.Point(484, 10);
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
            this.af_modificar.Location = new System.Drawing.Point(258, 10);
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
            this.af_buscar.Location = new System.Drawing.Point(144, 10);
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
            this.af_eliminar.Location = new System.Drawing.Point(372, 10);
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
            this.panel3.Size = new System.Drawing.Size(950, 78);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(897, 41);
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
            this.comboBox1.Location = new System.Drawing.Point(817, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(768, 15);
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
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(0, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(346, 46);
            this.af_Titulo_Gestion.TabIndex = 0;
            this.af_Titulo_Gestion.Text = "Gestión de factura";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxIdFactura);
            this.groupBox1.Controls.Add(this.af_id_alumno);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 55);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxIdFactura
            // 
            this.cbxIdFactura.FormattingEnabled = true;
            this.cbxIdFactura.Location = new System.Drawing.Point(190, 18);
            this.cbxIdFactura.Name = "cbxIdFactura";
            this.cbxIdFactura.Size = new System.Drawing.Size(271, 28);
            this.cbxIdFactura.TabIndex = 1;
            this.cbxIdFactura.TextUpdate += new System.EventHandler(this.cbxIdFactura_TextUpdate);
            // 
            // af_id_alumno
            // 
            this.af_id_alumno.AutoSize = true;
            this.af_id_alumno.Location = new System.Drawing.Point(6, 22);
            this.af_id_alumno.Name = "af_id_alumno";
            this.af_id_alumno.Size = new System.Drawing.Size(88, 20);
            this.af_id_alumno.TabIndex = 0;
            this.af_id_alumno.Text = "Nro factura";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker3);
            this.groupBox2.Controls.Add(this.txbObservaciones);
            this.groupBox2.Controls.Add(this.txbCAE);
            this.groupBox2.Controls.Add(this.txbFormaPago);
            this.groupBox2.Controls.Add(this.dateTimePicker2);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.txbSubtotal);
            this.groupBox2.Controls.Add(this.txbIVA);
            this.groupBox2.Controls.Add(this.txbCondicionIVA);
            this.groupBox2.Controls.Add(this.cbxIdCliente);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.txbEstado);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txbTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbDescuento);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txbDireccionFiscal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbxIdPedido);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txbTipofactura);
            this.groupBox2.Controls.Add(this.af_id_if);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 587);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Visible = false;
            this.dateTimePicker3.Location = new System.Drawing.Point(190, 491);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(271, 26);
            this.dateTimePicker3.TabIndex = 30;
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(190, 283);
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(271, 26);
            this.txbObservaciones.TabIndex = 31;
            // 
            // txbCAE
            // 
            this.txbCAE.Visible = false;
            this.txbCAE.Location = new System.Drawing.Point(190, 457);
            this.txbCAE.Name = "txbCAE";
            this.txbCAE.Size = new System.Drawing.Size(271, 26);
            this.txbCAE.TabIndex = 29;
            // 
            // txbFormaPago
            // 
            this.txbFormaPago.Location = new System.Drawing.Point(190, 225);
            this.txbFormaPago.Name = "txbFormaPago";
            this.txbFormaPago.Size = new System.Drawing.Size(271, 26);
            this.txbFormaPago.TabIndex = 27;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(190, 137);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(271, 26);
            this.dateTimePicker2.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 108);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(271, 26);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // txbSubtotal
            // 
            this.txbSubtotal.Visible = false;
            this.txbSubtotal.Location = new System.Drawing.Point(190, 389);
            this.txbSubtotal.Name = "txbSubtotal";
            this.txbSubtotal.Size = new System.Drawing.Size(271, 26);
            this.txbSubtotal.TabIndex = 23;
            // 
            // txbIVA
            // 
            this.txbIVA.AcceptsReturn = true;
            this.txbIVA.Visible = false;
            this.txbIVA.Location = new System.Drawing.Point(190, 423);
            this.txbIVA.Name = "txbIVA";
            this.txbIVA.Size = new System.Drawing.Size(271, 26);
            this.txbIVA.TabIndex = 25;
            // 
            // txbCondicionIVA
            // 
            this.txbCondicionIVA.Visible = false;
            this.txbCondicionIVA.Location = new System.Drawing.Point(190, 355);
            this.txbCondicionIVA.Name = "txbCondicionIVA";
            this.txbCondicionIVA.Size = new System.Drawing.Size(271, 26);
            this.txbCondicionIVA.TabIndex = 19;
            // 
            // cbxIdCliente
            // 
            this.cbxIdCliente.FormattingEnabled = true;
            this.cbxIdCliente.Location = new System.Drawing.Point(190, 48);
            this.cbxIdCliente.Name = "cbxIdCliente";
            this.cbxIdCliente.Size = new System.Drawing.Size(271, 28);
            this.cbxIdCliente.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 289);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 20);
            this.label17.TabIndex = 14;
            this.label17.Text = "Observaciones:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Visible = false;
            this.label19.Location = new System.Drawing.Point(5, 463);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 20);
            this.label19.TabIndex = 12;
            this.label19.Text = "CAE:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Visible = false;
            this.label20.Location = new System.Drawing.Point(5, 497);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(205, 20);
            this.label20.TabIndex = 13;
            this.label20.Text = "Fecha de vencimiento CAE:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 231);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(121, 20);
            this.label21.TabIndex = 15;
            this.label21.Text = "Forma de pago:";
            // 
            // txbEstado
            // 
            this.txbEstado.Location = new System.Drawing.Point(190, 253);
            this.txbEstado.Name = "txbEstado";
            this.txbEstado.Size = new System.Drawing.Size(271, 26);
            this.txbEstado.TabIndex = 28;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 259);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 20);
            this.label22.TabIndex = 11;
            this.label22.Text = "Estado:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Visible = false;
            this.label9.Location = new System.Drawing.Point(5, 429);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "IVA:";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(190, 195);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(271, 26);
            this.txbTotal.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "Total:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Visible = false;
            this.label11.Location = new System.Drawing.Point(5, 395);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Subtotal:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 172);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 20);
            this.label12.TabIndex = 8;
            this.label12.Text = "Descuento:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha emisión:";
            // 
            // txbDescuento
            // 
            this.txbDescuento.Location = new System.Drawing.Point(190, 166);
            this.txbDescuento.Name = "txbDescuento";
            this.txbDescuento.Size = new System.Drawing.Size(271, 26);
            this.txbDescuento.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha vencimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Visible = false;
            this.label7.Location = new System.Drawing.Point(5, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Condicion IVA:";
            // 
            // txbDireccionFiscal
            // 
            this.txbDireccionFiscal.Location = new System.Drawing.Point(190, 78);
            this.txbDireccionFiscal.Name = "txbDireccionFiscal";
            this.txbDireccionFiscal.Size = new System.Drawing.Size(271, 26);
            this.txbDireccionFiscal.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Dirección fiscal:";
            // 
            // cbxIdPedido
            // 
            this.cbxIdPedido.FormattingEnabled = true;
            this.cbxIdPedido.Location = new System.Drawing.Point(190, 18);
            this.cbxIdPedido.Name = "cbxIdPedido";
            this.cbxIdPedido.Size = new System.Drawing.Size(271, 28);
            this.cbxIdPedido.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nro pedido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nro cliente:";
            // 
            // txbTipofactura
            // 
            this.txbTipofactura.Visible = false;
            this.txbTipofactura.Location = new System.Drawing.Point(190, 321);
            this.txbTipofactura.Name = "txbTipofactura";
            this.txbTipofactura.Size = new System.Drawing.Size(271, 26);
            this.txbTipofactura.TabIndex = 16;
            // 
            // af_id_if
            // 
            this.af_id_if.AutoSize = true;
            this.af_id_if.Visible = false;
            this.af_id_if.Location = new System.Drawing.Point(5, 325);
            this.af_id_if.Name = "af_id_if";
            this.af_id_if.Size = new System.Drawing.Size(97, 20);
            this.af_id_if.TabIndex = 0;
            this.af_id_if.Text = "Tipo factura:";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Location = new System.Drawing.Point(478, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(469, 427);
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
            this.dataGridView1.Size = new System.Drawing.Size(435, 398);
            this.dataGridView1.TabIndex = 135;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 430);
            this.panel1.TabIndex = 0;
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
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(950, 436);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // frm09_Factura_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "frm09_Factura_2";
            this.Text = "frm09_Factura_2";
            this.Load += new System.EventHandler(this.frm09_Factura_2_Load);
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox cbxIdFactura;
        private System.Windows.Forms.Label af_id_alumno;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txbTipofactura;
        private System.Windows.Forms.Label af_id_if;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbDescuento;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbDireccionFiscal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxIdPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txbEstado;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.TextBox txbCAE;
        private System.Windows.Forms.TextBox txbFormaPago;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txbSubtotal;
        private System.Windows.Forms.TextBox txbIVA;
        private System.Windows.Forms.TextBox txbCondicionIVA;
        private System.Windows.Forms.ComboBox cbxIdCliente;
        private System.Windows.Forms.Button bita_exportar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}