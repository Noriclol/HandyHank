using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Chunk : MonoBehaviour
{
    public ChunkData data;
    public Vector3 chunkPos;
    public List<Tile> tiles;
    public Tilemap tilemap;
    int chunkSize = 16;



    void Start()
    {
        chunkPos = transform.position;
        Populate();
    }

    void Update()
    {

    }
    void Populate()
    {
        Vector3Int currentTile = tilemap.WorldToCell(chunkPos);

        for (int y = 0; y < chunkSize; y++)
        {
            for (int x = 0; x < chunkSize; x++)
            {
                //tilemap.SetTile(new Vector3Int(x, y, 0), TileManager.instance.grass);


            }
        }



    }
    //void GetBorderChunks();
    
}
