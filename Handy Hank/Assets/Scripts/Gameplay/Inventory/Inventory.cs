using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int invSize;
    public InventorySlot[] inventory;
    private void Awake()
    {
        inventory = new InventorySlot[invSize];
        for (int i = 0; i < invSize; i++)
        {
            inventory[i] = new InventorySlot();
        }
    }
    void AddAmountatIndex(ItemSO item, int amount, int index) {
        inventory[index].item = item;
        inventory[index].amount = amount;
        Debug.Log("added " + amount + " of " + item + " at " + index);
    }
    bool RemoveAmountatIndex(int index, int amount) {
        if (inventory[index].amount <= amount)
        {
            Debug.Log("removed all " + inventory[index].item + "s at " + index);
            inventory[index].item = null;
            inventory[index].amount = 0;
            return true;
        }
        else
        {
            Debug.Log("removed" + amount + " of " + inventory[index].item + " at " + index);
            inventory[index].amount = inventory[index].amount - amount;
            return false;
        }
    }
    int FindIndexofItem(ItemSO item) {
        for (int i = 0; i < invSize - 1; i++) {
            if (inventory[i].item == item) {
                return i;
            }
        }
        return invSize + 1;
    }
    int FindEmptySlot() {
        for (int i = 0; i < invSize - 1; i++) {
            if (inventory[i].amount == 0)
            {
                return i;
            }
        }
        return invSize + 1;
    }
    void UseItem(int index) {
        if (true)
        {

        }
    }

    public bool AddItemtoInventory(ItemSO item, int amount)
    {
        //look for item in existing inventory
        int foundIndex = FindIndexofItem(item);
        int emptySlot = FindEmptySlot();
        if (foundIndex <= invSize) { //look for empty item 
            //if item exists add amount to existing item pool
            int newAmount = inventory[foundIndex].amount + amount;
            AddAmountatIndex(item, newAmount, foundIndex);
            return true;
        }
        else if(emptySlot <= invSize)// look for empty slot
        {
            //if not then add item and amount on empty slot
            AddAmountatIndex(item, amount, emptySlot);
            return true;
        }
        else //return false
        {
            Debug.Log("Warning: Cant return item");
        }
        return false;
    }

    public bool RemoveItemsfromInventory(ItemSO item, int amount)
    {
        return RemoveAmountatIndex(FindIndexofItem(item), amount);
        //if true give reciever items and amount.
    }
}
public class InventorySlot
{
    public ItemSO item;
    public int amount = 0;
    public InventorySlot(ItemSO item, int amount)
	{
        this.item = item;
        this.amount = amount;
	}
    public InventorySlot() {
        this.item = null;
        this.amount = 0;
    
    }
}


