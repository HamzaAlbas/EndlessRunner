using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField] private BoxCollider col;
    
    private void Jumps()
    {       
        col.center = new Vector3(0.000237503f, 0.07229973f, 0.001021349f);
        col.size = new Vector3(0.0189953f, 0.07310934f, 0.01411375f);


    }

    private void Runs()
    {
        col.center = new Vector3(0.000237503f, 0.03852665f, 0.001021349f);
        col.size = new Vector3(0.0189953f, 0.07702339f, 0.01411375f);
    }

    private void Slides()
    {
        col.center = new Vector3(0.000237503f, 0.01818682f, 0.001021349f);
        col.size = new Vector3(0.0189953f, 0.0363437f, 0.01411375f);
    }
}
