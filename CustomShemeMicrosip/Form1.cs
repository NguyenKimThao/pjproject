using System;
using System.Windows.Forms;

namespace CustomShemeMicrosip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Environment.CurrentDirectory: "+ Environment.CurrentDirectory;
        }
    }
}