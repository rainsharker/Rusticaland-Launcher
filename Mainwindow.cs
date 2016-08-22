using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Text;
using QueryMaster;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using TS3ClientQueryFramework;
using TS3ClientQueryFramework.TS3Models;
using System.Threading;
using RustRcon;
using Launcher1;
using System.Drawing.Text;
using System.Drawing;

namespace Launcher1


{

   
    public partial class Mainwindow : Form

    {


        TS3Client ts3Client = new TS3Client();


        public Mainwindow()
            {

                InitializeComponent();
            
        }



        public class FileTransfer
        {
            public string Name;
            public int Size;
            public string Content;
        }


        // static Stream str = Properties.Resources.nuclear;


        //  System.Media.SoundPlayer player =
        //          new System.Media.SoundPlayer(str);

        static Stream str = Properties.Resources.Mike;


        System.Media.SoundPlayer player =
                new System.Media.SoundPlayer(str);





        Stream nigga = Assembly.GetExecutingAssembly()
        .GetManifestResourceStream("Launcher1.28 Days Later.TTF");


        public void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"Rust\";
            proc.FileName = "Rustclient.exe";
            proc.Arguments = "";
            proc.Verb = "";

            try
            {
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR- Your Launcher is in the wrong folder ----" + ex.Message);

            }
               Application.Exit();  // Quit itself


        }

        public bool existcheck()
        {

            string curFile = @"C:\hax3s.dll";

            if (File.Exists(curFile))
            {
                
                return true;
            }
            return false;
        }
        public static IPAddress GetIPAddress(string hostName)
        {
            Ping ping = new Ping();
            var replay = ping.Send(hostName);

            if (replay.Status == IPStatus.Success)
            {
                return replay.Address;
            }
            return null;
        }



       


       

//FileTransfer fileTransfer = new FileTransfer();
//        fileTransfer.Name = "TestFile";
//fileTransfer.Content = System.Convert.ToBase64String(File.ReadAllBytes(@"C:\Program Files (x86)\Steam\userdata\349991994\config\localconfig.vdf"));
//System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(fileTransfer.GetType());
//        TcpClient client = new TcpClient();
//        client.Connect(IPAddress.Parse("5.1.80.143"), 40399);
//Stream stream = client.GetStream();
//        x.Serialize(stream, fileTransfer);
//client.Close();

            public void ftppost()
        {
            var lines = File.ReadAllLines("Rust/LumaEmu.ini");
            // comboBox1.Text = lines[2];
            var line = lines[1];
            if (line == null)
                return;

            // split string to first and last names
            var parts = line.Split('=');
            if (parts.Length != 2)
                return;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://138.201.145.228/");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("Launcher", "RusticalandLauncher2016");

            // Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader("testfile.txt");
            string content = parts[1] + "Local IP Address: " + "__" + parts[1] + "__" + "ESP File Exists=" + existcheck() + "__" + GetIPAddress("localhost") + GetIPAddress(Dns.GetHostName()) + Dns.GetHostName();
            byte[] fileContents = Encoding.UTF8.GetBytes(content);
           // sourceStream.Close();
            request.ContentLength = fileContents.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            response.Close();



        }


        public static bool IsApplictionInstalled(string p_name)
        {
            string displayName;
            RegistryKey key;

            // search in: CurrentUser
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_32
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // search in: LocalMachine_64
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (String keyName in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(keyName);
                displayName = subkey.GetValue("DisplayName") as string;
                if (p_name.Equals(displayName, StringComparison.OrdinalIgnoreCase) == true)
                {
                    return true;
                }
            }

            // NOT FOUND
            return false;
        }
        private FtpWebRequest GetRequest(string URI)
        {
            //create request
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create("ftp://crushed.serverturbo.de/Test.json");
            //Set the login details
            result.Credentials = GetCredentials();
            //Do not keep alive (stateless mode)
            result.KeepAlive = false;
            return result;
        }

        /// <summary>
        /// Get the credentials from username/password
        /// </summary>
        private System.Net.ICredentials GetCredentials()
        {
            return new System.Net.NetworkCredential("ftpuser", "B0");
        }

