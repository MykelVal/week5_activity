using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviourPun, IPunObservable
{
    private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private string _equipment;

    private void Start()
    {
        if (photonView.IsMine)
        {
            _currentHealth = _maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(_currentHealth);
            stream.SendNext(_equipment);
        } else
        {
            _currentHealth = (int)stream.ReceiveNext();
            _equipment = (string)stream.ReceiveNext();
        }
    }

    public void UpdateHealth()
    {

    }

    private void Update()
    {
        if (!photonView.IsMine)
        {

        }
    }
}
