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
    public int page = 0, maxPage = 0;
    // Start is called before the first frame update
    void Start()
    {
        pc = player.GetComponent<PlayerController>();
        CollectInfo();
    }
    public void CollectInfo() {
        if (pc.closestInteractable = null) {
            page = 0;
            maxPage = 0;
        }
        else if (pc.closestInteractable != null) {
            page = pc.closestInteractable.content.currentPage;
            maxPage = pc.closestInteractable.content.dialogueSize;
            finished = pc.closestInteractable.content.finished;

        }
    }
    public void SetInfo() {
        if (pc.closestInteractable != null)
        {
            pc.closestInteractable.content.currentPage = page;
            pc.closestInteractable.content.dialogueSize = maxPage;
            pc.closestInteractable.content.finished = finished;
        }     
    }
    public void SetPageInfo(int i, string textRef, Sprite imgRef) // ON
    {
        Image image = DialoguePanel.GetComponentInChildren<Image>();
        Text text = DialoguePanel.GetComponentInChildren<Text>();

        image.sprite = imgRef;
        text.text = textRef;

        if (i == maxPage) {
            finished = true;
        }
        SetInfo();
    }
}
