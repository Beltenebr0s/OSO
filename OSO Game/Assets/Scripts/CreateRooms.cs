using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class CreateRooms : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomNameInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(roomNameInput.text);
    }
    public void JoinRoom(){
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
