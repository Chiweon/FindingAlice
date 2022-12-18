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

    Vector2 rect_SizeDelta;

    void Awake()
    {
        GameObject canvas = GameObject.Find("Canvas");
        defaultWidth = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.x;
        defaultHeight = canvas.gameObject.GetComponent<CanvasScaler>().referenceResolution.y;

        rect_SizeDelta = transform.gameObject.GetComponent<RectTransform>().sizeDelta;
        ImageWidth = rect_SizeDelta.x;
        ImageHeight = rect_SizeDelta.y;

        deviceWidth = Screen.width;
        deviceHeight = Screen.height;

        deviceAspectRatio = deviceWidth / deviceHeight;
        defaultAspectRatio = defaultWidth / defaultHeight;
        ImageAspectRatio = ImageWidth / ImageHeight;
    }

    void OnEnable()
    {
        SetResolution();
    }

    public void SetResolution()
    {
        if (ImageAspectRatio > deviceAspectRatio)
        {
            Debug.Log("way1");
            rect_SizeDelta = new Vector2(
                (int)(ImageWidth * (1.0 + defaultAspectRatio * 0.1)),
                (int)(ImageHeight * (1.0 + defaultAspectRatio * 0.1)));
        }
        else if (ImageAspectRatio < deviceAspectRatio)
        {
            Debug.Log("way2");
            rect_SizeDelta = new Vector2(
                (int)(ImageWidth * (1.0 - defaultAspectRatio * 0.1)),
                (int)(ImageHeight * (1.0 - defaultAspectRatio * 0.1)));
        }
    }
}