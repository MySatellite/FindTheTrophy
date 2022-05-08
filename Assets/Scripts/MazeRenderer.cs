using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{

    [SerializeField]
    [Range(1, 50)]
    private int width;

    [SerializeField]
    [Range(1, 50)]
    private int height;

    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;

    [SerializeField]
    private Transform floorPrefab = null;

    [SerializeField]
    private GameObject npc;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private int numberOfNPC;

    [SerializeField]
    Transform npcParent;

    [SerializeField]
    private GameObject trophy;

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);

        int spawnWidth = width - 10;
        int spawnHeight = height - 10;

        Vector3 playerPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), Random.Range(0, 10), Random.Range(-spawnHeight, spawnHeight)); // X, Y, Z
        Instantiate(player, playerPosition, Quaternion.identity);

        for ( int i = 0; i < numberOfNPC; i++ )
        {
            Vector3 npcPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), Random.Range(0, 10), Random.Range(-spawnHeight, spawnHeight)); // X, Y, Z
            Instantiate(npc, npcPosition, Quaternion.identity, npcParent);
        }

        Vector3 trophyPosition = new Vector3(Random.Range(-spawnWidth, spawnWidth), Random.Range(10, 20), Random.Range(-spawnHeight, spawnHeight)); // X, Y, Z
        Vector3 trophyRotation = new Vector3(-90, 0, 0);
        Instantiate(trophy, trophyPosition, Quaternion.Euler(trophyRotation));
    }

    private void Draw(WallState[,] maze)
    {

        var floor = Instantiate(floorPrefab, transform);
        floor.localScale = new Vector3(width, 1, height);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
