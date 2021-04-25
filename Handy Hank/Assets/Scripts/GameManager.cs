using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SceneHandler sceneHandler;
    public Camera ActiveCamera;
    public GameObject player;
    public GameObject WorldGrids;
    
    
    public int GameState;


    private void Awake()
    {
        sceneHandler = this.GetComponent<SceneHandler>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GenerateChunkPrefabs()
    {

    }
}
