using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using UnityEngine;

public class Conjurer : NetworkBehaviour
{
    public GameObject _projectile;
    private Transform _playerTrans;
    private NetworkObject nooj;

    private void OnEnable()
    {
        FirstObjectNotifier.OnFirstObjectSpawned += FirstObjectNotifierOnOnFirstObjectSpawned;
       //print(GiveOwnership());

       
    }

    private void FirstObjectNotifierOnOnFirstObjectSpawned(Transform obj)
    {
        _playerTrans = obj;
    }

    private void Update()
    {
        
        if (IsOwner && IsClient)
        {if (Input.GetKeyDown(KeyCode.Z))
            {
                ServerMaterialiseRequest();
            }
           
        }

        /*if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("is this script the owner?" + Owner + "for owner" + OwnerId);
            Debug.Log("is this script the owner?" + nooj.Owner + "for owner" + nooj.OwnerId);
        }*/
    }


    /*[ObserversRpc(BufferLast = true,IncludeOwner = false)]
    private void ServerMaterialiseRequest()
    {
        GameObject temp = Instantiate(_projectile, _playerTrans.position + Vector3.forward, Quaternion.identity);
        Spawn(temp,Owner);
       
    }*/
    
    //NetworkManager.ServerManager.Spawn();
    [ServerRpc]
    private void ServerMaterialiseRequest()
    {
        GameObject temp = Instantiate(_projectile, _playerTrans.position + Vector3.forward, Quaternion.identity);
        if (temp == null)
            Debug.Log("bullet not found");
        else
            base.Spawn(temp,base.Owner);
       
    }
    
    
}
