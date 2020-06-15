using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class PlayerKick : MonoBehaviour
{

    public Player kickPlayer
    {
        get;
        private set;
    }

    private void Awake()
    {

        if (!PhotonNetwork.IsMasterClient)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (!PhotonNetwork.IsMasterClient)
        {

            kickPlayer = FindObjectOfType<Sailing.Online.MatchingManager>().ReturnKickPlayer();

        }
    }

    public void OnClick()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CloseConnection(kickPlayer);
        }
    }

}
