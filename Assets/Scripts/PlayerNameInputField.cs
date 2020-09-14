using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNameInputField : MonoBehaviour
{
   public void SetPlayerName(string playerName)
    {
        if(string.IsNullOrEmpty(playerName))                // Check Player Name
        {
            Debug.Log("Player Name is Empty.");
            return;
        }

        PhotonNetwork.NickName = playerName;
    }
}
