using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "ismail47el@gmail.com",
                    Password = "gmzmhfzvplskohfr"
                }
            };
            MailAddress FromEmail = new MailAddress("ismail47el@gmail.com", "DROPI bb");
            MailAddress ToEmail = new MailAddress(textBox1.Text,"Someome");
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = textBox2.Text,
                Body = textBox3.Text
            };
            Message.To.Add(ToEmail);
            Client.SendCompleted += Client_SendCompleted;
            for (int i = 0; i < 3; i++)
            {
                Client.Send(Message);

            }

            //for (int i = 0; i < 5; i++)
            //{
            //    try
            //    {

            //        Client.Send(Message);

            //    }
            //    catch (Exception E)
            //    {
            //        MessageBox.Show("chi 7aja machi tal lih\n" + E.Message, "ree");
            //        break;
            //    }
            //}
            //MessageBox.Show("have sent");



        }
        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Error!=null)
            {
                MessageBox.Show("Error " + e.Error.Message, "Error");
                return;
            }
            MessageBox.Show("have sent");

        }

    }
}
