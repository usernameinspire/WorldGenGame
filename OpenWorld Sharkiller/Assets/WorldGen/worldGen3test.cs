using System.Collections.Generic;
using UnityEngine;

// BUT DU PROGRAME Créer une map générée aleatoirement
// on commence au debut en placant un bloc qui "se multiplie" mais sa multiplication est restreinte dans une zone AKA Worldsize, 
// on retient la position de chaque blocks pour ensuite peut etre y reacceder pour leur rajouter des Propriétées ou autres et pour empecher de replacer un block la ou il y en a deja un
//a chaque repetition on clear lesl iste de positions des blocks car elle empecherais de placer des blocks la ou il y en avait
//a chaque placement de block on lui assigne un biome qui est appliqué selon perlin noise pour donner une impression d'aleatoire



public class WorldGenerator : MonoBehaviour
{
    private const int BlockSpacing = 4;// espacement entre les blocks
    private const int WorldSize = 600;// taile du monde, peut changer

    
    public GameObject biome0;// blocks de biomes differents
    public GameObject biome1;
    public GameObject biome2;
    public GameObject biome3;

    int Intconverterah; // convertisseur float to int

    
    public Vector3Int startPosition = Vector3Int.zero;

   
    
    int noisescale2 = 200; // bigger = bigger biomes


    // 0 = a different layout every time you generate. Any other value
    // reproduces the same biome layout every time (handy for testing).
    [SerializeField] private int worldSeed = 1; // ne marche pas avec des nombres trop grands, si la seed est 0 cela donne une autre seeed random


    private Vector2 noiseOffset;
    private readonly HashSet<Vector3Int> occupiedPositions = new HashSet<Vector3Int>(); // Tableau qui indique ou chaque block placé est

    private static readonly Vector3Int[] Directions =     // ca c l'ia qui fait ca c un peut plus opitimisé mais bon
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

        GameObject[] biomePrefabs = { biome0, biome1, biome2, biome3 }; // type de block par biomes plus facilement accessible

        var frontier = new Queue<Vector3Int>();// pile de block qui n'a pas encore placé ses voisins

        occupiedPositions.Add(startPosition); // ajout de la premiere position au tableau des position occupées(on ajoute avant pour eviter les conflict de placement en mm temp de blocks
        SpawnBlock(startPosition, biomePrefabs); // premier block
        frontier.Enqueue(startPosition);// on rajoute le premier block a la queue car il n'a pas encore placé ses voisins

        while (frontier.Count > 0) // tant qu'il y a encore des blocks qui n'ont pas placés leurs voisins
        {
            Vector3Int current = frontier.Dequeue(); // on sort le block a traiter 

            foreach (Vector3Int dir in Directions)// devant derriere gauche ou droite, regarde chaque dirrection a coté et verifie si la position est occupée
            {
                Vector3Int nextPos = new Vector3Int(current.x, startPosition.y, current.z) + dir * BlockSpacing;

                if (occupiedPositions.Contains(nextPos))
                {
                    continue;
                }

                if (!InBounds(nextPos, dir))
                {
                    continue;
                }
                Intconverterah = Mathf.RoundToInt(Mathf.PerlinNoise(nextPos.x * 0.1f, nextPos.z * 0.1f) * 3);
                occupiedPositions.Add(nextPos);
                SpawnBlock(new Vector3Int(nextPos.x,nextPos.y + Intconverterah, nextPos.z), biomePrefabs);
                frontier.Enqueue(nextPos);
            }
        }
    }

    private Vector2 ComputeNoiseOffset()
    {
        if (worldSeed != 0)
        {
            var seededRandom = new System.Random(worldSeed); // world seed se fait randomizer si elle est = a 0
            return new Vector2(
                (float)seededRandom.NextDouble() * 10000f,
                (float)seededRandom.NextDouble() * 10000f);
        }

        return new Vector2(Random.Range(1f, 5000f), Random.Range(1f, 10000f));
    }

    private bool InBounds(Vector3Int nextPos, Vector3Int dir) // limite la map
    {
        
        if (dir.x != 0)
        {
            return dir.x < 0 ? nextPos.x > 0 : nextPos.x < WorldSize;
        }

        return dir.z < 0 ? nextPos.z > 0 : nextPos.z < WorldSize;
    }

    
    private int GetBiomeIndex(Vector3Int position) // I have yet to understand this thing , but this works
    {
        float sampleX = (position.x + noiseOffset.x)/ noisescale2;
        float sampleZ = (position.z + noiseOffset.y)/ noisescale2;
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