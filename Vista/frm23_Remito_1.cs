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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AluSoftPresentacion16_6
{
    public partial class frm23_Remito_1 : Form
    {
        public frm23_Remito_1()
        {
            InitializeComponent();
        }
        private int idPresupuestoInicial;

        // Busca la compra que salió del pedido de este presupuesto (la más reciente).
        private int BuscarCompra(int idPresupuesto)
        {
            List<int> pedidos = new BLL.PedidoReaprovisionamiento().ListarCatalogo2()
                .Where(p => p.IdPresupuestoProveedor == idPresupuesto)
                .Select(p => p.Idpedidoreaprovisionamiento).ToList();
            BE.cls17_Compras compra = new BLL.Compras().ListarCatalogo2()
                .Where(c => pedidos.Contains(c.IdPedidoReaprovisionamiento))
                .OrderByDescending(c => c.Idcompras).FirstOrDefault();
            return compra == null ? 0 : compra.Idcompras;
        }
        private int idCompra;
        public frm23_Remito_1(int idPresupuesto, int idCompra) : this()
        {
            idPresupuestoInicial = idPresupuesto;
            this.idCompra = idCompra;
        }
        BE.cls23_RemitoProveedor remito;
        BLL.RemitoProveedor gremito =new BLL.RemitoProveedor();
        BE.cls18_PresupuestoProveedor presupuesto;
        BLL.PresupuestoProveedor gpresupuesto = new BLL.PresupuestoProveedor();
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls18_PresupuestoProveedor> listaPersonasOriginal;
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
            listaPersonasOriginal = gpresupuesto.ListarCatalogo2();
            cbxIdPresupuestoProveedor.DataSource = listaPersonasOriginal;
            cbxIdPresupuestoProveedor.DisplayMember = "Combo";
            cbxIdPresupuestoProveedor.ValueMember = "IdPresupuestoProveedor";
            cbxIdPresupuestoProveedor.SelectedIndex = -1;
            cbxIdPresupuestoProveedor.DropDownStyle = ComboBoxStyle.DropDown;
        }
        private bool ValidarCampos()
        {
            errorProvider1.Clear();
            Control primerControlInvalido = null;
            bool valido = true;
            ValidarControlesRecursivamente(
                this,
                ref valido,
                ref primerControlInvalido);
            global::AluSoft.UI.ValidacionCampos.ValidarTipos(this, errorProvider1, ref valido, ref primerControlInvalido);
            primerControlInvalido = global::AluSoft.UI.ValidacionCampos.PrimeroConError(this, errorProvider1) ?? primerControlInvalido;
            if (!valido && primerControlInvalido != null)
                primerControlInvalido.Focus();
            return valido;
        }
        private void ValidarControlesRecursivamente(Control contenedor, ref bool valido, ref Control primerControlInvalido)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control.Visible && control.Enabled && !global::AluSoft.UI.ValidacionCampos.EsOpcional(control))
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        if (string.IsNullOrWhiteSpace(textBox.Text))
                        {
                            errorProvider1.SetError(textBox, "Tenés que completar este campo.");
                            if (primerControlInvalido == null)
                                primerControlInvalido = textBox;
                            valido = false;
                        }
                    }
                    else if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        if (comboBox.SelectedIndex == -1)
                        {
                            errorProvider1.SetError(comboBox, "Tenés que seleccionar una opción.");
                            if (primerControlInvalido == null)
                                primerControlInvalido = comboBox;
                            valido = false;
                        }
                    }
                }
                if (control.HasChildren)
                {
                    ValidarControlesRecursivamente(
                        control,
                        ref valido,
                        ref primerControlInvalido);
                }
            }
        }

        #endregion
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                remito = new BE.cls23_RemitoProveedor();
                if (!ValidarCampos()) return;
                remito.Idremitoproveedor = (gremito.Max(remito)+1);
                remito.Idpresupuestoproveedor = Convert.ToInt32(cbxIdPresupuestoProveedor.SelectedValue);
                remito.Fecha = DateTime.Parse(dateTimePicker2.Value.ToString()); 
                remito.Estado = txbEstado.Text.Trim();
                remito.Observaciones = txbObservaciones.Text.Trim();
                fa = gremito.Agregar(remito);
                if (fa != 0)
                {
                    CargarBitacora(24,1);
                    string aviso = "Remito N° " + remito.Idremitoproveedor + " registrado.";
                    BE.cls18_PresupuestoProveedor presu = cbxIdPresupuestoProveedor.SelectedItem as BE.cls18_PresupuestoProveedor;
                    if (presu != null)
                    {
                        // Recibido: entra lo que falta de la compra. Con faltantes: entra solo lo que llegó.
                        aviso += global::AluSoft.UI.CadenaCompra.IngresarMercaderia(presu.Idpresupuestoproveedor, remito.Idremitoproveedor, idCompra, remito.Estado);
                    }
                    MessageBox.Show(aviso, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    int compraDelRemito = idCompra > 0 ? idCompra : BuscarCompra(remito.Idpresupuestoproveedor);
                    if (compraDelRemito > 0 && global::AluSoft.UI.Navegacion.Preguntar("¿Querés registrar el pago al proveedor?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm24_Pagos_1(compraDelRemito));
                        return;
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

        private void frm23_Remito_1_Load(object sender, EventArgs e)
        {
            CargarBitacora(24,7);
            CargarCombo();
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Remito, BLL.Estados.Remito[0]);
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdPresupuestoProveedor, idPresupuestoInicial);
        }

        private void af_tabla_Click(object sender, EventArgs e)
        {
            try
            {
                int val = global::AluSoft.UI.AjusteFormularios.IdSeleccionado(cbxIdPresupuestoProveedor);
                if (val != 0)
                {
                    dataGridView1.DataSource = gpresupuesto.Consultar(presupuesto, val);
                }
                else
                {
                    dataGridView1.DataSource = gpresupuesto.ListarCatalogo2();
                }
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdPresupuestoProveedor);
                CargarBitacora(24, 5);
        
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
