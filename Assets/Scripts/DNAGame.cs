using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNAGame : MonoBehaviour
{
    GameManager gm;
    GameObject player;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        foreach (GameObject g in DNAgameObjects) {
            g.SetActive(false);
        }
        player = transform.Find("Player Cell").gameObject;

    }

    public GameObject[] DNAgameObjects;
    int currentIndex = 0;

    void PickLevel() {
        DNAgameObjects[currentIndex].SetActive(false);

        //generate random number != current game index
        int newIndex = currentIndex;
        if (DNAgameObjects.Length == 1)
        {
            newIndex = 0;
        }
        else
        {
            while (newIndex == currentIndex)
            {
                newIndex = Random.Range(0, DNAgameObjects.Length);
            }
        }

        //activate new scene, update build index
        DNAgameObjects[newIndex].SetActive(true);
        currentIndex = newIndex;
    }

    
    private void OnEnable()
    {
        PickLevel();
        player.transform.position = DNAgameObjects[currentIndex].transform.Find("Spawn").gameObject.transform.position;

    }

    public void Win() {
        gm.Win();
    }
}
