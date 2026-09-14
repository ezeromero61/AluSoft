using BE;
using BLL;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    public partial class frm35_Bitacora : Form
    {
        public frm35_Bitacora()
        {
            InitializeComponent();
        }

        BE.cls01_Inventario inv;
        BLL.Inventario ginv = new BLL.Inventario();
        BE.cls35_Bitacora bita;
        BLL.Bitacora gbita = new BLL.Bitacora();

        private void bita_buscar_accion_Click(object sender, EventArgs e)
        {
            switch (clsPerdurables.selector_en_informes)
            {
                case 1:
                    if (!string.IsNullOrEmpty(cbxIdBitacora.Text))
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = gbita.ListarCatalogo();

                        cls35_Bitacora bitacora = new cls35_Bitacora
                        {
                            idbitacora = gbita.Max(new cls35_Bitacora()),
                            idlogin = clsPerdurables.Id_Login,
                            idtabla = 26,
                            idaccion = 4,
                            fecha = DateTime.Now,
                            hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"))
                        };

                        gbita.Agregar(bitacora);
                        MessageBox.Show("Registro agregado en Bitácora");
                    }
                    break;

                case 2:
                    if (!string.IsNullOrEmpty(cbxIdLogin.Text))
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = gbita.ListarCatalogo();

                        cls35_Bitacora bitacora = new cls35_Bitacora
                        {
                            idbitacora = gbita.Max(new cls35_Bitacora()),
                            idlogin = clsPerdurables.Id_Login,
                            idtabla = 26,
                            idaccion = 4,
                            fecha = DateTime.Now,
                            hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"))
                        };

                        gbita.Agregar(bitacora);
                        MessageBox.Show("Registro agregado en Bitácora");
                    }
                    break;

                case 3:
                    if (!string.IsNullOrEmpty(cbxIdTabla.Text))
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = gbita.ListarCatalogo();

                        cls35_Bitacora bitacora = new cls35_Bitacora
                        {
                            idbitacora = gbita.Max(new cls35_Bitacora()),
                            idlogin = clsPerdurables.Id_Login,
                            idtabla = 26,
                            idaccion = 4,
                            fecha = DateTime.Now,
                            hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"))
                        };

                        gbita.Agregar(bitacora);
                        MessageBox.Show("Registro agregado en Bitácora");
                    }
                    break;

                case 4:
                    if (!string.IsNullOrEmpty(cbxIdAccion.Text))
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = gbita.ListarCatalogo();

                        cls35_Bitacora bitacora = new cls35_Bitacora
                        {
                            idbitacora = gbita.Max(new cls35_Bitacora()),
                            idlogin = clsPerdurables.Id_Login,
                            idtabla = 26,
                            idaccion = 4,
                            fecha = DateTime.Now,
                            hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"))
                        };

                        gbita.Agregar(bitacora);
                        MessageBox.Show("Registro agregado en Bitácora");
                    }
                    break;
            }
        }

        private async void frm35_Bitacora_Load(object sender, EventArgs e)
        {
            // Cargar datos en segundo plano para no congelar la UI
            var datos = await Task.Run(() => gbita.ListarCompleto());

            cbxIdAccion.DataSource = datos;
            cbxIdAccion.DisplayMember = "NombreAccion";
            cbxIdAccion.ValueMember = "IdAccion";
            cbxIdAccion.Text = null;

            cbxIdLogin.DataSource = datos;
            cbxIdLogin.DisplayMember = "Usuario";
            cbxIdLogin.ValueMember = "IdLogin";
            cbxIdLogin.Text = null;

            cbxIdTabla.DataSource = datos;
            cbxIdTabla.DisplayMember = "NombreTabla";
            cbxIdTabla.ValueMember = "IdTabla";
            cbxIdTabla.Text = null;

            cbxIdBitacora.DataSource = datos;
            cbxIdBitacora.DisplayMember = "IdBitacora";
            cbxIdBitacora.ValueMember = "IdBitacora";
            cbxIdBitacora.Text = null;
        }
    }
}
