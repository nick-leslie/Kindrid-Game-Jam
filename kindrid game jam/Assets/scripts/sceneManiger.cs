using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManiger : MonoBehaviour
{
    public const int NEVER_UNLOAD = 0;
    private GameObject player;
    private GameObject MainCammra;
    public bool gamer = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        MainCammra = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(gamer == true)
        {
            LoadNextLevle(gameObject.transform);
            gamer = false;
        }
    }
    public void LoadNextLevle(Transform startPostion)
    {
        swapScene(SceneManager.GetActiveScene().buildIndex + 1, true, startPostion);
    }
    private void swapScene(int loadSceneNumber, bool unload, Transform SpawnPostion)
    {
        //adds all scenes to an array this may be bad for preformence but its not as bad as it us to be
        Scene[] ActiveScenes = new Scene[SceneManager.sceneCount];
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            ActiveScenes[i] = SceneManager.GetSceneAt(i);
        }
        if (unload == true)
        {
            //moves player into the never unload scene so that the player dose not get yoot
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(0));
            SceneManager.MoveGameObjectToScene(MainCammra, SceneManager.GetSceneByBuildIndex(0));
            for (int i = 0; i < SceneManager.sceneCount-1; i++)
            {
                if (ActiveScenes[i].buildIndex != 0)
                {
                    StartCoroutine(unLoadScene(ActiveScenes[i].buildIndex));
                }
            }
        }
        SceneManager.LoadSceneAsync(loadSceneNumber, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(loadSceneNumber));
        SceneManager.MoveGameObjectToScene(MainCammra, SceneManager.GetSceneByBuildIndex(loadSceneNumber));
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    IEnumerator unLoadScene(int sence)
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        yield return null;
        SceneManager.UnloadSceneAsync(sence);

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
