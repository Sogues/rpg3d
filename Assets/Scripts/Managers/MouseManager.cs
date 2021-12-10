using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// [System.Serializable]
// public class EventVector3 : UnityEvent<Vector3>
// {
//     
// }

public class MouseManager : MonoBehaviour
{
    public static MouseManager Instance;
    
    private RaycastHit hitInfo;
    
    public Texture2D point, doorway, attack, target, arrow;

    // public EventVector3 OnMouseClicked;

    public event Action<Vector3> OnMouseClicked;

    private void Awake()
    {
        if (null != Instance)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

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
            switch (hitInfo.collider.gameObject.tag)
            {
                case "Plane":
                    Cursor.SetCursor(target, new Vector2(16,16), CursorMode.Auto);
                    break;
            }
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
