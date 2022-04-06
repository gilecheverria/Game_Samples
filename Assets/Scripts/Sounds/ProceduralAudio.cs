//By Benjamin Outram
//C# script for use in Unity 

// create a new file and copy paste this.  Name the file:
// ProceduralAudio.cs
// attach script to a GameObject that has an AudioSource on it.
// adjust the public variables to experiment.

using UnityEngine;

[RequireComponent(typeof(AudioLowPassFilter))]
public class ProceduralAudio : MonoBehaviour
{
    private float sampling_frequency = 48000;

    [Range(0f, 1f)]
    public float noiseRatio = 0.5f;

    //for noise part
    [Range(-1f, 1f)]
    public float offset;

    public float cutoffOn = 800;
    public float cutoffOff = 100;

    public bool cutOff;
    
    //for tonal part
    public float frequency = 440f;
    public float gain = 0.05f;

    private float increment;
    private float phase;

    System.Random rand = new System.Random();
    AudioLowPassFilter lowPassFilter;

    void Awake()
    {
        sampling_frequency = AudioSettings.outputSampleRate;

        lowPassFilter = GetComponent<AudioLowPassFilter>();
        Update();
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        float tonalPart = 0;
        float noisePart = 0;

        // update increment in case frequency has changed
        increment = frequency * 2f * Mathf.PI / sampling_frequency;

        for (int i = 0; i < data.Length; i++)
        {
            //noise
            noisePart = noiseRatio * (float)(rand.NextDouble() * 2.0 - 1.0 + offset);

            phase = phase + increment;
            if (phase > 2 * Mathf.PI) phase = 0;

            //tone
            tonalPart = (1f - noiseRatio) * (float)(gain * Mathf.Sin(phase));

            //together
            data[i] = noisePart + tonalPart;

            // if we have stereo, we copy the mono data to each channel
            if (channels == 2)
            {
                data[i + 1] = data[i];
                i++;
            }
        }
    }

    void Update()
    {
        lowPassFilter.cutoffFrequency = cutOff ? cutoffOn : cutoffOff;
    }
}