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
                string temp = "";   
                ipAdress = localIPs[2].ToString();
                for (int i = 0, a = 0; i < ipAdress.Length; i++)
                {
                    if (ipAdress[i] == '.' && ++a == 3)
                    {
                        temp = ipAdress.Substring(i+1, ipAdress.Length-i-1);
                        break;
                    }
                }
                ip = IPAddress.Parse(ipAdress);

            InitializeComponent();
            this.Text += temp;
            this.name = name;
            this.who = "host";
               
            server = new SimpleTcpServer();
                server.Delimiter = 0x13;
                server.StringEncoder = Encoding.UTF8;
                server.DataReceived += GetServer;
                server.Start(ip, 8000);
                players.Text = name + "\n";
        }
        public WaitingRoom(string name, int conNum)
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                ipAdress = localIPs[2].ToString();
                string temp = "";
                for (int i=0, a=0; i < ipAdress.Length; i++)
                {
                    if(ipAdress[i] == '.' && ++a == 3)
                    {
                        ipAdress = ipAdress.Substring(0, i+1) + conNum.ToString();
                        temp = conNum.ToString();
                        break;
                    }
                }
                ip = IPAddress.Parse(ipAdress);
            

            InitializeComponent();
            this.Text += temp;
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
        private void startMulti_Click(object sender, EventArgs e)
        {
            server.BroadcastLine("StArT");
            this.Stop();

            MultiPlayerHost mp = new MultiPlayerHost(ip);
            this.Hide();
            mp.ShowDialog();
            this.Show();
        }

        // functions
        private void GetServer(object sender, SimpleTCP.Message e)
        {
            string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);

            players.Invoke((MethodInvoker)delegate ()
            {
                players.Text += recieved + "\n";
            });
            server.BroadcastLine(players.Text);
        }
        private void GetClient(object sender, SimpleTCP.Message e)
        {
            string recieved = Regex.Replace(e.MessageString, @"\u0013", String.Empty);

            if(recieved.Equals("StArT"))
            {
                MultiPlayerClient mp = new MultiPlayerClient(ipAdress);
                this.Stop();

                this.Hide();
                mp.ShowDialog();
                this.Show();
            }

            players.Invoke((MethodInvoker)delegate ()
            {
                
                players.Text = recieved;
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
