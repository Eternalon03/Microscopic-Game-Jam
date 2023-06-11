using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVirusScript : MonoBehaviour
{
    GameManager gm;

    public GameObject player;
    float speed;
    float startTime;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        gm.loseOnTimer = true;
    }
    

    private void OnEnable()
    {
        player.transform.localPosition = new Vector3(4.92f, -3.33f, 0.0f);
        // // This game is a win when the timer runs out
        // // Randomly choose whether the nucleus starts on the top or the bottom
        // int startPosition = Random.Range(0, 2);

        // if (startPosition == 0)
        //     transform.position = new Vector3(-4, 0, 0);
        // else
        //     transform.position = new Vector3(-4, -2, 0);


        // // Set speed of nucleus proportional to time limit
        // speed = 20f / gm.time * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        // transform.position += new Vector3(speed, 0, 0);

        // if (transform.position.x > 4 || transform.position.x < -4)
        //     speed *= -1;
    }

    

    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(speed, 0, 0);
    }
}
