using MaterialSkin.Controls;
using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class WaitingRoom : MaterialForm
    {
        // properties
        SimpleTcpServer server;
        SimpleTcpClient client;
        string who;
        static string ipAdress = "127.0.0.1";
        IPAddress ip = IPAddress.Parse(ipAdress);
        string name;

        // constructor
        public WaitingRoom(string who, string name, int port)
        {
            InitializeComponent();
            this.name = name;
            this.who = who;

            switch (who)
            {
                case "host":
                    server = new SimpleTcpServer();
                    server.Delimiter = 0x13;
                    server.StringEncoder = Encoding.UTF8;
                    server.DataReceived += NewClient;
                    server.Start(ip, port);
                    test.Text = name + "\n";
                    break;
                case "client":
                    client = new SimpleTcpClient();
                    client.StringEncoder = Encoding.UTF8;
                    client.DataReceived += AddClient;
                    client.Connect(ipAdress, port);
                    test.Text = name + "\n";
                    break;
                default:
                    MessageBox.Show("Unknown TCP user");
                    this.Close();
                    break;
            }
        }

        // events
        private void WaitingRoom_Load(object sender, EventArgs e)
        {
            if (who == "client")
                client.WriteLineAndGetReply(name, TimeSpan.FromSeconds(3));
        }

        // functions
        private void NewClient(object sender, SimpleTCP.Message e)
        {
            test.Invoke((MethodInvoker)delegate ()
            {
                test.Text += e.MessageString + "\n";
                e.ReplyLine(name);
            });
        }
        private void AddClient(object sender, SimpleTCP.Message e)
        {
            test.Invoke((MethodInvoker)delegate ()
            {
                test.Text += e.MessageString + "\n";
            });
        }
        public void Close()
        {
            switch (who)
            {
                case "host":
                    server.Stop();
                    break;
                case "client":
                    client.Disconnect();
                    break;
            }
        }

        
    }
}
