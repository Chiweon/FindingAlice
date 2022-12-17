using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFixed : MonoBehaviour
{

    [SerializeField] float setWidth;       // ����� ����(Canvas Scaler) �ʺ�
    [SerializeField] float setHeight;      // ����� ����(Canvas Scaler) ����
    [SerializeField] float deviceWidth;      // ��� �ʺ� ����
    [SerializeField] float deviceHeight;     // ��� ���� ����

    [SerializeField] float thisImageWidth;   // �ش� �̹��� �ʺ�
    [SerializeField] float thisImageHeight;  // �ش� �̹��� ����

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");

        setWidth = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.x;
        setHeight = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.y;
        deviceWidth = Screen.width;
        deviceHeight = Screen.height;
        thisImageWidth = this.transform.gameObject.GetComponent<RectTransform>().sizeDelta.x;
        thisImageHeight = this.transform.gameObject.GetComponent<RectTransform>().sizeDelta.y;
    }

    void OnEnable()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        float currentAspectRatio = deviceWidth / deviceHeight;
        float fixedAspectRatio = setWidth / setHeight;
        float thisAspectRatio = thisImageWidth / thisImageHeight;

        if (thisAspectRatio > currentAspectRatio) // ������ ������� Ŭ ���
        {
            this.transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
                (int)(thisImageWidth * (1.0 + fixedAspectRatio * 0.1)),
                (int)(thisImageHeight * (1.0 + fixedAspectRatio * 0.1)));
        }
        else if (thisAspectRatio < currentAspectRatio) // 
        {
            this.transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(
                (int)(thisImageWidth * (1.0 - fixedAspectRatio * 0.1)),
                (int)(thisImageHeight * (1.0 - fixedAspectRatio * 0.1)));
        }
    }
}