using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSecuritatController : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera m_Camera; 
    void Awake()
    {
        m_Camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) { CanviCamera(); }
    }
    public void CanviCamera()
    {
        m_Camera.enabled = false;
    }
}
