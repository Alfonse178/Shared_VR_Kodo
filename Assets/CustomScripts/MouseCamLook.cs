﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseCamLook : MonoBehaviourPunCallbacks
{

    [SerializeField]
    public float sensitivity = 5.0f;
    [SerializeField]
    public float smoothing = 2.0f;
    // the chacter is the capsule
    public GameObject character;
    // get the incremental value of mouse moving
    private Vector2 mouseLook;
    // smooth the mouse moving
    private Vector2 smoothV;
    private PhotonView PV;

    //new variables
    public float mouseSensitivityX = 250f;
    public float mouseSensitivityY = 250f;
    Transform cameraT;
    float verticalRotation;
    // Use this for initialization
    void Start()
    {
        //PV = GetComponent<PhotonView>();
        character = this.transform.parent.gameObject;
        //cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //######OLD CODE#####
        Debug.Log("passed 2nd if statement");
        // md is mosue delta
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        // the interpolated float result between the two float values
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        // incrementally add to the camera look
        mouseLook += smoothV;

        // vector3.right means the x-axis
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);



        ////######NEW CODE######
        //transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivityX);
        //verticalRotation += Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivityY;
        //verticalRotation = Mathf.Clamp(verticalRotation, -60, 60);
        //cameraT.localEulerAngles = Vector3.left * verticalRotation;
    }
}