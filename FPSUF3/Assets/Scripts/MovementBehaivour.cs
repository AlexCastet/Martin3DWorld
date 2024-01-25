using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CustomGravity))]
public class MovementBehaivour : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Camera;
    private Rigidbody m_Rigidbody;
    [SerializeField]
    private float m_Speed = 15;
    
    [SerializeField]
    private float m_JumpForce = 100;
    [SerializeField]
    private InputActionAsset m_inputasset;

    private InputActionAsset m_inputAction;
    [SerializeField]
    private LayerMask m_ShootMask;
    [SerializeField]
    private LayerMask m_JumpMask;
    private Vector3 DireccioVelocity = Vector3.zero;

    private bool m_Jump;
    

    void Awake()
    {
        m_Jump = true;
        m_Rigidbody = GetComponent<Rigidbody>();
        m_inputAction = Instantiate(m_inputasset);
        m_inputAction.FindActionMap("Land").FindAction("Movement").performed += Movement;
        m_inputAction.FindActionMap("Land").FindAction("Movement").canceled += StopMovement;
        m_inputAction.FindActionMap("Land").FindAction("Jump").performed += Saltar;
        m_inputAction.FindActionMap("Land").FindAction("Shoot").performed += Disparar;
        m_inputAction.FindActionMap("Land").Enable();
        
       
    }

    
    public void EnableJump()
    {
        if (m_Jump) { return; }
        m_Jump = true;
    }
    private void OnDestroy()
    {
        m_inputAction.FindActionMap("Land").FindAction("Movement").performed -= Movement;
        m_inputAction.FindActionMap("Land").FindAction("Movement").canceled -= StopMovement;
        m_inputAction.FindActionMap("Land").FindAction("Jump").performed -= Saltar;
        m_inputAction.FindActionMap("Land").FindAction("Shoot").performed -= Disparar;
        m_inputAction.FindActionMap("Land").Disable();
    }

    private void Disparar(InputAction.CallbackContext context)
    {
        Debug.Log("Disparo");
        RaycastHit hit;
        if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out hit, 20f, m_ShootMask))
        {
            Debug.Log($"He tocat {hit.collider.gameObject} a la posici {hit.point} amb normal {hit.normal}");
            Debug.DrawLine(m_Camera.transform.position, hit.point, Color.red, 2f);
            m_Camera.GetComponent<Camera>().enabled = false;

        }
    }

    private void Saltar(InputAction.CallbackContext context)
    {
        if (!m_Jump) return;

        m_Rigidbody.AddForce(Vector3.up * m_JumpForce);
        Debug.Log("Salto");
        m_Jump = false;
    }

    private void StopMovement(InputAction.CallbackContext context)
    {
        m_Rigidbody.velocity = Vector3.zero;
        DireccioVelocity = Vector3.zero;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        DireccioVelocity = context.ReadValue<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        PuedoSaltar();
    }
    void FixedUpdate()
    {
        DireccioVelocity.Normalize();
        m_Rigidbody.velocity = (DireccioVelocity.z * transform.forward +DireccioVelocity.x*transform.right) * m_Speed + Vector3.up*m_Rigidbody.velocity.y;
    }

    private void PuedoSaltar()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1+f, m_JumpMask))
        {
            m_Jump = true;
            Debug.DrawLine(transform.position, hit.point, Color.red, 2f);
            

        }
    }
    
}
