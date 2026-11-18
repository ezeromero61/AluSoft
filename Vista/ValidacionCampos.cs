using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AluSoft.UI
{
    internal static class ValidacionCampos
    {
        internal enum Tipo { Entero, Decimal, Letras, Correo, Dni, Cuil, Telefono }

        internal sealed class Regla
        {
            public readonly Tipo Tipo; public readonly string Campo;
            public Regla(Tipo tipo, string campo) { Tipo = tipo; Campo = campo; }
        }

        internal const int LargoMaximo = 50;

        private static readonly Dictionary<string, Regla> reglas = new Dictionary<string, Regla>
        {
            { "frm00_Persona.txbApellido", new Regla(Tipo.Letras, "Apellido") },
            { "frm00_Persona.txbCorreo", new Regla(Tipo.Correo, "Correo") },
            { "frm00_Persona.txbCuil", new Regla(Tipo.Cuil, "Cuil") },
            { "frm00_Persona.txbDni", new Regla(Tipo.Dni, "Dni") },
            { "frm00_Persona.txbNombre", new Regla(Tipo.Letras, "Nombre") },
            { "frm00_Persona.txbTelefono", new Regla(Tipo.Telefono, "Teléfono") },
            { "frm00_Persona_2.txbApellido", new Regla(Tipo.Letras, "Apellido") },
            { "frm00_Persona_2.txbCorreo", new Regla(Tipo.Correo, "Correo") },
            { "frm00_Persona_2.txbCuil", new Regla(Tipo.Cuil, "Cuil") },
            { "frm00_Persona_2.txbDni", new Regla(Tipo.Dni, "DNI") },
            { "frm00_Persona_2.txbNombre", new Regla(Tipo.Letras, "Nombre") },
            { "frm00_Persona_2.txbTelefono", new Regla(Tipo.Telefono, "Teléfono") },
            { "frm01_Inventario_1.txbAlto", new Regla(Tipo.Entero, "Alto") },
            { "frm01_Inventario_1.txbLargo", new Regla(Tipo.Entero, "Largo") },
            { "frm01_Inventario_1.txtAncho", new Regla(Tipo.Entero, "Ancho") },
            { "frm01_Inventario_2.txbAlto", new Regla(Tipo.Entero, "Alto") },
            { "frm01_Inventario_2.txbLargo", new Regla(Tipo.Entero, "Largo") },
            { "frm01_Inventario_2.txtAncho", new Regla(Tipo.Entero, "Ancho") },
            { "frm02_Stock_1.txbCantActual", new Regla(Tipo.Entero, "Cantidad_actual") },
            { "frm02_Stock_1.txbCantMax", new Regla(Tipo.Entero, "Cantidad_maxima") },
            { "frm02_Stock_1.txbCantMin", new Regla(Tipo.Entero, "Cantidad_minima") },
            { "frm02_Stock_2.txbActual", new Regla(Tipo.Entero, "Cantidad actual") },
            { "frm02_Stock_2.txbMaxima", new Regla(Tipo.Entero, "Cantidad máxima") },
            { "frm02_Stock_2.txbMinima", new Regla(Tipo.Entero, "Cantidad mínima") },
            { "frm03_Cliente.textBox4", new Regla(Tipo.Cuil, "Cuil") },
            { "frm03_Cliente.txbDescripcion", new Regla(Tipo.Letras, "Apellido") },
            { "frm03_Cliente.txbNombre", new Regla(Tipo.Letras, "Nombre") },
            { "frm03_Cliente.txtAncho", new Regla(Tipo.Correo, "Correo") },
            { "frm03_Cliente.txtColor", new Regla(Tipo.Dni, "Dni") },
            { "frm03_Cliente.txtMaterial", new Regla(Tipo.Telefono, "Telefono") },
            { "frm03_Cliente_2.txbApellido", new Regla(Tipo.Letras, "Apellido") },
            { "frm03_Cliente_2.txbCorreo", new Regla(Tipo.Correo, "Correo") },
            { "frm03_Cliente_2.txbCuil", new Regla(Tipo.Cuil, "Cuil") },
            { "frm03_Cliente_2.txbDni", new Regla(Tipo.Dni, "Dni") },
            { "frm03_Cliente_2.txbNombre", new Regla(Tipo.Letras, "Nombre") },
            { "frm03_Cliente_2.txbTelefono", new Regla(Tipo.Telefono, "Telefono") },
            { "frm07_PresupuestoCliente.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm07_PresupuestoCliente.txbImpuestos", new Regla(Tipo.Entero, "Impuestos") },
            { "frm07_PresupuestoCliente.txbPlazoEntrega", new Regla(Tipo.Entero, "Plazo de entrega") },
            { "frm07_PresupuestoCliente.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm07_PresupuestoCliente.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm07_PresupuestoCliente_2.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm07_PresupuestoCliente_2.txbImpuestos", new Regla(Tipo.Entero, "Impuestos") },
            { "frm07_PresupuestoCliente_2.txbPlazoEntrega", new Regla(Tipo.Entero, "Plazo de entrega en días") },
            { "frm07_PresupuestoCliente_2.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm07_PresupuestoCliente_2.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm09_Factura_1.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm09_Factura_1.txbIVA", new Regla(Tipo.Entero, "IVA") },
            { "frm09_Factura_1.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm09_Factura_1.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm09_Factura_2.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm09_Factura_2.txbIVA", new Regla(Tipo.Entero, "IVA") },
            { "frm09_Factura_2.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm09_Factura_2.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm10_Cobro_1.txbImporte", new Regla(Tipo.Entero, "Importe") },
            { "frm10_Cobro_2.txbImporte", new Regla(Tipo.Entero, "Importe") },
            { "frm11_Ventas_1.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm11_Ventas_1.txbImpuestos", new Regla(Tipo.Entero, "Impuesto") },
            { "frm11_Ventas_1.txbSaldoPendiente", new Regla(Tipo.Entero, "Saldo Pendiente") },
            { "frm11_Ventas_1.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm11_Ventas_1.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm11_Ventas_1.txbTotalCobrado", new Regla(Tipo.Entero, "Total Cobrado") },
            { "frm11_Ventas_2.txbDescuento", new Regla(Tipo.Entero, "Descuento") },
            { "frm11_Ventas_2.txbImpuestos", new Regla(Tipo.Entero, "Impuesto") },
            { "frm11_Ventas_2.txbSaldoPendiente", new Regla(Tipo.Entero, "Saldo Pendiente") },
            { "frm11_Ventas_2.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm11_Ventas_2.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm11_Ventas_2.txbTotalCobrado", new Regla(Tipo.Entero, "Total Cobrado") },
            { "frm12_Catalogo_1.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm12_Catalogo_1.txbPrecio", new Regla(Tipo.Entero, "Precio unitario") },
            { "frm12_Catalogo_2.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm12_Catalogo_2.txbPrecioUnitario", new Regla(Tipo.Entero, "Precio unitario") },
            { "frm13_ListaPrecios_1.txbPrecio", new Regla(Tipo.Entero, "Precio") },
            { "frm13_ListaPrecios_2.txbPrecio", new Regla(Tipo.Entero, "Precio") },
            { "frm14_OrdenProduccion_1.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm14_OrdenProduccion_2.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm17_Compras_1.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm17_Compras_1.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm17_Compras_1.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm17_Compras_2.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm17_Compras_2.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm17_Compras_2.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm18_PresupuestoProveedor_1.txbPrecio", new Regla(Tipo.Entero, "Precio") },
            { "frm18_PresupuestoProveedor_1.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm18_PresupuestoProveedor_1.txbIva", new Regla(Tipo.Entero, "IVA") },
            { "frm18_PresupuestoProveedor_1.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm18_PresupuestoProveedor_1.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm18_PresupuestoProveedor_2.txbPrecio", new Regla(Tipo.Entero, "Precio") },
            { "frm18_PresupuestoProveedor_2.txbIva", new Regla(Tipo.Entero, "Iva") },
            { "frm18_PresupuestoProveedor_2.txbSubtotal", new Regla(Tipo.Entero, "Subtotal") },
            { "frm18_PresupuestoProveedor_2.txbTotal", new Regla(Tipo.Entero, "Total") },
            { "frm19_Maximo.txbCant", new Regla(Tipo.Entero, "Cantidad") },
            { "frm19_Maximo_2.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
            { "frm20_Minimo.txbCant", new Regla(Tipo.Entero, "Cantidad") },
            { "frm20_Minimo_2.txbCantidad", new Regla(Tipo.Entero, "Cantidad") },
        };

        private static readonly Regex soloLetras = new Regex(@"^[A-Za-zÁÉÍÓÚÜÑáéíóúüñ' .-]+$");
        private static readonly Regex correo = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        private static readonly Regex digitos = new Regex(@"^\d+$");

        internal static void LimitarLargo(Control contenedor)
        {
            foreach (Control c in contenedor.Controls)
            {
                TextBox tb = c as TextBox;
                if (tb != null && tb.MaxLength > LargoMaximo) tb.MaxLength = LargoMaximo;
                if (c.HasChildren) LimitarLargo(c);
            }
        }

        private const int LugarIcono = 22;

        internal static void DejarLugarParaIcono(Control contenedor)
        {
            if (contenedor is DataGridView) return;
            bool enCelda = contenedor is TableLayoutPanel;
            foreach (Control c in contenedor.Controls)
            {
                if (!enCelda && (c is TextBoxBase || c is ComboBox))
                {
                    int libre = contenedor.ClientSize.Width - c.Right;
                    int falta = LugarIcono - libre;
                    if (libre >= 0 && falta > 0) DarLugar(c, falta);
                }
                else if (c.HasChildren) DejarLugarParaIcono(c);
            }
        }

        internal static void ValidarTipos(Form formulario, ErrorProvider error,
            ref bool valido, ref Control primerControlInvalido)
        {
            Revisar(formulario, formulario.Name, error, ref valido, ref primerControlInvalido);
        }

        internal static Control PrimeroConError(Control raiz, ErrorProvider error)
        {
            AcomodarIconos(raiz, error);
            return BuscarPrimero(raiz, error);
        }

        internal static void EnfocarYMostrar(Control control)
        {
            if (control == null) return;
            for (Control contenedor = control.Parent; contenedor != null; contenedor = contenedor.Parent)
            {
                ScrollableControl desplazable = contenedor as ScrollableControl;
                if (desplazable != null) desplazable.ScrollControlIntoView(control);
            }
            control.Focus();
        }

        private static void AcomodarIconos(Control contenedor, ErrorProvider error)
        {
            foreach (Control c in contenedor.Controls)
            {
                if (c.HasChildren && !(c is ComboBox)) AcomodarIconos(c, error);
                if (string.IsNullOrEmpty(error.GetError(c)) || c.Parent == null || !c.IsHandleCreated) continue;
                Rectangle propio = c.Parent.RectangleToScreen(c.Bounds);
                int fin = propio.Right;
                int visible = int.MaxValue;
                for (Control a = c; a.Parent != null && !(a is Form); a = a.Parent)
                {
                    Control p = a.Parent;
                    visible = Math.Min(visible, p.RectangleToScreen(p.ClientRectangle).Right);
                    int capa = p.Controls.GetChildIndex(a);
                    foreach (Control otro in p.Controls)
                    {
                        if (otro == a || !otro.Visible || p.Controls.GetChildIndex(otro) > capa) continue;
                        Rectangle r = p.RectangleToScreen(otro.Bounds);
                        if (r.Left > propio.Left && r.Top < propio.Bottom && r.Bottom > propio.Top)
                            visible = Math.Min(visible, r.Left);
                    }
                }
                float escala;
                using (Graphics g = c.CreateGraphics()) escala = g.DpiX / 96f;
                int lugar = (int)Math.Ceiling(LugarIcono * escala) + error.GetIconPadding(c);
                int falta = lugar - (visible - fin);
                if (falta > 0) DarLugar(c, falta);
            }
        }

        private static void DarLugar(Control c, int falta)
        {
            Control p = c.Parent;
            if (p.AutoSize)
            {
                Padding m = p.Padding;
                p.Padding = new Padding(m.Left, m.Top, m.Right + falta, m.Bottom);
            }
            else if (c.Width - falta >= 60) c.Width -= falta;
        }

        private static Control BuscarPrimero(Control raiz, ErrorProvider error)
        {
            List<Control> hijos = new List<Control>();
            foreach (Control c in raiz.Controls) hijos.Add(c);
            hijos.Sort((a, b) =>
            {
                if (Math.Abs(a.Top - b.Top) > 10) return a.Top.CompareTo(b.Top);
                return a.Left.CompareTo(b.Left);
            });
            foreach (Control c in hijos)
            {
                if (!string.IsNullOrEmpty(error.GetError(c))) return c;
                if (c.HasChildren)
                {
                    Control h = BuscarPrimero(c, error);
                    if (h != null) return h;
                }
            }
            return null;
        }

        private static readonly System.Runtime.CompilerServices.ConditionalWeakTable<Form, ErrorProvider> avisos =
            new System.Runtime.CompilerServices.ConditionalWeakTable<Form, ErrorProvider>();

        // Campos de texto libre que nunca son obligatorios (descripción, observaciones, detalles, notas).
        internal static bool EsOpcional(Control c)
        {
            if (!(c is TextBox) && !(c is RichTextBox)) return false;
            string n = c.Name.ToLowerInvariant();
            return n.Contains("observ") || n.Contains("descrip") || n.Contains("detalle") || n.Contains("nota");
        }

        internal static bool Validar(Form formulario)
        {
            ErrorProvider error = avisos.GetValue(formulario, f => new ErrorProvider
            {
                ContainerControl = f,
                BlinkStyle = ErrorBlinkStyle.NeverBlink
            });
            error.Clear();
            bool valido = true; Control primero = null;
            foreach (Control c in formulario.Controls)
            {
                if (c.Dock == DockStyle.Top || c.Dock == DockStyle.Bottom) continue;
                MarcarVacios(c, error, ref valido, ref primero);
            }
            Revisar(formulario, formulario.Name, error, ref valido, ref primero);
            if (!valido)
            {
                Control foco = PrimeroConError(formulario, error) ?? primero;
                if (foco != null) foco.Focus();
            }
            return valido;
        }

        private static void MarcarVacios(Control c, ErrorProvider error, ref bool valido, ref Control primero)
        {
            if (!c.Visible || !c.Enabled || c is DataGridView || EsOpcional(c)) return;
            TextBox tb = c as TextBox;
            ComboBox cb = c as ComboBox;
            string msg = null;
            if (tb != null && !tb.ReadOnly && tb.Text.Trim().Length == 0) msg = "Tenés que completar este campo.";
            else if (cb != null && cb.SelectedIndex < 0) msg = "Tenés que seleccionar una opción.";
            if (msg != null)
            {
                error.SetError(c, msg);
                if (primero == null) primero = c;
                valido = false;
            }
            if (tb == null && cb == null)
                foreach (Control h in c.Controls) MarcarVacios(h, error, ref valido, ref primero);
        }

        private static void Revisar(Control contenedor, string form, ErrorProvider error,
            ref bool valido, ref Control primero)
        {
            foreach (Control c in contenedor.Controls)
            {
                TextBox tb = c as TextBox;
                if (tb != null && tb.Visible && tb.Enabled)
                {
                    string msg = Problema(form, tb);
                    if (msg != null)
                    {
                        if (error != null) error.SetError(tb, msg);
                        if (primero == null) primero = tb;
                        valido = false;
                    }
                }
                if (c.HasChildren) Revisar(c, form, error, ref valido, ref primero);
            }
        }

        private static string Problema(string form, TextBox tb)
        {
            string v = tb.Text.Trim();
            if (v.Length == 0) return null;
            if (v.Length > LargoMaximo)
                return "Máximo " + LargoMaximo + " caracteres.";

            Regla r;
            if (!reglas.TryGetValue(form + "." + tb.Name, out r)) return null;
            string campo = r.Campo;
            switch (r.Tipo)
            {
                case Tipo.Entero:
                    int n;
                    if (!digitos.IsMatch(v)) return "El campo " + campo + " sólo admite números enteros (sin letras, signos ni decimales).";
                    if (!int.TryParse(v, out n)) return "El número de " + campo + " es demasiado grande.";
                    return null;
                case Tipo.Decimal:
                    double d;
                    if (!double.TryParse(v, NumberStyles.Number, CultureInfo.CurrentCulture, out d))
                        return "El campo " + campo + " sólo admite números.";
                    if (d < 0) return "El campo " + campo + " no puede ser negativo.";
                    return null;
                case Tipo.Letras:
                    if (!soloLetras.IsMatch(v)) return "El campo " + campo + " sólo admite letras.";
                    return null;
                case Tipo.Correo:
                    if (!correo.IsMatch(v)) return "Ingresá un correo válido (por ejemplo nombre@dominio.com).";
                    return null;
                case Tipo.Dni:
                    if (!digitos.IsMatch(v) || v.Length < 7 || v.Length > 8)
                        return "El DNI debe tener 7 u 8 números, sin puntos.";
                    return null;
                case Tipo.Cuil:
                    if (!digitos.IsMatch(v) || v.Length != 11)
                        return "El CUIL debe tener 11 números, sin guiones.";
                    return null;
                case Tipo.Telefono:
                    if (!digitos.IsMatch(v) || v.Length < 6 || v.Length > 15)
                        return "El teléfono debe tener entre 6 y 15 números, sin espacios ni guiones.";
                    return null;
            }
            return null;
        }
    }
}
