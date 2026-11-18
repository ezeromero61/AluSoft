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
    public partial class frm10_Cobro_1 : Form
    {
        public frm10_Cobro_1()
        {
            InitializeComponent();
        }

        private int idFacturaInicial;
        private decimal saldoFactura;

        private decimal CalcularSaldo(int idFactura, decimal total)
        {
            decimal cobrado = gcobro.ListarCatalogo2()
                .Where(c => c.Idfactura == idFactura)
                .Sum(c => c.Importe);
            return total - cobrado;
        }

        public frm10_Cobro_1(int idFactura) : this()
        {
            idFacturaInicial = idFactura;
        }
        BE.cls35_Bitacora bitacora;
        BLL.Bitacora gbitacora = new BLL.Bitacora();
        BE.cls10_Cobro cobro;
        BLL.Cobro gcobro = new BLL.Cobro();
        BE.cls09_Factura factura;
        BLL.Factura gfactura = new BLL.Factura();
        #region Auxiliares
        private List<BE.cls03_Cliente> listaPersonasOriginal;
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
                else if (control is System.Windows.Forms. CheckBox)
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

        private void CargarCombo()
        {
            factura = new BE.cls09_Factura();
            cbxIdFactura.DataSource = gfactura.ListarCatalogo2();
            cbxIdFactura.DisplayMember = "Combo";
            cbxIdFactura.ValueMember = "IdFactura";
            cbxIdFactura.Text = null;
            cbxIdFactura.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion
        private void alum_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int fa = 0;
                if (!ValidarCampos()) return;
                cobro = new BE.cls10_Cobro();
                cobro.Idcobro = (gcobro.Max(cobro) + 1);
                cobro.Idfactura = clsValidacionesPerdurables.SoloNumeros(cbxIdFactura.SelectedValue.ToString(),"Id factura");
                cobro.Fechacobro = clsValidacionesPerdurables.FechaObligatoria(DateTime.Parse(dateTimePicker1.Text),"Fecha de cobro");
                cobro.Importe = clsValidacionesPerdurables.SoloNumeros(txbImporte.Text,"Importe");
                if (cobro.Importe <= 0)
                    throw new ArgumentException("El importe tiene que ser mayor a 0.");
                if (cobro.Importe > saldoFactura)
                    throw new ArgumentException("El importe no puede superar el saldo pendiente de la factura ($" + saldoFactura.ToString("0.##") + ").");
                cobro.Formapago = txbFormaPago.Text;
                cobro.Estado = txbEstado.Text;
                cobro.Observaciones = txbObservaciones.Text;
                fa = gcobro.Agregar(cobro);
                if (fa != 0)
                {
                    decimal resta = saldoFactura - cobro.Importe;
                    if (resta <= 0)
                    {
                        try
                        {
                            gfactura.ActualizarEstado(cobro.Idfactura, BLL.Estados.Factura[1]);
                        }
                        catch (Exception exEstado)
                        {
                            MessageBox.Show("El cobro se registró, pero no se pudo actualizar el estado de la factura: " + exEstado.Message,
                                "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    MessageBox.Show("El cobro se guardó correctamente." + (resta > 0 ? " Queda un saldo pendiente de $" + resta.ToString("0.##") + "." : " La factura quedó cobrada en su totalidad."), "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarBitacora(11, 1);
                    // [CORREGIDO] Solo se ofrece cerrar la venta cuando la factura quedó cobrada completa.
                    // Con saldo pendiente la venta no se puede registrar y Ventas abría otra factura.
                    if (resta <= 0 && global::AluSoft.UI.Navegacion.Preguntar("¿Querés cerrar la venta?"))
                    {
                        global::AluSoft.UI.Navegacion.Abrir(this, new frm11_Ventas_1(cobro.Idcobro));
                        return;
                    }
                    LimpiarControles(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alum_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
            
        }

        private void frm10_Cobro_1_Load(object sender, EventArgs e)
        {
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbEstado, BLL.Estados.Cobro, "Cobrado");
            global::AluSoft.UI.EstadosCombo.Reemplazar(txbFormaPago, BLL.Estados.FormaPago, "Efectivo");
            CargarCombo();
            global::AluSoft.UI.Navegacion.Seleccionar(cbxIdFactura, idFacturaInicial);
            CargarBitacora(11,7);      
            dataGridView1.DataSource = gfactura.ListarCatalogo2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = gfactura.ListarCatalogo2();
                global::AluSoft.UI.AjusteFormularios.AplicarFiltroGrilla(dataGridView1, cbxIdFactura, "IdFactura");
                CargarBitacora(11,5);
        
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

        private void cbxIdFactura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxIdFactura.SelectedIndex < 0 || cbxIdFactura.SelectedValue == null)
                return;

            int idFactura;
            if (!int.TryParse(cbxIdFactura.SelectedValue.ToString(), out idFactura))
                return;

            factura = new BE.cls09_Factura();

            DataTable datos = gfactura.Consultar(factura, idFactura);

            if (datos == null || datos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para esa factura.");
                return;
            }

            saldoFactura = CalcularSaldo(idFactura, factura.Total);
            txbImporte.Text = saldoFactura > 0 ? saldoFactura.ToString("0.##") : "0";
            if (saldoFactura <= 0)
                MessageBox.Show("Esta factura ya está cobrada en su totalidad.", "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (saldoFactura < factura.Total)
                MessageBox.Show("La factura tiene cobros anteriores. Saldo pendiente: $" + saldoFactura.ToString("0.##"), "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!string.IsNullOrWhiteSpace(factura.Formapago)) txbFormaPago.Text = factura.Formapago;
            txbEstado.Text = "Cobrado";
            txbObservaciones.Text = factura.Observaciones;
        }
    }
}
