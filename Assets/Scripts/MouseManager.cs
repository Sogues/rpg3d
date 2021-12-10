using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventVector3 : UnityEvent<Vector3>
{
    
}

public class MouseManager : MonoBehaviour
{
    private RaycastHit hitInfo;

    public EventVector3 OnMouseClicked;

    private long frame;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetCursorTexture();
        MonseControl();
    }

    void SetCursorTexture()
    {
        if (!(Camera.main is  { }))
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo))
        {
            // 切换鼠标贴图
        }
    }

    void MonseControl()
    {
        if (Input.GetMouseButtonDown(0) && null != hitInfo.collider)
        {
            if (hitInfo.collider.gameObject.CompareTag("Plane"))
            {
                OnMouseClicked?.Invoke(hitInfo.point);
                Debug.Log($"invoke position {hitInfo.point}");
            }
        }
    }

}
