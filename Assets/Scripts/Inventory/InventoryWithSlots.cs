using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class InventoryWithSlots : IInventory
{
    public int Capacity { get ; set; }

    public bool IsFull => _slots.All(slot => slot.IsFull);

    private List<IInventorySlot> _slots = new List<IInventorySlot>();

    public InventoryWithSlots(int capacity)
    {
        Capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);

        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();

        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty)
                allItems.Add(slot.Item);
        }

        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();

        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty && slot.ItemType == itemType)
                allItemsOfType.Add(slot.Item);
        }

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItem()
    {
        var equippedItems = new List<IInventoryItem>();

        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty && slot.Item.IsEquipped)
                equippedItems.Add(slot.Item);
        }

        return equippedItems.ToArray();
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.ItemType == itemType).Item;
    }

    public int GetItemAmount(Type itemType)
    {
        throw new NotImplementedException();
    }

    public bool HasItem(Type itemType, out IInventoryItem item)
    {
        throw new NotImplementedException();
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        throw new NotImplementedException();
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        throw new NotImplementedException();
    }
}
