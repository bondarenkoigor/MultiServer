using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WinformsClient
{
    public partial class ClientForm : Form
    {
        const int PORT = 8008;
        IPEndPoint IPEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), PORT);
        Socket ClientSocket;
        public ClientForm()
        {
            try
            {
                ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                ClientSocket.Connect(IPEndPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            InitializeComponent();
        }

        private void RichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                lock (ClientSocket)
                {
                    e.Handled = true;
                    string text = this.richTextBox.Text;
                    this.richTextBox.Clear();
                    if (text == String.Empty) return;

                    this.ClientSocket.Send(Encoding.Unicode.GetBytes("text"));
                    if (ReceiveString() == "message type confirmed")
                        this.ClientSocket.Send(Encoding.Unicode.GetBytes(text));

                    Label label = new Label();
                    label.Text = $"[{DateTime.Now.ToLongTimeString()}] text sent";
                    label.AutoSize = true;
                    label.Font = new Font("Arial", 20);
                    this.flowLayoutPanel.Controls.Add(label);
                }
            }
        }

        private string ReceiveString()
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = ClientSocket.Receive(buffer);
                sb.Append(Encoding.Unicode.GetString(buffer, 0, byteCount));
                if (byteCount == 0) continue;
            } while (ClientSocket.Available > 0);

            return sb.ToString();
        }

        private void AttachFileButton_Click(object sender, EventArgs e)
        {
            lock (ClientSocket)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.ShowDialog();
                if (openFileDialog.FileName == String.Empty) return;
                FileInfo file = new FileInfo(openFileDialog.FileName);

                ClientSocket.Send(Encoding.Unicode.GetBytes("file"));
                if (ReceiveString() != "message type confirmed") return;

                ClientSocket.Send(Encoding.Unicode.GetBytes(file.Extension));
                if (ReceiveString() != "extension confirmed") return;

                ClientSocket.Send(File.ReadAllBytes(file.FullName));

                Label label = new Label();
                label.Text = $"[{DateTime.Now.ToLongTimeString()}] {file.Name} sent";
                label.AutoSize = true;
                label.Font = new Font("Arial", 20);
                this.flowLayoutPanel.Controls.Add(label);
            }
        }
    }
}
