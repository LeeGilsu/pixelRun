using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    public  GameObject burst;
    public Transform boomPos;
    AudioManager sfxSound;

    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        sfxSound = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void boomBurst()
    {
        //sfxSound.PlaySFX("Hummer");

        audio.Play();
        Instantiate(burst, boomPos.transform.position, Quaternion.identity);
   
    }
}
