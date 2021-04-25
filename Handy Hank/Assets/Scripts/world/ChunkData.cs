using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public struct ChunkData
{
    public Vector2 Pos;

    public chunkBiome biome;
    public Tile whiteboxChunk;
    public List<Tile> tiles;

}

public enum chunkBiome
{
    ocean,
    Grass,
    City,
}
