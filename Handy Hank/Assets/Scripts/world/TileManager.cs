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
    //tileRepository
    public Tile grass;
    public Tile sand;

}
