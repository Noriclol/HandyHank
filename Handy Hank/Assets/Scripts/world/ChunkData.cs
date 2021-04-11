using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public struct ChunkData
{
    public chunkBiome biome;


    public List<Tile> structures;
}

public enum chunkBiome
{
    ocean,
    Grass,
    City,
}
