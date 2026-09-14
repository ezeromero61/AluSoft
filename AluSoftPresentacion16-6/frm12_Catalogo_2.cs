using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    public partial class frm12_Catalogo_2 : Form
    {
        public frm12_Catalogo_2()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls01_Inventario inventario;
        BLL.Inventario ginv = new BLL.Inventario();
        private void af_tabla_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbxIdCatalogo.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = gcatalogo.Consultar(catalogo, val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = gcatalogo.Listar2();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
            }
        }

        private void frm12_Catalogo_2_Load(object sender, EventArgs e)
        {
            #region Inventario
            catalogo = new BE.cls12_Catalogo();
            cbxIdCatalogo.DataSource = gcatalogo.Listar2();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdCatalogo.DisplayMember = "Nombre";
            cbxIdCatalogo.ValueMember = "IdCatalogo";
            cbxIdCatalogo.Text = null;
            #endregion
        }

        private void af_buscar_Click(object sender, EventArgs e)
        {
            int val = int.Parse(cbxIdCatalogo.SelectedValue.ToString());
            if (val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                gcatalogo.Consultar(catalogo, val);

                txbPrecioUnitario.Text = (catalogo.Preciounitario.ToString());
                txbDisponibilidad.Text = catalogo.Disponibilidad.ToString();
                txbCantidad.Text = catalogo.Cantidad.ToString();
                #endregion 
                dataGridView1.DataSource = gcatalogo.Listar2();
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            catalogo = new BE.cls12_Catalogo();

            catalogo.Preciounitario = int.Parse(txbPrecioUnitario.Text);
            catalogo.Disponibilidad = txbDisponibilidad.Text;
            catalogo.Cantidad = int.Parse(txbCantidad.Text);
            fa = gcatalogo.Editar(catalogo);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 13;
                bitacora.idaccion = 1;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = Convert.ToDateTime(DateTime.Now.TimeOfDay);
                fa = gbitacora.Agregar(bitacora);
                #endregion
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Comprobar el resultado del cuadro de mensaje
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Se han eliminado " + gcatalogo.Eliminar(catalogo) + " filas");
                foreach (Control controles in groupBox2.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                    }
                }
                foreach (Control controles in groupBox1.Controls)
                {
                    if (controles is System.Windows.Forms.TextBox)
                    {
                        System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                        texbox.Text = string.Empty;
                    }
                    else if (controles is System.Windows.Forms.ComboBox)
                    {
                        System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                        cbx.Text = string.Empty;
                        cbx.SelectedValue = 0;
                    }
                }
                dataGridView1.DataSource = null;
            }
            else
            {
            }
        }

        private void af_limpiar_Click(object sender, EventArgs e)
        {
            foreach (Control controles in groupBox2.Controls)
            {
                if (controles is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                    texbox.Text = string.Empty;
                }
                else if (controles is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                    cbx.Text = string.Empty;
                }
            }
            foreach (Control controles in groupBox1.Controls)
            {
                if (controles is System.Windows.Forms.TextBox)
                {
                    System.Windows.Forms.TextBox texbox = (System.Windows.Forms.TextBox)controles;
                    texbox.Text = string.Empty;
                }
                else if (controles is System.Windows.Forms.ComboBox)
                {
                    System.Windows.Forms.ComboBox cbx = (System.Windows.Forms.ComboBox)controles;
                    cbx.Text = string.Empty;
                    cbx.SelectedValue = 0;
                }
            }
            dataGridView1.DataSource = null;
        }
    }
}
