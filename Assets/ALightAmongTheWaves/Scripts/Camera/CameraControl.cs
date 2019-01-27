using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera _camera;

    Vector3 previousMousePosition = new Vector3(-9999, -9999, -9999);
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _camera.transform.position += Input.mousePosition - previousMousePosition;
        }

        previousMousePosition = Input.mousePosition;

        Vector2 scrool = Input.mouseScrollDelta;

        _camera.orthographicSize += scrool.y;
    }
}
