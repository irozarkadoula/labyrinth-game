using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube_controller : MonoBehaviour
{
    // Start is called before the first frame update

    private float x;
    private float z;
    private bool rotateX;
    private float rotationSpeed;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        x = 0.0f;
        z = 0.0f;
        rotateX = true;
        rotationSpeed = 3.0f;

       rb.centerOfMass = new Vector3(-2, 1, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()


    {

        if (rotateX == true)
        {
            x += Time.deltaTime * rotationSpeed;

            if (x > 180.0f)
            {
                x = 0.0f;
                rotateX = false;
            }
        }


      // transform.localRotation = Quaternion.Euler(x, 0, 0);
        transform.RotateAround(new Vector3(2, -1, 0f), transform.forward, Time.deltaTime * 100f);
    }
}
