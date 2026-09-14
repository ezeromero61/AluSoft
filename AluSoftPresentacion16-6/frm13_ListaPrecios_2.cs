using BLL;
using System;
using System.Collections;
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
    public partial class frm13_ListaPrecios_2 : Form
    {
        public frm13_ListaPrecios_2()
        {
            InitializeComponent();
        }
        BE.cls13_ListaPrecios lpre;
        BLL.ListaPrecios glpre = new BLL.ListaPrecios();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        private void frm13_ListaPrecios_2_Load(object sender, EventArgs e)
        {
            #region Lista Precios
            lpre = new BE.cls13_ListaPrecios();
            cbxIListaPrecio.DataSource = glpre.ListarCatalogo2();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIListaPrecio.DisplayMember = "Combo";
            cbxIListaPrecio.ValueMember = "IdCatalogo";
            cbxIListaPrecio.Text = null;
            #endregion
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbxIListaPrecio.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = glpre.Consultar(lpre, val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = glpre.ListarCatalogo2();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
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

        private void af_buscar_Click(object sender, EventArgs e)
        {
            int val = int.Parse(cbxIListaPrecio.SelectedValue.ToString());
            if (val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                glpre.Consultar(lpre, val);

                cbxIdCatalogo.Text= lpre.Idcatalogo.ToString();
                cbxIListaPrecio.SelectedValue= lpre.Idlista;
                dateTimePicker1.Text= lpre.Fecha.ToString();
                txbPrecio.Text= lpre.Precio.ToString();
                #endregion 
                dataGridView1.DataSource = glpre.ListarCatalogo2();
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            lpre = new BE.cls13_ListaPrecios();
            lpre.Idcatalogo = Convert.ToInt32(cbxIdCatalogo.Text);
            lpre.Idlista = Convert.ToInt32(cbxIListaPrecio.Text);
            lpre.Fecha = DateTime.Parse(dateTimePicker1.Text);
            lpre.Precio = int.Parse(txbPrecio.Text);
            fa = glpre.Editar(lpre);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 14;
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
                MessageBox.Show("Se han eliminado " + glpre.Eliminar(lpre) + " filas");
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
    }
}
