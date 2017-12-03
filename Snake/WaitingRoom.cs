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
using System.Text.RegularExpressions;
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
                    server.DataReceived += GetServer;
                    server.Start(ip, port);
                    test.Text = name + "\n";
                    break;
                case "client":
                    client = new SimpleTcpClient();
                    client.StringEncoder = Encoding.UTF8;
                    client.DataReceived += GetClient;
                    client.Connect(ipAdress, port);
                    startMulti.Visible = false;
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
                client.WriteLine(name);
        }

        // functions
        private void GetServer(object sender, SimpleTCP.Message e)
        {
            test.Invoke((MethodInvoker)delegate ()
            {
                string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);
                test.Text += recieved + "\n";
            });
            server.BroadcastLine(test.Text);
        }
        private void GetClient(object sender, SimpleTCP.Message e)
        {
            test.Invoke((MethodInvoker)delegate ()
            {
                string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);
                test.Text = recieved;
            });
        }
        public void Stop()
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
