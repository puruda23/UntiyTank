using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // Photon Networ
using Photon.Realtime;
using UnityEngine.SceneManagement; // �� ��ȯ

public class Photonlnit : MonoBehaviourPunCallbacks 
    // MonoBehaviour�� ���鼭 Photon Networ�� ����
{
    public string Version = "V1.1.0";


    void Start()
    {
        PhotonNetwork.GameVersion = Version;
        PhotonNetwork.ConnectUsingSettings();
        // ���� ��Ʈ��ũ�� ����

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log($"������ Ŭ���̾�Ʈ ����");
        PhotonNetwork.JoinLobby(); // �κ�� ���� �ض�
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log($"�κ� ����");
        PhotonNetwork.JoinRandomRoom(); // �������� �濡 �����ض�
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        print("�� ���ӿ� ����!"); // print =Debug
        PhotonNetwork.CreateRoom("TankBattleRoom", new RoomOptions { IsOpen = true, IsVisible = true, MaxPlayers = 20 });
                                                                  // �� �������� , �� ��� ����Ʈ ���� , �ִ� �����ڼ�
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log($"���������� �� ����!");
    }
}
