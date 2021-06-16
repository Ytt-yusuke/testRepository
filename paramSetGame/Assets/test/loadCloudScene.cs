using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadCloudScene : MonoBehaviour
{
    private AsyncOperation async;

    public GameObject loadingUI;

    public Slider loadSlider;

    private GameObject playerObj;
    private GameObject alliesObj;

    private Scene baseScene;

    private int loadCount;

    public int doorNum;

    private bool playerSet;
    private bool alliesSet;

    //normalが0,cloudが1,spaceが2
    // Start is called before the first frame update
    void Start()
    {
        loadingUI.SetActive(false);
        playerSet = false;
        alliesSet = false;
        baseScene = SceneManager.GetSceneByName("BaseScene");
        foreach(var rootGameObject in baseScene.GetRootGameObjects())
        {
            if(rootGameObject.CompareTag("Player"))
            {
                playerObj = rootGameObject;
                playerSet = true;
            }

            if(rootGameObject.name == "Allies")
            {
                alliesObj = rootGameObject;
                alliesSet = true;
            }

            if(playerSet == true && alliesSet == true)
            {
                break;
            }
        }
        SceneManager.sceneLoaded += UnloadScene;
        loadCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObj.transform.position.y > 20 && gameObject.scene == SceneManager.GetSceneByName("NormalScene"))
        {
            if (loadCount == 0)
            {
                LoadNextScene(1);
                loadCount++;
                playerObj.transform.position = new Vector3(transform.position.x, -5, 0);
            }
        }
        else if (playerObj.transform.position.y < -10 && gameObject.scene == SceneManager.GetSceneByName("CloudScene"))
        {
            if (loadCount == 0)
            {
                LoadNextScene(0);
                loadCount++;
                playerObj.transform.position = new Vector3(transform.position.x, 10, 0);
            }
        }
        Debug.Log(gameObject.scene.name);
    }

    public void LoadNextScene(int puttern)
    {
        loadingUI.SetActive(true);
        StartCoroutine(LoadScene(puttern));
    }

    IEnumerator LoadScene(int puttern)
    {
        switch (puttern)
        {
            case 0:
                async = SceneManager.LoadSceneAsync(("NormalScene"), LoadSceneMode.Additive);
                break;

            case 1:
                async = SceneManager.LoadSceneAsync(("CloudScene"), LoadSceneMode.Additive);
                break;

            case 2:
                async = SceneManager.LoadSceneAsync(("BossScene"), LoadSceneMode.Additive);
                break;
        }

        while(async.progress <= 0.9f)
        {
            loadSlider.value = async.progress;
            yield return null;
        }
    }

    void UnloadScene(Scene nextScene, LoadSceneMode mode)
    {
        if (nextScene == SceneManager.GetSceneByName("NormalScene"))
        {
            SceneManager.UnloadSceneAsync(("CloudScene"), UnloadSceneOptions.None);
        }
        else if (nextScene == SceneManager.GetSceneByName("CloudScene"))
        {
            SceneManager.UnloadSceneAsync(("NormalScene"), UnloadSceneOptions.None);
        }
        else if(nextScene == SceneManager.GetSceneByName("BossScene"))
        {
            SceneManager.UnloadSceneAsync(("NormalScene"), UnloadSceneOptions.None);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && gameObject.CompareTag("Door"))
        {
            switch(doorNum)
            {
                case 1:
                    playerObj.transform.position = Vector3.zero;
                    
                    for(int i = 0; i < alliesObj.transform.childCount; i++)
                    {
                        alliesObj.transform.GetChild(i).transform.position = playerObj.transform.position;
                    }
                    LoadNextScene(2);
                    break;
            }
        }
    }
}
