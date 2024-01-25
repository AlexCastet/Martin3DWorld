using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    [SerializeField]
    private float m_GravityScale = 1.0f;
    public float GravityScale => m_GravityScale;

    private static float globalGravity = -9.81f;
    void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
   
   void FixedUpdate()
    {
            Vector3 gravity = globalGravity * GravityScale * Vector3.up;
            rb.AddForce(gravity, ForceMode.Acceleration);
    }

    public void SetGravity(float gravity)
    {
        m_GravityScale = gravity;
    }
}
