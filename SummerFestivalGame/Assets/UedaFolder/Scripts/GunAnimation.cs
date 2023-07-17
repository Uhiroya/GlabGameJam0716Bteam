using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GunAnimation : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] Image _cursor;
    RectTransform _cursorTransform;
    // Start is called before the first frame update
    void Start()
    {
        _cursorTransform = _cursor.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -_camera.transform.position.z);
        _cursorTransform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //Debug.Log($"_camera.ScreenToWorldPoint(mousePosition):{_camera.ScreenToWorldPoint(mousePosition)}");
        transform.LookAt(_camera.ScreenToWorldPoint(mousePosition));
        transform.rotation *= Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y * 3f, 0);
        transform.rotation *= Quaternion.Euler(80, 0, 0);
    }
}
