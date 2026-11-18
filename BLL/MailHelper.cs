using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class MailHelper
    {
        private const string CuentaCorreo = "cuentaalusoft@gmail.com";
        private const string NombreRemitente = "AluSoft";
        private const string ContraseñaAplicacion = "imli czer hhpr rhas";

        public static void Enviar(string destino, string asunto, string cuerpo)
        {
            if (ContraseñaAplicacion.StartsWith("PEGAR_ACA"))
                throw new Exception("Falta configurar la contraseña de aplicación de Gmail en BLL\\MailHelper.cs.");
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(CuentaCorreo, NombreRemitente);
                mail.To.Add(destino);
                mail.Subject = asunto;
                mail.Body = cuerpo;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(CuentaCorreo, ContraseñaAplicacion.Replace(" ", ""));
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch
            {
                throw new Exception("Error al enviar el mail. \n \n " +
                    "Por favor verificá tu conexión a internet y que los datos de la cuenta sean correctos.");
            }
        }

        public static void EnviarRecuperacion(string destino, string usuario, string nuevaContraseña)
        {
            Enviar(destino, "AluSoft - Recuperación de contraseña", CrearCuerpoRecuperacion(usuario, nuevaContraseña));
        }

        private static string CrearCuerpoRecuperacion(string usuario, string nuevaContraseña)
        {
            return @"<div style='font-family:Segoe UI,Arial;color:#0B2E4A'>
                        <h2 style='color:#00A7B8'>AluSoft - Recuperación de contraseña</h2>
                        <p>Se generó una contraseña nueva para el usuario <b>" + WebUtility.HtmlEncode(usuario) + @"</b>:</p>
                        <h1 style='letter-spacing:3px'>" + WebUtility.HtmlEncode(nuevaContraseña) + @"</h1>
                        <p>Ingresá con esta contraseña. Si no pediste el cambio, avisale al administrador.</p>
                     </div>";
        }
    }
}
