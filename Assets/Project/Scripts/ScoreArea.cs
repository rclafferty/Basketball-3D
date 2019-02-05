using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    private GameObject effectObject;
    private ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        effectObject = GameObject.Find("Goal Particle System");
        particleSystem = effectObject.GetComponent<ParticleSystem>();
        particleSystem.Pause();
        // effectObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.GetComponent<Basketball>() is null))
        {
            particleSystem.Play();
            //effectObject.SetActive(true);
            //Debug.Log("Score!");
        }
    }
}
