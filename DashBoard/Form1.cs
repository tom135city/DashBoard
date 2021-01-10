using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Henke37.Valve.Source.ServerQuery;
using System.Net;
using System.Diagnostics;
using System.Media;
using System.IO;

namespace DashBoard
{
    public partial class Form1 : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
            (

            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse









            );




        private SoundPlayer _soundplayer;



    





        public  Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            ;


            if (File.Exists("1.wav"))
            {
                _soundplayer = new SoundPlayer("1.wav");
                _soundplayer.PlayLooping();
            }




        }

        private async void Form1_Load(object sender, EventArgs e)
        {


            ServerStatus ss = new ServerStatus();
                
            ss.Address = "149.202.223.29";

            ss.Timeout = 3000;

            await ss.Update();

            var rulez = ss.Info.Map;

            var sname = ss.Info.ServerName;

            var state = ss.State;


            var name = "Dashboard : " + sname;

            label4.Text = rulez.ToString();


            if (ss.Timeout.Equals(3000))
            {

                lbltitle.Text = name;
                lbltitle.ForeColor = Color.Green;

            }
            else
            {
                lbltitle.Text = "Serveur OFF :(";
                lbltitle.ForeColor = Color.Green;
            }







            var ply = ss.Info.PlayerCount;

            this.circularProgressBar1.Text = ply.ToString();

            int maxply = ss.Info.MaxPlayerCount;

            circularProgressBar1.Maximum = maxply;

            circularProgressBar1.Value = ply;

            listBox1.Items.Clear();



            foreach (var players in ss.Players.Players) { listBox1.Items.Add(players); }
            {





            };



        } 
        
        

        private async void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            btnContact.BackColor = Color.FromArgb(24, 30, 54);
            btnData.BackColor = Color.FromArgb(24, 30, 54);
            btnWebsite.BackColor = Color.FromArgb(24, 30, 54);


            







            ServerStatus ss = new ServerStatus();

              var ip = "149.202.223.29";


              ss.Address = ip;

               await  ss.Update();

               var sname = ss.Info.ServerName;

                var name = "Dashboard : " + sname;

                






               


              lbltitle.Text = name;





              Task tsk = Task.Run(async () =>
               {
                 try
            {



                        ss.Address = ip;

                        await ss.Update();

                        var ply = ss.Info.PlayerCount;




                       int maxply = ss.Info.MaxPlayerCount;

                       circularProgressBar1.Maximum = maxply;

                       circularProgressBar1.Value = ply;

                        this.circularProgressBar1.Text = ply.ToString();


                       listBox1.Items.Clear();



                       foreach (var players in ss.Players.Players) { listBox1.Items.Add(players); }
                       {


                          


                       };

                    //   label1.Text = ply.ToString();











                    }
                    catch (Exception error)
                    {



                    }
                });
                if (tsk.Wait(TimeSpan.FromSeconds(14)))
                {
                     ss.Timeout = 3000;
            }
                else
               {
                    ss.Timeout = 3000;
                };


            


        }

        private void btnData_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnData.Height;
            pnlNav.Top = btnData.Top;
            pnlNav.Left = btnData.Left;
            btnData.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnContact.BackColor = Color.FromArgb(24, 30, 54);
            btnWebsite.BackColor = Color.FromArgb(24, 30, 54);

            var url = "discord.gg/shibuya";
               if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
            ;
                    Process.Start(new ProcessStartInfo("chrome.exe", $"/c  {url}") { CreateNoWindow = true });
               }
               else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
               {
                   Process.Start("xdg-open", url);
             }
               else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
               {
                  Process.Start("open", url);
              }

        }

        private void btnWebsite_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnWebsite.Height;
            pnlNav.Top = btnWebsite.Top;
            pnlNav.Left = btnWebsite.Left;
            btnWebsite.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnContact.BackColor = Color.FromArgb(24, 30, 54);
            btnData.BackColor = Color.FromArgb(24, 30, 54);


            var url2 = "https://falloutcommunity.fr/accueil";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                ;
                Process.Start(new ProcessStartInfo("chrome.exe", $"/c  {url2}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url2);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url2);
            }





        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContact.Height;
            pnlNav.Top = btnContact.Top;
            pnlNav.Left = btnContact.Left;
            btnContact.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            btnData.BackColor = Color.FromArgb(24, 30, 54);
            btnWebsite.BackColor = Color.FromArgb(24, 30, 54);


            Process.Start(new ProcessStartInfo("steam://connect/149.202.223.29:27015") { UseShellExecute = true });
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSettings.Height;
            pnlNav.Top = btnSettings.Top;
            pnlNav.Left = btnSettings.Left;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);





        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnData_Leave(object sender, EventArgs e)
        {
            btnData.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void btnWebsite_Leave(object sender, EventArgs e)
        {
            btnWebsite.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnContact_Leave(object sender, EventArgs e)
        {
            btnContact.BackColor = Color.FromArgb(24, 30, 54);


        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void circularProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
 }
