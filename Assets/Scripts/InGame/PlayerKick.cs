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
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                kickPlayer = player;
            }
        }
        if (!PhotonNetwork.IsMasterClient)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnClick()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            /// <summary>Request a client to disconnect (KICK). Only the master client can do this</summary>
            /// <remarks>Only the target player gets this event. That player will disconnect automatically, which is what the others will notice, too.</remarks>
            /// <param name="kickPlayer">The Player to kick.</param>
            PhotonNetwork.CloseConnection(kickPlayer);
        }
    }

}
