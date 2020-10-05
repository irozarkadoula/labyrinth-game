using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe_controller : MonoBehaviour
{
    // Start is called before the first frame update

  
    public float newangle;
    private bool rotleft = false;
    private float update;
    private float direction = -300;
    private Rigidbody rb;
    Quaternion angle0 = Quaternion.Euler(0, 0, -180);
    Quaternion angle1 = Quaternion.Euler(0,0,0);
    private Quaternion targetangle;
    private float up;

    void Start()
    {
       Vector3  startposition = transform.position;
        rb = GetComponent<Rigidbody>();
     
    }

    // Update is called once per frame
    void FixedUpdate()


    {

        transform.Rotate(0, 0, direction * Time.deltaTime, Space.World);
        up += Time.deltaTime;
        if (up > 0.7f)
        {
            up = 0.0f;
            direction = -direction;
        }

    }


    
}
