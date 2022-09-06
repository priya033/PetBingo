using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
  [SerializeField]  private int _width, _height;

    [SerializeField] Tile _prefabTile;

    [SerializeField] private Transform _cam;

    private void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for(int x =0; x< _width; x++)
        {
            for(int y = 0; y < _height; y++)
            {
                var spawnedTile = Instantiate(_prefabTile, new Vector3(x,y),Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = (x + y)%2 == 1;

                spawnedTile.Init(isOffset);
            }
        }

        _cam.transform.position = new Vector3((float)_width/2 -0.5f,(float)_height/2 -0.5f,-10);
    }

    //TODO: Add this to the Bingo Tiles
    void BingoNumbersGenerator()
    {
        HashSet<int> numbers = new HashSet<int>();
        while (numbers.Count < 25)
        {
            numbers.Add(Random.Range(1, 100));
        }

    }

}
