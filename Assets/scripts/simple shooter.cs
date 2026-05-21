using UnityEngine;
using UnityEngine.InputSystem;

public class simpleshooter : MonoBehaviour
{
    public Vector3 force;
    public Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            KickTheBall();
        }
    }
    void KickTheBall() { 
        rb.AddForce(force);
    }
}
