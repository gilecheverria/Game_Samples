/*
Script to invoke the actions using keyboard presses

Gilberto Echeverria
2023-20-02
*/

using UnityEngine;

public class XActionControl : MonoBehaviour
{
    XActions xActions;

    // Start is called before the first frame update
    void Start()
    {
        xActions = GetComponent<XActions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)) {
            xActions.Fire();
        } else if (Input.GetKeyDown(KeyCode.W)) {
            xActions.Damage();
        } else if (Input.GetKeyDown(KeyCode.E)) {
            xActions.Celebrate();
        }
    }
}
