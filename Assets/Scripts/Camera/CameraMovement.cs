using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Camera
{
    public class CameraMovement : MonoBehaviour
    {
        private float _prevMousePos;

        private void Start()
        {
            _prevMousePos = Input.mousePosition.x;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _prevMousePos = Input.mousePosition.x;
            }

            if (!Input.GetMouseButton(0)) return;

            var deltaAngle = (_prevMousePos - Input.mousePosition.x) / 5;
            
            var angle = transform.eulerAngles.y + deltaAngle + 90;
            
            var x = (float) (Math.Cos(-Mathf.Deg2Rad * angle) * 14 + 11);
            var z = (float) (Math.Sin(-Mathf.Deg2Rad * angle) * 14 + 11);
        
            Debug.Log("New angle: " + angle + " || Pos: " + new Vector3(x, 18, z));
        
            transform.position = new Vector3(x, 18, z);
            transform.Rotate(0, -deltaAngle, 0, Space.World);

            _prevMousePos = Input.mousePosition.x;
        }
    }
}
