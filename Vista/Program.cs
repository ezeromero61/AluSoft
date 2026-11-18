using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AluSoftPresentacion16_6
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) =>
                MessageBox.Show("No se pudo completar la operación: " + e.Exception.Message,
                    "AluSoft", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            global::AluSoft.UI.VentanaGlobal.Iniciar();
            Application.Run(new Form1());
        }
    }
}
