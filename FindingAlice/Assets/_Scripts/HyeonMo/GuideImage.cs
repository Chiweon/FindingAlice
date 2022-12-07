using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImage : MonoBehaviour
{
    //�θ� ������Ʈ�� �Ҵ���
    //�θ� OffImages()�Լ��� �ִٰ� ġ�� ������ �ڽ��� Button�� Ȱ��ȭ�ǰ� ������ ������ - 1�� �������� ������ ��

    [HideInInspector] public int childCount = 0;

    //GuideImage���� �θ� ��ũ��Ʈ �Ҵ��� ��
    [SerializeField] GameObject parentGuideImages;

    [SerializeField] bool[] nextButtons;

    //�⺻������ SetActive(false)�� �� ��
    [SerializeField] GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons;

    void Start()
    {
        parentGuideImages = this.gameObject;

        childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];
        nextButtons = new bool[childCount];

        for (int i = 0; i < childCount; i++)
        {
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;

            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            guideImages[i].SetActive(false);
        }
    }

    public void OffImages()
    {
        //for (int i = childCount - 1; i >= 0; i++)
        //{
        //    if (i <= 0)
        //        break;

        //    //if (!guideImages[i].activeSelf)
        //    //    continue;

        //    if (nextButtons[i])
        //        continue;

        //    guideImages[i - 1].SetActive(true);
        //    guideImages[i].SetActive(false);
        //    StartCoroutine(TurnOnGuide());
        //    break;
        //}

        if (childCount == 0)
        {
            guideImages[childCount].SetActive(false);
            return;
        }

        guideImages[childCount - 1].SetActive(true);
        guideImages[childCount].SetActive(false);
        StartCoroutine(TurnOnGuide());

    }

    public IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

        //for (int i = childCount - 1; i >= 0; i--)
        //{
        //    if (i <= 0)
        //        break;

        //    if (nextButtons[i])
        //        continue;

        //    buttons[i].enabled = true;
        //    nextButtons[i] = true;

        //    break;
        //}

        buttons[childCount].enabled = true;
        childCount--;

        //yield break;
        yield return null;
    }
}