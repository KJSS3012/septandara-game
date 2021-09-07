using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Book : MonoBehaviour
{
    public WorldMath world;
    public int sceneActive;
    public ButtonBook[] buttonsFase;
    
    private void Start()
    {
        sceneActive = SceneManager.GetActiveScene().buildIndex;
    }

    private void UpdateScenesUnlocked()
    {
        
    }

    private void Update()
    {
        
    }

}
