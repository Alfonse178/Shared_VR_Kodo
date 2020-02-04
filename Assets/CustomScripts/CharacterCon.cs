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

    // Use this for initialization
    void Start()
    {
        // turn off the cursor
        PV = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
        if (!PV.IsMine)
        {
            //Destroy(m_Camera);
            m_Camera.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Input.GetAxis() is used to get the user's input
        // You can furthor set it on Unity. (Edit, Project Settings, Input)
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
    }
}