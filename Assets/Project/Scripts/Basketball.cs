using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : MonoBehaviour
{
    private GameObject trailObject;

    // Start is called before the first frame update
    void Start()
    {
        trailObject = GameObject.Find("Trail Particle");
        trailObject.SetActive(false); // Deactivate the object to start
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTrail()
    {
        trailObject.SetActive(true);
    }

    public void DeactivateTrail()
    {
        trailObject.SetActive(false);
    }
}
