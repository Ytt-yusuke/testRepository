using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bossStageChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += UnloadScene;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameObject.scene.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(("BossScene"), LoadSceneMode.Additive);
        }

        Debug.Log(collision.gameObject.name);
    }
    void UnloadScene(Scene nextScene, LoadSceneMode mode)
    {
        if (nextScene == SceneManager.GetSceneByName("BossScene"))
        {
            SceneManager.UnloadSceneAsync(("NormalScene"), UnloadSceneOptions.None);
        }
    }
}
