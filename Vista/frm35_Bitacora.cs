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
using ClosedXML.Excel;
using Microsoft.SqlServer.Dac;

namespace AluSoftPresentacion16_6
{
    public partial class frm35_Bitacora : Form
    {
        public frm35_Bitacora()
        {
            InitializeComponent();
            dataGridView1.DataSourceChanged += (s, e) => FormatearGrilla();
        }

        private bool formateando = false;

        private static readonly Dictionary<string, string> nombresSecciones = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Persona", "Persona" }, { "Inventario", "Inventario" }, { "Stock", "Stock" },
            { "Cliente", "Cliente" }, { "Proveedor", "Proveedor" }, { "Login", "Usuarios" },
            { "Venta", "Venta" }, { "PresupuestoCliente", "Presupuesto de cliente" },
            { "PedidoCliente", "Pedido de cliente" }, { "Factura", "Factura" }, { "Cobro", "Cobro" },
            { "Ventas", "Ventas" }, { "Catalogo", "Catálogo" }, { "ListaPrecios", "Lista de precios" },
            { "OrdenProduccion", "Orden de producción" }, { "Estado", "Estado de producción" },
            { "PedidoReaprovisionamiento", "Pedido de reaprovisionamiento" }, { "Compras", "Compras" },
            { "PresupuestoProveedor", "Presupuesto de proveedor" }, { "Maximo", "Stock máximo" },
            { "Minimo", "Stock mínimo" }, { "Produccion", "Producción" }, { "Reportes", "Reportes" },
            { "RemitoProveedor", "Remito de proveedor" }, { "Pagos", "Pagos" }, { "Bitacora", "Bitácora" }
        };

        private static string NombreSeccion(string nombreTabla)
        {
            string n = (nombreTabla ?? "").Trim();
            int guion = n.IndexOf('_');
            if (n.StartsWith("cls", StringComparison.OrdinalIgnoreCase) && guion > 0)
                n = n.Substring(guion + 1);
            string amigable;
            return nombresSecciones.TryGetValue(n, out amigable) ? amigable : n;
        }

        private static DateTime HoraDe(object valor)
        {
            if (valor is DateTime) return (DateTime)valor;
            if (valor is TimeSpan) return DateTime.Today.Add((TimeSpan)valor);
            DateTime d;
            return valor != null && DateTime.TryParse(valor.ToString(), out d) ? d : DateTime.MinValue;
        }

