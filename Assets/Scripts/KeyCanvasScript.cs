using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyCanvasScript : MonoBehaviour
{
    public GameObject gameOver;
    public static List<GameObject> key;
    // Start is called before the first frame update
    void Start()
    {
        key = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeSelf == true)
        {
            foreach(GameObject item in key)
            {
                item.SetActive(true);
            }
            PortalScript.keys = 0;
        }
    }
}
