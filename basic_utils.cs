    public void downloadFile(string url)
        {
            try {
                
                WebClient client = new WebClient();
                byte[] host2 = client.DownloadData(url);
            }
            catch (WebException) { MessageBox.Show("Unable to connect to internet.\nPlease check your connection and retry"); }
        }

    public void execnow(string fldr_url_or_program)
        {
            System.Diagnostics.Process.Start(fldr_url_or_program);
        }

    private void SendMail(string mail, Utente u)
        {
            var fromAddress = new MailAddress("mail mittente", "es - mittente Team");
            var toAddress = new MailAddress("mail destinataria");//, "");
            const string fromPassword = "password dell'account mittente";
            const string subject = "oggetto della mail";
            string body = "testo della mail";


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential("mail mittente", fromPassword),
                Timeout = 20000
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try { smtp.Send(message); }
                catch
                {
                    MessageBox.Show("Riscontrato un errore nell' invio della mail");
                }
            }
        }