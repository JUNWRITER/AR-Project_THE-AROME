using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    #region Declaration & Definition
    // Touch Panel point
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    Vector3 FirstMovePoint;

    // Rotation
    public float rotSpeed = 0.02f;
    public float xAngle = 0f;
    public float yAngle = 55f;
    float xAngleTemp;
    float yAngleTemp;

    // Scale
    float sizeSpeed = 0.03f;
    public Vector3 sizeMin = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 sizeMax = new Vector3(1.5f, 1.5f, 1.5f);

    #endregion

    #region Unity Default Method
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            ObjectRotation();
        }

        if (Input.touchCount == 2)
        {
            ObjectChangeScale();
        }
    }
    #endregion

    #region Method

    private void GetInputTouch()
    {

    }

    private void ObjectRotation()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            FirstPoint = Input.GetTouch(0).position;
        }

        if (touch.phase == TouchPhase.Moved)
        {
            FirstMovePoint = Input.GetTouch(0).position;

            xAngleTemp = xAngle;
            yAngleTemp = yAngle;

            xAngle = xAngleTemp + (FirstMovePoint.x - FirstPoint.x) * 180 / Screen.width;
            yAngle = yAngleTemp - (FirstMovePoint.y - FirstPoint.y) * 90 / Screen.height;

            transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
        }
    }

    private void ObjectChangeScale()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
        {
            FirstPoint = Input.GetTouch(0).position;
            SecondPoint = Input.GetTouch(1).position;
        }
        float firstInputLength = Vector3.Magnitude(SecondPoint - FirstPoint);

        if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
        {
            FirstPoint = Input.GetTouch(0).position;
            SecondPoint = Input.GetTouch(1).position;

            float SecondInputLength = Vector3.Magnitude(SecondPoint - FirstPoint);
            float ScaleVariance = (SecondInputLength - firstInputLength) * Time.deltaTime * sizeSpeed;

            this.transform.localScale += new Vector3(ScaleVariance, ScaleVariance, ScaleVariance);

            float scaleMagnitude = Vector3.Magnitude(this.transform.localScale);
            float sizeMaxMagnitude = Vector3.Magnitude(sizeMax);
            float sizeMinMagnitude = Vector3.Magnitude(sizeMin);

            if (scaleMagnitude >= sizeMaxMagnitude)
            {
                this.transform.localScale = sizeMax;
            }
            else if (scaleMagnitude < sizeMinMagnitude)
            {
                this.transform.localScale = sizeMin;
            }
        }
    }
    #endregion
}
