using System;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public static CollisionController Instance;
    public bool isCollided;
    
    
    private void Awake()
    {
        Instance = this;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isCollided = true;    
        }
    }
}
