using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D), typeof(GameObject))]
public class Interactable : MonoBehaviour
{
    public GameObject player;
    public Collider2D ICollider;
    public DialogueObject content; // why wont this work??????
    private void Awake()
    {
        ICollider = GetComponent<Collider2D>();
        player = GetComponent<GameObject>();
    }
}
