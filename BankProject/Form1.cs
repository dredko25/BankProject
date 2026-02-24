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

            BankAccounts.Add(new BankAccount(OwnerTxt.Text));
            RefreshGrid();
            OwnerTxt.Text = string.Empty;
        }

        private void RefreshGrid()
        {
            BankAccountGrid.DataSource = null;
            BankAccountGrid.DataSource = BankAccounts;
        }
    }
}
