using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySysHandler : MonoBehaviour
{
    public GameObject player;

    public GameObject InventoryPanel;
    public GameObject InventorySlotContainer;
    public GameObject InventorySlot;

    

    private void Start()
    {
        player.GetComponent<Inventory>();
    }
    public void Populate() {

        //for (int i = 0; i < player.inventory; i++)

    }

}
