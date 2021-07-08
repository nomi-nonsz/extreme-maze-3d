using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollision : MonoBehaviour
{
    public ParticleSystem getCoinParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            Destroy();
        }
    }

    public void Destroy()
    {
        Instantiate(getCoinParticle, transform.position, Quaternion.Euler(-90, 0, 0));

        Destroy(gameObject);
    }
}
