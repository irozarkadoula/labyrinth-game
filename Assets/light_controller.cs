using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_controller : MonoBehaviour
{

    public GameObject player;
   
    private Vector3 offset;
    float tiltAngle = 25f;
    private Vector3 velocity = Vector3.zero;
    private bool trap3;




    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

        offset = transform.position - player.transform.position;
        rb = player.GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
            new Vector3(player.transform.position.x, player.transform.position.y + offset.y, player.transform.position.z),
            ref velocity, 0.1f);

        //float tiltAround = rb.velocity.x* tiltAngle * Time.deltaTime;
        float tilt = Input.GetAxis("Horizontal") * tiltAngle * Time.deltaTime;


        trap3 = player.GetComponent<player_controller>().trap;


        if (trap3)
        {

            transform.Rotate(0, tilt, 0, Space.World);

        }
        else

        {
            transform.Rotate(0, -tilt, 0, Space.World);
        }

    }
}
