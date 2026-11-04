using System;
using System.Collections.Generic;
using System.Linq;
using Restauracja.Shared;

namespace Restauracja.Web.Services
{
    public class CartService
    {
        private readonly Dictionary<int, int> items = new Dictionary<int, int>();

        public event Action? OnChange;

        public Dictionary<int, int> Items
        {
            get { return items; }
        }

        public int ItemCount
        {
            get { return items.Values.Sum(); }
        }

        public void Add(DanieDto dish)
        {
            if (!dish.Dostepne)
                return;

            if (items.ContainsKey(dish.Id))
                items[dish.Id]++;
            else
                items.Add(dish.Id, 1);

            NotifyStateChanged();
        }

        public void ChangeQuantity(int id, int change)
        {
            if (!items.ContainsKey(id))
                return;

            items[id] += change;

            if (items[id] <= 0)
                items.Remove(id);

            NotifyStateChanged();
        }

        public void Remove(int id)
        {
            if (items.Remove(id))
                NotifyStateChanged();
        }

        public void Clear()
        {
            items.Clear();
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}
