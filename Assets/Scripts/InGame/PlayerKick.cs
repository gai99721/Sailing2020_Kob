using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class PlayerKick : MonoBehaviour
{

    public Player[] kickPlayer
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
        foreach (Player player in PhotonNetwork.PlayerList)
        {
               kickPlayer = PhotonNetwork.PlayerList;
        }
    }

    public void OnClick()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            int i = 0;
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                PhotonNetwork.CloseConnection(kickPlayer[1]);
                i++;
            }
        }
    }

}
