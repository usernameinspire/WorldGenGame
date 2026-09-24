using System.Collections.Generic;
using UnityEngine;


public class WorldGenerator : MonoBehaviour
{
    private const int BlockSpacing = 4;
    private const int WorldSize = 600;

    
    public GameObject biome0;
    public GameObject biome1;
    public GameObject biome2;
    public GameObject biome3;

    
    public Vector3Int startPosition = Vector3Int.zero;

   
    [SerializeField] private float noiseScale = 50f;

    // 0 = a different layout every time you generate. Any other value
    // reproduces the same biome layout every time (handy for testing).
    [SerializeField] private int worldSeed = 1;

    private Vector2 noiseOffset;
    private readonly HashSet<Vector3Int> occupiedPositions = new HashSet<Vector3Int>();

    private static readonly Vector3Int[] Directions =
    {
        Vector3Int.left,
        Vector3Int.right,
        Vector3Int.forward,
        new Vector3Int(0, 0, -1) // back
    };

    void Start()
    {
        GenerateWorld();
    }

    public void GenerateWorld()
    {
        occupiedPositions.Clear();
        noiseOffset = ComputeNoiseOffset();

        GameObject[] biomePrefabs = { biome0, biome1, biome2, biome3 }; // type de block par biomes

        var frontier = new Queue<Vector3Int>();

        occupiedPositions.Add(startPosition); // ajout de la premiere position au tableau des position occupées(on ajoute avant pour eviter les conflict de placement en mm temp de blocks
        SpawnBlock(startPosition, biomePrefabs); // premier block
        frontier.Enqueue(startPosition);// pile de block qui n'a pas encore placé ses voisins

        while (frontier.Count > 0)
        {
            Vector3Int current = frontier.Dequeue();

            foreach (Vector3Int dir in Directions)
            {
                Vector3Int nextPos = current + dir * BlockSpacing;

                if (occupiedPositions.Contains(nextPos))
                {
                    continue;
                }

                if (!InBounds(nextPos, dir))
                {
                    continue;
                }

                occupiedPositions.Add(nextPos);
                SpawnBlock(nextPos, biomePrefabs);
                frontier.Enqueue(nextPos);
            }
        }
    }

    private Vector2 ComputeNoiseOffset()
    {
        if (worldSeed != 0)
        {
            var seededRandom = new System.Random(worldSeed);
            return new Vector2(
                (float)seededRandom.NextDouble() * 10000f,
                (float)seededRandom.NextDouble() * 10000f);
        }

        return new Vector2(Random.Range(0f, 5000f), Random.Range(0f, 10000f));
    }

    private bool InBounds(Vector3Int nextPos, Vector3Int dir)
    {
        // Only one axis is non-zero for any direction we use (x or z).
        if (dir.x != 0)
        {
            return dir.x < 0 ? nextPos.x > 0 : nextPos.x < WorldSize;
        }

        return dir.z < 0 ? nextPos.z > 0 : nextPos.z < WorldSize;
    }

    // Position-based biome lookup. Same (x, z) always returns the same
    // biome, which is what makes neighboring cells cohere into regions
    // instead of flickering independently.
    private int GetBiomeIndex(Vector3Int position)
    {
        float sampleX = (position.x + noiseOffset.x) / noiseScale;
        float sampleZ = (position.z + noiseOffset.y) / noiseScale;
        float noiseValue = Mathf.PerlinNoise(sampleX, sampleZ); // 0..1

        int biomeIndex = Mathf.FloorToInt(noiseValue * 4f);
        return Mathf.Clamp(biomeIndex, 0, 3);
    }

    private void SpawnBlock(Vector3Int position, GameObject[] biomePrefabs)
    {
        int biomeIndex = GetBiomeIndex(position);
        GameObject prefab = biomePrefabs[biomeIndex];
        GameObject instance = Instantiate(prefab, (Vector3)position, Quaternion.identity);

        block2 blockComponent = instance.GetComponent<block2>();
        if (blockComponent != null)
        {
            blockComponent.SetBiome(biomeIndex);
        }
    }
}