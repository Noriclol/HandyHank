using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public string dialogueName;
    public int currentPage = 0;
    public bool finished = false;
    public List<string> DialogueText = new List<string>();
    public List<Sprite> DialogueImages = new List<Sprite>();
}
