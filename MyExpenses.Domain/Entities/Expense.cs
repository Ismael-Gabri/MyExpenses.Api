using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Domain.Entities
{
    public class Expense : Entity
    {
        public Expense(string title, decimal price)
        {
            Title = title;
            Price = price;
            IsSubscription = false;
            Notifications = new Dictionary<string, string>();

            if (title == "" || title == null)
                Notifications.Add("Expense Title", "Título vazio ou nulo");

            if(title.Length > 15)
                Notifications.Add("Expense Title", "Título muito grande");

            if (price == null)
                Notifications.Add("Expense Price", "Preço não pode ser nulo");
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool IsSubscription { get; private set; }
        public IDictionary<string, string> Notifications { get; private set; }

        public void EditTitle(string newTitle)
        {
            Title = newTitle;

            if (newTitle == "" || newTitle == null)
                Notifications.Add("Expense Title", "Título vazio ou nulo");

            if (newTitle.Length > 15)
                Notifications.Add("Expense Title", "Título muito grande");
        }
        public void EditPrice(decimal newPrice)
        {
            Price = newPrice;
        }
        public void EditSubscription()
        {
            IsSubscription = true; //Ou false?
        }
    }
}
