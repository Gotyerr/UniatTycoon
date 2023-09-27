using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Manager : MonoBehaviour
{


    //publicas

    public Text resourceText;

    //privadas

    private float currentResources;

    // Start is called before the first frame update
    void Start()
    {
        currentResources = 0f;
        UpdateUI();

    }

    public void AddResources(float _value)
    {
        currentResources += _value;
        UpdateUI();
    }
    public void RemoveResources(float _value)
    {
        currentResources -= _value;
        UpdateUI();

    }


    public float CurrentResources()
    {
        return currentResources;
    }


    public void UpdateUI()
    {
        resourceText.text = "Piedra Preciosa $" + currentResources;
    }
}
