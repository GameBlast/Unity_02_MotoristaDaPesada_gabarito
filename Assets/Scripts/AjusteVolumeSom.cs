using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjusteVolumeSom : MonoBehaviour
{
    float volumeInicial;

    // Start is called before the first frame update
    void Start()
    {
        volumeInicial = gameObject.GetComponent<AudioSource>().volume;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = volumeInicial * Time.timeScale;
    }
}
