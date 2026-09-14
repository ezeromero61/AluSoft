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
    public partial class frm07_PresupuestoCliente_2 : Form
    {
        public frm07_PresupuestoCliente_2()
        {
            InitializeComponent();
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls03_Cliente cliente;
        BLL.Cliente gcliente = new BLL.Cliente();
        BE.cls12_Catalogo catalogo;
        BLL.Catalogo gcatalogo = new BLL.Catalogo();
        BE.cls07_PresupuestoCliente presupuesto;
        BLL.PresupuestroCliente gpresupuesto = new BLL.PresupuestroCliente();
        BE.cls26_Combinado combinado;
        private void frm07_PresupuestoCliente_2_Load(object sender, EventArgs e)
        {
            combinado = new BE.cls26_Combinado();

            #region Presupuesto cliente
            presupuesto = new BE.cls07_PresupuestoCliente();
            cbxIdPresupuestoCliente.DataSource = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuestoCliente.DisplayMember = "Combo";
            cbxIdPresupuestoCliente.ValueMember = "IdPresupuesto";
            cbxIdPresupuestoCliente.Text = null;
            #endregion
            #region Catalogo
            catalogo = new BE.cls12_Catalogo();
            cbxIdCatalogo.DataSource = gpresupuesto.ListarCatalogo2();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdCatalogo.DisplayMember = "NombreInventario";
            cbxIdCatalogo.ValueMember = "IdCatalogo";
            cbxIdCatalogo.Text = null;
            #endregion
            #region Cliente
            cliente = new BE.cls03_Cliente();
            cbxIdCliente.DataSource = gpresupuesto.ListarCatalogo2();//generica.cargarComboint("Obtener_21_IdTipoDoc");
            cbxIdCliente.DisplayMember = "Apellido";
            cbxIdCliente.ValueMember = "IdCliente";
            cbxIdCliente.Text = null;
            #endregion

        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            int val = Convert.ToInt32(cbxIdPresupuestoCliente.SelectedValue);
            if (val != 0)
            {
                dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);//asistencia_alumnos.ListaAsistenciaAlumnosPorId(Convert.ToInt32(cbxIDasistencia.Text));
            }
            else
            {
                dataGridView1.DataSource = gpresupuesto.ListarCatalogo();//asistencia_alumnos.ListaAsistenciaAlumnosSinId();
            }
        }

        private void af_buscar_Click(object sender, EventArgs e)
        {
            int val = int.Parse(cbxIdPresupuestoCliente.SelectedValue.ToString());
            if (val == 0)
            {
                MessageBox.Show("No existe registro para ese Alumno");
            }
            else
            {
                #region 07_Asistencias_Alumnos
                gpresupuesto.Consultar2(combinado, val);

                cbxIdCliente.Text=(combinado.Idcliente.ToString());
                cbxIdCatalogo.Text=combinado.IdCatalogo.ToString();
                txbFechaCreacion.Text = combinado.FechaCreacion.ToString();
                txbEstado.Text = combinado.Estado;
                txbObservaciones.Text = combinado.Observaciones;
                txbDescuento.Text = combinado.Descuento.ToString();
                txbTotal.Text = combinado.Total.ToString();
                txbPlazoEntrega.Text = combinado.PlazoEntregaDias.ToString();
                txbFechaValidez.Text = combinado.FechaValidez.ToString();
                txbDescripcion.Text = combinado.Descripcion;
                txbSubtotal.Text = combinado.Subtotal.ToString();
                txbImpuestos.Text = combinado.Impuestos.ToString();
                txbFormaPago.Text = combinado.FormaPago;
                #endregion 
                dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
            }
        }

        private void af_modificar_Click(object sender, EventArgs e)
        {
            presupuesto = new BE.cls07_PresupuestoCliente();
            int fa = 0;
            presupuesto.Idpresupuesto = (gpresupuesto.Max(presupuesto) + 1);
            presupuesto.Idcliente = Convert.ToInt32(cbxIdCliente.SelectedValue);
            presupuesto.Idcatalogo = Convert.ToInt32(cbxIdCatalogo.SelectedValue);
            presupuesto.FechaCreacion = DateTime.Parse(txbFechaCreacion.Text);
            presupuesto.FechaValidez = DateTime.Parse(txbFechaValidez.Text);
            presupuesto.Estado = (txbEstado.Text);
            presupuesto.Descripcion = (txbDescripcion.Text);
            presupuesto.Observaciones = txbObservaciones.Text;
            presupuesto.Subtotal = int.Parse(txbSubtotal.Text);
            presupuesto.Descuento = int.Parse(txbDescuento.Text);
            presupuesto.Impuestos = int.Parse(txbImpuestos.Text);
            presupuesto.Total = int.Parse(txbTotal.Text);
            presupuesto.FormaPago = (txbFormaPago.Text);
            presupuesto.PlazoEntregaDias = int.Parse(txbPlazoEntrega.Text);
            presupuesto.Idlogin = clsPerdurables.Id_Login;
            fa = gpresupuesto.Editar(presupuesto);

            if (fa != 0)
            {
                MessageBox.Show("Se agrego");
                #region Bitacora 
                bitacora = new BE.cls35_Bitacora();
                bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
                bitacora.idlogin = clsPerdurables.Id_Login;
                bitacora.idtabla = 8;
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
                MessageBox.Show("Se han eliminado " + gpresupuesto.Eliminar(presupuesto) + " filas");
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
