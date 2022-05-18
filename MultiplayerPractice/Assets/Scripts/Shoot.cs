using FishNet.Object;
using UnityEngine;

public class Shoot : NetworkBehaviour
{
    private float speed;
    private float birth;
    private bool _timeToFade;

    private void Start()
    {
        speed = 5f;
        birth = Time.unscaledTime;


    }

    private void Update()
    {
        if (IsOwner)
        {
            transform.Translate(speed * Time.deltaTime * transform.forward);
            if (!_timeToFade && Time.unscaledTime >= birth + 3f)
            {
                _timeToFade = true;
                Destroyer();
            }

        }

        //if (Time.unscaledTime >= birth + 3f)
            
                /*if (IsServer)
                {
                    ServerManager.Despawn(gameObject);
                }*/
                //Destroyer();
    }

    [ServerRpc]
    private void Destroyer()
    {
        ServerManager.Despawn(base.gameObject);
        //Destroy(gameObject);
    }
}
