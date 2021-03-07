using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject player;
    public ItemSO item;
    public int amount;

    public void OnPickup()
    {
        player.GetComponent<Inventory>().AddItemtoInventory(item, amount);
        player.GetComponent<InventorySysHandler>().Populate();
        Destroy(gameObject);
    }
}
