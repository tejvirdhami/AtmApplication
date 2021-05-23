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
    public partial class frmATM : Form
    {
        public frmATM()
        {
            InitializeComponent();
        }

        //Declartion og Global Variables
        clsATM myBank;
        clsClient currentClient;
        clsAccount currentAccount;

        private void frmATM_Load(object sender, EventArgs e)
        {
            this.Height = 198;
            txtDeposit.Visible = false;
            lblDeposit.Visible = false;
            txtWithdraw.Visible = false;
            lblWithdraw.Visible = false;

            clsListClient clients = clsDatasource.getAllClients();
            myBank = new clsATM("atm-0001", "Toronto Dominion", "Lasalle College", "active", clients, 20000);
        }

        private void btnNextPin_Click(object sender, EventArgs e)
        {
            string pin = txtPin.Text.Trim();
            if (pin != currentClient.Pin)
            {
                MessageBox.Show("Incorrect Pin, Try again.", "TD: Pin identification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPin.Focus();
                txtPin.Clear();
                return;
            }
            else
            {
                currentClient.Accounts = clsDatasource.GetThisClientAccounts(currentClient.Number);
                foreach(clsAccount itm in currentClient.Accounts.Elements)
                {
                    cboAccounts.Items.Add(itm.Type);
                }
                cboAccounts.SelectedIndex = 0;
                this.Height = 368;
            }
            
        }

        private void btnNextAccount_Click(object sender, EventArgs e)
        {
            foreach (clsAccount itm in currentClient.Accounts.Elements)
            {
                if (itm.Type == cboAccounts.SelectedItem.ToString())
                {
                    currentAccount = itm;
                }
            }
            MessageBox.Show(currentAccount.Consult());
            this.Height = 473;
        }

        private void btnNextTransaction_Click(object sender, EventArgs e)
        {
            if (radDeposit.Checked)
            {
                decimal amount = Convert.ToDecimal(txtDeposit.Text);
                if (currentAccount.Deposit(amount) == false)
                {
                    MessageBox.Show("Deposit Fails, The amount must be between 2$ and 20000$.",
                        "TD: Deposit Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDeposit.Focus();
                    return;
                }
            }
            else if (radWithdraw.Checked)
            {
                decimal amount = Convert.ToDecimal(txtWithdraw.Text);
                int result = currentAccount.Withdraw(amount);
                switch (result)
                {
                    case 1:
                        MessageBox.Show("Withdraw Fails, The maximum amount to withdraw is $500.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case 2:
                        MessageBox.Show("Withdraw Fails, The minimum amount to withdraw is $20.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case -1:
                        MessageBox.Show("Withdraw Fails, The amount to withdraw must be multiple of $20.",
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                    case 3:
                        MessageBox.Show("Withdraw Fails, Insufficient Funds, your balance is " + currentAccount.Balance,
                        "TD: Withdraw Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtWithdraw.Focus();
                        return;
                }
            }
            lblAccount.Text = currentAccount.Consult();
            this.Height = 646;
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            this.Height = 198;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnNextnumber_Click(object sender, EventArgs e)
        {
            string number = txtNumber.Text.Trim();
            currentClient = myBank.Clients.Find(number);
            if (currentClient == null)
            {
                MessageBox.Show("Client Not Found, Try again.", "TD: Number identification Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumber.Focus();
                return;
            }
            else
            {
                lblWelcome.Text = "Welcome " + currentClient.Name;
                this.Height = 292;
            }
            
        }

        private void radDeposit_CheckedChanged(object sender, EventArgs e)
        {
            txtDeposit.Visible = lblDeposit.Visible = true;
            txtWithdraw.Visible = lblWithdraw.Visible = false;
            txtDeposit.Focus();
        }

        private void radWithdraw_CheckedChanged(object sender, EventArgs e)
        {
            txtWithdraw.Visible = lblWithdraw.Visible = true;
            txtDeposit.Visible = lblDeposit.Visible = false;
            txtWithdraw.Focus();
        }

        private void radConsult_CheckedChanged(object sender, EventArgs e)
        {
            txtWithdraw.Visible = lblWithdraw.Visible = false;
            txtDeposit.Visible = lblDeposit.Visible = false;
        }

        private void txtDeposit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; //do not allow the characters to be displayed on the block.
            }
        }

        private void txtWithdraw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false)
            {
                e.Handled = true; //do not allow the characters to be displayed on the block.
            }
        }
    }
}
