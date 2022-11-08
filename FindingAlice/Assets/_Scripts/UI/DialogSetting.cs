using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSetting : MonoBehaviour
{
    // ����� ���� ����̽��� ���̸� �����ͼ� dialogue�� height�� ���̸� ����.
    [SerializeField] GameObject dialogue;
    private void Start()
    {
        float dialHeight = Screen.height;
        dialogue.GetComponent<RectTransform>().sizeDelta = new Vector2(dialogue.GetComponent<RectTransform>().rect.width, Screen.height);
    }
}
