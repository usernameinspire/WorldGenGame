using UnityEngine;

public class generationAlgues : MonoBehaviour
{
    public GameObject Algues;

    void Start()
    {
        // Se limite au premier quadrant (i < 75 et j < 75)
        for (int i = 0; i < 75; i++)
        {
            for (int j = 0; j < 75; j++)
            {
                int rng = Random.Range(0, 50);
                if (rng == 0)
                {
                    // Multiplié par 4 pour correspondre à l'espacement des cubes
                    Vector3 position = new Vector3((i * 4) + 2, 1, (j * 4) + 2);
                    Instantiate(Algues, position, Quaternion.identity);
                }
            }
        }
    }
}