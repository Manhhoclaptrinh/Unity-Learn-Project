using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.Random;


public class NewMonoBehaviourScript : MonoBehaviour
{
    private Tilemap m_Tilemap;

    public int width;
    public int height;
    public Tile[] GroundTile;
    public Tile[] WallTile;

    public class Celldata
    {
        public bool passable;
    }
    private Celldata[,] m_BoardData;

    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        m_BoardData = new Celldata[width, height];

        for(int y = 0; y < height; ++y)
        {
            for(int x = 0; x < width; ++x)
            {
                Tile tile;
                m_BoardData[x, y] = new Celldata();

                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                {
                    tile = WallTile[UnityEngine.Random.Range(0, WallTile.Length)];
                    m_BoardData[x,y].passable = false;
                }
                else
                {
                    tile = GroundTile[UnityEngine.Random.Range(0, GroundTile.Length)];
                    m_BoardData[x, y].passable = true;
                }
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
       
    }

    void Update()
    {
        
    }
}
