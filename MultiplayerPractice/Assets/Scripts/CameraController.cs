using Cinemachine;
using FishNet.Managing;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void OnEnable()
    {
        FirstObjectNotifier.OnFirstObjectSpawned += FirstObjectNotifier_OnFirstObjectSpawned;
        
    }
    
    private void OnDisable()
    {
        FirstObjectNotifier.OnFirstObjectSpawned -= FirstObjectNotifier_OnFirstObjectSpawned;
    }

    private void FirstObjectNotifier_OnFirstObjectSpawned(Transform obj)
    {
        /*Camera c = Camera.main;*/
        CinemachineVirtualCamera vc = GetComponent<CinemachineVirtualCamera>();
        vc.Follow = obj;
        vc.LookAt = obj.transform;
    }
    
}
