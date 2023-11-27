using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPointScript : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        NextScene();
    }
    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Test");
    }
    
}
