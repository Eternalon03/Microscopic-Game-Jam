using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Nucleus : MonoBehaviour
{
    GameManager gm;
    float speed;
    public TextMeshProUGUI label;
    public GameObject player;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        // This game is a win when the timer runs out
        gm.loseOnTimer = false;

        // Randomly choose whether the nucleus starts on the top or the bottom
        int startPosition = Random.Range(0, 2);

        if (startPosition == 0)
            transform.position = new Vector3(-4, 0, 0);
        else
            transform.position = new Vector3(-4, -2, 0);


        // Set speed of nucleus proportional to time limit
        speed = 20f / gm.time * Time.fixedDeltaTime;

        // Set label
        label.text = "Dodge the Nucleus Bomb!";

        player.transform.position = new Vector3(4, -1, 0);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0);

        if (transform.position.x > 4 || transform.position.x < -4)
            speed *= -1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player Cell"))
            gm.Loss();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(speed, 0, 0);
    }
}