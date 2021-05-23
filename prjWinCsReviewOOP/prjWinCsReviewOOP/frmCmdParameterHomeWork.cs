using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{
    public partial class frmCmdParameterHomeWork : Form
    {
        public frmCmdParameterHomeWork()
        {
            InitializeComponent();
        }
        OleDbConnection myCon = new OleDbConnection();
        private void frmCmdParameterHomeWork_Load(object sender, EventArgs e)
        {

            //first task
            myCon.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Tejvir Dhami\source\repos\prjWinCsReviewOOP\prjWinCsReviewOOP\databases\DBBank2003.mdb";
            myCon.Open();

            //Second task
            OleDbCommand myCmd = new OleDbCommand("SELECT DISTINCT Gender FROM Students", myCon);

            //Third Task
            OleDbDataReader myRder = myCmd.ExecuteReader();

            while(myRder.Read())
            {
                cboGender.Items.Add(myRder["Gender"].ToString());
            }
            myRder.Close();


            //----------------------------------FILLING CBO BOX WITH AVERAGE-----------------------------------------
            myCmd = new OleDbCommand("SELECT DISTINCT Average FROM Students", myCon);
            myRder = myCmd.ExecuteReader();
            //Third Task

            while (myRder.Read())
            {
                cboAverage.Items.Add(myRder["Average"].ToString());
            }
            myRder.Close();
        }

        private void btnFindAllStudents_Click(object sender, EventArgs e)
        {
            string sql = "";
            OleDbDataReader myRder;

            if (chkGender.Checked == false && chkAverage.Checked == false)
            {
                sql = "SELECT FullName, Birthdate, Gender, Average, Balance FROM Students";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                 myRder = myCmd.ExecuteReader();
            }
            //--------------------------WHEN GENDER IS CHECKED-----------------------------
            else if (chkGender.Checked == true && chkAverage.Checked == false)
            {
                sql = "SELECT FullName, Birthdate, Gender, Average, Balance FROM Students WHERE Gender = @gndr";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                myCmd.Parameters.AddWithValue("@gndr", cboGender.SelectedItem.ToString());
                myRder = myCmd.ExecuteReader();
            }
            //--------------------------WHEN Average IS CHECKED-----------------------------
            else if (chkGender.Checked == false && chkAverage.Checked == true)
            {
                sql = "SELECT FullName, Birthdate, Gender, Average, Balance FROM Students WHERE Average >= @avg";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                myCmd.Parameters.AddWithValue("@avg",Convert.ToSingle(cboAverage.SelectedItem.ToString()));
                myRder = myCmd.ExecuteReader();
            }


            //--------------------------WHEN BOTH ARE CHECKED-----------------------------

            else if (chkGender.Checked == true && chkAverage.Checked == true)
            {
                sql = "SELECT FullName, Birthdate, Gender, Average, Balance FROM Students WHERE Gender = @gndr AND Average >= @avg";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                myCmd.Parameters.AddWithValue("@gndr", cboGender.SelectedItem.ToString());
                myCmd.Parameters.AddWithValue("@avg", Convert.ToSingle(cboAverage.SelectedItem.ToString()));
                myRder = myCmd.ExecuteReader();
            }

            else
            {
                sql = "SELECT FullName, Birthdate, Gender, Average, Balance FROM Students";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);
                myRder = myCmd.ExecuteReader();
            }



            DataTable tmp = new DataTable();
            tmp.Load(myRder);
            gridReader.DataSource = tmp;

        }
    }
}
