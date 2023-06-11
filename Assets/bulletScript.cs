using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public GameObject player;

    public GameObject playerGun;
    public float speed = 2;

    public Rigidbody2D rb;

    Vector3 velocityBullet;

    int justMade = 0;

    void Start() 
    {
        velocityBullet = playerGun.transform.position - player.transform.position;
    }

    void Update() 
    {

        if(justMade == 0) {
            justMade = 1;
            transform.rotation = player.transform.rotation;
        }

        transform.position += this.transform.position * Time.deltaTime;

        if(gameObject.name == "Bullet(Clone)"){
            Destroy(gameObject, 3);
        }
    }
}


