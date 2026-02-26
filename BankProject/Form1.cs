namespace BankProject
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();

            //List<BankAccount> bankAccounts = new List<BankAccount>
            //{
            //    new BankAccount ("John Doe"),
            //    new BankAccount ("Test", 200),
            //    new BankAccount ("Test3", 300)
            //};

            //for(int i = 1; i < 6; i++)
            //{
            //    string name = (i == 1) ? "John Doe" : "John Doe" + i.ToString();
            //    BankAccount bankAccount = new BankAccount();
            //    bankAccount.Owner = name;
            //    bankAccount.AccNum = Guid.NewGuid(); // Призначити новий унікальний ідентифікатор
            //    bankAccount.Balance = 100*i;
            //    bankAccounts.Add(bankAccount);
            //}

            //BankAccountGrid.DataSource = bankAccounts;
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
                return;

            if (InterestRateNum.Value > 0)
                BankAccounts.Add(new SavingAccount(OwnerTxt.Text, InterestRateNum.Value));
            else
                BankAccounts.Add(new BankAccount(OwnerTxt.Text));

            RefreshGrid();
            OwnerTxt.Text = string.Empty;
            InterestRateNum.Value = 0;
        }

        private void RefreshGrid()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = BankAccounts;
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count == 1)
            {
                BankAccount selectedAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;
                string message = selectedAccount.Deposit(AmountNum.Value);
                RefreshGrid();
                OwnerTxt.Text = string.Empty;
                AmountNum.Value = 0;
                MessageBox.Show(message);
            }


        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountGrid.SelectedRows.Count == 1)
            {
                BankAccount selectedAccount = BankAccountGrid.SelectedRows[0].DataBoundItem as BankAccount;
                string message = selectedAccount.Withdraw(AmountNum.Value);
                RefreshGrid();
                OwnerTxt.Text = string.Empty;
                AmountNum.Text = string.Empty;
                MessageBox.Show(message);
            }
        }

    }
}
