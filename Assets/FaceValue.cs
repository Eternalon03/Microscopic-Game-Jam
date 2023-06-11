using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceValue : MonoBehaviour
{

    void Update()
{
    if (Input.GetKeyDown(KeyCode.DownArrow))
        {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }  

    if (Input.GetKeyDown(KeyCode.LeftArrow))
    {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }    

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
    }  

    if (Input.GetKeyDown(KeyCode.RightArrow))
    {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
    }  

}
}

