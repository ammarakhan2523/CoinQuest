using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    public float TimeToLive = 5f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive); // destroy bullets after 5f
    }
}
