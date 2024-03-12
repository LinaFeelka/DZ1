using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DZ1
{
    public partial class addForm : Form
    {
       DataBase database = new DataBase();
        public addForm()
        {
            InitializeComponent();
        }

        private void addBut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }
 
        //добавление в бд
        private void saveBut_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var name = nameTB.Text;
            //var phone = phoneTB.Text;
            var phone = maskedTextBox1.Text;
            phone = phone.Replace("()-", "");

            var addQuery = $"insert into contact (name, phone) values ('{name}', '{phone}')";
            var comm = new NpgsqlCommand(addQuery, database.getConnection());

            if (checkuser())
                return;

            comm.ExecuteNonQuery();

            
                MessageBox.Show("Контакт добавлен", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 form1 = new Form1();
                form1.Show();
                this.Close();
            
            database.closeConnection();
            
        }

        private Boolean checkuser()
        {            
            var phone =  maskedTextBox1.Text;

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select name, phone from contact where phone = '{phone}'";

            NpgsqlCommand command = new NpgsqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Номер уже добавлен!");
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            nameTB.Text = "";
            maskedTextBox1.Text = "";
        }
    }
}
