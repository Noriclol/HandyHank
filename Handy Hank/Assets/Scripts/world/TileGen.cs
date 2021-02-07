using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TileGen
{
    private int width, height;
    private int[,] gridArray;

    public TileGen(int width, int height)
    {
        this.width = width;
        this.height = height;

        gridArray = new int[width, height];

        for (int i = 0; i < width; i++) {
            for (int j = 0; j < height; j++)
            {
                Debug.Log(i + " " + j);
            }
        }
    }
    //public static textmesh createworldtile(transform parent, string text, vector3 localposition, int fontsize, color color, textanchor textanchor, textalignment textalignment,)
    //{
    //    gameobject gameobject = new gameobject("world_text", typeof(textmesh));
    //    transform transform = gameobject.transform;
    //    transform.setparent(parent, false);
    //    transform.localposition = localposition;
    //    textmesh textmesh = gameobject.getcomponent<textmesh>();
    //    textmesh.anchor = textanchor;
    //    textmesh.alignment = textalignment;
    //    textmesh.text = text;
    //    textmesh.fontsize;

    //}

}
