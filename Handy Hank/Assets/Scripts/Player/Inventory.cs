using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    
    InventorySlot[] inventory = new InventorySlot[20];

    void addItematIndex(Item item, int amount, int index) {
        //inventory[index] = InventorySlot(item, index);
    }
    void RemoveatIndex(int index) { }
    void FindItem(Item item) { }
    void UseItem() { }
}
public class InventorySlot
{
    Item item;
    int amount = 0;
    InventorySlot(Item item, int amount)
	{
        this.item = item;
        this.amount = amount;
	}
}
public class Item
{
    string itemName;
    public Item() { }
}
public enum ItemType {Junk, Tool};
public class Hammer : Item
{
    ItemType type = ItemType.Tool;
    
}

