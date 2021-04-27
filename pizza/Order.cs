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
    public partial class Order : Form
    {
        cards client;
        pizzaContext db;
        public Order()
        {
            InitializeComponent();
            db = new pizzaContext();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var query = (from c in db.cards
                             select c);
                foreach(var q in query)
                {                    
                    comboBox1.Items.Add(q.FullName);
                }
            }
            else
            {
                comboBox1.Items.Clear();
                comboBox1.SelectedIndex = -1;
            }
        }

        private void Order_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.cartLine.Sum(i => i.p.price * i.count).ToString();
            label5.Text = label2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//Convert.ToInt32(comboBox1.Text.Split(' ')[0]) q.id.ToString() + " " + 
            var query = (from c in db.cards
                         where c.FullName == comboBox1.Text
                         select c);
            foreach (var c in query)
            {
                label6.Text = c.bonus.ToString();
                label7.Text = c.rank.ToString();
                client = c;
            }
            if (client.lastAction.Value.AddDays(365) < DateTime.Now)
            {
                client.bonus = 0;
                db.SaveChanges();
                label6.Text = "0";
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                label5.Text = (Convert.ToInt32(label2.Text) - Convert.ToInt32(label6.Text)).ToString();
            }
            else
                label5.Text = label2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int spis = 0;
            double inbonus = 0;
            int bonus = 0;
            if (checkBox1.Checked)
            {
                if (checkBox2.Checked)
                {
                    spis = (int)client.bonus;
                    client.bonus = 0;
                }
                inbonus = Convert.ToDouble(label2.Text) * (Convert.ToDouble(client.rank) / 100);
                client.bonus += (int)inbonus;
                bonus = (int)client.bonus;
            }
            MessageBox.Show($"Оплачено: {label5.Text} \n" +
                $"Списано бонусов {spis.ToString()} \n" +
                $"Начислено бонусов: {inbonus.ToString()} \n" +
                $"Всего бонусов: {bonus.ToString()}");
            db.SaveChanges();
        }
    }
}
