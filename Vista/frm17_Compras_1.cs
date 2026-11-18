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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AluSoftPresentacion16_6
{
    public partial class frm17_Compras_1 : Form
    {
        public frm17_Compras_1()
        {
            InitializeComponent();
        }
        private int idPedidoInicial;
        public frm17_Compras_1(int idPedido) : this()
        {
            idPedidoInicial = idPedido;
        }
        private ComboBox cbxPedido;
        private BE.cls16_PedidoReaprovisionamiento pedidoSeleccionado;

        // Agrega arriba del formulario el combo para elegir el pedido de reaprovisionamiento.
        private void CrearComboPedido()
        {
            foreach (Control c in groupBox2.Controls) c.Top += 36;
            groupBox2.Height += 36;
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Text = "Pedido:";
            lbl.Location = new System.Drawing.Point(15, 29);
            cbxPedido = new ComboBox();
            cbxPedido.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPedido.Location = new System.Drawing.Point(cbxIdStock.Left, 21);
            cbxPedido.Width = cbxIdStock.Width;
            cbxPedido.DropDownWidth = 420;
            groupBox2.Controls.Add(lbl);
            groupBox2.Controls.Add(cbxPedido);
            af_id_alumno.Text = "Producto:";

            List<BE.cls16_PedidoReaprovisionamiento> pedidos = new BLL.PedidoReaprovisionamiento().ListarCatalogo2();
            cbxPedido.DataSource = pedidos;
            cbxPedido.DisplayMember = "Combo";
            cbxPedido.ValueMember = "Idpedidoreaprovisionamiento";
            cbxPedido.SelectedIndex = -1;
            cbxPedido.SelectedIndexChanged += delegate { CargarDesdePedido(); };
        }

        private void CargarDesdePedido()
        {
            pedidoSeleccionado = cbxPedido.SelectedItem as BE.cls16_PedidoReaprovisionamiento;
            if (pedidoSeleccionado == null) return;
            if (pedidoSeleccionado.Idstock > 0) cbxIdStock.SelectedValue = pedidoSeleccionado.Idstock;
            txbCantidad.Text = pedidoSeleccionado.Cantidad.ToString();
            txbSubtotal.Text = pedidoSeleccionado.Subtotal.ToString();
            txbTotal.Text = pedidoSeleccionado.Total.ToString();
        }
        BE.cls17_Compras compras;
        BLL.Compras gcompras = new BLL.Compras();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls02_Stock stock;
        BLL.Stock gstock = new BLL.Stock();
        #region Auxiliares
        private List<BE.cls02_Stock> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void CargarBitacora(int tabla, int accion)
        {
            #region Bitacora 
            int fu;
            bitacora = new BE.cls35_Bitacora();
            bitacora.idbitacora = (gbitacora.Max(bitacora) + 1);
            bitacora.idlogin = clsPerdurables.Id_Login;
            bitacora.idtabla = tabla;
            bitacora.idaccion = accion;
            bitacora.fecha = (DateTime.Now);
            bitacora.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
            fu = gbitacora.Agregar(bitacora);
            #endregion
        }
        private void LimpiarControles(Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                    ((ComboBox)control).Text = "";
                }
                else if (control is System.Windows.Forms.CheckBox)
                {
                    ((System.Windows.Forms.CheckBox)control).Checked = false;
                }
                else if (control is System.Windows.Forms.RadioButton)
                {
                    ((System.Windows.Forms.RadioButton)control).Checked = false;
                }
                else if (control is DateTimePicker)
                {
                    ((DateTimePicker)control).Value = DateTime.Today;
                }
                else if (control is NumericUpDown)
                {
                    NumericUpDown numeric = (NumericUpDown)control;
                    numeric.Value = numeric.Minimum;
                }
                else if (control is DataGridView)
                {
                    ((DataGridView)control).DataSource = null;
                }
                if (control.HasChildren)
                {
                    LimpiarControles(control);
                }
            }
        }
        private void CargarCombo()
        {
            listaPersonasOriginal = gstock.ListarCatalogo2();
            cbxIdStock.DataSource = listaPersonasOriginal;
            cbxIdStock.DisplayMember = "Combo";
            cbxIdStock.ValueMember = "IdStock";
            cbxIdStock.SelectedIndex = -1;
            cbxIdStock.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!global::AluSoft.UI.ValidacionCampos.Validar(this)) return;
                int fa = 0;
                compras = new BE.cls17_Compras();
                compras.Idcompras = (gcompras.Max(compras)+1);
                compras.Idstock = int.Parse(cbxIdStock.SelectedValue.ToString());
                compras.Cantidad = int.Parse(txbCantidad.Text);
                compras.Fecha = DateTime.Parse(dateTimePicker1.Text);
                compras.Subtotal = int.Parse(txbSubtotal.Text);
                compras.Total = int.Parse(txbTotal.Text);
                if (pedidoSeleccionado != null)
                {
                    compras.IdProveedor = pedidoSeleccionado.Idproveedor;
                    compras.IdPedidoReaprovisionamiento = pedidoSeleccionado.Idpedidoreaprovisionamiento;
                }
                fa = gcompras.Agregar(compras);
                if (fa != 0)
                {
                    MessageBox.Show("Compra N° " + compras.Idcompras + " registrada.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(18,1);
                    if (pedidoSeleccionado != null)
                    {
                        new BLL.PedidoReaprovisionamiento().ActualizarEstado(pedidoSeleccionado.Idpedidoreaprovisionamiento, "Comprado");
                        if (global::AluSoft.UI.Navegacion.Preguntar("¿Querés registrar el remito de la mercadería recibida?"))
                        {
                            global::AluSoft.UI.Navegacion.Abrir(this, new frm23_Remito_1(pedidoSeleccionado.IdPresupuestoProveedor, compras.Idcompras));
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);           
        }

        private void frm17_Compras_1_Load(object sender, EventArgs e)
        {
            CargarCombo();
            CrearComboPedido();
            CargarBitacora(18,7);
            global::AluSoft.UI.Navegacion.Seleccionar(cbxPedido, idPedidoInicial);
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdStock);
                if (val != 0)
                {
                    dataGridView1.DataSource = gstock.Consultar(stock, val);
                }
                else
                {
                    dataGridView1.DataSource = gstock.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdStock);
                CargarBitacora(18, 5);
        
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Complete el formulario con los datos correctos y presione guardar. " +
          "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
          "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
          "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
