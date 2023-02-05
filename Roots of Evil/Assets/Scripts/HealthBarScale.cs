using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScale : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private float barScale;
    private RectTransform bar;
    


    // Start is called before the first frame update
    void Awake()
    {
        bar = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        barScale = (playerHealth.currentHealth / playerHealth.MaxHealth) * 1000;
        bar.sizeDelta = new Vector2(barScale, 10);
    }
}
