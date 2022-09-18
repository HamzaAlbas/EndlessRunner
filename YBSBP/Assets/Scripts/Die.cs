using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Die : MonoBehaviour
{

    private void Dead()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Dead();    
        }
        
    }
}
