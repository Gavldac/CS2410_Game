using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public GameObject portal, shadow, platform;
    public int sceneIndex;
    [SerializeField] public int keyAmount;
    public static int keys;
    // Start is called before the first frame update
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(keys >= 3)
        {
            portal.SetActive(true);
            shadow.SetActive(true);
            platform.SetActive(true);
        }
        if(keys == 0)
        {
            portal.SetActive(false);
            shadow.SetActive(true);
            platform.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
            
            Debug.Log(SceneManager.GetActiveScene().ToString());
            SceneManager.LoadScene(sceneIndex+1);
    }
}
