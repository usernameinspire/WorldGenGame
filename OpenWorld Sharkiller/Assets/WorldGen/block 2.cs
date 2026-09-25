using UnityEngine;

// Plain data holder set by WorldGenerator after a block is placed.
// biomefalloff is gone -- biome is now looked up from noise based on
// position, so there's no per-block "stubbornness" value to track anymore.
public class block2 : MonoBehaviour
{
    private float biome;

    public float GetBiome()
    {
        return biome;
    }

    public void SetBiome(float newBiome)
    {
        biome = newBiome;
    }
}