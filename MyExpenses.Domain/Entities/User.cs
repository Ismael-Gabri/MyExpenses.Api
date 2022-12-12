using MyExpenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Entities
{
    public class User : Entity
    {
        private readonly IList<IncomeSource> _incomes;
        private readonly IList<Expense> _expenses;
        public User (Name name,
            Email email
            )
        {
            Name = name;
            Email = email;
            IsPremium = false;
            EntryDate = DateTime.UtcNow;
            _incomes = new List<IncomeSource>();
            _expenses = new List<Expense>();
            Notifications = new Dictionary<string, string>();
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public string Password { get; private set; }
        public string Image { get; private set; }
        public bool IsPremium { get; private set; }
        public DateTime EntryDate { get; private set; }
        public IReadOnlyCollection<IncomeSource> IncomeSources { get { return _incomes.ToArray(); } }
        public IReadOnlyCollection<Expense> Expenses { get { return _expenses.ToArray(); } }
        public IDictionary<string, string> Notifications { get; private set; }


        public void ChangeProfileImage(string image) 
        {
            //Validar se é imagem

            //Salvar imagem
            Image = image;
        }
        public void ChangePremiumStatus() 
        {
            IsPremium = true;
        }
        public void AddIncomeSource(IncomeSource incomeObject)
        {
            //Validar se income eh valido
            if(incomeObject.Title == null || incomeObject.Title == "")
            {
                Notifications.Add("Income Title", "Título Vazio ou nulo");
            }
            if(incomeObject.Income == null)
            {
                Notifications.Add("Income Valor", "Valor Vazio ou nulo");
            }
            else
            {
                //Adicionar income se valido
                _incomes.Add(incomeObject);
            }
        }
        public void RemoveIncomeSource(IncomeSource incomeObject) 
        {
            try
            {
                foreach (IncomeSource income in _incomes)
                {
                    if (income.Id == incomeObject.Id)
                    {
                        _incomes.Remove(income);
                    }
                }
            }
            catch
            {
                Notifications.Add("Income Deletion", "Income Id not found");
            }
        }
        public void AddExpense(Expense expense) 
        {
            //Validar se income eh valido
            if (expense.Title == null || expense.Title == "")
            {
                Notifications.Add("Income Title", "Título Vazio ou nulo");
            }
            if (expense.Price == null)
            {
                Notifications.Add("expense Price", "Valor Vazio ou nulo");
            }
            else
            {
                //Adicionar expense se valido
                _expenses.Add(expense);
            }
        }
        public void RemoveExpense(Expense expense)
        {
            try
            {
                foreach (Expense expense1 in _expenses)
                {
                    if (expense1.Id == expense.Id)
                    {
                        _expenses.Remove(expense1);
                    }
                }
            }
            catch
            {
                Notifications.Add("Expense Deletion", "Expense Id not found");
            }
        }
        public void CalculateTotalIncome() { }
    }
}
