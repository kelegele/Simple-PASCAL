using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_PASCAL
{
    public partial class MainInfoForm : Form
    {
        public MainInfoForm()
        {
            InitializeComponent();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = linkLabel.Text;
            linkLabel.LinkVisited = true;
            Process.Start(path);
        }
    }
}
