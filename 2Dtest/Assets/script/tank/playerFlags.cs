using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlags : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject shootNomTex;

    [SerializeField]
    private GameObject shootTex;

    [SerializeField]
    private GameObject driveNomTex;

    [SerializeField]
    private GameObject driveTex;

    private playercontroler PC;


    void Start()
    {
        PC = GetComponent<playercontroler>();
        shootTex.SetActive(false);
        driveNomTex.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PC.shootMode == false)
        {
            shootTex.SetActive(false); 
            driveNomTex.SetActive(false);
            shootNomTex.SetActive(true); 
            driveTex.SetActive(true);
        }
        else
        {
            shootTex.SetActive(true);
            driveNomTex.SetActive(true);
            shootNomTex.SetActive(false);
            driveTex.SetActive(false);
        }
    }
}
