using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueSysHandler : MonoBehaviour
{
    public Sprite sprt;
    public string testText;
    public GameObject player;
    public GameObject DialoguePanel;
    public GameObject DialogueImage;
    public GameObject DialogueText;
    PlayerController pc;
    public int page = 0, maxPage = 0;
    void Start()
    {
        //DialogueImage.GetComponent<Image>().sprite = sprt;
        //DialogueText.GetComponent<Text>().text = testText;
        pc = player.GetComponent<PlayerController>();
        if (pc.ci != null) {
            Debug.Log("no null"); 
        }
        else if (pc.ci == null) {
            Debug.Log("null");
        }
    }     
    public void SetPageInfo(string textRef, Sprite imgRef) // ON
    {
        DialogueImage.GetComponent<Image>().sprite = imgRef;
        DialogueText.GetComponent<Text>().text = textRef;
    }

    public void ToggleWindowVisibility(bool isActive)
    {
        Sprite image;
        string text;
        if (isActive)//activate
        {
            DialoguePanel.gameObject.SetActive(true);
            InitPage();
            image = pc.ci.content.DialogueImages[page];
            text = pc.ci.content.DialogueText[page];
            SetPageInfo(text, image);

        }
        else
        {
            DialoguePanel.gameObject.SetActive(false);
        }
    }

    public void InitPage()
    {
        page = 0;
        maxPage = pc.ci.content.DialogueText.Count;
        
    }
    public void NextPage()
    {

    }
}
