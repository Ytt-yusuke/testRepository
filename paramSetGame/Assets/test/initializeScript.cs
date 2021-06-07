using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class initializeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("NormalScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
