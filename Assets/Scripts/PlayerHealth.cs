using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    
    public RectTransform valueRectTransform;

    private float _maxValue;

    public GameObject gameplayUI;
    public GameObject gameOverScreen;

    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }
    
    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            PlayerIsDeaD();
        }
        
        DrawHealthBar();
    }

    void Update()
    {
        
    }

    private void DrawHealthBar()
    {
        valueRectTransform.anchorMax = new Vector2(value / _maxValue,1);
    }
    private void PlayerIsDeaD()
    {
        gameplayUI.SetActive(false);
        gameOverScreen.SetActive(true);
        GetComponent<PlayerController>().enabled = false;
        GetComponent<FireballCaster>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
    }

}

