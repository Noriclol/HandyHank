using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotButtonHandler : MonoBehaviour
{
    public GameObject ItemIcon, NameText, AmountText;

    void start()
    {
    }

    void ClearSlot()
    {
        //ItemIcon.GetComponent<Image>().sprite = sprite; // need to figure out way to clear this
        NameText.GetComponent<Text>().text = " ";
        AmountText.GetComponent<Text>().text = " ";
    }
    public void PopulateSlot(ItemSO item, int amount)
    {
        if (item == null && amount == 0)
        {
            ToggleSlotVisibility(false);
            return;
        }
        ItemIcon.GetComponent<Image>().sprite = item.icon;
        NameText.GetComponent<TMPro.TextMeshProUGUI>().text = item.name;
        AmountText.GetComponent<TMPro.TextMeshProUGUI>().text = "x" + amount.ToString();
    }
    void ToggleSlotVisibility(bool toggle)
    {
        NameText.SetActive(toggle);
        AmountText.SetActive(toggle);
    }
}
