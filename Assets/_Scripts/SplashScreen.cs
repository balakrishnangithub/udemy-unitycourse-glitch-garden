using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SplashScreen : MonoBehaviour
{
    public float unfillSpeed = 7f;
    public float fillSpeed = 5f;

    private bool startFlag;

    private GameObject levelManager;
    private Image imageComponent;

    void Start()
    {
        levelManager = GameObject.Find("Level Manager") as GameObject;
        imageComponent = GameObject.Find("Splash Image").GetComponent<Image>();
        imageComponent.fillAmount = 0;
        imageComponent.fillMethod = Image.FillMethod.Radial360;
    }

    void Update()
    {
        if (startFlag)
        {
            imageComponent.fillAmount -= unfillSpeed * Time.deltaTime;
            if (imageComponent.fillAmount <= 0)
                levelManager.GetComponent<LevelManager>().LoadLevel("Start");
        }
        else
        {
            imageComponent.fillAmount += fillSpeed * Time.deltaTime;
            if (imageComponent.fillAmount >= 1 && !IsInvoking("SetStartFlag"))
            {
                imageComponent.fillMethod = Image.FillMethod.Vertical;
                Invoke("SetStartFlag", 1.5f);
            }
        }
    }

    void SetStartFlag()
    {
        startFlag = true;
    }
}