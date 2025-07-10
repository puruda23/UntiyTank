using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // Photon Networ
using Photon.Realtime;
using UnityEngine.SceneManagement; // 씬 전환

public class Photonlnit : MonoBehaviourPunCallbacks 
    // MonoBehaviour를 쓰면서 Photon Networ에 전달
{
    public string Version = "V1.1.0";


    void Start()
    {
        PhotonNetwork.GameVersion = Version;
        PhotonNetwork.ConnectUsingSettings();
        // 포톤 네트워크에 접속

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log($"마스터 클라이언트 접속");
        PhotonNetwork.JoinLobby(); // 로비로 접속 해라
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log($"로비에 접속");
        PhotonNetwork.JoinRandomRoom(); // 무작위의 방에 접속해라
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("룸 접속에 실패!"); // print =Debug
        PhotonNetwork.CreateRoom("TankBattleRoom", new RoomOptions { IsOpen = true, IsVisible = true, MaxPlayers = 20 });
                                                                  // 방 공개여부 , 방 목록 리스트 여부 , 최대 접속자수
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log($"정상적으로 룸 접속!");
    }
}
