using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjWinCsReviewOOP
{

    public partial class frmClassReview : Form
    {

        public frmClassReview()
        {
            InitializeComponent();
        }

        clsStudent myStud;

        private void frmClassReview_Load(object sender, EventArgs e)
        {
            myStud = new clsStudent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            int dy = dtPicker.Value.Day;
            int mt = dtPicker.Value.Month;
            int yr = dtPicker.Value.Year;

            myStud.Register(name, dy, mt, yr);

            btnRegister.Enabled = false;
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            Single grade = Convert.ToSingle(txtGrade.Text);
            if (myStud.ToGrade(grade) == true)
            {
                MessageBox.Show("Grading Succeed !");
            }
            else
            {
                MessageBox.Show("Grading Failed, Invalid Grade !");
            }
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            lblInfo.Text = myStud.Display();
        }

        private void txtGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; //do not allow the characters to be displayed on the block.
            }
        }

    }
}