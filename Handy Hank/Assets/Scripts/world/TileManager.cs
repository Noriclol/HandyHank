using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public TileManager instance;
    private void Start()
    {
        instance = this;
    }

    //whiteboxChunks
    public Tile WB_grass;
    public Tile WB_ocean;


    //tileRepository
    public Tile grass;
    public Tile sand;

}
