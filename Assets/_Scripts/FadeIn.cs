using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public float fadeInSpeed = 1f;
    private Image imageComponent;
    private Color currentColor;

    void Start()
    {
        gameObject.SetActive(true);
        imageComponent = GetComponent<Image>();
        currentColor = Color.black;
    }

    void Update()
    {
        currentColor.a -= Time.deltaTime * fadeInSpeed;
        imageComponent.color = currentColor;
        if (currentColor.a <= 0)
            gameObject.SetActive(false);
    }
}