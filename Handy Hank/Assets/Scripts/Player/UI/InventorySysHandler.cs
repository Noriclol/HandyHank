using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySysHandler : MonoBehaviour
{
    public GameObject player;

    public GameObject InventoryPanel;
    public GameObject InventorySlotContainer;
    public GameObject InventorySlot;
    public ItemSO item;
    public int amount = 1;
    Inventory pi;
    List<GameObject> SlotArray;

    private void Start()
    {
        pi = player.GetComponent<Inventory>();
        SlotArray = new List<GameObject>();
    }
    public void Populate() {
        foreach(Transform child in InventorySlotContainer.transform) {
            GameObject.Destroy(child.gameObject);
        }
        SlotArray.Clear();
        for (int i = 0; i < pi.invSize; i++) {
            //Debug.Log(pi.inventory[i].amount);
            GameObject newSlot = Instantiate(InventorySlot, InventorySlotContainer.transform);
            SlotArray.Add(newSlot);
            if (pi.inventory[i].amount > 0){
                newSlot.GetComponent<SlotButtonHandler>().PopulateSlot(pi.inventory[i].item, pi.inventory[i].amount);
            }
            //newSlot.GetComponent<SlotButtonHandler>().PopulateSlot(item, amount);
        }
    }
    public void Close()
	{
        InventoryPanel.SetActive(false);
	}
}
