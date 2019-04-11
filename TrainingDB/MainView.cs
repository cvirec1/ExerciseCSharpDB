using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingDB
{
    public partial class MainView : Form
    {
        MainViewModel viewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();           
            dataGridView1.DataSource = viewModel.GetPeople();
            dataGridView2.DataSource = viewModel.GetPerson();
            dataGridView2.DataMember = "Person";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = viewModel.GetFilter(textBox1.Text,textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = viewModel.GetFilter(textBox1.Text, textBox2.Text);
        }
    }
}
