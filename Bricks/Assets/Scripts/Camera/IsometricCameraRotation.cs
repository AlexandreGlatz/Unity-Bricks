using UnityEngine;

public class IsometricCameraRotation : MonoBehaviour
{
    [SerializeField] float _rotationSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)) 
        {
            float mouseDeltaX = Input.GetAxis("Mouse X");

            transform.Rotate(Vector3.up, mouseDeltaX * _rotationSpeed * Time.deltaTime);

        }
    }
}
