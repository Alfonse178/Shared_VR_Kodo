using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private PhotonView pv;
    private CharacterController myCC;
    public float movementspeed;
    public float rotationspeed;
    Camera mycamera;
    Rigidbody rb;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //mycamera=GetComponent<>
        pv = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Before the photonview.ismine");
        if (!pv.IsMine)
        {
            Debug.Log("in the pv.ismine loop");
            BasicMovement();
            BasicRotation();
        }
    }

    void BasicMovement()
    {
        //old code
        if (Input.GetKey(KeyCode.W))
        {
            myCC.Move(transform.forward * Time.deltaTime * movementspeed);
            Debug.Log("Just pressed w...");
        }
        if (Input.GetKey(KeyCode.A))
        {
            myCC.Move(-transform.right * Time.deltaTime * movementspeed);
            Debug.Log("Just pressed a...");
        }
        if (Input.GetKey(KeyCode.S))
        {
            myCC.Move(-transform.forward * Time.deltaTime * movementspeed);
            Debug.Log("Just pressed s...");
        }
        if (Input.GetKey(KeyCode.D))
        {
            myCC.Move(transform.right * Time.deltaTime * movementspeed);
            Debug.Log("Just pressed d...");
        }
    }

    void BasicRotation()
    {
        float mouseX = Input.GetAxis("Horizontal") * Time.deltaTime * rotationspeed;
        float mouseY= Input.GetAxis("Vertical") * Time.deltaTime * rotationspeed;
        transform.Rotate(new Vector3(mouseX, 0, mouseY));
    }
}
