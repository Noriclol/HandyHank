using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{
    public GameObject player;
    public ItemSO item;
    public int amount;

    public SpriteRenderer sr;

    void Start()
	{
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = item.icon;
        player = GameObject.FindGameObjectWithTag("Player");
	}

    public void OnPickup()
    {
        player.GetComponent<Inventory>().AddItemtoInventory(item, amount);
        player.GetComponent<PlayerController>().inventoryHandler.Populate();

        gameObject.SetActive(false);
    }
}
