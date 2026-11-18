using AluSoftPresentacion16_6;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Microsoft.SqlServer.Dac;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoft
{
    public partial class Menu_Soporte : Form
    {
        public Menu_Soporte()
        {
            InitializeComponent();
            ConfigurarMenusPorArea();
            global::AluSoft.UI.TemaMenus.Aplicar(this, toolStrip1, panel1, "Soporte técnico");
        }

        #region Organización del menú

        private void ConfigurarMenusPorArea()
        {
            ToolStrip barra = toolStripSplitButton1.Owner;
            if (barra == null || toolStripSplitButton2.Owner != barra)
            {
                throw new InvalidOperationException(
                    "Los dos botones originales deben pertenecer al mismo ToolStrip.");
            }

            barra.SuspendLayout();
            try
            {
                ToolStripSplitButton comercial = toolStripSplitButton1;
                ToolStripSplitButton stock = toolStripSplitButton2;
                ToolStripSplitButton produccion = new ToolStripSplitButton();
                ToolStripSplitButton reaprovisionamiento = new ToolStripSplitButton();

                PrepararBoton(comercial, "Comercial");
                PrepararBoton(stock, "Stock");
                PrepararBoton(produccion, "Producción");
                PrepararBoton(reaprovisionamiento, "Reaprovisionamiento");

                produccion.Name = "menuProduccion";
                reaprovisionamiento.Name = "menuReaprovisionamiento";

                int posicion = Math.Min(barra.Items.IndexOf(comercial),
                                        barra.Items.IndexOf(stock));
                barra.Items.Remove(comercial);
                barra.Items.Remove(stock);
                barra.Items.Insert(posicion++, comercial);
                barra.Items.Insert(posicion++, stock);
                barra.Items.Insert(posicion++, produccion);
                barra.Items.Insert(posicion, reaprovisionamiento);

                ToolStripMenuItem comercialAltas = CrearSubmenu(comercial, "Formularios de alta");
                AgregarOpcion(comercialAltas, "Personas", cargaPersonasToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Clientes", cargaClientesToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Presupuestos de clientes", cargarPresupuestoClienteToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Pedidos de clientes", cargarPedidoClienteToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Facturas", cargarFacturaToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Cobros", cargaCobroToolStripMenuItem_Click);
                AgregarOpcion(comercialAltas, "Ventas", cargaVentasToolStripMenuItem_Click);

                ToolStripMenuItem comercialGestion = CrearSubmenu(comercial, "Formularios de gestión");
                AgregarOpcion(comercialGestion, "Personas", personaToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Clientes", clienteToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Presupuestos de clientes", presupuestoClienteToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Pedidos de clientes", pedidoDeClienteToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Facturas", facturaToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Cobros", cobroToolStripMenuItem_Click);
                AgregarOpcion(comercialGestion, "Ventas", ventaToolStripMenuItem_Click);

                ToolStripMenuItem stockAltas = CrearSubmenu(stock, "Formularios de alta");
                AgregarOpcion(stockAltas, "Inventario", cargarInventarioToolStripMenuItem_Click);
                AgregarOpcion(stockAltas, "Stock", cargarStockToolStripMenuItem_Click);
                AgregarOpcion(stockAltas, "Catálogo", cargarCatàlogoToolStripMenuItem_Click);
                AgregarOpcion(stockAltas, "Lista de precios", cargarListaPreciosToolStripMenuItem_Click);

                ToolStripMenuItem stockGestion = CrearSubmenu(stock, "Formularios de gestión");
                AgregarOpcion(stockGestion, "Inventario", inventarioToolStripMenuItem_Click);
                AgregarOpcion(stockGestion, "Stock", stockToolStripMenuItem_Click);
                AgregarOpcion(stockGestion, "Catálogo", catalogoToolStripMenuItem_Click);
                AgregarOpcion(stockGestion, "Lista de precios", listaDePreciosToolStripMenuItem_Click);

                ToolStripMenuItem produccionAltas = CrearSubmenu(produccion, "Formularios de alta");
                AgregarOpcion(produccionAltas, "Órdenes de producción", cargaOrdenDeProducciónToolStripMenuItem_Click);
                AgregarOpcion(produccionAltas, "Estados de producción", cargaEstadoToolStripMenuItem_Click);
                AgregarOpcion(produccionAltas, "Producción", cargaProducciónToolStripMenuItem_Click);

                ToolStripMenuItem produccionGestion = CrearSubmenu(produccion, "Formularios de gestión");
                AgregarOpcion(produccionGestion, "Órdenes de producción", ordenDeProducciónToolStripMenuItem_Click);
                AgregarOpcion(produccionGestion, "Estados de producción", estadoDeProducciónToolStripMenuItem_Click);
                AgregarOpcion(produccionGestion, "Producción", producciónToolStripMenuItem_Click);

                ToolStripMenuItem reaprovisionamientoAltas = CrearSubmenu(reaprovisionamiento, "Formularios de alta");
                AgregarOpcion(reaprovisionamientoAltas, "Proveedores", cargaProveedorToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoAltas, "Presupuestos de proveedores", cargarPresupuestoProveedorToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoAltas, "Pedidos de reaprovisionamiento", cargarReaprovisionamientoToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoAltas, "Compras", cargaComprasToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoAltas, "Remitos", cargaRemitoToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoAltas, "Pagos", cargaPagosToolStripMenuItem_Click);

                ToolStripMenuItem reaprovisionamientoGestion = CrearSubmenu(reaprovisionamiento, "Formularios de gestión");
                AgregarOpcion(reaprovisionamientoGestion, "Proveedores", proveedorToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoGestion, "Presupuestos de proveedores", presupuestoProveedorToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoGestion, "Pedidos de reaprovisionamiento", reaprovisionamientoToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoGestion, "Compras", comprasToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoGestion, "Remitos", remitoToolStripMenuItem_Click);
                AgregarOpcion(reaprovisionamientoGestion, "Pagos", pagosToolStripMenuItem_Click);

            }
            finally
            {
                barra.ResumeLayout(true);
            }
        }

        private void PrepararBoton(ToolStripSplitButton boton, string texto)
        {
            boton.Text = texto;
            boton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            boton.DropDownItems.Clear();
        }

        private ToolStripMenuItem CrearSubmenu(ToolStripSplitButton boton, string texto)
        {
            ToolStripMenuItem submenu = new ToolStripMenuItem(texto);
            boton.DropDownItems.Add(submenu);
            return submenu;
        }

        private void AgregarOpcion(ToolStripMenuItem submenu, string texto,
                                  EventHandler evento)
        {
            ToolStripMenuItem opcion = new ToolStripMenuItem(texto);
            opcion.Click += evento;
            submenu.DropDownItems.Add(opcion);
        }

        #endregion

        #region Formulario
        public void LimpiarPanel()
        {
            if (panel1.Controls.Count > 0)
            {
                foreach (System.Windows.Forms.Control control in panel1.Controls)
                {
                    control.Dispose();
                }
                panel1.Controls.Clear();
            }
        }
        public void AbrirFormularioEnPanel(Form formulario)
        {
            panel1.Controls.Clear();

            global::AluSoft.UI.AjusteFormularios.PrepararParaPanel(formulario);
            formulario.TopLevel = false;
            formulario.Dock = DockStyle.Fill;
            formulario.FormBorderStyle = FormBorderStyle.None;

            panel1.Controls.Add(formulario);
            panel1.Tag = formulario;
            formulario.Show();
        }

        #endregion

        private void menu_alum_volver_Click(object sender, EventArgs e)
        {
            Form1 Prueba2_Alumnoss = new Form1();
            this.Hide();
            Prueba2_Alumnoss.Show();
           
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm35_Bitacora());
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_2());
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_2());
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm03_Cliente_2());
        }

        private void presupuestoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm07_PresupuestoCliente_2());
        }

        private void catalogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_2());
        }

        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_2());
        }

        private void reaprovisionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm16_PedidoReaprovisionamiento_2());
        }

        private void presupuestoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm18_PresupuestoProveedor_2());
        }

        private void máximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo_2());
        }

        private void mínimoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo_2());
        }

        private void personaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm00_Persona_2());
        }

        private void cargarInventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm01_Inventario_1());
        }

        private void cargarStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm02_Stock_1());
        }

        private void cargarCatàlogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm12_Catalogo_1());
        }

        private void cargarListaPreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm13_ListaPrecios_1());
        }

        private void cargarPresupuestoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm18_PresupuestoProveedor_1());
        }

        private void cargarPresupuestoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm07_PresupuestoCliente());
        }

        private void cargarReaprovisionamientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm16_PedidoReaprovisionamiento());
        }

        private void cargarMàximoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm19_Maximo());
        }

        private void cargarMìnimoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm20_Minimo());
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_2());
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm09_Factura_2());
        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm11_Ventas_2());
        }

        private void ordenDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_2());
        }

        private void estadoDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_2());
        }

        private void pedidoDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm08_PedidoCliente_2());
        }

        private void cobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm10_Cobro_2());
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm17_Compras_2());
        }

        private void producciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm21_Produccion_2());
        }

        private void remitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm23_Remito_2());
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm24_Pagos_2());
        }

        private void cargarPedidoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm08_PedidoCliente_1());
        }

        private void cargarFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm09_Factura_1());
        }

        private void cargaCobroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm10_Cobro_1());
        }

        private void cargaVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm11_Ventas_1());
        }

        private void cargaOrdenDeProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm14_OrdenProduccion_1());
        }

        private void cargaEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm15_Estado_1());
        }

        private void cargaProducciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm21_Produccion_1());
        }

        private void cargaProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm04_Proveedor_1());
        }

        private void cargaRemitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm23_Remito_1());
        }

        private void cargaPagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm24_Pagos_1());
        }

        private void cargaComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm17_Compras_1());
        }

        private void cargaPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new frm00_Persona(true));
        }

        private void cargaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // El alta completa conserva el paso para generar el presupuesto del cliente.
            AbrirFormularioEnPanel(new frm03_Cliente_Demo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarPanel();
        }

        private void toolStripSplitButton3_ButtonClick(object sender, EventArgs e)
        {
            ((ToolStripSplitButton)sender).ShowDropDown();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Cambiar_Contraseña formulario = new Cambiar_Contraseña())
                formulario.ShowDialog(this);
        }

        private async void exportarBackupToolStripMenuItem_Click(object sender, EventArgs e)
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
                Cursor = Cursors.WaitCursor;

                // Antes se lanzaba la copia en segundo plano sin esperarla: el mensaje de
                // "copia generada" salía enseguida y si la exportación fallaba no se veía el error.
                StringBuilder detalles = new StringBuilder();
                Enabled = false;
                try
                {
                    await Task.Run(() =>
                    {
                        DacServices servicio = new DacServices(cadenaConexion);
                        servicio.Message += (s, ev) =>
                        {
                            if (ev.Message.MessageType == DacMessageType.Error)
                                detalles.AppendLine(ev.Message.ToString());
                        };
                        servicio.ExportBacpac(rutaArchivo, BLL.Conexion.BaseDeDatos);
                    });

                    if (File.Exists(rutaArchivo) && new FileInfo(rutaArchivo).Length > 0)
                        MessageBox.Show("La copia se generó correctamente en:\n" + rutaArchivo, "BACPAC generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("La exportación terminó pero no se encontró el archivo:\n" + rutaArchivo, "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    string mensaje = ex.Message;
                    if (ex.InnerException != null) mensaje += "\n" + ex.InnerException.Message;
                    if (detalles.Length > 0) mensaje += "\n\n" + detalles.ToString();
                    if (mensaje.Length > 3000) mensaje = mensaje.Substring(0, 3000) + "...";
                    MessageBox.Show("No se pudo generar el BACPAC:\n" + mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Enabled = true;
                    Cursor = Cursors.Default;
                }
            }
        }
        private string CitarArgumento(string valor)
        {
            StringBuilder resultado = new StringBuilder();
            resultado.Append('"');

            int barras = 0;

            foreach (char caracter in valor)
            {
                if (caracter == '\\')
                {
                    barras++;
                }
                else if (caracter == '"')
                {
                    resultado.Append('\\', barras * 2 + 1);
                    resultado.Append('"');
                    barras = 0;
                }
                else
                {
                    resultado.Append('\\', barras);
                    resultado.Append(caracter);
                    barras = 0;
                }
            }

            resultado.Append('\\', barras * 2);
            resultado.Append('"');

            return resultado.ToString();
        }
        private void importarBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar archivo BACPAC";
                dialogo.Filter = "Archivos BACPAC (*.bacpac)|*.bacpac";
                dialogo.CheckFileExists = true;

                if (dialogo.ShowDialog() != DialogResult.OK)
                    return;

                string rutaSqlPackage =
                    @"C:\Program Files\Microsoft SQL Server\160\DAC\bin\SqlPackage.exe";

                if (!File.Exists(rutaSqlPackage))
                {
                    MessageBox.Show("No se encontró SqlPackage.exe. Revisá la ruta configurada.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                string servidor;
                string baseDatos;

                using (DialogoDestinoSql dialogoDestino = new DialogoDestinoSql())
                {
                    if (dialogoDestino.ShowDialog(this) != DialogResult.OK)
                        return;

                    servidor = dialogoDestino.Servidor;
                    baseDatos = dialogoDestino.BaseDatos;
                }

                if (servidor.Length == 0 || baseDatos.Length == 0)
                {
                    MessageBox.Show("Ingresá el servidor y el nombre de la base de datos.");
                    return;
                }

                DialogResult confirmacion = MessageBox.Show(
                    "Se importará el archivo en la base de datos '" + baseDatos +
                    "'. El destino debe ser una base nueva o vacía. ¿Continuar?",
                    "Confirmar importación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes)
                    return;

                Cursor = Cursors.WaitCursor;

                try
                {
                    SqlConnectionStringBuilder conexion =
                        new SqlConnectionStringBuilder();

                    conexion.DataSource = servidor;
                    conexion.InitialCatalog = baseDatos;
                    conexion.IntegratedSecurity = true;
                    conexion.Encrypt = true;
                    conexion.TrustServerCertificate = true;

                    string argumentos =
                        "/Action:Import " +
                        "/SourceFile:" + CitarArgumento(dialogo.FileName) + " " +
                        "/TargetConnectionString:" +
                        CitarArgumento(conexion.ConnectionString);

                    ProcessStartInfo inicio = new ProcessStartInfo();
                    inicio.FileName = rutaSqlPackage;
                    inicio.Arguments = argumentos;
                    inicio.UseShellExecute = false;
                    inicio.CreateNoWindow = true;
                    inicio.RedirectStandardOutput = true;
                    inicio.RedirectStandardError = true;

                    using (Process proceso = new Process())
                    {
                        proceso.StartInfo = inicio;
                        proceso.Start();

                        Task<string> salida = proceso.StandardOutput.ReadToEndAsync();
                        Task<string> error = proceso.StandardError.ReadToEndAsync();

                        proceso.WaitForExit();

                        if (proceso.ExitCode == 0)
                        {
                            MessageBox.Show("La base de datos se importó correctamente.","AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Falló la importación.\r\n\r\n" +salida.Result + "\r\n" + error.Result,"Error de importación",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo ejecutar la importación:\r\n" + ex.Message,"AluSoft",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usted está en la pantalla del soporte, ellos estarán dedicados a resolver los problemas que pueda tener algún usuario de los anteriores, ya que este tiene la totalidad de funcionalidades disponibles, ayudando a resolver posibles errores o equivocaciones. " +
"También otorgará el permiso a los directivos para crear su perfil. " +
"En caso de necesitar más ayuda se puede comunicar con alusoft@gmail.com.\n\n");
        }
    }
}
