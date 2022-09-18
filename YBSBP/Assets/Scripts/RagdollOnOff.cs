using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{

    public BoxCollider mainCollider;
    public GameObject mainRig;
    public Animator mainAnimator;
    public GameObject gameOverUI, playUI;

    
    private void Start()
    {
        GetRagDollRb();
        RagDollModeOff();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            RagDollModeOn();
        }
    }

    private Collider[] _ragDollColliders;
    private Rigidbody[] _limbsRigidbodies;
    void GetRagDollRb()
    {
        _ragDollColliders = mainRig.GetComponentsInChildren<Collider>();
        _limbsRigidbodies = mainRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagDollModeOn()
    {
        mainAnimator.enabled = false;
        foreach (Collider col in _ragDollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rb in _limbsRigidbodies)
        {
            rb.isKinematic = false;
        }
        
        mainCollider.enabled = false;
        
       
        GetComponent<Rigidbody>().isKinematic = true;

        StartCoroutine(WaitCoroutine());
    }

    void RagDollModeOff()
    {
        foreach (Collider col in _ragDollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rb in _limbsRigidbodies)
        {
            rb.isKinematic = true;
        }

        mainAnimator.enabled = true;
        mainCollider.enabled = true;

        GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(3);
        playUI.SetActive(true);
        gameOverUI.SetActive(true);
        
    }

    public void ReplayButton()
    {
        var scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

    }
    
}


