using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySuggestingTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            //textBox1.ListItems = listItems;
            //textBox2.ListItems = listItems;
            System.Collections.Generic.List<string> listItems = new System.Collections.Generic.List<string> { "Navid", "Hamed", "Alireza", "Saeed", "Nahid", "ALI", "Hadi", "Narges", "Hamid" };
            //object[] listItems = new object[] { "Navid", "Hamed", "Alireza", "Saeed", "Nahid", "ALI", "Hadi", "Narges", "Hamid" };
            textBox2.ListItems = listItems;
        }


    }
}
