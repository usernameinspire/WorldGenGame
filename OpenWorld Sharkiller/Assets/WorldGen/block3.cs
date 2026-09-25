using System.Collections.Generic;
using UnityEngine;

public class block3 : MonoBehaviour
{
    private const int BlockSpacing = 4;
    private const int WorldSize = 40;

    // Shared by every block instance.
    private static HashSet<Vector3Int> occupiedPositions =
        new HashSet<Vector3Int>();

    public GameObject biome0;
    public GameObject biome1;
    public GameObject biome2;
    public GameObject biome3;

    private GameObject[] biomePrefabs;

    GameObject son;

    Vector3Int nextblock;

    private float biome;

    float random;
    private float biomefalloff;

    // The four directions a new block can spawn in.
    private static readonly Vector3Int[] Directions =
    {
        Vector3Int.left,
        Vector3Int.right,
        Vector3Int.forward,
        new Vector3Int(0, 0, -1) // back
    };

    public static void ClearOccupiedPositions()
    {
        occupiedPositions.Clear();
    }

    public float GetBiome()
    {
        return biome;
    }

    public void SetBiome(float newBiome)
    {
        biome = newBiome;
    }

    public void SetBiomeFalloff(float newBiomeFalloff)
    {
        biomefalloff = newBiomeFalloff;
    }

    private Vector3Int GridPosition(Vector3 position)
    {
        return new Vector3Int(
            Mathf.RoundToInt(position.x),
            Mathf.RoundToInt(position.y),
            Mathf.RoundToInt(position.z)
        );
    }

    private bool blockcollé(Vector3Int dir)
    {
        nextblock = (GridPosition(transform.position) + dir * BlockSpacing);

        return occupiedPositions.Contains(nextblock);
    }

    // Is the spawn position for this direction still inside the world bounds?
    private bool InBounds(Vector3Int dir)
    {
        // Only one axis is non-zero for any direction we use (x or z).
        if (dir.x != 0)
        {
            float newX = transform.position.x + dir.x * BlockSpacing;
            return dir.x < 0 ? newX > 0 : newX < WorldSize;
        }
        else
        {
            float newZ = transform.position.z + dir.z * BlockSpacing;
            return dir.z < 0 ? newZ > 0 : newZ < WorldSize;
        }
    }

    // Rolls the falloff/biome logic once (was copy-pasted 4x before).
    private void RollBiome()
    {
        random = Random.Range(0, 100);
        if (biomefalloff < random)
        {
            biomefalloff += 1;
        }
        else
        {
            biome = Random.Range(0, 4);
            biomefalloff = 0;
        }
    }

    // Spawns a neighbor block in the given direction (was copy-pasted 4x before).
    private void SpawnNeighbor(Vector3Int dir)
    {
        RollBiome();

        Vector3 spawnPosition = transform.position + (Vector3)dir * BlockSpacing;

        GameObject prefab = biomePrefabs[(int)biome];
        son = Instantiate(prefab, spawnPosition, Quaternion.identity);
        son.GetComponent<block>().setbiome(biome);
        son.GetComponent<block>().setbiomefalloff(biomefalloff);
    }

    void Awake()
    {
        biomePrefabs = new[] { biome0, biome1, biome2, biome3 };

        Debug.Log("awake");

        foreach (Vector3Int dir in Directions)
        {
            if (!blockcollé(dir) && InBounds(dir))
            {
                Debug.Log(dir); // was "LEFT"/"RIGHT"/"FRONT"/"BACK" before
                SpawnNeighbor(dir);
            }
        }
    }
}
