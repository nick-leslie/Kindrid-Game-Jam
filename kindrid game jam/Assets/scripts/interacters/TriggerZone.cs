using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private bool disableAfterUse;
    private bool used;
    //----------------------- levle things
    [Header("levle swap things")]
    [SerializeField]
    private bool ChangeLevle;
    private sceneManiger SceneManiger;
    //----------------------- cinima things
    [SerializeField]
    [Header("camera things")]
    private cameraControler cammraControler;
    [SerializeField]
    private bool TrigerCinima;
    [SerializeField]
    private bool ChangeFOV;
    [SerializeField]
    private Transform CinimaTarget;
    [SerializeField]
    private int FOVMod;
    [SerializeField]
    private float FOVLerpTime;
    [SerializeField]
    private float timeHeld;
    //---------------------- Player
    [Header("Player things")]
    [SerializeField]
    private GameObject player;
    private HealthManiger healthManiger;
    //flags
    [SerializeField]
    private bool KillPlayer;
    [SerializeField]
    private bool dammagePlayer;
    [SerializeField]
    private bool healPlayer;
    [SerializeField]
    private bool changePos;
    //values
    [SerializeField]
    private int DammageAmount;
    [SerializeField]
    private int HealAmount;
    [SerializeField]
    private Transform newPos;
    //------------------------sound stuff
    [SerializeField]
    [Header("BackgroundSound stuff")]
    private audioManiger aManiger;
    [SerializeField]
    private bool ChangeBackgroundJam;
    [SerializeField]
    private bool NextBackgroundJam;
    [SerializeField]
    private string JamName;

    [Header("sfx stuff")]
    [SerializeField]
    private bool triggerSFX;
    [SerializeField]
    private string[] SFXNames;
    private void Start()
    {
        SceneManiger = GameObject.FindGameObjectWithTag("SceneManiger").GetComponent<sceneManiger>();
        cammraControler = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<cameraControler>();
        player = GameObject.FindGameObjectWithTag("Player");
        healthManiger = player.GetComponent<HealthManiger>();
        aManiger = GameObject.FindGameObjectWithTag("audioManiger").GetComponent<audioManiger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if (used == false)
            {
                if (ChangeLevle == true)
                {
                    SceneManiger.LoadNextLevle();
                    return;
                }
                if (KillPlayer)
                {
                    healthManiger.death();
                    return;
                }
                if (TrigerCinima == true)
                {
                    if (ChangeFOV != true)
                    {
                        cammraControler.MoveCamera(CinimaTarget, timeHeld);
                    } else
                    {
                        cammraControler.MoveCamera(CinimaTarget, timeHeld, FOVMod, FOVLerpTime);
                        
                    }
                }
                if(dammagePlayer)
                {
                    healthManiger.DealDamage(DammageAmount);
                }
                if(healPlayer)
                {
                    healthManiger.Heal(HealAmount);
                }
                if(changePos)
                {
                    player.transform.position = newPos.position;
                }
                if(ChangeBackgroundJam == true)
                {
                    if(NextBackgroundJam == true)
                    {
                        aManiger.PlayNextBackground();
                    } else
                    {
                        aManiger.PlayBackgroundSong(JamName);
                    }
                }
                if(triggerSFX)
                {
                    for(int i=0;i<SFXNames.Length;i++)
                    {
                        aManiger.PlaySfx(SFXNames[i]);
                    }
                }
                if(disableAfterUse == true)
                {
                    used = true;
                }
            }
        }
    }
}
