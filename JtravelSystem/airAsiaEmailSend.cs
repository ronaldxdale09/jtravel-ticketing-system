using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JtravelSystem
{
    public partial class airAsiaEmailSend : Form
    {
        String agentEmail = settings.agentEmail;
        String agentPass = settings.agentPassword;
        public airAsiaEmailSend()
        {
            InitializeComponent();
      
            textFilename.Text = airasia.fileLocation;
            emailTitle.Text = "JTRAVEL TICKET; CEB PAC PNR Booking No.[    ]";
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {

                MailMessage mail = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(agentEmail);
                mail.To.Add(clientEmail.Text);
                mail.Subject = emailTitle.Text;
                mail.Body = textBody.Text;
                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(textFilename.Text);
                mail.Attachments.Add(attachment);

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(agentEmail, agentPass);
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Mail Has been Sent", "SUCESSFULL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void linkAttachFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.ShowDialog();
            textFilename.Text = openFileDialog1.FileName;
        }
    }
}
