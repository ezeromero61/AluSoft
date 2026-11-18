namespace AluSoftPresentacion16_6
{
    partial class frm02_Stock_2
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.af_Titulo_Gestion = new System.Windows.Forms.Label();
            this.af_volver = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bita_exportar = new System.Windows.Forms.Button();
            this.af_tabla = new System.Windows.Forms.Button();
            this.af_limpiar = new System.Windows.Forms.Button();
            this.af_modificar = new System.Windows.Forms.Button();
            this.af_buscar = new System.Windows.Forms.Button();
            this.af_eliminar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxIdinventario = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbActual = new System.Windows.Forms.TextBox();
            this.af_id_if = new System.Windows.Forms.Label();
            this.af_nota = new System.Windows.Forms.Label();
            this.txbMaxima = new System.Windows.Forms.TextBox();
            this.txbMinima = new System.Windows.Forms.TextBox();
            this.af_fecha = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxIdStock = new System.Windows.Forms.ComboBox();
            this.af_id_alumno = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.af_Titulo_Gestion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.af_Titulo_Gestion.AutoSize = true;
            this.af_Titulo_Gestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.af_Titulo_Gestion.Location = new System.Drawing.Point(11, 16);
            this.af_Titulo_Gestion.Name = "af_Titulo_Gestion";
            this.af_Titulo_Gestion.Size = new System.Drawing.Size(319, 46);
            this.af_Titulo_Gestion.TabIndex = 0;
            this.af_Titulo_Gestion.Text = "Gestión de stock";
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
            this.panel5.Size = new System.Drawing.Size(973, 75);
            this.panel5.TabIndex = 2;
            // 
            // bita_exportar
            // 
            this.bita_exportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bita_exportar.Location = new System.Drawing.Point(721, 10);
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
            this.af_tabla.Location = new System.Drawing.Point(610, 10);
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
            this.af_limpiar.Location = new System.Drawing.Point(498, 10);
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
            this.af_modificar.Location = new System.Drawing.Point(272, 10);
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
            this.af_buscar.Location = new System.Drawing.Point(158, 10);
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
            this.af_eliminar.Location = new System.Drawing.Point(386, 10);
            this.af_eliminar.Name = "af_eliminar";
            this.af_eliminar.Size = new System.Drawing.Size(91, 57);
            this.af_eliminar.TabIndex = 2;
            this.af_eliminar.Text = "Eliminar";
            this.af_eliminar.UseVisualStyleBackColor = true;
            this.af_eliminar.Click += new System.EventHandler(this.af_eliminar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxIdinventario);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txbActual);
            this.groupBox2.Controls.Add(this.af_id_if);
            this.groupBox2.Controls.Add(this.af_nota);
            this.groupBox2.Controls.Add(this.txbMaxima);
            this.groupBox2.Controls.Add(this.txbMinima);
            this.groupBox2.Controls.Add(this.af_fecha);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 181);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // cbxIdinventario
            // 
            this.cbxIdinventario.FormattingEnabled = true;
            this.cbxIdinventario.Location = new System.Drawing.Point(237, 30);
            this.cbxIdinventario.Name = "cbxIdinventario";
            this.cbxIdinventario.Size = new System.Drawing.Size(216, 28);
            this.cbxIdinventario.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elemento de inventario:";
            // 
            // txbActual
            // 
            this.txbActual.Location = new System.Drawing.Point(237, 71);
            this.txbActual.Name = "txbActual";
            this.txbActual.Size = new System.Drawing.Size(216, 26);
            this.txbActual.TabIndex = 5;
            // 
            // af_id_if
            // 
            this.af_id_if.AutoSize = true;
            this.af_id_if.Location = new System.Drawing.Point(6, 77);
            this.af_id_if.Name = "af_id_if";
            this.af_id_if.Size = new System.Drawing.Size(126, 20);
            this.af_id_if.TabIndex = 1;
            this.af_id_if.Text = "Cantidad Actual:";
            // 
            // af_nota
            // 
            this.af_nota.AutoSize = true;
            this.af_nota.Location = new System.Drawing.Point(6, 149);
            this.af_nota.Name = "af_nota";
            this.af_nota.Size = new System.Drawing.Size(135, 20);
            this.af_nota.TabIndex = 3;
            this.af_nota.Text = "Cantidad Máxima:";
            // 
            // txbMaxima
            // 
            this.txbMaxima.Location = new System.Drawing.Point(237, 142);
            this.txbMaxima.Name = "txbMaxima";
            this.txbMaxima.Size = new System.Drawing.Size(216, 26);
            this.txbMaxima.TabIndex = 7;
            // 
            // txbMinima
            // 
            this.txbMinima.Location = new System.Drawing.Point(237, 109);
            this.txbMinima.Name = "txbMinima";
            this.txbMinima.Size = new System.Drawing.Size(216, 26);
            this.txbMinima.TabIndex = 6;
            // 
            // af_fecha
            // 
            this.af_fecha.AutoSize = true;
            this.af_fecha.Location = new System.Drawing.Point(6, 116);
            this.af_fecha.Name = "af_fecha";
            this.af_fecha.Size = new System.Drawing.Size(131, 20);
            this.af_fecha.TabIndex = 2;
            this.af_fecha.Text = "Cantidad Mínima:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxIdStock);
            this.groupBox1.Controls.Add(this.af_id_alumno);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 60);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // cbxIdStock
            // 
            this.cbxIdStock.FormattingEnabled = true;
            this.cbxIdStock.Location = new System.Drawing.Point(237, 19);
            this.cbxIdStock.Name = "cbxIdStock";
            this.cbxIdStock.Size = new System.Drawing.Size(216, 28);
            this.cbxIdStock.TabIndex = 1;
            this.cbxIdStock.SelectedIndexChanged += new System.EventHandler(this.cbxIdStock_SelectedIndexChanged);
            this.cbxIdStock.TextUpdate += new System.EventHandler(this.cbxIdStock_TextUpdate);
            // 
            // af_id_alumno
            // 
            this.af_id_alumno.AutoSize = true;
            this.af_id_alumno.Location = new System.Drawing.Point(6, 27);
            this.af_id_alumno.Name = "af_id_alumno";
            this.af_id_alumno.Size = new System.Drawing.Size(54, 20);
            this.af_id_alumno.TabIndex = 0;
            this.af_id_alumno.Text = "Stock:";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.SystemColors.Control;
            this.panel7.Controls.Add(this.dataGridView1);
            this.panel7.Location = new System.Drawing.Point(489, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(481, 430);
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
            this.dataGridView1.Size = new System.Drawing.Size(447, 401);
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
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 436);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 392);
            this.panel1.TabIndex = 0;
            // 
            // frm02_Stock_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "frm02_Stock_2";
            this.Text = "frm02_Stock_2";
            this.Load += new System.EventHandler(this.frm02_Stock_2_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label af_Titulo_Gestion;
        private System.Windows.Forms.Button af_volver;
        private System.Windows.Forms.Panel panel5;
        internal System.Windows.Forms.Button af_tabla;
        private System.Windows.Forms.Button af_limpiar;
        private System.Windows.Forms.Button af_modificar;
        private System.Windows.Forms.Button af_buscar;
        private System.Windows.Forms.Button af_eliminar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label af_id_if;
        private System.Windows.Forms.Label af_nota;
        private System.Windows.Forms.TextBox txbMaxima;
        private System.Windows.Forms.TextBox txbMinima;
        private System.Windows.Forms.Label af_fecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxIdStock;
        private System.Windows.Forms.Label af_id_alumno;
        private System.Windows.Forms.Panel panel7;
        internal System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txbActual;
        private System.Windows.Forms.ComboBox cbxIdinventario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bita_exportar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}