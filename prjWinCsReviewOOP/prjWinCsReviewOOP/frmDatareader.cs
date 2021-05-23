using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.CodeDom.Compiler;

namespace prjWinCsReviewOOP
{
    public partial class frmDatareader : Form
    {
        public frmDatareader()
        {
            InitializeComponent();
        }
        //global variable
        string mode = "";
        OleDbConnection myCon = new OleDbConnection();
        private void frmDatareader_Load(object sender, EventArgs e)
        {
            //always use this to create connection.

            //first task
            myCon.ConnectionString=@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Apple\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            //second task
            OleDbCommand myCmd = new OleDbCommand();
            myCmd.CommandText = "SELECT Number, ClientName, Pin, Status FROM Clients";
            myCmd.Connection = myCon;


            //third final task
            OleDbDataReader myReader = myCmd.ExecuteReader();

            while (myReader.Read() == true)
            {
                lstNumbers.Items.Add(myReader["Number"].ToString());
            }


            //connection done and open
            OleDbCommand myCmd2 = new OleDbCommand();
            myCmd2.CommandText = "SELECT [Number], Type, OpenDay, OpenMonth, OpenYear, Status, Balance, ClientID FROM Accounts";
            // myCmd2.CommandText = "SELECT * FROM Clients";
            myCmd2.Connection = myCon;

            OleDbDataReader myReader2 = myCmd2.ExecuteReader();

            //gridResult.DataSource = myReader;
            DataTable tmp = new DataTable();
            tmp.Load(myReader2);
            gridResult.DataSource = tmp;

            //myCon.Close();
        }

        private void lstNumbers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectNB = lstNumbers.SelectedItem.ToString();

            //LOOP VERSION

            //OleDbCommand myCmd = new OleDbCommand();
            //myCmd.CommandText = "SELECT Number, ClientName, Pin , Status FROM Clients";
            //myCmd.Connection = myCon;

            //OleDbDataReader myReader = myCmd.ExecuteReader();


            //while (myReader.Read() == true)
            //{
            //    if (myReader["Number"].ToString() == selectNB)
            //    {
            //        txtNumber.Text = myReader["Number"].ToString();
            //        txtName.Text = myReader["ClientName"].ToString();
            //        txtPin.Text = myReader["Pin"].ToString();
            //        txtStatus.Text = myReader["Status"].ToString();
            //    }
            //}

            OleDbCommand myCmd = new OleDbCommand();
            myCmd.CommandText = "SELECT [Number], ClientName, Pin, Status FROM Clients WHERE [Number] ='"+selectNB+"'";
            myCmd.Connection = myCon;

            OleDbDataReader myReader = myCmd.ExecuteReader();


            if (myReader.Read())
            {
                 txtNumber.Text = myReader["Number"].ToString();
                txtName.Text = myReader["ClientName"].ToString();
                txtPin.Text = myReader["Pin"].ToString();
                txtStatus.Text = myReader["Status"].ToString();
            }
            myReader.Close();

            //Display clients


            myCmd = new OleDbCommand();
            myCmd.CommandText = "SELECT [Number], Type, OpenDay, OpenMonth, OpenYear, Status, Balance, ClientID FROM Accounts WHERE [ClientID] ='"+selectNB+"'";
            // myCmd2.CommandText = "SELECT * FROM Clients";
            myCmd.Connection = myCon;

            myReader = myCmd.ExecuteReader();

            //gridResult.DataSource = myReader;
            DataTable tmp = new DataTable();
            tmp.Load(myReader);
            gridResult.DataSource = tmp;

            //myCon.Close();


           

        }

        private void btnWrite2Database_Click(object sender, EventArgs e)
        {
            //first task

            //myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Apple\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            //myCon.Open();

            //second task
            OleDbCommand myCmd = new OleDbCommand();
            string sql = "";

            //To add or insert a new record statement
            // sql = "INSERT INTO Clients([Number], ClientName, Pin, Status) VALUES('c8c8','Donald Looser', 'password','suspended')";

            //To edit or update an existing record
            //sql = "UPDATE Clients SET ClientName='Barack Obama', Pin='jordan' WHERE [Number] = 'c8c8'";

            //To remove or delete an existing record
            sql = "DELETE from Clients where [Number]='c8c8'";
            myCmd.CommandText = sql;
            myCmd.Connection = myCon;

            myCmd.ExecuteNonQuery();
            MessageBox.Show("Done");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mode = "add";
            txtNumber.Text = txtName.Text = txtPin.Text = "";
            txtStatus.Text = "active";
            txtNumber.Focus();

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string num = txtNumber.Text;
            string nam = txtName.Text;
            string pin = txtPin.Text;
            string stat = txtStatus.Text;
            string sql = "";
            if (mode == "add")
            {
                if (lstNumbers.Items.Contains(num) == true)
                {
                    MessageBox.Show("Warning! The number entered already exists!", "Error");
                    txtNumber.Focus();
                    return;
                }
                sql = "INSERT INTO Clients([Number], ClientName, Pin, Status) VALUES('" + num + "','" + nam + "','" + pin + "','" + stat + "')";
                OleDbCommand mycmd = new OleDbCommand(sql, myCon);
                mycmd.ExecuteNonQuery();
                lstNumbers.Items.Add(num);
            }
            else if(mode == "edit")
            {
                sql = "UPDATE Clients SET ClientName='" + nam + "', Pin='" + pin + "', Status='" + stat + "'  WHERE [Number] ='" + num + "'";
                OleDbCommand mycmd = new OleDbCommand(sql, myCon);
                mycmd.ExecuteNonQuery();
                txtNumber.Enabled = true;
            }

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            mode = "edit";
            txtNumber.Enabled = false;
            txtName.Focus();

            btnAdd.Enabled = btnEdit.Enabled = btnDelete.Enabled = false;
            btnSave.Enabled = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string num = txtNumber.Text;
            if(MessageBox.Show("Are you sure you want o delete this client ?", "Delete Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                string sql = "DELETE FROM Clients WHERE [Number] ='" + num + "'";
                OleDbCommand mycmd = new OleDbCommand(sql, myCon);
                mycmd.ExecuteNonQuery();

                lstNumbers.SelectedIndex = 0;//to select the first item of the list
                lstNumbers.Items.Remove(num);
            }
        }
    }
}
