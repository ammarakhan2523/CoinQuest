using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
   
    public GameObject player;
    RaycastHit hitData;
    private Animator enemyAnim;
    int enemyHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnim.SetBool("Walking", true);
        DetectPlayer();
    }
    void DetectPlayer() // detect player when in contact
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 4);
        if (Physics.Raycast(ray, out hitData))
        {
            if (hitData.collider.gameObject == player)
            {
                GetComponent<NavMeshAgent>().destination = player.transform.position;
                enemyAnim.SetTrigger("Attack");
                enemyAnim.SetBool("Walking", false);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {   // decrease and destroy enemy when collided with bullets
        if(other.gameObject.CompareTag("Bullet"))
        {

            //Destroy(gameObject);
            enemyHealth += -20;
            Destroy(other.gameObject);

            if(enemyHealth == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    { // decrease player health when attacked by enemy
        if(collision.transform.gameObject == player )
        {
            PlayerController.playerHealth += -20;
        }
      
    }
}
