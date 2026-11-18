namespace AluSoft
{
    partial class frm13_ListaPrecios_1
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
            this.label3 = new System.Windows.Forms.Label();
            this.alum_Titulo_Alta = new System.Windows.Forms.Label();
            this.alum_volver = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.alum_limpiar = new System.Windows.Forms.Button();
            this.alum_guardar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.alum_id_tipo_doc = new System.Windows.Forms.Label();
            this.cbxIdTipoDoc = new System.Windows.Forms.ComboBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.alum_nombre = new System.Windows.Forms.Label();
            this.alum_apellido = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.alum_Titulo_Alta);
            this.panel3.Controls.Add(this.alum_volver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1158, 60);
            this.panel3.TabIndex = 0;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1103, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 27);
            this.button2.TabIndex = 4;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1025, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(976, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Idiomas";
            this.label3.Visible = false;
            this.alum_Titulo_Alta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.alum_Titulo_Alta.AutoSize = true;
            this.alum_Titulo_Alta.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alum_Titulo_Alta.Location = new System.Drawing.Point(104, 8);
            this.alum_Titulo_Alta.Name = "alum_Titulo_Alta";
            this.alum_Titulo_Alta.Size = new System.Drawing.Size(305, 46);
            this.alum_Titulo_Alta.TabIndex = 1;
            this.alum_Titulo_Alta.Text = "Lista de Precios";
            this.alum_volver.Location = new System.Drawing.Point(28, 12);
            this.alum_volver.Name = "alum_volver";
            this.alum_volver.Size = new System.Drawing.Size(91, 45);
            this.alum_volver.TabIndex = 0;
            this.alum_volver.Text = "Volver";
            this.alum_volver.UseVisualStyleBackColor = true;
            this.alum_volver.Visible = false;
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.alum_limpiar);
            this.panel5.Controls.Add(this.alum_guardar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 474);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1158, 75);
            this.panel5.TabIndex = 2;
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.Location = new System.Drawing.Point(643, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ver tabla";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.alum_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_limpiar.Location = new System.Drawing.Point(527, 6);
            this.alum_limpiar.Name = "alum_limpiar";
            this.alum_limpiar.Size = new System.Drawing.Size(91, 57);
            this.alum_limpiar.TabIndex = 1;
            this.alum_limpiar.Text = "Borrar";
            this.alum_limpiar.UseVisualStyleBackColor = true;
            this.alum_limpiar.Click += new System.EventHandler(this.alum_limpiar_Click);
            this.alum_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_guardar.Location = new System.Drawing.Point(414, 6);
            this.alum_guardar.Name = "alum_guardar";
            this.alum_guardar.Size = new System.Drawing.Size(91, 57);
            this.alum_guardar.TabIndex = 0;
            this.alum_guardar.Text = "Guardar";
            this.alum_guardar.UseVisualStyleBackColor = true;
            this.alum_guardar.Click += new System.EventHandler(this.alum_guardar_Click);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.alum_id_tipo_doc);
            this.groupBox2.Controls.Add(this.cbxIdTipoDoc);
            this.groupBox2.Controls.Add(this.txbPrecio);
            this.groupBox2.Controls.Add(this.alum_nombre);
            this.groupBox2.Controls.Add(this.alum_apellido);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(567, 142);
            this.groupBox2.TabIndex = 182;
            this.groupBox2.TabStop = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(214, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(314, 26);
            this.dateTimePicker1.TabIndex = 4;
            this.alum_id_tipo_doc.AutoSize = true;
            this.alum_id_tipo_doc.Location = new System.Drawing.Point(9, 43);
            this.alum_id_tipo_doc.Name = "alum_id_tipo_doc";
            this.alum_id_tipo_doc.Size = new System.Drawing.Size(171, 20);
            this.alum_id_tipo_doc.TabIndex = 0;
            this.alum_id_tipo_doc.Text = "Elemento de Catálogo:";
            this.cbxIdTipoDoc.FormattingEnabled = true;
            this.cbxIdTipoDoc.Location = new System.Drawing.Point(214, 35);
            this.cbxIdTipoDoc.Name = "cbxIdTipoDoc";
            this.cbxIdTipoDoc.Size = new System.Drawing.Size(314, 28);
            this.cbxIdTipoDoc.TabIndex = 3;
            this.txbPrecio.Location = new System.Drawing.Point(214, 103);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(314, 26);
            this.txbPrecio.TabIndex = 5;
            this.alum_nombre.AutoSize = true;
            this.alum_nombre.Location = new System.Drawing.Point(9, 77);
            this.alum_nombre.Name = "alum_nombre";
            this.alum_nombre.Size = new System.Drawing.Size(58, 20);
            this.alum_nombre.TabIndex = 1;
            this.alum_nombre.Text = "Fecha:";
            this.alum_apellido.AutoSize = true;
            this.alum_apellido.Location = new System.Drawing.Point(9, 110);
            this.alum_apellido.Name = "alum_apellido";
            this.alum_apellido.Size = new System.Drawing.Size(57, 20);
            this.alum_apellido.TabIndex = 2;
            this.alum_apellido.Text = "Precio:";
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(546, 371);
            this.dataGridView1.TabIndex = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1158, 414);
            this.tableLayoutPanel1.TabIndex = 1;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 385);
            this.panel1.TabIndex = 0;
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(582, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 408);
            this.panel2.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "frm13_ListaPrecios_1";
            this.Text = "frm13_ListaPrecios_1";
            this.Load += new System.EventHandler(this.frm13_ListaPrecios_1_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label alum_Titulo_Alta;
        private System.Windows.Forms.Button alum_volver;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button alum_limpiar;
        private System.Windows.Forms.Button alum_guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label alum_id_tipo_doc;
        private System.Windows.Forms.ComboBox cbxIdTipoDoc;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label alum_nombre;
        private System.Windows.Forms.Label alum_apellido;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}