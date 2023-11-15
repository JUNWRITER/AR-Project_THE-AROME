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
                    yAngle = yAngleTemp - (SecondPoint.y - FirstPoint.y) * 90 / Screen.height; // Y�� ��ȭ�� �� ������ 3�� ������.

                    transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
                }
            }

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0); //ù��° �հ��� ��ġ�� ����
                Touch touchOne = Input.GetTouch(1); //�ι�° �հ��� ��ġ�� ����

                //��ġ�� ���� ���� ��ġ���� ���� ������
                //ó�� ��ġ�� ��ġ(touchZero.position)���� ���� �����ӿ����� ��ġ ��ġ�� �̹� �����ӿ��� ��ġ ��ġ�� ���̸� ��
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition; //deltaPosition�� �̵����� ������ �� ���
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // �� �����ӿ��� ��ġ ������ ���� �Ÿ� ����
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude; //magnitude�� �� ������ �Ÿ� ��(����)
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // �Ÿ� ���� ����(�Ÿ��� �������� ũ��(���̳ʽ��� ������)�հ����� ���� ����_���� ����)
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
