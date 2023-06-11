using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nucleus : MonoBehaviour
{
    GameManager gm;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        gm = FindObjectOfType<GameManager>();

        // Randomly choose whether the nucleus starts on the top or the bottom
        int startPosition = Random.Range(0, 2);

        if (startPosition == 0)
            transform.position = new Vector3(-4, 0, 0);
        else
            transform.position = new Vector3(-4, -2, 0);


        // Set speed of nucleus proportional to time limit
        speed = 9f / gm.time * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed, 0, 0);

        if (transform.position.x >= 4)
            gm.Win();
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
