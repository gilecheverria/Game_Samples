/*
Produce sounds when the dot hits an obstacle
Alternate between two sounds

Gilberto Echeverria
2024-02-26
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;

    AudioSource source;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        source.clip = sounds[index++];
        source.Play();
        index %= sounds.Length;
    }
}
