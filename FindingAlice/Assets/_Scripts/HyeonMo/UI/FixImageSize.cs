using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixImageSize : MonoBehaviour
{
    //���̵� �̹����� GuideImage ������Ʈ�� Width, Height�� ���ƾ� ��
    float defaultWidth  ,   defaultHeight;
    float deviceWidth   ,   deviceHeight;

    float ImageWidth,   ImageHeight;   // �ش� �̹��� �ʺ�� ����

    float deviceAspectRatio;
    float defaultAspectRatio;
    float ImageAspectRatio;

    RectTransform rectTransform;

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        defaultWidth = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.x;
        defaultHeight = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.y;

        rectTransform = transform.gameObject.GetComponent<RectTransform>();
        ImageWidth = rectTransform.sizeDelta.x;
        ImageHeight = rectTransform.sizeDelta.y;

        deviceWidth = Screen.width;
        deviceHeight = Screen.height;

        deviceAspectRatio = deviceWidth / deviceHeight;
        defaultAspectRatio = defaultWidth / defaultHeight;
        ImageAspectRatio = ImageWidth / ImageHeight;
    }

    void Start()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        if (ImageAspectRatio > deviceAspectRatio)
        {
            Debug.Log("way1");
            rectTransform.sizeDelta = new Vector2(
                (int)(ImageWidth * (1.0 + defaultAspectRatio * 0.1)),
                (int)(ImageHeight * (1.0 + defaultAspectRatio * 0.1)));
            Debug.Log("way1 Normal");
        }
        else if (ImageAspectRatio < deviceAspectRatio)
        {
            Debug.Log("way2");
            rectTransform.sizeDelta = new Vector2(
                (int)(ImageWidth * (1.0 - defaultAspectRatio * 0.1)),
                (int)(ImageHeight * (1.0 - defaultAspectRatio * 0.1)));
            Debug.Log("way2 Normal");
        }
    }
}