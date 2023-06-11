using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateViruses : MonoBehaviour
{
    public GameObject[] viruses;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        for (int i = 0; i < 4; ++i)
            viruses[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
