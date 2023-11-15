using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTouchEvent : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 500f;

    private Vector3 FirstPoint;
    private Vector3 SecondPoint;
    private float xAngle;
    private float yAngle;
    private float xAngleTemp;
    private float yAngleTemp;


    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if(Input.touchCount==1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    FirstPoint = Input.GetTouch(0).position;
                    xAngleTemp = xAngle;
                    yAngleTemp = yAngle;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    SecondPoint = Input.GetTouch(0).position;
                    xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
                    yAngle = yAngleTemp - (SecondPoint.y - FirstPoint.y) * 90 / Screen.height; // Y값 변화가 좀 느려서 3배 곱해줌.

                    transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0); //첫번째 손가락 터치를 저장
                Touch touchOne = Input.GetTouch(1); //두번째 손가락 터치를 저장

                //터치에 대한 이전 위치값을 각각 저장함
                //처음 터치한 위치(touchZero.position)에서 이전 프레임에서의 터치 위치와 이번 프로임에서 터치 위치의 차이를 뺌
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; //deltaPosition는 이동방향 추적할 때 사용
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // 각 프레임에서 터치 사이의 벡터 거리 구함
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; //magnitude는 두 점간의 거리 비교(벡터)
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // 거리 차이 구함(거리가 이전보다 크면(마이너스가 나오면)손가락을 벌린 상태_줌인 상태)
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                transform.localScale += new Vector3(deltaMagnitudeDiff* Time.deltaTime, deltaMagnitudeDiff * Time.deltaTime, deltaMagnitudeDiff * Time.deltaTime);

            }

            if (transform.localScale.x < 0.1f)
                transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            if (transform.localScale.x >0.5f)
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        }
    }

}
