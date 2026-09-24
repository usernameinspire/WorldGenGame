using UnityEngine;

public class generateurPierres : MonoBehaviour
{
    public GameObject caillouvolcan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 75 * 2; i++)
        {
            for (int j = 0; j < 75 * 2; j++)
            {
                int rng = Random.Range(0, 350);
                if (rng == 0)
                {
                    Instantiate(caillouvolcan, new Vector3(i, 1, j), Quaternion.identity);

                }
            }

        }


    }
}

