using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Dialogue")]
public class DialogueObject : ScriptableObject
{
    public string dialogueName;
    public int dialogueSize;
    public int currentPage = 0;
    public bool finished =false;
    [SerializeField]
    public List<string> DialogueString = new List<string>();
    [SerializeField]
    public List<Sprite> DialogueImages = new List<Sprite>();
}
