using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] List<AudioClip> sounds;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 7 || collision.gameObject.layer == 6)
        {
            int i = Random.Range(0, sounds.Count);
            audioSource.PlayOneShot(sounds[i]);
        }
    }
}
