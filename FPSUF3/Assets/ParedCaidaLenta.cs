using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ParedCaidaLenta : MonoBehaviour
{
    [SerializeField]
    private float NormalScaleGravity = 1.0f;
    [SerializeField]
    private float OnCollisionGravity;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision != null) { return; }
        collision.gameObject.GetComponent<CustomGravity>().SetGravity(OnCollisionGravity);
        collision.gameObject.GetComponent<MovementBehaivour>().EnableJump();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision != null) { return; }
        collision.gameObject.GetComponent<CustomGravity>().SetGravity(NormalScaleGravity);
    }
}
