using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Upgrader : MonoBehaviour
{

    public Resource_Manager resourceManager;
    public float cost;
    public string text;

    public UnityEvent onActivated;


    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = text + "$" + cost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
          
            if  (resourceManager.CurrentResources() >= cost)
            {
                resourceManager.RemoveResources(cost);
                onActivated.Invoke();
                Destroy(gameObject);

            }
        }
    }
}
