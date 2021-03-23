/*
Generate new balls at random horizontal positions

Gilberto Echeverria
2021-02-18
*/

using UnityEngine;

public class DropBalls : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Vector2 limits;
    [SerializeField] float delay;

    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping balls after 1 second, then every 'delay' seconds
        InvokeRepeating("NewBall", 1, delay);
    }

    void NewBall()
    {
        // Generate the new random position based on the settings
        position = new Vector3(Random.Range(-limits.x, limits.x), limits.y, 0);
        Instantiate(ball, position, Quaternion.identity);
    }

    // This method will stop the generation of new balls
    public void StopBalls()
    {
        CancelInvoke();
    }
}
