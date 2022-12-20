using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public TMP_Text debugText;
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        debugText.text = "Número de jugadores: " + PhotonNetwork.CurrentRoom.PlayerCount;
        if( PhotonNetwork.CurrentRoom.PlayerCount >= GameManager.Instance.MinNumPlayers)
        {
            GameManager.Instance.CanStartGame = true;
            debugText.text += "\nPuede empezar la partida";
        }
    }
}
