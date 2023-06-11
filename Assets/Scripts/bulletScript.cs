using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject player;
    GameObject game;

    public float speed = 2;

    public Rigidbody2D rb;

    Vector3 velocityBullet;

    void Start() 
    {
        game = GameObject.Find("WhiteCellShooter");
        player = game.transform.Find("Player Cell").gameObject;

        transform.rotation = player.transform.rotation;

        if (transform.rotation.eulerAngles.z == 0)
            velocityBullet = new Vector3(-5, 0, 0);
        else if (transform.rotation.eulerAngles.z == 90)
            velocityBullet = new Vector3(0, -5, 0);
        else if (transform.rotation.eulerAngles.z == 180)
            velocityBullet = new Vector3(5, 0, 0);
        else
            velocityBullet = new Vector3(0, 5, 0);
    }

    void Update() 
    {
        transform.position += velocityBullet * Time.deltaTime;

        if(gameObject.name == "Bullet(Clone)"){
            Destroy(gameObject, 3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Virus"))
        {
            collision.gameObject.SetActive(false);
            Destroy(this.gameObject);

            Shooter shooter = FindObjectOfType<Shooter>();
            shooter.virusesLeft--;
            if (shooter.virusesLeft == 0)
            {
                shooter.virusesLeft = 4;
                GameManager gm = FindObjectOfType<GameManager>();
                gm.Win();
            }
        }
    }
}


