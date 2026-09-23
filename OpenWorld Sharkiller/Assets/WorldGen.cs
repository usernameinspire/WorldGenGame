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
    bool Arenaspawnb1 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < 75*2; i++)//z
        {
            for (int j = 0; j < 75*2; j++)//x
            {
                if (i < 75 && j < 75) 
                { 
                    Instantiate(Cube, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.2f, j * 0.2f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity); 
                }
                if (i < 50 && j < 50) 
                { 
                    if (Arenaspawnb1 = false)
                    {
                        Instantiate(ARENA, new Vector3(transform.position.x + (i * 4) + 2, transform.position.y + 20, transform.position.z + (j * 4) + 2), Quaternion.identity);
                        Arenaspawnb1 = true;
                    }
                        
                }
                if (i < 75 && j>= 75 && j < 150) 
                { 
                    Instantiate(Cube2, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.2f, j * 0.2f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity); 
                }
                if (i < 150 && i >= 75  && j < 75) 
                {
                    Instantiate(Cube3, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.2f, j * 0.2f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity); 
                }
                if (i < 150 && i >=75 && j >= 75 && j < 150) 
                { 
                    Instantiate(Cube4, new Vector3(transform.position.x + (i * 4) + 2, Mathf.PerlinNoise(i * 0.2f, j * 0.2f) * 3, transform.position.z + (j * 4) + 2), Quaternion.identity); 
                }


            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
