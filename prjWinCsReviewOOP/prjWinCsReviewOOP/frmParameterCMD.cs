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

namespace prjWinCsReviewOOP
{
    public partial class frmParameterCMD : Form
    {
        public frmParameterCMD()
        {
            InitializeComponent();
        }

        OleDbConnection myCon;
        private void frmParameterCMD_Load(object sender, EventArgs e)
        {

            //first task
            myCon = new OleDbConnection();
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Apple\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            //second task
            OleDbCommand myCmd = new OleDbCommand();
            string sql;
            sql = "SELECT * FROM Students";
            myCmd.CommandText = sql;
            myCmd.Connection = myCon;

            //third final task
            OleDbDataReader myReader = myCmd.ExecuteReader();

            //gridResult.DataSource = myReader;
            DataTable tmp = new DataTable();
            tmp.Load(myReader);
            gridResults.DataSource = tmp;

            // Filing the combo box with genders

            //second task
            sql = "SELECT DISTINCT Gender FROM Students";

            OleDbCommand myCmd2 = new OleDbCommand(sql, myCon);
            OleDbDataReader myReader2 = myCmd2.ExecuteReader();
            while(myReader2.Read())
            {
                cboGender.Items.Add(myReader2["Gender"].ToString());
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Single grade = Convert.ToSingle(txtAverage.Text);

            //second task
            OleDbCommand myCmd = new OleDbCommand();
            string sql;
            // When yopu imsert @ symbol in sql, you indicate u hacve a parameter.
            sql = "SELECT * FROM Students WHERE Gender = 'Female' AND Average <= @avg" ;
            myCmd.CommandText = sql;


            //SHORT VERSION FOR PARAMETER
            myCmd.Parameters.AddWithValue("@avg", Convert.ToSingle(txtAverage.Text));

            //OleDbParameter myPar = new OleDbParameter();
            //myPar.DbType = DbType.Single;
            //myPar.Value = Convert.ToSingle(txtAverage.Text);
            //myCmd.Parameters.Add(myPar);

            myCmd.Connection = myCon;

            //third final task
            OleDbDataReader myReader = myCmd.ExecuteReader();

            //gridResult.DataSource = myReader;
            DataTable tmp = new DataTable();
            tmp.Load(myReader);
            gridResults.DataSource = tmp;
        }
    }
}
