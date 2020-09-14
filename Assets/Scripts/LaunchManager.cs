using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LaunchManager : MonoBehaviourPunCallbacks
{
    #region GameObjects
    public GameObject enterGamePanel;
    public GameObject connectionStatusPanel;
    public GameObject lobbyPanel;
    public GameObject instructionsPanel;
    #endregion

    #region Unity Methods
        
    private void Awake()
    {   
        PhotonNetwork.AutomaticallySyncScene = true;                // Synchronization between players.
    }

    // Start is called before the first frame update
    void Start()
    {
        enterGamePanel.SetActive(true);
        connectionStatusPanel.SetActive(false);
        lobbyPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Public Methods

    public void ConnectToPhotonServer()         // Connect to Photon Server            
    {
        if(!PhotonNetwork.IsConnected)                  
        {
            PhotonNetwork.ConnectUsingSettings();
            connectionStatusPanel.SetActive(true);
            enterGamePanel.SetActive(false); 
        }
    }

    public void JoinRandomRoom()                // Join Random Room
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void LoadGameScene()                         // Load Game Scene
    {
        PhotonNetwork.LoadLevel("GameScene");
    }

    #endregion

    #region Photon Callbacks

    public override void OnConnectedToMaster()                  // On Connected to Photon Server/Master Server
    {
        Debug.Log(PhotonNetwork.NickName + " connected to photon");
        lobbyPanel.SetActive(true);
        connectionStatusPanel.SetActive(false);

    }
        
    public override void OnConnected()                         // On connected to Internet
    {
        Debug.Log(" connected to internet");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)           // Joining Random Room Failed
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()                         // Called when player joins the room
    {
        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
        instructionsPanel.SetActive(true);
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {

        string roomName = " Room" + Random.Range(1000, 10000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;


        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    #endregion
}
