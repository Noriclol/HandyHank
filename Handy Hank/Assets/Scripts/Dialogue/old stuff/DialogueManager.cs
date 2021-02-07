using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> images;

    void Start()
    {
        sentences = new Queue<string>();
        images = new Queue<Sprite>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
    }
}
