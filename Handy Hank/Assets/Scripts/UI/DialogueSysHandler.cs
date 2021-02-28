using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSysHandler : MonoBehaviour
{
    public GameObject player;
    public GameObject DialoguePanel;
    public GameObject DialogueImage;
    public GameObject DialogueText;
    PlayerController pc;
    Sprite emptySprite;
    string emptyString;
    public int page = 0, maxPage = 0;
    void Start()
    {
        pc = player.GetComponent<PlayerController>();

        //Debug shit
        

    }     
    public void SetPageInfo(string textRef, Sprite imgRef) // ON
    {
        DialogueImage.GetComponent<Image>().sprite = imgRef;
        DialogueText.GetComponent<Text>().text = textRef;
    }
    public void ClearPageInfo()
    {
        DialogueImage.GetComponent<Image>().sprite = emptySprite;
        DialogueText.GetComponent<Text>().text = emptyString;
        Debug.Log("page cleared");

    }

    public void ToggleWindowVisibility(bool isActive)
    {

        if (isActive)//activate
        {
            DialoguePanel.gameObject.SetActive(true);
            SetPageInfo(pc.ci.content.DialogueText[page], pc.ci.content.DialogueImages[page]);
        }
        else
        {
            DialoguePanel.gameObject.SetActive(false);
        }

        //Debug
        
        if (pc.ci != null)
        {
            Debug.Log("no null");
        }
        else if (pc.ci == null)
        {
            Debug.Log("null");
        }
    }
    public void NextPage() {
        ClearPageInfo();
        page++;
        SetPageInfo(pc.ci.content.DialogueText[page], pc.ci.content.DialogueImages[page]);
    }
}
