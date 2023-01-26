using Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFServer;

namespace WCFClient
{
    public partial class Form1 : Form
    {
      //  public static string connectionString = "Server=(local);Database=Astronauts;Trusted_Connection=True;";
        DataSet dsBooks = new DataSet();
        Client client = new Client();
        Login_test_ login;
        public Form1(Login_test_ login)
        {
            InitializeComponent();
            RefreshView();
            this.login = login;

        }
        void RefreshView()
        {
            DataTable dt = client.RefreshView(textBox1.Text);
            dataGridView1.DataSource = dt;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
         }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            EditForm frm = new EditForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
               RefreshView();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int ThisRow = dataGridView1.CurrentCell.RowIndex;
            int id = int.Parse(dataGridView1["ID", ThisRow].EditedFormattedValue.ToString());
            EditForm frm = new EditForm(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
              RefreshView();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int ThisRow = dataGridView1.CurrentCell.RowIndex;
            int id = int.Parse(dataGridView1["ID", ThisRow].EditedFormattedValue.ToString());
            //string name = Astronaut.Proc(id);
            DialogResult res = MessageBox.Show("Вы уверены, что хотите удалить данного астронавта?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                client.DeleteAstronaut(id);
                RefreshView();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshView();
        }
    }
}
