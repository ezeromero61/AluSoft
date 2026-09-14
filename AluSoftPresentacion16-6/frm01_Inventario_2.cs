using BE;
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
    public partial class frm01_Inventario_2 : Form
    {
        public frm01_Inventario_2()
        {
            InitializeComponent();
        }
        BE.cls01_Inventario inv;
        BLL.Inventario ginv = new BLL.Inventario();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        private void frm01_Inventario_2_Load(object sender, EventArgs e)
        {
            #region Inventario
            inv = new BE.cls12_Catalogo();
            cbxIdInventario.DataSource = ginv.ListarCatalogo();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdInventario.DisplayMember = "Nombre";
            cbxIdInventario.ValueMember = "IdInventario";
            cbxIdInventario.Text = null;
            #endregion
        }

        private void af_buscar_Click(object sender, EventArgs e)
        {
            int val=int.Parse(cbxIdInventario.SelectedValue.ToString());
            if ( val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                ginv.Consultar(inv,val);
                txbNombre.Text = inv.Nombre;
                txbDescripcion.Text=inv.Descripcion;
                txbTipo.Text = inv.Tipo;
                txbAlto.Text=Convert.ToString(inv.Alto);
                txbLargo.Text= Convert.ToString(inv.Largo);
                txtAncho.Text = Convert.ToString(inv.Ancho);
                txbMaterial.Text = inv.Material;
                txbColor.Text = inv.Color;
                #endregion 
                dataGridView1.DataSource = ginv.Consultar(inv, val);
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

        private void af_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este elemento?. Are you sure you want to delete this item?. Êtes-vous sûr de vouloir supprimer cet élément ?", "Confirmar eliminación. Confirm delete. Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // Comprobar el resultado del cuadro de mensaje
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Se han eliminado "+ginv.Eliminar(inv)+" filas");
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
            }
            else
            {
            }
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {           
            int val = Convert.ToInt32(cbxIdInventario.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = ginv.Consultar(inv,val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = ginv.ListarCatalogo();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            inv = new BE.cls01_Inventario();
            inv.Idinventario = int.Parse(cbxIdInventario.SelectedValue.ToString());
            inv.Nombre = txbNombre.Text;
            inv.Descripcion = (txbDescripcion.Text);
            inv.Tipo = (txbTipo.Text);
            inv.Alto = int.Parse(txbAlto.Text);
            inv.Largo = int.Parse(txbLargo.Text);
            inv.Ancho = int.Parse(txtAncho.Text);
            inv.Material = txbMaterial.Text;
            inv.Color = (txbColor.Text);
            fa = ginv.Editar(inv);
            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 2;
                bitacora.idaccion = 2;
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
    }
}
