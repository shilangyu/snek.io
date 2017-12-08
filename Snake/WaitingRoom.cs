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
        static string ipAdress;
        IPAddress ip;
        string name;

        // constructor
        public WaitingRoom(string name)
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                ipAdress = localIPs[2].ToString();
                ip = IPAddress.Parse(ipAdress);

            InitializeComponent();
            this.name = name;
            this.who = "host";
               
            server = new SimpleTcpServer();
                server.Delimiter = 0x13;
                server.StringEncoder = Encoding.UTF8;
                server.DataReceived += GetServer;
                server.Start(ip, 8000);
                test.Text = name + "\n";
        }
        public WaitingRoom(string name, int conNum)
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                ipAdress = localIPs[2].ToString();
                for(int i=0, a=0; i < ipAdress.Length; i++)
                {
                    if(ipAdress[i] == '.' && ++a == 3)
                    {
                        ipAdress = ipAdress.Substring(0, i+1) + conNum.ToString();
                    }
                }
                ip = IPAddress.Parse(ipAdress);

            InitializeComponent();
            this.name = name;
            this.who = "client";
            
            client = new SimpleTcpClient();
                client.StringEncoder = Encoding.UTF8;
                client.DataReceived += GetClient;
                client.Connect(ipAdress, 8000);
                startMulti.Visible = false;
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
