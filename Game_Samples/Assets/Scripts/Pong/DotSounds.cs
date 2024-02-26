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
    // A list of clips to be cicled around
    [SerializeField] AudioClip[] sounds;

    // The compoment that produces the sound
    AudioSource source;

    // Index to change the sound played each time
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Configure with a sound from the list
        source.clip = sounds[index++];
        source.Play();
        // Loop around the sounds
        index %= sounds.Length;
    }
}