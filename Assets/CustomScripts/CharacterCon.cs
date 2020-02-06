using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CharacterCon : MonoBehaviourPunCallbacks
{

    public float speed = 10.0f;
    private float translation;
    private float straffe;
    private PhotonView PV;
    [SerializeField] private Camera m_Camera;

    //new variables
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    public float walkSpeed = 4f;
    public float jumpForce = 220f;
    public LayerMask groundedMask;

    Transform cameraTransform;
    float verticalLookRotation;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    bool grounded;
    //new variables
    // Use this for initialization
    void Start()
    {
        //########OLD CODE#########
        // turn off the cursor
        PV = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        if (!PV.IsMine)
        {
            //Destroy(m_Camera);
            m_Camera.enabled = false;
        }
        //new line of code
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            Debug.Log("passed the if statement");
            translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            transform.Translate(straffe, 0, translation);

            if (Input.GetKeyDown("escape"))
            {
                // turn on the cursor
                Cursor.lockState = CursorLockMode.None;
            }
        }
        //newcode
        if (PV.IsMine)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
            verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;
            verticalLookRotation = Mathf.Clamp(verticalLookRotation, -60, 60);
            cameraTransform.localEulerAngles = Vector3.left * verticalLookRotation;

            // Calculate movement:
            float inputX = Input.GetAxisRaw("Horizontal");
            float inputY = Input.GetAxisRaw("Vertical");

            Vector3 moveDir = new Vector3(inputX, 0, inputY).normalized;
            Vector3 targetMoveAmount = moveDir * walkSpeed;
            moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                if (grounded)
                {
                    GetComponent<Rigidbody>().AddForce(transform.up * jumpForce);
                }
            }

            // Grounded check
            Ray ray = new Ray(transform.position, -transform.up);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            Rigidbody rb1 = GetComponent<Rigidbody>();
            rb1.MovePosition(rb1.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }
    }
}