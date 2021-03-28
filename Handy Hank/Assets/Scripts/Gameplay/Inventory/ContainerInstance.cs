using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerInstance : MonoBehaviour
{
    public GameObject player;
    public ContainerSO container;
    public ItemSO[] containerInv;
    public int[] amountInv;

    public SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        sr.sprite = container.sprite;
        player = GameObject.FindGameObjectWithTag("Player");
    }
}
