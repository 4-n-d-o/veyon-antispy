using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static antispy_lol.hide;

namespace antispy_lol
{
    public partial class cs : Form
    {
        uint DW_MONITOR = 1;
        public cs()
        {
            InitializeComponent();
            this.TransparencyKey = Color.LimeGreen;
            this.TopMost = true;
            NotifyIcon icon = new NotifyIcon();
            icon.ContextMenu = new ContextMenu();
            icon.ContextMenu.MenuItems.Add(new MenuItem("Hide / Show overlay", new EventHandler(togglelabel)));
            icon.ContextMenu.MenuItems.Add(new MenuItem("Close", new EventHandler(close)));
            icon.ContextMenu.MenuItems.Add(new MenuItem("Windows mode", new EventHandler(windowtoggle)));
            icon.Visible = true;
            icon.Text = "veyon";
            icon.Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName);
            this.ShowInTaskbar = false;
        }

        private void close(object sender, EventArgs e)
        {
            this.Close();
        }

        bool toggle = true;
        private void togglelabel(object sender, EventArgs e)
        {
            if (toggle)
            {
                label1.Hide();
                toggle = false;
            } 
            else
            {
                label1.Show();
                toggle = true;
            }
        }

        private void windowtoggle(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized) {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Padding = new Padding(37);
            } else
            {
                this.Padding = Padding.Empty;
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hide.Hide(this.Handle, DW_MONITOR);
        }
    }
}
