using TreeEditor;
using UnityEngine;

public class Cellarena : MonoBehaviour //cellarena spawner
{
    public GameObject cube;
    public GameObject upperbaseblock;
    public GameObject smallborder;
    public GameObject Case;
    GameObject rotatedbord;// not actually rotation it only started that wayn ow its about changing size too
    float casecompteurx = 0; // sert a espacer les plaques
    float casecompteury = 0;

    float casechance; // chance qu'une case soit skip
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Awake()
    {

            
        for(int i = 0; i < 100; i++)
            {
                rotatedbord = Instantiate(smallborder, new Vector3(transform.right.x + i, transform.up.y, transform.forward.z - 0.5f), Quaternion.identity);//small outer border z start
                rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
                rotatedbord = Instantiate(smallborder, new Vector3(transform.right.x + 10 + i * 0.8f, transform.up.y+1, transform.forward.z + 10 - 0.5f), Quaternion.identity);//higher outer border z start
                rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
                rotatedbord.transform.localScale = new Vector3(1, 2.5f, 1);
                
                for (int j = 0; j < 100; j++) 
                {  
                    Instantiate(cube, new Vector3(transform.right.x + i, transform.up.y, transform.forward.z + j), Quaternion.identity);// flat base
                    
                    Instantiate(upperbaseblock, new Vector3(transform.right.x + 10 + i*0.8f, transform.up.y+1, transform.forward.z+ 10 + j * 0.8f), Quaternion.identity); // higher part

                    if (i == 0) // for x borders (start)
                    {
                        Instantiate(smallborder, new Vector3(transform.right.x + i-0.5f, transform.up.y, transform.forward.z + j), Quaternion.identity);//small outer border x start
                        rotatedbord = Instantiate(smallborder, new Vector3(transform.right.x + 10 + i * 0.8f - 0.5f, transform.up.y+1, transform.forward.z + 10 + j *0.8f), Quaternion.identity);//higher outer border x start
                        rotatedbord.transform.localScale = new Vector3(1, 2.5f, 1);
                    }
                    if (i == 99) // for x borders (start)
                    {
                        Instantiate(smallborder, new Vector3(transform.right.x + i + 0.5f, transform.up.y, transform.forward.z + j), Quaternion.identity);//small outer border x end
                        rotatedbord = Instantiate(smallborder, new Vector3(transform.right.x + 10 + i * 0.8f + 0.5f, transform.up.y+1, transform.forward.z + 10 + j * 0.8f), Quaternion.identity);//higher outer border x start
                        rotatedbord.transform.localScale = new Vector3(1, 2.5f, 1);
                    }
                    if (casecompteurx == 0 && casecompteury == 0 && j < 98 && i < 98) // generation de case espacées
                    {
                        casechance = Random.Range(0, 10); // 10% de chance
                        
                        if (casechance != 0) { Instantiate(Case, new Vector3(transform.right.x + 12 + i * 0.8f + 0.5f, transform.forward.y + 2.8f , transform.forward.z + 12 + j * 0.8f), Quaternion.identity); }//ajout d'une case 10% chance de ne pas le faire

                    }
                    casecompteury += 1;
                    if (casecompteury == 5) { casecompteury = 0; } // reset le compte a 5 car elle sont espacé de 4 blocks




                }// base
                rotatedbord = Instantiate( smallborder, new Vector3(transform.right.x + i , transform.up.y, transform.forward.z + 100 -0.5f), Quaternion.identity);//small outer border z end
                rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
                rotatedbord = Instantiate(smallborder, new Vector3(transform.right.x + 10 + i * 0.8f, transform.up.y+1, transform.forward.z +10+ 100*0.8f - 0.5f), Quaternion.identity);//higher outer border z end
                rotatedbord.transform.Rotate(new Vector3(0, 90, 0));
                rotatedbord.transform.localScale = new Vector3(1, 2.5f, 1);
                casecompteury = 0;// au cas ou
                casecompteurx += 1;
                if (casecompteurx == 5) { casecompteurx = 0; } // reset le compte a 5 car elle sont espacé de 4 blocks
                


           
        }
    }
}
