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
using System.Xml.Linq;

namespace WCFClient
{
    public partial class EditForm : Form
    {
        Astronaut book = new Astronaut();
        Client client = new Client();
        public EditForm()
        {
            InitializeComponent();
          

        }
        public EditForm(int ID)
        {
            InitializeComponent();

            book = client.LoadAstronaut(ID);
            txtName.Text = book.FirstName.Trim();
            txtSurname.Text = book.SecondName;
            txtAge.Text = book.Age.ToString();
          //  txtcountry.Text=book.AstronautId.ToString();
            txtNumber.Text = book.IdNumber.ToString();
            txtResultMathTest.Text = book.ResultMathTest.ToString();
            txtSportTest.Text = book.ResultSportTest.ToString();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            book.FirstName = txtName.Text;
            book.SecondName = txtSurname.Text;
            book.Age = Convert.ToInt32(this.txtAge.Text);
            book.IdNumber = Convert.ToChar(txtNumber.Text);
            book.ResultMathTest = (float)Convert.ToDouble(txtResultMathTest.Text);
            book.ResultSportTest = (decimal)Convert.ToDouble(txtSportTest.Text);
          //  book.AstronautId = Convert.ToInt32(this.txtAge.Text);
            if (book.Id == 0)
            {
                client.InsertAstronaut(book);
            }
            else
            {
                client.UpdateAstronaut(book);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
