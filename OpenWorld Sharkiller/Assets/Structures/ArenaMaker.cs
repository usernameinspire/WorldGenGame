using TreeEditor;
using UnityEngine;

public class Cellarena : MonoBehaviour //cellarena spawner
{
    public GameObject cube;
    
    GameObject rotatedbord;// not actually rotation it only started that wayn ow its about changing size too
    

    float casechance; // chance qu'une case soit skip
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Awake()
    {
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 50, transform.position.y-1f, transform.position.z +50), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(100, 4f, 100);
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 50, transform.position.y+ 0.5f, transform.position.z + 50), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(80, 4f, 80);


        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 49.5f, transform.position.y- 1f, transform.position.z - 0.5f), Quaternion.identity);
        rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
        rotatedbord.transform.localScale = new Vector3(1, 4.2f, 101);
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 49.5f, transform.position.y + 0.5f, transform.position.z + 10 - 0.5f), Quaternion.identity);
        rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
        rotatedbord.transform.localScale = new Vector3(1, 4.5f, 81);

        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 49.5f, transform.position.y- 1f, transform.position.z + 100 - 0.5f), Quaternion.identity);
        rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
        rotatedbord.transform.localScale = new Vector3(1, 4.2f, 101);
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 49.5f, transform.position.y + 0.5f, transform.position.z + 10+ 80 - 0.5f), Quaternion.identity);
        rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
        rotatedbord.transform.localScale = new Vector3(1, 4.5f, 81);


        rotatedbord = Instantiate(cube, new Vector3(transform.position.x - 0.5f, transform.position.y- 1f, transform.position.z + 49.5f), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(1, 4.2f, 101);
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 10 - 0.5f, transform.position.y + 0.5f, transform.position.z + 49.5f), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(1, 4.5f, 81);

        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 100 - 0.5f, transform.position.y- 1f, transform.position.z + 49.5f), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(1, 4.2f, 101);
        rotatedbord = Instantiate(cube, new Vector3(transform.position.x + 10 + 80 - 0.5f, transform.position.y + 0.5f, transform.position.z + 49.5f), Quaternion.identity);
        rotatedbord.transform.localScale = new Vector3(1, 4.5f, 81);


        for (int i = 0; i < 20; i++)
        {
                
                
            for (int j = 0; j < 20; j++)
            {
                casechance = Random.Range(0, 10); // 10% de chance

                if (casechance != 0)
                {
                    rotatedbord = Instantiate(cube, new Vector3(transform.position.x + i * 3.95f + 12  , transform.position.y + 2.5f, transform.position.z + j * 3.95f + 12), Quaternion.identity);
                    rotatedbord.transform.localScale = new Vector3(3.3f, 0.25f, 3.3f);
                }//ajout d'une case 10% chance de ne pas le faire

            }



           
        }
    }
}
