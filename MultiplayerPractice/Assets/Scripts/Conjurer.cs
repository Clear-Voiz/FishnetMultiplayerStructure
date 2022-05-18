
using System;
using FishNet.Object;
using UnityEngine;

public class Conjurer : NetworkBehaviour
{
    public GameObject _projectile;
    private Transform _playerTrans;
    private NetworkObject nooj;

    private void Update()
    {
        
        if (IsOwner && IsClient)
        {if (Input.GetKeyDown(KeyCode.Z))
            {
                ServerMaterialiseRequest();
            }
           
        }
    }


    
    [ServerRpc]
    private void ServerMaterialiseRequest()
    {
        //GameObject temp = Instantiate(_projectile, _playerTrans.position + Vector3.forward, Quaternion.identity);
        Debug.Log(_playerTrans);
        GameObject projectile = Instantiate(_projectile,transform.position + transform.forward,Quaternion.identity);
       
        if (projectile == null)
            Debug.Log("bullet not found");
        else
            base.Spawn(projectile,base.Owner); //base.Owner
       
    }
    
    
}
