namespace AluSoftPresentacion16_6
{
    partial class frm14_OrdenProduccion_1
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
            this.cbxIdStock = new System.Windows.Forms.ComboBox();
            this.lblStockOrden = new System.Windows.Forms.Label();
            this.af_id_alumno = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.af_nota = new System.Windows.Forms.Label();
            this.af_id_materia = new System.Windows.Forms.Label();
            this.txbObservaciones = new System.Windows.Forms.TextBox();
            this.txbCantidad = new System.Windows.Forms.TextBox();
            this.af_fecha = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.af_Titulo_Gestion = new System.Windows.Forms.Label();
            this.af_volver = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.panel5.Size = new System.Drawing.Size(1250, 75);
            this.panel5.TabIndex = 2;
            // 
            // af_tabla
            // 
            this.af_tabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_tabla.AutoSize = true;
            this.af_tabla.Location = new System.Drawing.Point(700, 6);
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
            this.alum_limpiar.Location = new System.Drawing.Point(590, 6);
            this.alum_limpiar.Name = "alum_limpiar";
            this.alum_limpiar.Size = new System.Drawing.Size(91, 57);
            this.alum_limpiar.TabIndex = 1;
            this.alum_limpiar.Text = "Borrar";
            this.alum_limpiar.UseVisualStyleBackColor = true;
            this.alum_limpiar.Click += new System.EventHandler(this.alum_limpiar_Click);
            // 
            // alum_guardar
            // 
            this.alum_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_guardar.Location = new System.Drawing.Point(477, 6);
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
            this.panel7.Location = new System.Drawing.Point(628, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(619, 430);
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
            this.dataGridView1.Size = new System.Drawing.Size(585, 401);
            this.dataGridView1.TabIndex = 135;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxIdStock);
            this.groupBox2.Controls.Add(this.lblStockOrden);
            this.groupBox2.Controls.Add(this.af_id_alumno);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.af_nota);
            this.groupBox2.Controls.Add(this.af_id_materia);
            this.groupBox2.Controls.Add(this.txbObservaciones);
            this.groupBox2.Controls.Add(this.txbCantidad);
            this.groupBox2.Controls.Add(this.af_fecha);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 269);
            this.groupBox2.TabIndex = 187;
            this.groupBox2.TabStop = false;
            // 
            // cbxIdStock
            // 
            this.cbxIdStock.FormattingEnabled = true;
            this.cbxIdStock.Location = new System.Drawing.Point(174, 37);
            this.cbxIdStock.Name = "cbxIdStock";
            this.cbxIdStock.Size = new System.Drawing.Size(350, 28);
            this.cbxIdStock.TabIndex = 4;
            // 
            // lblStockOrden
            // 
            this.lblStockOrden.AutoSize = true;
            this.lblStockOrden.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lblStockOrden.Location = new System.Drawing.Point(15, 219);
            this.lblStockOrden.Name = "lblStockOrden";
            this.lblStockOrden.Size = new System.Drawing.Size(0, 20);
            this.lblStockOrden.TabIndex = 20;
            // 
            // af_id_alumno
            // 
            this.af_id_alumno.AutoSize = true;
            this.af_id_alumno.Location = new System.Drawing.Point(15, 45);
            this.af_id_alumno.Name = "af_id_alumno";
            this.af_id_alumno.Size = new System.Drawing.Size(54, 20);
            this.af_id_alumno.TabIndex = 0;
            this.af_id_alumno.Text = "Stock:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(174, 74);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(350, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // af_nota
            // 
            this.af_nota.AutoSize = true;
            this.af_nota.Location = new System.Drawing.Point(15, 148);
            this.af_nota.Name = "af_nota";
            this.af_nota.Size = new System.Drawing.Size(118, 20);
            this.af_nota.TabIndex = 3;
            this.af_nota.Text = "Observaciones:";
            // 
            // af_id_materia
            // 
            this.af_id_materia.AutoSize = true;
            this.af_id_materia.Location = new System.Drawing.Point(15, 79);
            this.af_id_materia.Name = "af_id_materia";
            this.af_id_materia.Size = new System.Drawing.Size(125, 20);
            this.af_id_materia.TabIndex = 1;
            this.af_id_materia.Text = "Fecha de orden:";
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(174, 142);
            this.txbObservaciones.Multiline = true;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbObservaciones.Size = new System.Drawing.Size(350, 69);
            this.txbObservaciones.TabIndex = 7;
            // 
            // txbCantidad
            // 
            this.txbCantidad.Location = new System.Drawing.Point(174, 108);
            this.txbCantidad.Name = "txbCantidad";
            this.txbCantidad.Size = new System.Drawing.Size(350, 26);
            this.txbCantidad.TabIndex = 6;
            // 
            // af_fecha
            // 
            this.af_fecha.AutoSize = true;
            this.af_fecha.Location = new System.Drawing.Point(15, 114);
            this.af_fecha.Name = "af_fecha";
            this.af_fecha.Size = new System.Drawing.Size(77, 20);
            this.af_fecha.TabIndex = 2;
            this.af_fecha.Text = "Cantidad:";
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
            this.panel3.Size = new System.Drawing.Size(1250, 78);
            this.panel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1197, 41);
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
            this.comboBox1.Location = new System.Drawing.Point(1117, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1068, 15);
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
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(150, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(560, 46);
            this.af_Titulo_Gestion.TabIndex = 1;
            this.af_Titulo_Gestion.Text = "Carga de orden de producción";
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1250, 436);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 430);
            this.panel1.TabIndex = 0;
            // 
            // frm14_OrdenProduccion_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "frm14_OrdenProduccion_1";
            this.Text = "frm14_OrdenProduccion_1";
            this.Load += new System.EventHandler(this.frm14_OrdenProduccion_1_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button alum_limpiar;
        private System.Windows.Forms.Button alum_guardar;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxIdStock;
        private System.Windows.Forms.Label lblStockOrden;
        private System.Windows.Forms.Label af_id_alumno;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label af_id_materia;
        private System.Windows.Forms.Label af_nota;
        private System.Windows.Forms.TextBox txbObservaciones;
        private System.Windows.Forms.TextBox txbCantidad;
        private System.Windows.Forms.Label af_fecha;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label af_Titulo_Gestion;
        private System.Windows.Forms.Button af_volver;
        internal System.Windows.Forms.Button af_tabla;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}