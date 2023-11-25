using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gulping : MonoBehaviour
{
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine("PlaySound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(0.5f);
        source.Play();
        yield return new WaitForSeconds(0.5f);
        source.Play();
        yield return new WaitForSeconds(0.4f);
        source.Play();
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("IDCardView");
    }
}
