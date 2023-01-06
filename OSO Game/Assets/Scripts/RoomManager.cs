using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{

    public TMP_Text debugText;

    [SerializeField] private PhotonView PV;

    [SerializeField] private Button buttonPlay;

    void Start()
    {
        buttonPlay.gameObject.SetActive(false);
        buttonPlay.onClick.AddListener(GameManager.Instance.InitGame);
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master?");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PV.RPC("UpdateDebugText", RpcTarget.All, "\nNúmero de jugadores: " + PhotonNetwork.CurrentRoom.PlayerCount);
        PV.RPC("UpdateDebugText", RpcTarget.All, "\nMínimo de jugadores: " + GameManager.Instance.MinNumPlayers);
        if( PhotonNetwork.CurrentRoom.PlayerCount >= GameManager.Instance.MinNumPlayers)
        {
            GameManager.Instance.CanStartGame = true;
            buttonPlay.gameObject.SetActive(true);
        }

        PV.RPC("UpdateDebugText", RpcTarget.All, "\nPuede empezar la partida");
    }

    [PunRPC]
    public void UpdateDebugText(string text)
    {
        debugText.text += text;
    }
}
