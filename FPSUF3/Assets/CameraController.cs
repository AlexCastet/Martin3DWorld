using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject m_camera;
    [SerializeField] float m_ClampY;
    [SerializeField] float m_MouseSpeed;

    private float XRotation;
    private float YRotation;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         XRotation = Input.GetAxis("Mouse X");
         YRotation = Input.GetAxis("Mouse Y");
    }
    private void FixedUpdate()
    {
        transform.Rotate(0, XRotation*m_MouseSpeed*Time.deltaTime,0);
        float eulerx = m_camera.transform.localEulerAngles.x;
        eulerx -= YRotation * m_MouseSpeed * Time.deltaTime; 
        m_camera.transform.localEulerAngles = Vector3.right * eulerx;
        m_camera.transform.LookAt(m_camera.transform.position);
    }
}
