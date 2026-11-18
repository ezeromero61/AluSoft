namespace AluSoft
{
    partial class frm02_Stock_1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.alum_id_tipo_doc = new System.Windows.Forms.Label();
            this.cbxIdTipoDoc = new System.Windows.Forms.ComboBox();
            this.txbCantMin = new System.Windows.Forms.TextBox();
            this.alum_nombre = new System.Windows.Forms.Label();
            this.txbCantActual = new System.Windows.Forms.TextBox();
            this.alum_apellido = new System.Windows.Forms.Label();
            this.alum_genero = new System.Windows.Forms.Label();
            this.txbCantMax = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.alum_Titulo_Alta = new System.Windows.Forms.Label();
            this.alum_volver = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            this.panel5.Controls.Add(this.af_tabla);
            this.panel5.Controls.Add(this.alum_limpiar);
            this.panel5.Controls.Add(this.alum_guardar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 474);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1242, 75);
            this.panel5.TabIndex = 2;
            this.af_tabla.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.af_tabla.AutoSize = true;
            this.af_tabla.Location = new System.Drawing.Point(700, 6);
            this.af_tabla.Name = "af_tabla";
            this.af_tabla.Size = new System.Drawing.Size(91, 57);
            this.af_tabla.TabIndex = 2;
            this.af_tabla.Text = "Ver tabla";
            this.af_tabla.UseVisualStyleBackColor = true;
            this.af_tabla.Click += new System.EventHandler(this.af_tabla_Click);
            this.alum_limpiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_limpiar.Location = new System.Drawing.Point(592, 6);
            this.alum_limpiar.Name = "alum_limpiar";
            this.alum_limpiar.Size = new System.Drawing.Size(91, 57);
            this.alum_limpiar.TabIndex = 1;
            this.alum_limpiar.Text = "Borrar";
            this.alum_limpiar.UseVisualStyleBackColor = true;
            this.alum_limpiar.Click += new System.EventHandler(this.alum_limpiar_Click);
            this.alum_guardar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.alum_guardar.Location = new System.Drawing.Point(479, 6);
            this.alum_guardar.Name = "alum_guardar";
            this.alum_guardar.Size = new System.Drawing.Size(91, 57);
            this.alum_guardar.TabIndex = 0;
            this.alum_guardar.Text = "Guardar";
            this.alum_guardar.UseVisualStyleBackColor = true;
            this.alum_guardar.Click += new System.EventHandler(this.alum_guardar_Click);
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.alum_id_tipo_doc);
            this.groupBox2.Controls.Add(this.cbxIdTipoDoc);
            this.groupBox2.Controls.Add(this.txbCantMin);
            this.groupBox2.Controls.Add(this.alum_nombre);
            this.groupBox2.Controls.Add(this.txbCantActual);
            this.groupBox2.Controls.Add(this.alum_apellido);
            this.groupBox2.Controls.Add(this.alum_genero);
            this.groupBox2.Controls.Add(this.txbCantMax);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(615, 408);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.alum_id_tipo_doc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alum_id_tipo_doc.AutoSize = true;
            this.alum_id_tipo_doc.Location = new System.Drawing.Point(21, 43);
            this.alum_id_tipo_doc.Name = "alum_id_tipo_doc";
            this.alum_id_tipo_doc.Size = new System.Drawing.Size(177, 20);
            this.alum_id_tipo_doc.TabIndex = 0;
            this.alum_id_tipo_doc.Text = "Elemento de Inventario:";
            this.cbxIdTipoDoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxIdTipoDoc.FormattingEnabled = true;
            this.cbxIdTipoDoc.Location = new System.Drawing.Point(278, 35);
            this.cbxIdTipoDoc.Name = "cbxIdTipoDoc";
            this.cbxIdTipoDoc.Size = new System.Drawing.Size(303, 28);
            this.cbxIdTipoDoc.TabIndex = 4;
            this.cbxIdTipoDoc.SelectedIndexChanged += new System.EventHandler(this.cbxIdTipoDoc_SelectedIndexChanged);
            this.txbCantMin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCantMin.Location = new System.Drawing.Point(278, 103);
            this.txbCantMin.Name = "txbCantMin";
            this.txbCantMin.Size = new System.Drawing.Size(303, 26);
            this.txbCantMin.TabIndex = 6;
            this.alum_nombre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alum_nombre.AutoSize = true;
            this.alum_nombre.Location = new System.Drawing.Point(21, 77);
            this.alum_nombre.Name = "alum_nombre";
            this.alum_nombre.Size = new System.Drawing.Size(126, 20);
            this.alum_nombre.TabIndex = 1;
            this.alum_nombre.Text = "Cantidad Actual:";
            this.txbCantActual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCantActual.Location = new System.Drawing.Point(278, 70);
            this.txbCantActual.Name = "txbCantActual";
            this.txbCantActual.Size = new System.Drawing.Size(303, 26);
            this.txbCantActual.TabIndex = 5;
            this.alum_apellido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alum_apellido.AutoSize = true;
            this.alum_apellido.Location = new System.Drawing.Point(21, 110);
            this.alum_apellido.Name = "alum_apellido";
            this.alum_apellido.Size = new System.Drawing.Size(131, 20);
            this.alum_apellido.TabIndex = 2;
            this.alum_apellido.Text = "Cantidad Mínima:";
            this.alum_genero.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alum_genero.AutoSize = true;
            this.alum_genero.Location = new System.Drawing.Point(21, 143);
            this.alum_genero.Name = "alum_genero";
            this.alum_genero.Size = new System.Drawing.Size(135, 20);
            this.alum_genero.TabIndex = 3;
            this.alum_genero.Text = "Cantidad Máxima:";
            this.txbCantMax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbCantMax.Location = new System.Drawing.Point(278, 136);
            this.txbCantMax.Name = "txbCantMax";
            this.txbCantMax.Size = new System.Drawing.Size(303, 26);
            this.txbCantMax.TabIndex = 7;
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.alum_Titulo_Alta);
            this.panel3.Controls.Add(this.alum_volver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1242, 60);
            this.panel3.TabIndex = 0;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1187, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 27);
            this.button2.TabIndex = 4;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1109, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Visible = false;
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1060, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Idiomas";
            this.label3.Visible = false;
            this.alum_Titulo_Alta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.alum_Titulo_Alta.AutoSize = true;
            this.alum_Titulo_Alta.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alum_Titulo_Alta.Location = new System.Drawing.Point(146, 8);
            this.alum_Titulo_Alta.Name = "alum_Titulo_Alta";
            this.alum_Titulo_Alta.Size = new System.Drawing.Size(296, 46);
            this.alum_Titulo_Alta.TabIndex = 1;
            this.alum_Titulo_Alta.Text = "Carga de Stock";
            this.alum_volver.Location = new System.Drawing.Point(28, 12);
            this.alum_volver.Name = "alum_volver";
            this.alum_volver.Size = new System.Drawing.Size(91, 45);
            this.alum_volver.TabIndex = 0;
            this.alum_volver.Text = "Volver";
            this.alum_volver.UseVisualStyleBackColor = true;
            this.alum_volver.Visible = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(603, 398);
            this.dataGridView1.TabIndex = 0;
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(624, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 408);
            this.panel1.TabIndex = 1;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1242, 414);
            this.tableLayoutPanel1.TabIndex = 1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1242, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Name = "frm02_Stock_1";
            this.Text = "frm02_Stock_1";
            this.Load += new System.EventHandler(this.frm02_Stock_1_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button alum_limpiar;
        private System.Windows.Forms.Button alum_guardar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label alum_id_tipo_doc;
        private System.Windows.Forms.ComboBox cbxIdTipoDoc;
        private System.Windows.Forms.TextBox txbCantMin;
        private System.Windows.Forms.Label alum_nombre;
        private System.Windows.Forms.TextBox txbCantActual;
        private System.Windows.Forms.Label alum_apellido;
        private System.Windows.Forms.Label alum_genero;
        private System.Windows.Forms.TextBox txbCantMax;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label alum_Titulo_Alta;
        private System.Windows.Forms.Button alum_volver;
        private System.Windows.Forms.DataGridView dataGridView1;
        internal System.Windows.Forms.Button af_tabla;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}