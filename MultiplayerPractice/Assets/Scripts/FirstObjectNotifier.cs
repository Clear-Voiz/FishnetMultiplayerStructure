using UnityEngine;
using System;
using FishNet.Object;

public class FirstObjectNotifier : NetworkBehaviour
{
    public static event Action<Transform> OnFirstObjectSpawned;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            NetworkObject nob = LocalConnection.FirstObject;
            if (nob == NetworkObject)
                OnFirstObjectSpawned?.Invoke(transform);
            
            Debug.Log("is this script the owner?" + Owner + "for owner" + OwnerId);
        }
    }
}
