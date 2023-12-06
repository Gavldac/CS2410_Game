using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject Key1, Key2, Key3, gameOver;
    public GameObject HUDKey1, HUDKey2, HUDKey3;
    public List<GameObject> KeyList; 
    public List<GameObject> HUDKeyList;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        HUDKeyList = new List<GameObject> { HUDKey1,HUDKey2,HUDKey3 };
        KeyList = new List<GameObject> { Key1, Key2, Key3 };

       foreach(GameObject HUDKey in HUDKeyList)
        {
            HUDKey.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver.activeSelf == true)
        {
            index = 0;
            foreach(GameObject key in HUDKeyList)
            {
                key.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            KeyCanvasScript.key.Add(KeyList[index]);
            KeyList[index].SetActive(false);
            PortalScript.keys += 1;
            HUDKeyList[index].SetActive(true);
            index++;
        }
    }
}
