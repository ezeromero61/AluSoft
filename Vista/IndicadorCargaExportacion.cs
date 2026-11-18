using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    /// <summary>
    /// Muestra una animación mientras se genera un archivo Excel.
    /// Se ejecuta en un hilo de interfaz independiente para seguir animándose
    /// aunque la exportación actual se realice de forma síncrona.
    /// </summary>
    internal sealed class IndicadorCargaExportacion : IDisposable
    {
        private readonly ManualResetEvent ventanaLista = new ManualResetEvent(false);
        private readonly Thread hiloVentana;
        private Form ventana;

        public IndicadorCargaExportacion()
        {
            hiloVentana = new Thread(MostrarVentana);
            hiloVentana.IsBackground = true;
            hiloVentana.SetApartmentState(ApartmentState.STA);
            hiloVentana.Start();
            ventanaLista.WaitOne();
        }

        private void MostrarVentana()
        {
            ventana = new Form();
            ventana.Text = "Exportando a Excel";
            ventana.FormBorderStyle = FormBorderStyle.FixedDialog;
            ventana.StartPosition = FormStartPosition.CenterScreen;
            ventana.ClientSize = new Size(390, 112);
            ventana.ControlBox = false;
            ventana.ShowInTaskbar = false;
            ventana.TopMost = true;

            Label mensaje = new Label();
            mensaje.AutoSize = false;
            mensaje.Text = "Generando el archivo de Excel. Por favor, espere...";
            mensaje.TextAlign = ContentAlignment.MiddleCenter;
            mensaje.Location = new Point(15, 14);
            mensaje.Size = new Size(360, 28);

            ProgressBar progreso = new ProgressBar();
            progreso.Style = ProgressBarStyle.Marquee;
            progreso.MarqueeAnimationSpeed = 28;
            progreso.Location = new Point(25, 58);
            progreso.Size = new Size(340, 22);

            ventana.Controls.Add(mensaje);
            ventana.Controls.Add(progreso);
            ventana.Shown += (sender, args) => ventanaLista.Set();
            Application.Run(ventana);
        }

        public void Dispose()
        {
            if (ventana != null && hiloVentana.IsAlive)
            {
                try
                {
                    // Invoke es síncrono: espera a que el otro hilo oculte y
                    // cierre la ventana antes de que continúe la exportación.
                    ventana.Invoke(new Action(() =>
                    {
                        ventana.Hide();
                        ventana.Close();
                    }));

                    // Application.Run termina al cerrarse la ventana.
                    hiloVentana.Join();
                }
                catch (InvalidOperationException)
                {
                    // La ventana o su hilo ya se estaban cerrando.
                }
            }

            ventanaLista.Dispose();
        }
    }
}
