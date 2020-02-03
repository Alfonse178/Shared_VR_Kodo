using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private int multiplayerSceneIndex;//number for the build index for multiplay scene

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Connected to a room...");
        StartGame();
    }

    private void StartGame()//actually loads the scene being used
    {
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Staring Game...");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
        }
    }

}
