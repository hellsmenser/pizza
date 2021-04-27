﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pizza
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach(CartItem i in Form1.cartLine)
            {
                flowLayoutPanel1.Controls.Add(i.panel1);
            }
        }
    }
}
