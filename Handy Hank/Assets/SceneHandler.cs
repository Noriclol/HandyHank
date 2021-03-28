using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    //sceneRefs
    private string currentScene;
    //public List<string> activeScenes;
    // Start is called before the first frame update
    void Start()
    {
        //activeScenes = new List<string>();
        currentScene = "Error";
    }

    void ChangeScene(string name) 
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
        //activeScenes.Add(name);
        if (currentScene != "Error")
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        currentScene = name;
       
    }
    
    //void ChangeScene(int name) { }
}
