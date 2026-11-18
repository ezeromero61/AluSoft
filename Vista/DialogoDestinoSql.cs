using System;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    // Ventana para elegir el servidor y la base de datos de destino (los controles están en el diseño).
    public sealed partial class DialogoDestinoSql : Form
    {
        public DialogoDestinoSql()
        {
            InitializeComponent();
            txtBaseDatos.Text = BLL.Conexion.BaseDeDatos;
        }

        public string Servidor
        {
            get { return txtServidor.Text.Trim(); }
        }

        public string BaseDatos
        {
            get { return txtBaseDatos.Text.Trim(); }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServidor.Text))
            {
                MessageBox.Show("Ingresá el servidor o la instancia de SQL Server.");
                txtServidor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBaseDatos.Text))
            {
                MessageBox.Show("Ingresá el nombre de la base de datos.");
                txtBaseDatos.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
