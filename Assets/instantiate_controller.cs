using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pref;
    public double width = 2;
    public double height = 7;
    private float update;
    


    //private GameObject e;
    void Start()
    {



    }

    // Update is called once per frame
    void Update()

    {

        update += Time.deltaTime;
        if (update > 0.5f)
        {
            update = 0.0f;

            for (float y = 0; y < 1; y = y + 0.07f)
            {
                for (float z = 0; z < 3 ; z = z + 1.0f)
                {
                    for (float x = 0; x < 1 ; x = x + 0.2f)
                    {
                        Instantiate(pref, new Vector3(y, z, x), Quaternion.identity);
                    }  
                }
            }

            
        }

    }
}

   
