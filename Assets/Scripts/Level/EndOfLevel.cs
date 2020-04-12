using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    public DarknessController darkness;
    public Transform SpawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            
                
                
            //darkness.SetDarkness();
                
            
            //else
            //{
                int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
                if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
                else
                {
                    Debug.Log("There's no next available scene in the build settings. Do you want to add this?", this);
                }
            //}
        }
    }
}
