using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private Vector3 offset, targetrotate, rotateval;
    private Vector3 distance, crossAngle;
    public Transform target;


    //for rotation with velocity
    float tiltAngleX = 30f;
    float tiltAngleZ = 0.3f;

    //for rotation with control
    float tiltAngle = 20f;

    private Rigidbody rb;
    private bool trap2;


    public float verticalBuffer = -0.5f;
    public float horizontalBuffer = 3f;
    private Vector3 velocity = Vector3.zero;
    void Start()

    {
        offset = transform.position - player.transform.position;
        rb = player.GetComponent<Rigidbody>();


        transform.position = player.transform.position + offset;

    }
    // Update is called once per frame
    void FixedUpdate()

    {
        distance = new Vector3(0, 0.75f, -0.5f);


        //rotate with control
        float tilt = Input.GetAxis("Horizontal") * tiltAngle * Time.deltaTime;

        //float tiltAroundX = rb.velocity.x * tiltAngleX * Time.deltaTime;
        //float tiltAroundZ = rb.velocity.z * tiltAngleZ * Time.deltaTime;

        trap2 = player.GetComponent<player_controller>().trap;


        float angle = Vector3.SignedAngle(player.transform.position , transform.position , Vector3.up);

        transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, transform.position.z),
           new Vector3(player.transform.position.x + distance.x , player.transform.position.y+ offset.y , player.transform.position.z + distance.z),
             ref velocity, 0.01f);
      
        


        if (trap2)
        {
           
                transform.Rotate(0, tilt, 0, Space.World);
       
        }
        else

        {
            transform.Rotate(0, -tilt, 0, Space.World);
        }


    
     



    }
}
   

