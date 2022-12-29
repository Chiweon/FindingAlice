using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    //���� "ȭ���� ���� â �ݱ�"��� Text.text�� ����
    Text fadeText;

    void OnEnable()
    {
        fadeText = this.GetComponent<Text>();
        //StartCoroutine(BlinkText());

        StartCoroutine(FadeTextToFullAlpha());
    }

    //IEnumerator BlinkText() // �����̴� Text
    //{
    //    while (true)
    //    {
    //        fadeText.text = textContents;
    //        yield return new WaitForSeconds(0.5f);
    //        fadeText.text = " ";
    //        yield return new WaitForSeconds(0.5f);

    //        yield return null;
    //    }
    //}

    IEnumerator FadeTextToFullAlpha() // ���İ� 0���� 1�� ��ȯ
    {
        fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, 0);

        while (fadeText.color.a < 2f)
        {
            fadeText.color =
                new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b,
                fadeText.color.a + (Time.deltaTime / 1.5f));
            //Debug.Log("����1");
            yield return null;

        }

        StartCoroutine(FadeTextToZero());
        StopCoroutine(FadeTextToFullAlpha());
    }

    IEnumerator FadeTextToZero()  // ���İ� 1���� 0���� ��ȯ
    {
        fadeText.color = new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b, 1);

        while (fadeText.color.a > 0.0f)
        {
            fadeText.color =
                new Color(fadeText.color.r, fadeText.color.g, fadeText.color.b,
                fadeText.color.a - (Time.deltaTime / 1.5f));
            //Debug.Log("����2");
            yield return null;
        }

        StartCoroutine(FadeTextToFullAlpha());
        StopCoroutine(FadeTextToZero());
    }
}