namespace AluSoftPresentacion16_6
{
    partial class frm35_Bitacora
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bita_titulo = new System.Windows.Forms.Label();
            this.bita_volver = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.bita_exportar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bita_buscar_accion = new System.Windows.Forms.Button();
            this.bita_id_accion = new System.Windows.Forms.Label();
            this.cbxIdAccion = new System.Windows.Forms.ComboBox();
            this.bita_id_login = new System.Windows.Forms.Label();
            this.cbxIdBitacora = new System.Windows.Forms.ComboBox();
            this.bita_id_bitacora = new System.Windows.Forms.Label();
            this.cbxIdLogin = new System.Windows.Forms.ComboBox();
            this.bita_id_tabla = new System.Windows.Forms.Label();
            this.cbxIdTabla = new System.Windows.Forms.ComboBox();
            this.bita_limpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.bita_titulo);
            this.panel3.Controls.Add(this.bita_volver);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(973, 78);
            this.panel3.TabIndex = 179;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(920, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 28);
            this.button2.TabIndex = 189;
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
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 140;
            this.label1.Text = "Idiomas";
            this.label1.Visible = false;
            // 
            // bita_titulo
            // 
            this.bita_titulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bita_titulo.AutoSize = true;
            this.bita_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bita_titulo.Location = new System.Drawing.Point(12, 15);
            this.bita_titulo.Name = "bita_titulo";
            this.bita_titulo.Size = new System.Drawing.Size(168, 46);
            this.bita_titulo.TabIndex = 137;
            this.bita_titulo.Text = "Bitácora";
            // 
            // bita_volver
            // 
            this.bita_volver.Location = new System.Drawing.Point(30, 12);
            this.bita_volver.Name = "bita_volver";
            this.bita_volver.Size = new System.Drawing.Size(91, 57);
            this.bita_volver.TabIndex = 49;
            this.bita_volver.Text = "Volver";
            this.bita_volver.UseVisualStyleBackColor = true;
            this.bita_volver.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.bita_exportar);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.bita_limpiar);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 453);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(973, 136);
            this.panel5.TabIndex = 180;
            // 
            // bita_exportar
            // 
            this.bita_exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bita_exportar.Location = new System.Drawing.Point(860, 78);
            this.bita_exportar.Name = "bita_exportar";
            this.bita_exportar.Size = new System.Drawing.Size(91, 47);
            this.bita_exportar.TabIndex = 53;
            this.bita_exportar.Text = "Exportar";
            this.bita_exportar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bita_buscar_accion);
            this.groupBox1.Controls.Add(this.bita_id_accion);
            this.groupBox1.Controls.Add(this.cbxIdAccion);
            this.groupBox1.Controls.Add(this.bita_id_login);
            this.groupBox1.Controls.Add(this.cbxIdBitacora);
            this.groupBox1.Controls.Add(this.bita_id_bitacora);
            this.groupBox1.Controls.Add(this.cbxIdLogin);
            this.groupBox1.Controls.Add(this.bita_id_tabla);
            this.groupBox1.Controls.Add(this.cbxIdTabla);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 125);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(451, 68);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(141, 23);
            this.dateTimePicker2.TabIndex = 53;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(141, 67);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(141, 23);
            this.dateTimePicker1.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 17);
            this.label3.TabIndex = 51;
            this.label3.Text = "Fecha Final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Fecha Inicial:";
            // 
            // bita_buscar_accion
            // 
            this.bita_buscar_accion.Location = new System.Drawing.Point(722, 51);
            this.bita_buscar_accion.Name = "bita_buscar_accion";
            this.bita_buscar_accion.Size = new System.Drawing.Size(75, 36);
            this.bita_buscar_accion.TabIndex = 49;
            this.bita_buscar_accion.Text = "Buscar";
            this.bita_buscar_accion.UseVisualStyleBackColor = true;
            this.bita_buscar_accion.Click += new System.EventHandler(this.bita_buscar_accion_Click);
            // 
            // bita_id_accion
            // 
            this.bita_id_accion.AutoSize = true;
            this.bita_id_accion.Location = new System.Drawing.Point(325, 48);
            this.bita_id_accion.Name = "bita_id_accion";
            this.bita_id_accion.Size = new System.Drawing.Size(93, 17);
            this.bita_id_accion.TabIndex = 47;
            this.bita_id_accion.Text = "ID_ACCCION:";
            // 
            // cbxIdAccion
            // 
            this.cbxIdAccion.FormattingEnabled = true;
            this.cbxIdAccion.Location = new System.Drawing.Point(451, 43);
            this.cbxIdAccion.Name = "cbxIdAccion";
            this.cbxIdAccion.Size = new System.Drawing.Size(141, 24);
            this.cbxIdAccion.TabIndex = 48;
            // 
            // bita_id_login
            // 
            this.bita_id_login.AutoSize = true;
            this.bita_id_login.Location = new System.Drawing.Point(15, 48);
            this.bita_id_login.Name = "bita_id_login";
            this.bita_id_login.Size = new System.Drawing.Size(76, 17);
            this.bita_id_login.TabIndex = 38;
            this.bita_id_login.Text = "ID_LOGIN:";
            // 
            // cbxIdBitacora
            // 
            this.cbxIdBitacora.FormattingEnabled = true;
            this.cbxIdBitacora.Location = new System.Drawing.Point(141, 16);
            this.cbxIdBitacora.Name = "cbxIdBitacora";
            this.cbxIdBitacora.Size = new System.Drawing.Size(141, 24);
            this.cbxIdBitacora.TabIndex = 33;
            // 
            // bita_id_bitacora
            // 
            this.bita_id_bitacora.AutoSize = true;
            this.bita_id_bitacora.BackColor = System.Drawing.Color.Transparent;
            this.bita_id_bitacora.Location = new System.Drawing.Point(15, 24);
            this.bita_id_bitacora.Name = "bita_id_bitacora";
            this.bita_id_bitacora.Size = new System.Drawing.Size(102, 17);
            this.bita_id_bitacora.TabIndex = 34;
            this.bita_id_bitacora.Text = "ID_BITACORA:";
            // 
            // cbxIdLogin
            // 
            this.cbxIdLogin.FormattingEnabled = true;
            this.cbxIdLogin.Location = new System.Drawing.Point(141, 41);
            this.cbxIdLogin.Name = "cbxIdLogin";
            this.cbxIdLogin.Size = new System.Drawing.Size(141, 24);
            this.cbxIdLogin.TabIndex = 35;
            // 
            // bita_id_tabla
            // 
            this.bita_id_tabla.AutoSize = true;
            this.bita_id_tabla.Location = new System.Drawing.Point(324, 24);
            this.bita_id_tabla.Name = "bita_id_tabla";
            this.bita_id_tabla.Size = new System.Drawing.Size(77, 17);
            this.bita_id_tabla.TabIndex = 36;
            this.bita_id_tabla.Text = "ID_TABLA:";
            // 
            // cbxIdTabla
            // 
            this.cbxIdTabla.FormattingEnabled = true;
            this.cbxIdTabla.Location = new System.Drawing.Point(451, 17);
            this.cbxIdTabla.Name = "cbxIdTabla";
            this.cbxIdTabla.Size = new System.Drawing.Size(141, 24);
            this.cbxIdTabla.TabIndex = 37;
            // 
            // bita_limpiar
            // 
            this.bita_limpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bita_limpiar.Location = new System.Drawing.Point(860, 19);
            this.bita_limpiar.Name = "bita_limpiar";
            this.bita_limpiar.Size = new System.Drawing.Size(91, 47);
            this.bita_limpiar.TabIndex = 51;
            this.bita_limpiar.Text = "Limpiar";
            this.bita_limpiar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(949, 342);
            this.dataGridView1.TabIndex = 181;
            // 
            // frm35_Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 589);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Name = "frm35_Bitacora";
            this.Text = "frm35_Bitacora";
            this.Load += new System.EventHandler(this.frm35_Bitacora_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bita_titulo;
        private System.Windows.Forms.Button bita_volver;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button bita_exportar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bita_buscar_accion;
        private System.Windows.Forms.Label bita_id_accion;
        private System.Windows.Forms.ComboBox cbxIdAccion;
        private System.Windows.Forms.Label bita_id_login;
        private System.Windows.Forms.ComboBox cbxIdBitacora;
        private System.Windows.Forms.Label bita_id_bitacora;
        private System.Windows.Forms.ComboBox cbxIdLogin;
        private System.Windows.Forms.Label bita_id_tabla;
        private System.Windows.Forms.ComboBox cbxIdTabla;
        private System.Windows.Forms.Button bita_limpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}