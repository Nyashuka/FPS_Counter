using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryWithSlots : IInventory
{
    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;

    public int Capacity { get; set; }
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
            if (!slot.IsEmpty && slot.Item.State.IsEquipped)
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
        int amount = 0;
        foreach (var slot in _slots)
        {
            if (!slot.IsEmpty && slot.ItemType == itemType)
                amount++;
        }

        return amount;
    }

    public bool HasItem(Type itemType, out IInventoryItem item)
    {
        item = GetItem(itemType);

        return item != null;
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        var countSlotsWithItem = slotsWithItem.Length;

        if (countSlotsWithItem == 0)
            return;

        int amountToRemove = amount;

        for (int i = countSlotsWithItem - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];

            if (slot.Amount >= amountToRemove)
            {
                slot.Item.State.Amount -= amountToRemove;

                if (slot.Amount == 0)
                    slot.Clear();

                OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);

                break;
            }

            OnInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);

            amountToRemove -= slot.Amount;
            slot.Clear();
        }
    }

    private IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty = _slots.Find(slot => !slot.IsEmpty &&
                                                      slot.ItemType == item.Type &&
                                                      !slot.IsFull);

        if (slotWithSameItemButNotEmpty != null)
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);

        var emptySlot = _slots.Find(slot => slot.IsEmpty);

        if (emptySlot != null)
            return TryToAddToSlot(sender, emptySlot, item);

        Debug.Log("Full inventory");
        return false;
    }

    private bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        int amountToAdd;

        if (slot.Amount + item.State.Amount > item.Info.MaxItemsInInventorySlot)
            amountToAdd = item.State.Amount;
        else
            amountToAdd = item.Info.MaxItemsInInventorySlot - slot.Amount;

        int amountLeft = item.State.Amount - amountToAdd;

        var clonnedItem = item.Clone();
        clonnedItem.State.Amount = amountLeft;

        if (slot.IsEmpty)
            slot.SetItem(clonnedItem);
        else
            slot.Item.State.Amount += amountToAdd;

        OnInventoryItemAddedEvent?.Invoke(sender, item, amountToAdd);

        if (amountLeft <= 0)
            return true;

        item.State.Amount = amountLeft;

        return TryToAdd(sender, item);
    }
}
