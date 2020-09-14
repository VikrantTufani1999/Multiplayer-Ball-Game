using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGameManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    public GameObject gameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.IsConnected)
        {
            int randomPoint = Random.Range(-5, 5);
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(randomPoint, 10, randomPoint), Quaternion.identity);
        }
    }

    private void Update()
    {
        
    }
}
