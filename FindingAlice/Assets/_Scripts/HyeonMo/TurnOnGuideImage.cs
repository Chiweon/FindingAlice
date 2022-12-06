using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    //�ش� ��ũ��Ʈ�� Guide���� ��� ������Ʈ�� �Ҵ��ؾ� �մϴ�.

    int childCount = 0;

    [SerializeField] GameObject parentGuideImages; 
    //���� �������� Inspector���� Ű���� GuideImages ������Ʈ �Ҵ�
    

    [SerializeField] bool[] nextButtons;

    [SerializeField] GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons; //�����Խ�

    //void Awake()
    //{
    //    if (parentGuideImages == null)
    //    {
    //        if (this.transform.GetComponent<RectTransform>())
    //        {
    //            parentGuideImages = this.transform.gameObject;
    //            Debug.Log(this.gameObject.name + "����");

    //            if (parentGuideImages.transform.GetChild(0) == null)
    //                parentGuideImages = parentGuideImages.transform.parent.gameObject;
    //        }

    //        else if (this.transform.GetComponent<Transform>())
    //            Debug.Log(this.transform.name + "�̶�� ������Ʈ�� GuideImage�� �Ҵ���� �ʾҽ��ϴ�.");
    //    }
    //}

    void Start()
    {
        childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];
        nextButtons = new bool[childCount];

        //Debug.Log(this.gameObject.name + "Start ����");

        for (int i = 0; i < childCount; i++)
        {
            //Debug.Log(this.gameObject.name + "for�� ���� ��");
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;
            
            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            buttons[i].enabled = false;
            nextButtons[i] = false;
            guideImages[i].SetActive(false);

            //Debug.Log(this.gameObject.name + "for�� ���� ����, (" + i +")��°");
        }

    }

    public void OffImages()
    {
        for (int i = childCount - 1; i >= 0; i++)
        {
            if (i <= 0)
                break;

            if (!guideImages[i].activeSelf)
                continue;
            
            guideImages[i].SetActive(false);
            StartCoroutine(TurnOnGuide());
            break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            guideImages[childCount - 1].SetActive(true);

            StartCoroutine(TurnOnGuide());
        }
    }

    //void OnDisable()
    //{
    //    for (int i = childCount - 1; i >= 0; i--)
    //    {
    //        if (i <= 0)
    //            break;

    //        if (this.transform.gameObject == guideImages[i])
    //        {
    //            guideImages[i - 1].SetActive(true);
    //            break;
    //        }
    //    }
    //}

    IEnumerator TurnOnGuide()
    {
        yield return new WaitForSeconds(3.0f);

        buttons[childCount - 1].enabled = true;
        nextButtons[childCount - 1] = true;

        for (int i = childCount - 1; i >= 0; i--)
        {
            if (i <= 0)
                break;

            if (nextButtons[i])
                continue;

            buttons[i].enabled = true;
            nextButtons[i] = true;

            break;
        }

        yield break;
    }
}