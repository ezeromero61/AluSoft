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
    public partial class frm16_PedidoReaprovisionamiento_2 : Form
    {
        public frm16_PedidoReaprovisionamiento_2()
        {
            InitializeComponent();
        }
        BE.cls00_Persona persona;
        BLL.Persona gpersona = new BLL.Persona();
        BE.cls04_Proveedor prov;
        BLL.Proveedor gprov = new BLL.Proveedor();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls16_PedidoReaprovisionamiento reaprov;
        BLL.PedidoReaprovisionamiento greaprov = new BLL.PedidoReaprovisionamiento();
        private void frm16_PedidoReaprovisionamiento_2_Load(object sender, EventArgs e)
        {
            prov = new BE.cls04_Proveedor();
            reaprov = new BE.cls16_PedidoReaprovisionamiento();
            #region Presupuesto cliente
            cbxIdPedidoReaprovionamiento.DataSource = greaprov.ListarCatalogo2();
            cbxIdPedidoReaprovionamiento.DisplayMember = "Combo";
            cbxIdPedidoReaprovionamiento.ValueMember = "IdPedidoReaprovisionamiento";
            cbxIdPedidoReaprovionamiento.Text = null;
            #endregion
            //#region Presupuesto cliente
            //cbxIdProveedor.DataSource = greaprov.ListarCatalogo2();
            //cbxIdProveedor.DisplayMember = "NombreEmpresa";
            //cbxIdProveedor.ValueMember = "IdPedidoReaprovisionamiento";
            //cbxIdProveedor.Text = null;
            //#endregion
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbxIdPedidoReaprovionamiento.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = greaprov.Consultar(reaprov, val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = greaprov.ListarCatalogo2();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
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
            int val = int.Parse(cbxIdPedidoReaprovionamiento.SelectedValue.ToString());
            if (val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                greaprov.Consultar(reaprov, val);
                cbxIdProveedor.Text = (reaprov.Idproveedor.ToString());
                dateTimePicker2.Text = reaprov.Fechapedido.ToString();
                dateTimePicker3.Text = reaprov.Fechaentregaestimada.ToString();
                dateTimePicker1.Text = reaprov.Fechaentregareal.ToString();
                txbEstado.Text = reaprov.Estado;
                txbPrioridad.Text = reaprov.Prioridad.ToString();
                txbObservaciones.Text = reaprov.Observaciones.ToString();
                #endregion 
                dataGridView1.DataSource = greaprov.ListarCatalogo2();
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            int fa = 0;
            reaprov = new BE.cls16_PedidoReaprovisionamiento();
            reaprov.Idpedidoreaprovisionamiento = int.Parse(cbxIdPedidoReaprovionamiento.ValueMember.ToString());
            reaprov.Idproveedor = int.Parse(cbxIdProveedor.ValueMember);
            reaprov.Fechapedido = DateTime.Parse(dateTimePicker1.Text);
            reaprov.Fechaentregaestimada = DateTime.Parse(dateTimePicker2.Text);
            reaprov.Fechaentregareal = DateTime.Parse(dateTimePicker3.Text);
            reaprov.Estado = txbEstado.Text;
            reaprov.Prioridad = (txbPrioridad.Text);
            reaprov.Observaciones = (txbObservaciones.Text);
            reaprov.Idlogin = clsPerdurables.Id_Login;
            reaprov.DigitoVerificador = 1;
            fa = greaprov.Editar(reaprov);

            if (fa != 0)
            {
                MessageBox.Show("Se agregaron " + fa + " filas.");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 3;
                bitacora.idaccion = 1;
                bitacora.fecha = (DateTime.Now);
                bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
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
                MessageBox.Show("Se han eliminado " + greaprov.Eliminar(reaprov) + " filas");
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
