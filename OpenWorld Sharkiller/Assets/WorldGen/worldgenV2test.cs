using UnityEngine;
using UnityEngine.UIElements;

public class worldgenV2test : MonoBehaviour
{
    public GameObject Cube;


    void Update()
    {
        if (Input.GetKey(KeyCode.E)) { Instantiate(Cube, Vector3.zero, Quaternion.identity); }

    }
}

    
