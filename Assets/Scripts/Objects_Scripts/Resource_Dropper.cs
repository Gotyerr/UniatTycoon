using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Dropper : MonoBehaviour
{

    public GameObject[] resources;
    public float spawnTime;

    private int dropperTier;
    private bool isActive;


    // Start is called before the first frame update
    void Start()
    {
        dropperTier = 1;
        isActive = true;
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void DropResource()
    {
        if(resources[dropperTier - 1] != null)
        {

            Instantiate(resources[dropperTier - 1], transform.position, Quaternion.identity);

        
        
        }
    }

    public void ChangeState(bool _state)
    {
        isActive = _state;
        if (isActive)
        {

            StartCoroutine(SpawnCoroutine());

        }
    }

    public void UpgradeDropper()
    {
        if (dropperTier +1 <= resources.Length)
        {
            dropperTier++;

        }
    }

    IEnumerator SpawnCoroutine()
    {

        yield return new WaitForSeconds(spawnTime);
        DropResource();
        if (isActive)
            {

            StartCoroutine(SpawnCoroutine());

            }



    }
}
