using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "inventory/Item")]

public class ItemSO : ScriptableObject
{
    public new string name;
    public string desc;
    public Sprite icon;
    public int worth;
    public bool usable, sellable;
    public string useText;
}

public enum ItemType { Junk, Tool };