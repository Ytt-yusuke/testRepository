using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class systemScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    GlobalClock GC;

    [SerializeField]
    GameObject pauseUI;

    [SerializeField]
    GameObject resultUI;

    [SerializeField]
    GameObject EndGameUI;

    [SerializeField]
    Slider HPSlider;

    private bool pauseFlag;
    private float GCTimeScale;
    private float NumTimeScale;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        pauseUI.SetActive(false);
        resultUI.SetActive(false);
        EndGameUI.SetActive(false);
        Time.timeScale = 1;
        GC.localTimeScale = 1;
        pauseFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseFlag == false)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pauseFlag = true;
                pauseUI.SetActive(true);
                NumTimeScale = Time.timeScale;
                Time.timeScale = 0;
                GCTimeScale = GC.localTimeScale;
                GC.localTimeScale = 0;
            }
            else
            {
                Back();
            }
        }

        if(HPSlider.value == 0)
        {
            resultUI.SetActive(true);
            Time.timeScale = 0;
            GC.localTimeScale = 0;
        }

        if(resultUI.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                Retry();
            }
        }
    }

    public void Retry()
    {
        SceneManager.LoadSceneAsync("BaseScene");
    }

    public void Back()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        pauseFlag = false;
        pauseUI.SetActive(false);
        EndGameUI.SetActive(false);
        Time.timeScale = NumTimeScale;
        GC.localTimeScale = GCTimeScale;
    }

    public void EndUISet()
    {
        EndGameUI.SetActive(true);
    }

    public void EndUIRemove()
    {
        EndGameUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
