using Unity.VisualScripting;
using UnityEngine;

public class block : MonoBehaviour
{

    
    Vector3 checkSize = new Vector3(1, 2.5f, 1);
    public LayerMask blockLayer;

    float biome = 0;
    float biomefalloff = 0;

    float random;
    public GameObject biome0;
    public GameObject biome1;
    public GameObject biome2;
    public GameObject biome3;
    float comp = 0;
    GameObject son;

    public bool IsBlockAside(Vector3 direction)
    {
        Vector3 checkPos = transform.position + direction;
        Collider[] hits = Physics.OverlapBox(checkPos, checkSize, Quaternion.identity, blockLayer);
        comp = 0;
        foreach (Collider hit in hits) 
            {

                if (hit.gameObject != this.gameObject) 
                {
                if (hit.gameObject.transform.position.z != this.gameObject.transform.position.z) { comp++; } 
                } 
            }
        //Collider test = hits[0];
        //GameObject Objettest = test.gameObject;
        //if (Objettest != this.gameObject) { return hits.Length > 0;}
        return comp > 0;
    }
    public bool IsBlockAsideZ(Vector3 direction)
    {
        Vector3 checkPos = transform.position + direction;
        Collider[] hits = Physics.OverlapBox(checkPos, checkSize, Quaternion.identity, blockLayer);
        comp = 0;
        foreach (Collider hit in hits)
        {

            if (hit.gameObject != this.gameObject)
            {
                if (hit.gameObject.transform.position.x != this.gameObject.transform.position.x) { comp++; } 
            }
        }
        //Collider test = hits[0];
        //GameObject Objettest = test.gameObject;
        //if (Objettest != this.gameObject) { return hits.Length > 0;}
        return comp > 0;
    }


    public float getbiome() { return biome; }
    public void setbiome(float newbiome)
    {
        this.biome = newbiome;
    }
    public void setbiomefalloff(float newbiomefallof)
    {
        this.biomefalloff = newbiomefallof;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("awake");
        if (IsBlockAside(Vector3.right*-1) != true && transform.position.x - 4 > 0 ) // left
        {
            Debug.Log("LEFT");
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
            if (biome == 0)
            {
                son = Instantiate(biome0, new Vector3(transform.position.x - 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 1)
            {
                son = Instantiate(biome1, new Vector3(transform.position.x - 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 2)
            {
                son = Instantiate(biome2, new Vector3(transform.position.x - 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if(biome == 3)
            {
                son = Instantiate(biome3, new Vector3(transform.position.x - 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }


        }
        if (IsBlockAside(Vector3.right) != true && transform.position.x + 4 < 40 ) // right
        {
            Debug.Log("RIGHT");
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
            if (biome == 0)
            {
                son = Instantiate(biome0, new Vector3(transform.position.x + 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 1)
            {
                son = Instantiate(biome1, new Vector3(transform.position.x + 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 2)
            {
                son = Instantiate(biome2, new Vector3(transform.position.x + 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 3)
            {
                son = Instantiate(biome3, new Vector3(transform.position.x + 4, transform.position.y, transform.position.z), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }

        }
        if (IsBlockAside(Vector3.forward) != true && transform.position.z + 4 < 40) //front
        {
            Debug.Log("FRONT");
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
            if (biome == 0)
            {
                son = Instantiate(biome0, new Vector3(transform.position.x, transform.position.y, transform.position.z + 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 1)
            {
                son = Instantiate(biome1, new Vector3(transform.position.x , transform.position.y, transform.position.z + 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 2)
            {
                son = Instantiate(biome2, new Vector3(transform.position.x , transform.position.y, transform.position.z + 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 3)
            {
                son = Instantiate(biome3, new Vector3(transform.position.x , transform.position.y, transform.position.z + 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
        }
        if (IsBlockAside(Vector3.forward*-1) != true && transform.position.z - 4 > 0) // back
        {
            Debug.Log("BACK");
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
            if (biome == 0)
            {
                son = Instantiate(biome0, new Vector3(transform.position.x  , transform.position.y, transform.position.z - 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 1)
            {
                son = Instantiate(biome1, new Vector3(transform.position.x , transform.position.y, transform.position.z - 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 2)
            {
                son = Instantiate(biome2, new Vector3(transform.position.x , transform.position.y, transform.position.z - 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
            else if (biome == 3)
            {
                son = Instantiate(biome3, new Vector3(transform.position.x , transform.position.y, transform.position.z - 4), Quaternion.identity);
                son.GetComponent<block>().setbiome(biome);
                son.GetComponent<block>().setbiomefalloff(biomefalloff);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
