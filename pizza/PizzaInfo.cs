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
    public partial class PizzaInfo : Form
    {
        public PizzaInfo()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = (Convert.ToDecimal(label3.Text) * numericUpDown1.Value).ToString();
        }
    }
}
