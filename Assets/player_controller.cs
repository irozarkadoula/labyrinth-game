using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public float speed = 3;
    private bool isGrounded = true;
    public bool trap = true;
    public Text failText;
    public Text winText;
  
    Text t_text;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t_text = GetComponent<Text>();
   
 
  

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");



        if (trap)
        {
            Vector3 force_direction = new Vector3(moveHorizontal, 0, moveVertical);
            rb.AddForce(speed * force_direction);

        }
        else

        {
            Vector3 force_direction2 = new Vector3(-moveHorizontal, 0, moveVertical);
            rb.AddForce(speed * force_direction2);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, 1, 0) * 5, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            rb.AddForce(rb.velocity.normalized * 5, ForceMode.Impulse);
        }

       
     
        //transform.position += new Vector3(moveHorizontal * Time.deltaTime, 0, moveVertical * Time.deltaTime); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            ShowWinMessage();
            Destroy(other.gameObject);

            
        }

        if (other.CompareTag("Trap"))
        {
            trap = false;

        }

        if (other.CompareTag("TrapAxe"))
        {


            ShowFailMessage();

            Destroy(gameObject);
            Application.Quit();

        }



    }

    void OnCollisionEnter()
    {
        isGrounded = true;

     
    }

    private void ShowFailMessage()
    {
     
        failText.text = "YOU LOSE";
    }

    private void ShowWinMessage()
    {
        winText.text = "YOU WIN";
    }
}
