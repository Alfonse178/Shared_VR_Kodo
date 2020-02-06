﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;

public class GameSetupController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating a player...");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar1"), Vector3.zero, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