        // Muestra la bitácora con nombres legibles, lo más reciente arriba y sin espacios vacíos.
        private void FormatearGrilla()
        {
            if (formateando) return;
            object fuente = dataGridView1.DataSource;
            if (fuente == null || (fuente is DataTable && ((DataTable)fuente).TableName == "BitacoraVista")) return;

            var filas = new List<Tuple<int, DateTime, DateTime, string, string, string, string>>();
            List<BE.cls35_Bitacora> lista = fuente as List<BE.cls35_Bitacora>;
            DataTable dt = fuente as DataTable;
            if (lista != null)
            {
                foreach (BE.cls35_Bitacora b in lista)
                    filas.Add(Tuple.Create(b.IdBitacora, b.Fecha, b.Hora, b.Usuario, b.NombreRol, b.NombreAccion, b.NombreTabla));
            }
            else if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    Func<string, string> txt = c => dt.Columns.Contains(c) && r[c] != DBNull.Value ? r[c].ToString() : "";
                    int id; int.TryParse(txt("IdBitacora"), out id);
                    DateTime fecha = dt.Columns.Contains("Fecha") ? HoraDe(r["Fecha"]) : DateTime.MinValue;
                    DateTime hora = dt.Columns.Contains("Hora") ? HoraDe(r["Hora"]) : DateTime.MinValue;
                    filas.Add(Tuple.Create(id, fecha, hora, BLL.Cifrado.DesencriptarString(txt("Usuario")),
                        txt("NombreRol"), txt("NombreAccion"), txt("NombreTabla")));
                }
            }
            else return;

            DataTable vista = new DataTable("BitacoraVista");
            vista.Columns.Add("Fecha");
            vista.Columns.Add("Hora");
            vista.Columns.Add("Usuario");
            vista.Columns.Add("Rol");
            vista.Columns.Add("Acción");
            vista.Columns.Add("Sección");
            foreach (var f in filas.OrderByDescending(x => x.Item2.Date)
                                   .ThenByDescending(x => x.Item3.TimeOfDay)
                                   .ThenByDescending(x => x.Item1))
            {
                vista.Rows.Add(
                    f.Item2 == DateTime.MinValue ? "" : f.Item2.ToString("dd/MM/yyyy"),
                    f.Item3 == DateTime.MinValue ? "" : f.Item3.ToString("HH:mm:ss"),
                    f.Item4, f.Item5, f.Item6, NombreSeccion(f.Item7));
            }

            formateando = true;
            try
            {
                dataGridView1.DataSource = vista;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.Columns["Fecha"].FillWeight = 70;
                dataGridView1.Columns["Hora"].FillWeight = 60;
                dataGridView1.Columns["Sección"].FillWeight = 140;
            }
            finally
            {
                formateando = false;
            }
        }
        private DateTime fechaSeleccionada;
        BE.cls05_Login login;
        BLL.Login glogin = new BLL.Login();
        BE.cls29_Tabla tabla;
        BLL.Tabla gtabla = new BLL.Tabla();
        BE.cls28_Accion accion;
        BLL.Accion gaccion = new BLL.Accion();
        BE.cls25_Rol rol;
        BLL.Rol grol = new BLL.Rol();
        BE.cls01_Inventario inv;
        BLL.Inventario ginv = new BLL.Inventario();
        BE.cls35_Bitacora bita;
        BLL.Bitacora gbita = new BLL.Bitacora();
        #region Auxiliares
        private List<BE.cls35_Bitacora> listaPersonasOriginal;
        private bool filtrandoCombo = false;
        private void LimpiarControles(Control contenedor)
        {
            bita = new BE.cls35_Bitacora();
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).Text = "";
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).Checked = false;
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
        #endregion
        private void bita_buscar_accion_Click(object sender, EventArgs e)
        {
            try
            {
                bita = new BE.cls35_Bitacora();
                int fa = 0;
                switch (clsPerdurables.selector_en_informes)
                {
                    case 1:
                        if (cbxIdBitacora.Text != null && cbxIdBitacora.Text != "")
                        {
                            int id = int.Parse(cbxIdBitacora.SelectedValue.ToString());
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ConsultarConRol(bita,id);                       
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ListarCompleto();
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        break;
                    case 2:
                        if (cbxIdLogin.Text != null && cbxIdLogin.Text != "")
                        {
                            int id = int.Parse(cbxIdLogin.SelectedValue.ToString());
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ConsultarConUsuario(bita,id);
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ListarCompleto();
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        break;
                    case 3:
                        if (cbxIdTabla.Text != null && cbxIdTabla.Text != "")
                        {
                            int id = int.Parse(cbxIdTabla.SelectedValue.ToString());
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ConsultarConTabla(bita,id);
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ListarCompleto();
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        break;
                    case 4:
                        if (cbxIdAccion.Text != null && cbxIdAccion.Text != "")
                        {
                            int id = int.Parse(cbxIdAccion.SelectedValue.ToString());
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ConsultarConAccion(bita,id);
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ListarCompleto();
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        break;
                    case 5:
                        if (dateTimePicker1.Text != null && dateTimePicker1.Text != "")
                        {
                            DateTime id = DateTime.Parse(dateTimePicker1.Text);
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ConsultarConFecha(bita, id);
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = gbita.ListarCompleto();
                            #region Bitacora                     
                            bita = new BE.cls35_Bitacora();
                            bita.idbitacora = (gbita.Max(bita) + 1);
                            bita.idlogin = clsPerdurables.Id_Login;
                            bita.idtabla = 26;
                            bita.idaccion = 4;
                            bita.fecha = (DateTime.Now);
                            bita.hora = DateTime.Parse(DateTime.Now.ToString("HH:mm:ss"));
                            fa = gbita.Agregar(bita);
                            #endregion #endregion
                        } 
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo completar la operación: " + ex.Message, "AluSoft",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frm35_Bitacora_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= gbita.ListarCompleto();
            cbxIdAccion.DataSource = gaccion.ListarAccion();
            cbxIdAccion.DisplayMember = "Nombre";
            cbxIdAccion.ValueMember = "IdAccion";
            cbxIdAccion.Text = null;
            cbxIdAccion.SelectedIndex = -1;
            cbxIdAccion.DropDownStyle = ComboBoxStyle.DropDown;

            cbxIdLogin.DataSource = glogin.ListarCompleto();
            cbxIdLogin.DisplayMember = "Usuario";
            cbxIdLogin.ValueMember = "IdLogin";
            cbxIdLogin.Text = null;
            cbxIdLogin.SelectedIndex = -1;
            cbxIdLogin.DropDownStyle = ComboBoxStyle.DropDown;

            cbxIdTabla.DataSource = gtabla.ListarTabla()
                .Select(t => new { t.IdTabla, Nombre = NombreSeccion(t.Nombre) })
                .OrderBy(t => t.Nombre).ToList();
            cbxIdTabla.DisplayMember = "Nombre";
            cbxIdTabla.ValueMember = "IdTabla";
            cbxIdTabla.Text = null;
            cbxIdTabla.SelectedIndex = -1;
            cbxIdTabla.DropDownStyle = ComboBoxStyle.DropDown;

            cbxIdBitacora.DataSource = grol.ListarRol();
            cbxIdBitacora.DisplayMember = "Nombre";
            cbxIdBitacora.ValueMember = "IdRol";
            cbxIdBitacora.Text = null;
            cbxIdBitacora.SelectedIndex = -1;
            cbxIdBitacora.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void bita_limpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles(this);
        }

        private void cbxIdBitacora_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdBitacora.SelectedIndex;
            if (selectedIndex >= 0)
            {
                cbxIdAccion.Text = null;
                cbxIdTabla.Text = null;
                cbxIdLogin.Text = null;
                clsPerdurables.selector_en_informes = 1;
            }
            else
            {
                cbxIdBitacora.Text = null;
            }         
        }

        private void cbxIdLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdLogin.SelectedIndex;
            if (selectedIndex >= 0)
            {
                cbxIdAccion.Text = null;
                cbxIdTabla.Text = null;
                cbxIdBitacora.Text = null;
                clsPerdurables.selector_en_informes = 2;
            }
            else
            {
                cbxIdLogin.Text = null;
            }
        }

        private void cbxIdTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdTabla.SelectedIndex;
            if (selectedIndex >= 0)
            {
                cbxIdAccion.Text = null;
                cbxIdBitacora.Text=null;
                cbxIdLogin.Text = null;
                clsPerdurables.selector_en_informes = 3;
            }
            else
            {
                cbxIdTabla.Text = null;
            }
        }

        private void cbxIdAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdAccion.SelectedIndex;
            if (selectedIndex >= 0)
            {
                cbxIdTabla.Text = null;
                cbxIdBitacora.Text = null;
                clsPerdurables.selector_en_informes = 4;
            }
            else
            {
                cbxIdAccion.Text = null;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fechaSeleccionada = dateTimePicker1.Value.Date;
            cbxIdLogin.SelectedIndex = -1;
            cbxIdAccion.SelectedIndex = -1;
            cbxIdTabla.SelectedIndex = -1;
            cbxIdBitacora.SelectedIndex = -1;
            clsPerdurables.selector_en_informes = 5;
        }

        private void bita_exportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog guardar = new SaveFileDialog())
            {
                guardar.Filter = "Archivo de Excel (*.xlsx)|*.xlsx";
                guardar.Title = "Exportar Bitacora a Excel";
                guardar.FileName = "AluSoft_Bitacora_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (guardar.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (IndicadorCargaExportacion carga = new IndicadorCargaExportacion())
                    {
                        using (XLWorkbook libro = new XLWorkbook())
                    {
                        var hoja = libro.Worksheets.Add("Bitacora");

                        for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                        {
                            if (dataGridView1.Columns[columna].Visible)
                            {
                                hoja.Cell(1, columna + 1).Value =
                                    dataGridView1.Columns[columna].HeaderText;
                            }
                        }

                        int filaExcel = 2;

                        foreach (DataGridViewRow fila in dataGridView1.Rows)
                        {
                            if (fila.IsNewRow)
                                continue;

                            for (int columna = 0; columna < dataGridView1.Columns.Count; columna++)
                            {
                                if (!dataGridView1.Columns[columna].Visible)
                                    continue;

                                object valor = fila.Cells[columna].Value;
                                var celda = hoja.Cell(filaExcel, columna + 1);

                                if (valor == null || valor == DBNull.Value)
                                {
                                    celda.Value = "";
                                }
                                else if (valor is DateTime fecha)
                                {
                                    celda.Value = fecha;
                                    celda.Style.DateFormat.Format = "dd/MM/yyyy";
                                }
                                else if (valor is bool booleano)
                                {
                                    celda.Value = booleano;
                                }
                                else if (valor is byte || valor is short || valor is int ||
                                         valor is long || valor is float || valor is double ||
                                         valor is decimal)
                                {
                                    celda.Value = Convert.ToDouble(valor);
                                }
                                else
                                {
                                    celda.Value = valor.ToString();
                                }
                            }

                            filaExcel++;
                        }

                        hoja.Columns().AdjustToContents();
                        libro.SaveAs(guardar.FileName);
                    }

                    }
                    MessageBox.Show("La tabla se exportó correctamente.",
                        "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo exportar la tabla: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialogo = new SaveFileDialog())
            {
                dialogo.Title = "Guardar copia BACPAC";
                dialogo.Filter = "Archivos BACPAC (*.bacpac)|*.bacpac";
                dialogo.DefaultExt = "bacpac";
                dialogo.AddExtension = true;
                dialogo.OverwritePrompt = true;
                dialogo.FileName = "AluSoft_" +
                    DateTime.Now.ToString("yyyyMMdd_HHmm") +
                    ".bacpac";

                if (dialogo.ShowDialog(this) != DialogResult.OK)
                    return;

                string rutaArchivo = dialogo.FileName;

                string cadenaConexion = BLL.Conexion.Cadena;
                btnGenerarBacpac.Enabled = false;
                Cursor = Cursors.WaitCursor;

                try
                {
                     Task.Run(() =>
                     {
                        DacServices servicio = new DacServices(cadenaConexion);
                        servicio.ExportBacpac(rutaArchivo, BLL.Conexion.BaseDeDatos);
                    });

                    MessageBox.Show(
                        "La copia se generó correctamente en:\n" + rutaArchivo,
                        "BACPAC generado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "No se pudo generar el BACPAC:\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    btnGenerarBacpac.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("En este formulario hay múltiples filtros de búsqueda. Para cargar la totalidad de los datos de la bitácora se deberá presionar cualquier botón \"Buscar\" sin que haya dato alguno cargado en las listas combobox. " +
           "Si se desea buscar por algún dato en específico, se deberá presentar en el combobox el id deseado. " +
           "Con el botón exportar se creará una planilla de Excel con el contenido que esté presentado en la grilla. " +
           "Si hubo algún dato incorrecto, informe a su referente o superior para corregirlo. " +
           "Si algún error aparece en pantalla, por favor guarde o anote el mensaje para notificarlo luego. " +
           "En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
