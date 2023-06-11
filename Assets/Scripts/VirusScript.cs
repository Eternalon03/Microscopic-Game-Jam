using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusScript : MonoBehaviour
{

    GameManager gm;
    float speed;
    float startTime;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        gm.loseOnTimer = true;
        
    }

    private void OnEnable()
    {
        float x = Random.Range(-5.79f, 5.39f);
        float y = Random.Range(-4.01f, 2.01f);
        if(x > 3.11f) {
            y = Random.Range(-0.67f, 2.01f);
        }
        float z = 0.0f;
        Vector3 pos = new Vector3(x, y, z);
        transform.position = pos; 
        
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player Cell"))
            gm.Win();
    }
}
