using System.Net;
using System.Net.Security;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MQLDatabase.Common
{
    public static class EmailHelper
    {
        public static void SendMailBySmtp(string host, int port, bool ssl, string email, string name, string usersender, string emailsender, string passsender, string namesender, string subject, string body)
        {
            var toAddress = new MailAddress(email, name);
            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = ssl,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(usersender, passsender)
            };
            using (var message = new MailMessage(new MailAddress(emailsender, namesender), toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8
            })
            {

                ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
                smtp.Send(message);
            }
        }

        private static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }
    }
}
