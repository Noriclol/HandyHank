using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Container", menuName = "inventory/Container")]
public class ContainerSO : ScriptableObject
{
	public new string name;
	public Sprite sprite;
	public float weight;
}
