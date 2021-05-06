using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Chunk : MonoBehaviour
{
    public ChunkData data;
    private int tileSize = 16;
    private int chunkSize = 1;

    public Vector2Int Position;
    public Tile Tile;
    public ChunkBiome Biome;
    
    private Tilemap map;


    void Start()
    {
        Populate();
    }

    void Update()
    {

    }

    public bool MayInstantiate()
    {
        Camera camera = GameManager.Instance.ActiveCamera;
        var cameraPosition = camera.transform.position;

        var height = Screen.height;
        var width = Screen.width;

        var tilePos = this.Position;
        return tilePos.x > cameraPosition.x + width && tilePos.x < width &&
               tilePos.y > cameraPosition.y + height && tilePos.y < height;
    }

    void Populate()
    {
        var enabled = this.MayInstantiate();
        this.enabled = enabled;
        this.gameObject.SetActive(enabled);

        //if (enabled)
        //{
        //    Tile[] children = this.GetComponentsInChildren<Tile>();
        //    foreach (var child in children.ToList().OrderBy(x => x.))
        //    {
        //
        //    }
        //}


        //var currentTile = map.WorldToCell(pos);

        //for (int y = 0; y < tileSize; y++)
        //{
        //    for (int x = 0; x < tileSize; x++)
        //    {
        //        //tilemap.SetTile(new Vector3Int(x, y, 0), TileManager.instance.grass);
        //
        //
        //    }
        //}



    }
    //void GetBorderChunks();
}