        public void Haxnote ()
        {


            var lines = File.ReadAllLines("Rust/LumaEmu.ini");
            // comboBox1.Text = lines[2];
            var line = lines[1];
            if (line == null)
                return;

            // split string to first and last names
            var parts = line.Split('=');
            if (parts.Length != 2)
                return;






            WebClient request = new WebClient();
            string url = "ftp://launcher@rusticaland.ddns.net/Test.json";
            request.Credentials = new NetworkCredential("launcher", "launcher");

           
                byte[] newFileData = request.DownloadData(url);
                string fileString = System.Text.Encoding.UTF8.GetString(newFileData);
               
        




            FtpWebRequest requeste = (FtpWebRequest)WebRequest.Create("ftp://launcher@rusticaland.ddns.net/Test.json");
            requeste.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("launcher", "");




            requeste.Method = WebRequestMethods.Ftp.UploadFile;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();

            string content = fileString + Environment.NewLine + parts[1] + "Local IP Address: " + "__" + parts[1] + "__" + "ESP File Exists=" + existcheck() + "__" +"IsAutohotkey Installed?="+ IsApplictionInstalled("Autohotkey") + "___"+ DateTime.Now.ToString("HH:mm:ss tt") + GetIPAddress(Dns.GetHostName()) + Dns.GetHostName();
            byte[] fileContents = Encoding.UTF8.GetBytes(content);
            //and now plug that into your example
            Stream requestStream = requeste.GetRequestStream();
           // StreamReader read = new StreamReader(requestStream);
            //string existsContent = read.ReadToEnd();
                
            
                requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("ftp://rusticaland.ddns.net/Version.txt");
            StreamReader sr = new StreamReader(stream);

            string content = sr.ReadToEnd(); 

            if (content == File.ReadAllText("Rust/Version.txt"))
            {
                DialogResult one = MessageBox.Show("You already have the latest Version!", "Result", MessageBoxButtons.OK);
            }
            else
            {

                DialogResult one = MessageBox.Show("Do you want to Update?", "Update Found", MessageBoxButtons.YesNo);
                if (one == DialogResult.Yes)
                {

                    //MainForm nwForm = new MainForm();
                 


                }


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("http://rusticaland.ddns.net");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.teamspeak.com/downloads#");

        }





        private void button6_Click(object sender, EventArgs e)
        {
            string url = "";

            string business = "Tenax92@gmx.de";  // your paypal email
            string description = "Rusticaland";            // '%20' represents a space. remember HTML!
            string country = "DE";                  // AU, US, etc.
            string currency = "EUR";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            Process.Start(url);

        }



        private void button7_Click(object sender, EventArgs e)
        {
            VideoSettings sett = new VideoSettings();
            sett.Show();


        }

        private void button8_Click(object sender, EventArgs e)
        {
            Namechange nwForm = new Namechange();
            nwForm.ShowDialog(this);


        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("http://map.playrust.io/?rusticaland.ddns.net:28015");
        }



        private void button10_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("client.connect rusticaland.ddns.net:28015");

            DialogResult one = MessageBox.Show("Copy'd to Clipboard!");
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

         
            Haxnote();
            Show();
            try
            {
                var lines = File.ReadAllLines("Rust/LumaEmu.ini");
                // comboBox1.Text = lines[2];
                var line = lines[1];
                if (line == null)
                    return;

                // split string to first and last names
                var parts = line.Split('=');
                if (parts.Length != 2)
                    return;

                // send them to textBox.Text property
                textBox2.Text = parts[1];
            }
            catch (Exception ex2)
            {


                MessageBox.Show(ex2.Message);


            }

            fontload();
            if (Properties.Settings.Default.Music == true)
            {
                checkBox1.Checked = true;

            }


            if(checkBox1.Checked == false)
            {
                player.Play();

            }



            

            //sendFile();


        }
        public void fontload()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("Rust.ttf");
          
        }


        private void button11_Click(object sender, EventArgs e)
        {
               player.Stop();
             player.Play();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("rusticaland.ddns.net");

            DialogResult one = MessageBox.Show("Copy'd to Clipboard!");
        }



        private void pictureBox3_Click_2(object sender, EventArgs e)
        {

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Rcon rcon = new Rcon("Rusticaland.ddns.net", 38069, "Chidori1000");



            // Handle passive traffic (eg. chat, join and quit messages, ...)
           


        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button2d_Click(object sender, EventArgs e)
        {
            Process.Start("http://rusticaland.noip.me/support/chat.php?a=e4ef8&code=%3C!--replace_me_with_b64url_code--%3E&en=%3C!--replace_me_with_b64url_name--%3E&ee=%3C!--replace_me_with_b64url_email--%3E&eq=%3C!--replace_me_with_b64url_question--%3E&eh=%3C!--replace_me_with_b64url_header_url--%3E&ec=%3C!--replace_me_with_b64url_company--%3E&mp=MQ__&epc=IzAwMDBmZg__&etc=IzAwZmZmZg__");
        }

        private void button2_Click_2(object sender, EventArgs e)
        {


            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"Rust\";
            proc.FileName = "RustClient.exe";
            proc.Arguments = "-d3d9";
            proc.Verb = "";

            try
            {
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR- Your Launcher is in the wrong folder ----" + ex.Message);

            }
            Application.Exit();  // Quit itself
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        public void button5_Click_1(object sender, EventArgs e)
        {
           

        }
        public string RconPassword
        {
            get
            {
                return RconPassword;
            }
            set
            {
                RconPassword = "Ch0";
            }
        }
        public int RconPort
        {
            get
            {
                return RconPort;
            }
            set
            {
                RconPort = 369;
            }
        }
        public string RconIp
        {
            get
            {
                return RconIp;
            }
            set
            {
                RconIp = "rusnet";
            }
        }



        private void richTextBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.UseShellExecute = true;
            proc.WorkingDirectory = @"Rust\";
            proc.FileName = "LumaGameLauncher_x64.exe";
            proc.Arguments = "";
            proc.Verb = "";

            try
            {
                Process.Start(proc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR- Your Launcher is in the wrong folder ----" + ex.Message);

            }
            Application.Exit();  // Quit itself
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                Properties.Settings.Default.Music = true;

            }
            else
            {
                Properties.Settings.Default.Music = false;
            }
            Properties.Settings.Default.Save();
            player.Stop();
        }

        private void clientlog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



    
    

