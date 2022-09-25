using Rehber.data;
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

namespace Rehber
{
    public partial class Form1 : Form
    {
        PhoneBookEntities db = new PhoneBookEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSurname.Text = "";
            txtPhone.Text = "";



        }
        private void ClearControls()
        {

            foreach (Control c in this.Controls)
            {
                if (c is TextBox && c.TabStop == true || c is MaskedTextBox && c.TabStop == true)
                {
                    c.ResetText();
                }
            }
            ID = 0;
        }
        int ID = 0;
        int RowIndex = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {

            db.Person.Add(new Person
            {
                Name = txtName.Text.Trim(),
                Surname = txtSurname.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                EMail = txtEmail.Text.Trim(),
                Address = txtAdres.Text.Trim()
            });
            db.SaveChanges();

            dataGridView1.DataSource = db.Person.ToList();


            s();

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;
            RowIndex = e.RowIndex;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void seçileniSilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetData();
            dataGridView1.DataSource = db.Person.ToList();
        }
        private void GetData()
        {
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            txtSearch.ResetText();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in db.Person)
            {
                if (item.Name == txtSearch.Text.Trim())
                {
                    dataGridView1.DataSource = db.Person.Where(x => x.PersonID == item.PersonID);
                }
                else
                {
                    MessageBox.Show("Aradığınız isim yok");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (var item in db.Person)
            {
                if (item.Name == txtSearch.Text.Trim())
                {
                    dataGridView1.DataSource = db.Person.Where(x => x.PersonID == item.PersonID);
                }
                else
                {
                    MessageBox.Show("Aradığınız isim yok");
                }
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            foreach (var item in db.Person)
            {
                if (item.Name == txtSearch.Text.Trim())
                {
                    dataGridView1.DataSource = db.Person.Where(x => x.PersonID == item.PersonID);
                }
                else
                {
                    MessageBox.Show("Aradığınız isim yok");
                }
            }
        }
    }
}
