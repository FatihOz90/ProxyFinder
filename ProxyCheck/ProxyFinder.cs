using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyCheck
{
    public partial class ProxyFinder : Form
    {
        readonly WebClient _WC                  = new WebClient();
        readonly DefaultRegex _DFR              = new DefaultRegex();
        readonly HashSet<string> ProxyIpHashSet = new HashSet<string>();
        readonly List<string> ProxyIpList       = new List<string>();
        readonly List<Task> taskList            = new List<Task>();
        readonly OpenFileDialog LoadFile        = new OpenFileDialog();


        public bool IsFinish = true;
        public ProxyFinder()
        {
            CheckForIllegalCrossThreadCalls = false; //Thread çakışmalarını pass geç.
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Render
            DGV_PROXYLIST.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(DGV_PROXYLIST, true, null);
        }

        //Proxy 
        private void btn_GetProxyIP_Click(object sender, EventArgs e)
        {
            if (IsFinish)
                new Thread(new ThreadStart(GatherTheProxies)).Start();
            else
                LB_Logs.Items.Add("GetProxyIP :Is Working (Please Wait)");
        }

        private void GatherTheProxies()
        {
            IsFinish = false;
            ProxyIpHashSet.Clear();

            foreach (string Source in TB_Sources.Lines)
            {
                bool isError = false;  //flag would remain flase if no exception occurs 
                try
                {
                    string UnparsedWebSource = _WC.DownloadString(Source);
                    MatchCollection _MC = _DFR.REGEX.Matches(UnparsedWebSource);
                    foreach (Match Proxy in _MC)
                    {
                        if (ProxyIpHashSet.Add(Proxy.ToString()))
                        {
                            //MessageBox.Show(line  + " IpAddress duplicate values.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    LB_Logs.Items.Add(ex.Message.ToString());
                    isError = true;
                }
                if (isError) continue;   //flag would be true if exception occurs
            }

            Thread.Sleep(10);//Wait

            LB_Logs.Items.Add("Duplicate Proxy Clean.. (Please Wait)");

            DGV_PROXYLIST.Rows.Clear();//Clean List

            foreach (var item in ProxyIpHashSet)
                DGV_PROXYLIST.Rows.Add(item, false, false, false);

            IsFinish = true;
            LB_Logs.Items.Add("Added Proxy Count  : " + DGV_PROXYLIST.Rows.Count + " (Completed) ");
        }
        // Proxy End

        //Test List
        public static bool SoketConnect(string ip, int port)
        {
            var is_success = false;
            try
            {
                var connsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                connsock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 200);

                Thread.Sleep(100);
                var hip = IPAddress.Parse(ip);
                var ipep = new IPEndPoint(hip, port);
                connsock.Connect(ipep);
                if (connsock.Connected)
                    is_success = true;

                connsock.Close();
            }
            catch (Exception)
            {
                is_success = false;
            }
            return is_success;
        }
        public static bool PingTest(string ip)
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(ip, 2000);
                if (reply == null) return false;

                return (reply.Status == IPStatus.Success);
            }
            catch (PingException)
            {
                return false;
            }
        }
        public bool TestProxyWeb(string destIP, int destPort)
        {
            try
            {
                WebClient web = new WebClient
                {
                    Proxy = new WebProxy(destIP, destPort)
                };
                web.DownloadString("http://icanhazip.com/");
                return true;
            }
            catch (Exception) { }
            return false;
        }

        //Ckeck Proxy List (Is Working)
        private void BtnCheckProxy_Click(object sender, EventArgs e)
        {
            Task.Run(async () => await BtnCheckProxy_DoWorkAsync());
        }

        private async Task BtnCheckProxy_DoWorkAsync()
        {
            foreach (DataGridViewRow row in DGV_PROXYLIST.Rows)
            {
                string[] Ipshred = DGV_PROXYLIST.Rows[row.Index].Cells[0].Value.ToString().Split(':');

                var task = Task.Run(() => {
                    Foo(Ipshred[0], Convert.ToInt32(Ipshred[1]), row.Index);
                });
                taskList.Add(task);
            }

            await Task.WhenAll(taskList);

            LB_Logs.Items.Add("All threads complete, All Proxy Checked.");
        }

        void Foo(string ip, int port, int rowId)
        {
            bool resultSoketConnect = SoketConnect(ip, port);
            bool resultPingTest = PingTest(ip);
            bool resultTestProxyGoogle = TestProxyWeb(ip, port);

            //Update Table
            DGV_PROXYLIST.Rows[rowId].Cells[1].Value = resultSoketConnect;
            DGV_PROXYLIST.Rows[rowId].Cells[2].Value = resultPingTest;
            DGV_PROXYLIST.Rows[rowId].Cells[3].Value = resultTestProxyGoogle;
        }

        //Btn List
        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            const string sPath = ".\\save.txt";
            StreamWriter SaveFile = new StreamWriter(sPath);

            foreach (DataGridViewRow row in DGV_PROXYLIST.Rows.OfType<DataGridViewRow>().ToList())
                SaveFile.WriteLine(row.Cells[0].Value.ToString());

            SaveFile.Close();

            LB_Logs.Items.Add("Proxy List saved!");
        }
        private void btnLoadText_Click(object sender, EventArgs e)
        {
            ProxyIpList.Clear();

            LoadFile.InitialDirectory = ".\\";
            LoadFile.Filter = "Text |*.txt";

            if (LoadFile.ShowDialog() == DialogResult.OK)
            {
                string Filedir = LoadFile.FileName;
                string FileName = LoadFile.SafeFileName;
                string[] lines = File.ReadAllLines(Filedir);

                foreach (var item in lines)
                {
                    if (!ProxyIpList.Contains(item))
                        ProxyIpList.Add(item);
                }


                foreach (var item in ProxyIpList)
                    DGV_PROXYLIST.Rows.Add(item, false, false, false);

                LB_Logs.Items.Add(FileName.ToString() + " File Add.");
            }
        }
        private void btnNotWorkingDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DGV_PROXYLIST.Rows.Count; i++)
            {
                var data = DGV_PROXYLIST.Rows[i];

                if ((bool)data.Cells[1].Value == false &&
                   (bool)data.Cells[2].Value == false &&
                   (bool)data.Cells[3].Value == false)
                {
                    DGV_PROXYLIST.Rows.Remove(data);
                }
            }
        }

        private void btnGethttpProxy_Click(object sender, EventArgs e)
        {
            string[] links = new string[] {
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/http.txt",
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/socks4.txt",
            "https://raw.githubusercontent.com/TheSpeedX/SOCKS-List/master/socks5.txt",
            "https://raw.githubusercontent.com/fate0/proxylist/master/proxy.list",
            "https://raw.githubusercontent.com/a2u/free-proxy-list/master/free-proxy-list.txt",
            "http://rootjazz.com/proxies/proxies.txt",
            "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=http&timeout=10000&country=all&ssl=all&anonymity=all",
            "https://api.proxyscrape.com/v2/?request=displayproxies&protocol=socks5&timeout=10000&country=all&ssl=all&anonymity=all",
            "https://github.com/roosterkid/openproxylist/blob/main/SOCKS5_RAW.txt",
            "https://github.com/roosterkid/openproxylist/blob/main/HTTPS_RAW.txt",
            "https://github.com/opsxcq/proxy-list/blob/master/list.txt",
            "https://github.com/hookzof/socks5_list/blob/master/proxy.txt",
            "https://github.com/ShiftyTR/Proxy-List/blob/master/proxy.txt",
            "https://github.com/clarketm/proxy-list/blob/master/proxy-list.txt",
            "https://github.com/mmpx12/proxy-list/blob/master/proxies.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/hproxy.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/http.txt",
            "https://github.com/Volodichev/proxy-list/blob/main/http_old.txt",
            "https://github.com/sunny9577/proxy-scraper/blob/master/proxies.txt",
            "https://github.com/jetkai/proxy-list/blob/main/online-proxies/txt/proxies.txt",
            "https://checkerproxy.net/api/archive/" + DateTime.Today.ToString("yyyy-MM-d"),
        };

            foreach (string link in links)
                TB_Sources.Text += link.ToString() + Environment.NewLine;

            LB_Logs.Items.Add("Web Proxy list loaded.");
        }
    }
}