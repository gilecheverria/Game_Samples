/*
Simple noice generator

From:
https://www.gamedeveloper.com/audio/procedural-audio-in-unity
*/

using UnityEngine;

public class MakeNoise : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float offset;
    
    System.Random rand = new System.Random();
    
    void OnAudioFilterRead(float[] data, int channels) {
        for (int i = 0; i < data.Length; i++) {
            data[i] = (float)(rand.NextDouble() * 2.0 - 1.0 + offset);
        }
    }
}