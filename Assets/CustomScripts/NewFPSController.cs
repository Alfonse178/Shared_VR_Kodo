using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewFPSController : MonoBehaviour
{
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 4f;
    public float jumpForce = 220f;
    public LayerMask groundedMask;

    Transform cameraT;
    float verticalRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded;
    //new variables
    [SerializeField] private Camera m_Camera;
    private PhotonView PV;
    // Use this for initialization
    void Start()
    {
        PV = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        if (!PV.IsMine)
        {
            //Destroy(m_Camera);
            m_Camera.enabled = false;
        }
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
            verticalRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
            verticalRotation = Mathf.Clamp(verticalRotation, -60, 60);
            cameraT.localEulerAngles = Vector3.left * verticalRotation;

            Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

            if (Input.GetButtonDown("Jump"))
            {
                if (grounded)
                {
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.AddForce(transform.up * jumpForce);
                }

            }

            grounded = false;
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1.1f, groundedMask))
            {
                grounded = true;
            }
            Rigidbody rb1 = GetComponent<Rigidbody>();
            rb1.MovePosition(rb1.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
            }
           
    }
}
