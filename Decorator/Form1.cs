using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decorator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dessert dessert;
            if (comboBox2.Text == "Tiramisu")
                dessert = new Tiramisu();
            else if (comboBox2.Text == "Cheesecake")
                dessert = new Cheesecake();
            else
                dessert = new Pie();
            if (comboBox1.Text == "Monday" || comboBox1.Text == "Wednesday")
                dessert = new MondayAndWednesdayDessert(dessert);
            else if (comboBox1.Text == "Friday" || comboBox1.Text == "Sunday")
                dessert = new FridayAndSundayDessert(dessert);
            label1.Text = dessert.Name + " costs " + dessert.GetCost() + " UAH";
        }
    }
}
