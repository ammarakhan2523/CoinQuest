using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject scoretext;
    float speed = 2;
    private Animator playerAnim;
    bool holdButton;
    public GameObject bulletPrefab;
    public GameObject gunPrefab;
    public static int playerHealth = 100;
    int totalCoins = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealth < 0) // when player health is lessthan zero play animation of death and game is over
        {
            //Destroy(gameObject);
            playerAnim.SetTrigger("death");
            print("GameOver");
        }
        print(playerHealth);
        scoretext.GetComponent<Text>().text = "Score = " + totalCoins.ToString();
       
        PlayerMovement();


        if (Input.GetKeyDown(KeyCode.Space)) // play shoot animation
        {
          
            playerAnim.SetTrigger("Shoot");
          
           
        }
        

    }

    void PlayerMovement()
    {

        if (Input.GetKey(KeyCode.UpArrow ))
        {
            ForwardInput();
            transform.localEulerAngles = new Vector3(0, 0, 0);
          
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
           
            transform.localEulerAngles = new Vector3(0, 180, 0);
            ForwardInput();
          
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
            ForwardInput();
          
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, 270, 0);
            ForwardInput();
           
        }
        else 
        {
            playerAnim.SetBool("isMoving", false);
            holdButton = false;
        }
      
    }

    void ForwardInput()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        playerAnim.SetBool("isMoving", true);
        holdButton = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))// increase coins on collection
        {
            Destroy(collision.gameObject);
            totalCoins++;
        }
    }

}

