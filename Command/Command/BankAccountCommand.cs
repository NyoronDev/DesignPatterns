﻿namespace Command.Command
{
    public class BankAccountCommand : ICommand
    {
        private BankAccount account;
        private Action action;
        private int amount;

        public enum Action
        {
            Deposit, Withdraw
        }

        public BankAccountCommand(BankAccount account, Action action, int amount)
        {
            this.account = account;
            this.action = action;
            this.amount = amount;
        }

        public void Call()
        {
            switch (action)
            {
                case Action.Deposit:
                    account.Deposit(amount);
                    break;

                case Action.Withdraw:
                    account.Withdraw(amount);
                    break;

                default:
                    break;
            }
        }
    }
}