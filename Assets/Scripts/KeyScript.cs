using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    public GameObject Key1, Key2, Key3, gameOver;
    public GameObject HUDKey1, HUDKey2, HUDKey3;
    public List<GameObject> KeyList; 
    public List<GameObject> HUDKeyList;

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

    /// <summary>
    /// Checks if the game is over every frame. If so, the HUD is reset.
    /// </summary>
     void Update()
    {
        if(gameOver.activeSelf == true)
        {
            Reset();
        }
    }

    /// <summary>
    /// Checks for a scene change. If scene has changed, the HUD is reset.
    /// </summary>
    /// <param name="scene"></param>
    /// <param name="mode"></param>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Reset();
    }

    /// <summary>
    /// Resets the area of the HUD that contains the keys
    /// </summary>
    public void Reset()
    {
        PortalScript.keys = 0;
        
        foreach (GameObject HUDKey in HUDKeyList)
        {
            HUDKey.SetActive(false);
        }
    }

    /// <summary>
    /// Handles collision of player and key. Gets name of key when collision occurs
    /// and passes to helper method.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            string keyName = collision.otherCollider.name;
            ActivateKey(keyName);
        }
    }

    /// <summary>
    /// Handles the key identification and adds key to HUD. Keeps track of key count.
    /// </summary>
    /// <param name="keyObjectName"></param>
    private void ActivateKey(string keyObjectName)
    {
        switch (keyObjectName)
        {
            case "Key1":
               
                Key1.SetActive(false);
                HUDKey1.SetActive(true);
                PortalScript.keys += 1;
                KeyCanvasScript.key.Add(Key1);
                break;

            case "Key2":
               
                Key2.SetActive(false);
                HUDKey2.SetActive(true);
                PortalScript.keys += 1;
                KeyCanvasScript.key.Add(Key2);
                break;

            case "Key3":
               
                Key3.SetActive(false);
                HUDKey3.SetActive(true);
                PortalScript.keys += 1;
                KeyCanvasScript.key.Add(Key3);
                break;

            default:
               
                break;
        }
    }
}
