using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory
{
    internal class Apple : IInventoryItem
    {
        public Type Type => GetType();

        public IInventoryItemInfo Info { get; }

        public IInventoryItemState State { get; }

        public Apple(IInventoryItemInfo info)
        {
            Info = info;
            State = new InventoryItemState();
        }

        public IInventoryItem Clone()
        {
            var clonedApple = new Apple(Info);
            clonedApple.State.Amount = State.Amount;

            return clonedApple;
        }
    }
}
