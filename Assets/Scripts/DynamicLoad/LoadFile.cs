/*
Test for dinamically loading and configuring objects in a scene
from data specified in a CSV file

References:
https://forum.unity.com/threads/how-to-read-a-dataset-from-a-csv.858814/
https://docs.unity3d.com/ScriptReference/Resources.Load.html

Gilberto Echeverria
2021-03-26
*/

using UnityEngine;

public class LoadFile : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    Vector3 position;
    GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        //Load a text file (Assets/Resources/Text/positions.csv)
        var textFile = Resources.Load<TextAsset>("Text/positions"); 
        var dataLines = textFile.text.Split('\n'); // Split also works with simple arguments
 
        for(int i = 0; i < dataLines.Length; i++) {
            // Get the corrdinates for the object
            var data = dataLines[i].Split(',');
            float.TryParse(data[1], out position.x);
            float.TryParse(data[2], out position.y);
            position.z = 0.0f;
            // Create the object instance
            instance = Instantiate(prefab, position, Quaternion.identity);

            // Change the sprite of the instance
            var sprite = Resources.Load<Sprite>(data[0]);
            instance.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        }
    }
}
