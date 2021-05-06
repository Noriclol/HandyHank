using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class ChunkData
{
    public Vector2Int Pos;

    public ChunkBiome biome;
    public Tile whiteboxChunk;
    //public List<Tile> tiles;
    //public List<GameObject> structures;
    //public List<GameObject> characters;
    public ChunkData(Vector2Int Pos, ChunkBiome biome, Tile WB) {
        this.Pos = Pos;
        this.whiteboxChunk = WB;
        this.biome = biome;
    }
}

public enum ChunkBiome
{
    ocean,
    Grass,
    City,
}

