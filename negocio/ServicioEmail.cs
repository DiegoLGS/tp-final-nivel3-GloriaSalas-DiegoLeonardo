using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ServicioEmail
    {
        private MailMessage email;
        private SmtpClient server;

        public ServicioEmail()
        {
            server = new SmtpClient();
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }
        public void armarCorreo(string emailDestino, string credencialEmail, string credencialPassword)
        {
            server.Credentials = new NetworkCredential(credencialEmail, credencialEmail);
            email = new MailMessage();
            email.To.Add(emailDestino);
            email.Subject = "¡Bienvenido a Tienda Web!";
            email.IsBodyHtml = true;

            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            sb.Append("<body style='font-family: Arial, sans-serif; color: #333;'>");
            sb.Append("<h1 style='color: #007bff; text-decoration: underline;'>¡Bienvenido a TiendaWeb!</h1>");
            sb.Append("<p>Estimado Usuario,</p>");
            sb.Append("<p>Te damos la bienvenida a <span style='color: #007bff;'>TiendaWeb</span>, tu tienda en línea favorita.</p>");
            sb.Append("<p>Aquí encontrarás una amplia selección de productos y ofertas exclusivas.</p>");
            sb.Append("<p style='font-size: 24px;'>¡Esperamos que disfrutes de tu experiencia de compra!</p>");
            sb.Append("<br/>");
            sb.Append("<p>Atentamente,</p>");
            sb.Append("<p>El equipo de TiendaWeb</p>");
            sb.Append("</body>");
            sb.Append("</html>");

            email.Body = sb.ToString();
        }

        public void enviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
