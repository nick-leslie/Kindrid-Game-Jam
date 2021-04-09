using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManiger : MonoBehaviour
{
    public const int NEVER_UNLOAD = 0;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject MainCammra;
    [SerializeField]
    private bool NextLevle = true;
    private audioManiger aManiger;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MainCammra = GameObject.FindGameObjectWithTag("MainCamera");
        aManiger = GameObject.FindGameObjectWithTag("audioManiger").GetComponent<audioManiger>();
    }

    // Update is called once per frame
    void Update()
    {
        if(NextLevle == true)
        {
            swapScene(SceneManager.GetActiveScene().buildIndex + 1, false);
            NextLevle = false;
        }
    }
    public void LoadNextLevle()
    {
       swapScene(SceneManager.GetActiveScene().buildIndex + 1, true);
    }
    private void swapScene(int loadSceneNumber, bool unload)
    {
        //adds all scenes to an array this may be bad for preformence but its not as bad as it us to be
        Scene[] ActiveScenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            ActiveScenes[i] = SceneManager.GetSceneAt(i);
        }
        if (unload == true)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                if (ActiveScenes[i].buildIndex != 0)
                {
                    StartCoroutine(unLoadScene(ActiveScenes[i].buildIndex));
                }
            }
        }
        SceneManager.LoadSceneAsync(loadSceneNumber, LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    IEnumerator unLoadScene(int sence)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        yield return null;
        SceneManager.UnloadSceneAsync(sence);

    }
    IEnumerator MovePlayer()
    {
        //Debug.Log("being called");
        yield return null;
        Transform spawnPos = GameObject.FindGameObjectWithTag("PlayerSpawnPos").transform;
        player.GetComponent<HealthManiger>().changeSpawn(spawnPos);
        player.transform.position = spawnPos.position;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        StartCoroutine(MovePlayer());
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    public void ReloadLvl()
    {
        //MainCammra.GetComponent<>
        swapScene(SceneManager.GetActiveScene().buildIndex, true);
        aManiger.CurrentBackground -= 1;
    }
}
