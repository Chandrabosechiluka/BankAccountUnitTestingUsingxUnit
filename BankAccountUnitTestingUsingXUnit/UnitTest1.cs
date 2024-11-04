namespace BankAccountUnitTestingUsingxUnit
{
    public class BankAccountTests
    {
        [Fact]
        public void Depositing_ActualAmount_To_IncreaseBalance()
        {
            var account = new BankAccount(600);
            account.Deposit(10);
            int expectedBalance = 610;
            Assert.Equal(expectedBalance, account.GetBalance());
        }

        [Fact]
        public void Depositing_NotActualAmount_ThrowsException()
        {
            var account = new BankAccount(600);
            Assert.Throws<ArgumentException>(() =>
            account.Deposit(-10));
        }

        [Fact]
        public void Withdrawing_ActualAmount_To_DecreaseBalance()
        {
            var account = new BankAccount(600);
            account.Withdraw(10);
            int expectedBalance = 590;
            Assert.Equal(expectedBalance, account.GetBalance());
        }

        [Fact]
        public void Withdrawing_MoreAmountThanTheBalance_ThrowsException()
        {
            var account = new BankAccount(600);
            Assert.Throws<InsufficientFundsException>(() =>
            account.Withdraw(610));
        }

        [Fact]
        public void Withdrawing_NotActualAmount_ThrowsException()
        {
            var account = new BankAccount(600);
            Assert.Throws<ArgumentException>(() =>
            account.Withdraw(0));
        }

        [Fact]
        public void Transfering_ActualAmount_DecreasesSourceBalance_IncreasesTargetAccountBalance()
        {
            var sourceAccount = new BankAccount(600);
            var targetAccount = new BankAccount(700);

            sourceAccount.Transfer(targetAccount, 40);

            int expectedSourceAccountBalance = 560;
            int expectedTargetAccountBalance = 740;

            Assert.Equal(expectedSourceAccountBalance, sourceAccount.GetBalance());
            Assert.Equal(expectedTargetAccountBalance, targetAccount.GetBalance());
        }

        [Fact]
        public void Transfering_To_NotAccountAccount_ThrowsArgumentException()
        {
            var account = new BankAccount(100);
            Assert.Throws<ArgumentException>(() =>
            account.Transfer(null, 60));
        }
    }

}