using System;
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
    public partial class Form1 : Form
    {

        public static List<CartItem> cartLine = new List<CartItem>();
        pizzaContext db;
        public Form1()
        {
            InitializeComponent();
            db = new pizzaContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var query = from p in db.pizza
                        orderby p.name
                        select p;
            foreach(pizza p in query)
            {
                MenuItem item = new MenuItem(p);
                flowLayoutPanel1.Controls.Add(item.panel1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            DialogResult result = cart.ShowDialog();
            if (result == DialogResult.Cancel)
                return;
            Order order = new Order();
            order.Show();
        }
    }
}
