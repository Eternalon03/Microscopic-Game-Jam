using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ActivateViruses : MonoBehaviour
{
    public GameObject[] viruses;
    GameManager gm;
    public TextMeshProUGUI label;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < 4; ++i)
            viruses[i].SetActive(true);

        gm.loseOnTimer = true;
        label.text = "Shoot the viruses!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
