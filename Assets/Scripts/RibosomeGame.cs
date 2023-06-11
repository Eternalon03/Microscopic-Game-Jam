using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RibosomeGame : MonoBehaviour
{
    Transform spawnPoint;
    GameObject player;

    int spawnNum;
    public float[] startPositions;
    public Transform[] spawns;

    public float speed;

    GameObject obj;

    private void Start()
    {
        spawnPoint = transform.Find("Game Obj/Spawn Point");
        player = transform.Find("Player Cell").gameObject;

        obj = transform.Find("Game Obj").gameObject;

        spawnNum = 0;
        spawnPoint = spawns[0];
        obj.transform.localPosition = new Vector3(0, startPositions[0], 0);
        player.transform.position = spawnPoint.position;
    }

    private void FixedUpdate()
    {
        obj.transform.position += new Vector3(0, -speed, 0);
    }

    void ChooseSpawnPoint() {
        int newIndex = spawnNum;
        if (startPositions.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            while (newIndex == spawnNum)
            {
                newIndex = Random.Range(0, startPositions.Length);
            }
        }

        spawnNum = newIndex;
    }

    private void OnEnable()
    {
        FindObjectOfType<GameManager>().loseOnTimer = false;
        ChooseSpawnPoint();
        spawnPoint = spawns[spawnNum];
        obj.transform.localPosition = new Vector3(0, startPositions[spawnNum], 0);
        player.transform.position = spawnPoint.position;
    }
}
