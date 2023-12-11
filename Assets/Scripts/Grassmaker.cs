using UnityEngine;

public class Grassmaker : MonoBehaviour
{
    public GameObject grassPrefab;
    public GameObject dirtPrefab;
    public int gridSizeX = 10;
    public int gridSizeY = 10;
    public int innerGridSizeX = 5;
    public int innerGridSizeY = 5;
    public float tileSize = 1.0f;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Create an empty GameObject to act as the parent for the tiles
        GameObject gridParent = new GameObject("GridParent");

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                GameObject tilePrefab = (x < innerGridSizeX && y < innerGridSizeY) ? grassPrefab : dirtPrefab;
                Vector3 spawnPosition = new Vector3(x * tileSize, y * tileSize, 0);

                // Instantiate the tilePrefab as a child of gridParent
                GameObject tile = Instantiate(tilePrefab, spawnPosition, Quaternion.identity, gridParent.transform);
            }
        }
    }
}
