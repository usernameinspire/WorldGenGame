using Unity.Collections.Tests.CoreCLR.TestJobs;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject Cube;
    public GameObject Cube2;
    public GameObject Cube3;
    public GameObject Cube4;
    public GameObject ARENA;



    public float Randomchance;
    bool Arenaspawnb2 = false;

    bool Arenaspawnb3 = false;
    bool Arenaspawnb4 = false;
    bool Arenaspawnb1 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 75*2; i++)//z
        {
            for (int j = 0; j < 75*2; j++)//x
            {
                if (i < 75 && j < 75) // BIOME 1
                { 
                    Instantiate(Cube, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.1f, j * 0.1f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity); 
                }
                if (i < 50 && j < 50 && i > 25 && j > 25)
                {
                    if (Arenaspawnb1 == false)

                    {
                        if (Random.Range(0,50) == 1)
                        { 
                        Instantiate(ARENA, new Vector3(transform.position.x + (i * 4) + 2, transform.position.y + 9, transform.position.z + (j * 4) + 2), Quaternion.identity);
                        Arenaspawnb1 = true;
                        }
                    }
                        
                }
                if (i < 75 && j >= 75 && j < 150)  // BIOME 2
                {

                    Instantiate(Cube2, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.1f, j * 0.1f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity);
                    if (i < 50 && j < 125 && i > 25 && j > 100)
                    {
                        if (Arenaspawnb2 == false)

                        {
                            if (Random.Range(0, 50) == 1)
                            {
                                Instantiate(ARENA, new Vector3(transform.position.x + (i * 4) + 2, transform.position.y + 9, transform.position.z + (j * 4) + 2), Quaternion.identity);
                                Arenaspawnb2 = true;
                            }
                        }
                    }
                }
                if (i < 150 && i >= 75  && j < 75) // BIOME 3
                    {

                    Instantiate(Cube3, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.1f, j * 0.1f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity);
                        if (i < 125 && j < 50 && i > 100 && j > 25)
                        {
                            if (Arenaspawnb3 == false)

                            {
                                if (Random.Range(0, 50) == 1)
                                {
                                    Instantiate(ARENA, new Vector3(transform.position.x + (i * 4) + 2, transform.position.y + 9, transform.position.z + (j * 4) + 2), Quaternion.identity);
                                    Arenaspawnb3 = true;
                                }
                            }
                        }
                    }
                if (i < 150 && i >=75 && j >= 75 && j < 150) // BIOME 4
                { 
                    Instantiate(Cube4, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.1f, j * 0.1f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity);
                    if (i < 125 && j < 125 && i > 100 && j > 100)
                    {
                        if (Arenaspawnb4 == false)

                        {
                            if (Random.Range(0, 50) == 1)
                            {
                                Instantiate(ARENA, new Vector3(transform.position.x + (i * 4) + 2, transform.position.y + 9, transform.position.z + (j * 4) + 2), Quaternion.identity);
                                Arenaspawnb4 = true;
                            }
                        }
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
