using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public int virusesLeft = 4;

    public GameObject bulletPrefab;

    public GameObject player;
    // Start is called before the first frame update
    void OnEnable()
    {
        virusesLeft = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            transform.rotation = Quaternion.identity;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 0, 270);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 0, 180);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.identity;
            transform.Rotate(0, 0, 90);
        }
    }
}
