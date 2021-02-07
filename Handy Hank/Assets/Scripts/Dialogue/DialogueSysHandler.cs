using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSysHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject DialoguePanel;
    PlayerController pc;
    public bool finished;
    public int page = 0, maxPage;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        maxPage = pc.closestInteractable.realContent.dialogueSize;
    }

    public void SetPageInfo(int i, string textRef, Sprite imgRef)
    {
        Image image = DialoguePanel.GetComponentInChildren<Image>();
        Text text = DialoguePanel.GetComponentInChildren<Text>();

        image.sprite = imgRef;
        text.text = textRef;

        if (i >= maxPage) {
            finished = true;
        }
    }
    public void SetPageInfo()
    {
        //empty
    }
}
