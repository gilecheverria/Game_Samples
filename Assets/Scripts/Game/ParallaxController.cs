/*
Replicate the background images and move them as the camera moves
Also add parallax effect to multiple background layers

Based on the tutorial and code at:
https://www.youtube.com/watch?v=Mp6BWCMJZH4&list=RDCMUCe45-2uomTfrnGZwJcATeUA&index=2
https://pressstart.vip/tutorials/2019/05/1/94/parallax-effect-in-unity.html

Gilberto Echeverria
2021-04-04
*/

using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] GameObject[] bgLayers;
    [SerializeField] Camera mainCamera;
    // GEF: Use the transform of the virtual Cinemachine camera
    [SerializeField] Transform cameraTransform;
    [SerializeField] float margin;

    Vector2 screenBounds;
    Vector3 lastCameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera = Camera.main;
        // Determine the viewable space as determined by the camera
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        // Replicate background images
        foreach (GameObject obj in bgLayers) {
            DuplicateImages(obj);
        }
        // Store the initial camera position
        lastCameraPosition = cameraTransform.position;
    }

    // Create a hierarchical structure for each image in the background
    // Each image is duplicated to fill the space of the camera
    void DuplicateImages(GameObject obj)
    {
        float imageWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - margin;
        // Determine the number of copies of the image to cover the screen twice over
        int copiesNeeded = Mathf.CeilToInt(screenBounds.x * 3 / imageWidth);
        // Make a copy of the original image object
        GameObject clone = Instantiate(obj);
        // Create further copies and make them a child of the object
        for (int i=0; i<copiesNeeded; i++) {
            GameObject instance = Instantiate(clone);
            instance.transform.parent = obj.transform;
            // Move the images a bit back so that they always cover the full screen space
            instance.transform.position = new Vector3(imageWidth * (i - 0.5f), obj.transform.position.y, obj.transform.position.z);
            instance.name = obj.name + i;
        }
        // Cleanup
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
        //Destroy(obj.GetComponent<Collider2D>());
    }

    // Move the child images when they are no longer visible
    void RepositionChildImages(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1) {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfImageWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - margin;
            // Detect when an image needs to be moved
            if (cameraTransform.position.x + screenBounds.x > lastChild.transform.position.x + halfImageWidth) {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfImageWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (cameraTransform.position.x - screenBounds.x < firstChild.transform.position.x - halfImageWidth) {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfImageWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }

    void LateUpdate()
    {
        foreach (GameObject obj in bgLayers) {
            RepositionChildImages(obj);
            // GEF: Modified the formula to use smaller values in Z for the layers
            float parallaxSpeed = 1 - Mathf.Clamp01(1 / obj.transform.position.z);
            //float parallaxSpeed = 1 - Mathf.Clamp01(Mathf.Abs(transform.position.z / obj.transform.position.z));
            float difference = cameraTransform.position.x - lastCameraPosition.x;
            obj.transform.Translate(Vector3.right * difference * parallaxSpeed);
        }
        lastCameraPosition = cameraTransform.position;
    }
}
