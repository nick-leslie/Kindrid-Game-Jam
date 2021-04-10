using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManiger : MonoBehaviour
{
    public bool GameIsPaused=false;
    [SerializeField]
    private GameObject PausedUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused==true)
            {
                unPause();
            } else
            {
                Pause();
            }
        }   
    }
    public void unPause()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PausedUI.SetActive(false);
    }
    public void Pause()
    {
        PausedUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
