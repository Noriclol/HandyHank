using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public SceneHandler sceneHandler;
    public Camera ActiveCamera;
    public GameObject player;
    public GameObject WorldGrids;
    public GameObject ChunkHandler;

    public int GameState;


    private void Awake()
    {
        Instance = this;
        
        sceneHandler = this.GetComponent<SceneHandler>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GenerateChunk(ChunkData chunkData) {

    }
}
