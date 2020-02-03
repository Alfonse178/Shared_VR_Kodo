using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    //lets me edit it in the editor instead of opening up the script
    [SerializeField]
    private GameObject quickstartbutton;//button for creating and joining
    [SerializeField]
    private GameObject quickcancelbutton; //button stops the search
    [SerializeField]
    private int roomsize;//set the number of players allowed in the room at one time

    public override void OnConnectedToMaster()//callback function for first connection made
    {
        PhotonNetwork.AutomaticallySyncScene = true; //the scene that the master is on, all clients see
        quickstartbutton.SetActive(true);
    }

    public void QuickStart()
    {
        quickstartbutton.SetActive(false);
        quickcancelbutton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); //first, lets join an exisiting room
        Debug.Log("Quick start has been initialized");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();//go to the create room function due to none being available
    }
    void CreateRoom()
    {
        Debug.Log("Creating a room now...");//making a new room after failed attempt at joining one
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions RoomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomsize};
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, RoomOps);//starting to make a new room
        Debug.Log(randomRoomNumber);//shows the room number created in the console
    }

    public override void OnCreateRoomFailed(short returnCode, string message)//essentially a loop for making a room
    {
        Debug.Log("Failed to make a room...trying again now");
        CreateRoom();
    }

    public void QuickCancel()//essentially stop looking for a room
    {
        quickcancelbutton.SetActive(false);
        quickstartbutton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
