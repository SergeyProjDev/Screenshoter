﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Screenshoter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideWindowAndDoScreen();  
        }

        private void HideWindowAndDoScreen()
        {
            this.Hide();
            MakeScreen();
        }

        private void MakeScreen()
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}