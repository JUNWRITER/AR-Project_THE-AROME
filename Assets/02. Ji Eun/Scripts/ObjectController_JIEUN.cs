using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ObjectController_JIEUN : MonoBehaviour
{
    Quaternion Rotation;
    Vector3 Scale;

    public float perspectiveZoomSpeed = 0.05f;
    public float localScale;
    private float speed = 3f;

    [SerializeField]
    private float maxLocalScale;

    [SerializeField]
    private float minLocalScale;


    private void Start()
    {
        Rotation = transform.rotation;
        Scale = transform.localScale;
    }

    void Update()
    {
        
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = touchDeltaMag - prevTouchDeltaMag;

            transform.localScale += new Vector3(deltaMagnitudeDiff, deltaMagnitudeDiff, deltaMagnitudeDiff);


            if (transform.localScale.x >= maxLocalScale)
            {
                transform.localScale = new Vector3(maxLocalScale, maxLocalScale, maxLocalScale);
            }
            else if (transform.localScale.x <= minLocalScale)
            {
                transform.localScale = new Vector3(minLocalScale, minLocalScale, minLocalScale);
            }
        }

        if(Input.GetMouseButton(0))
        {
            transform.Rotate(0f, -Input.GetAxis("Mouse X") * speed, 0f, Space.World);
            transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f);
        }


    }   
}
