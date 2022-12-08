using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImage : MonoBehaviour
{
    public int childCount = 0;

    //GuideImage ���� �θ� ������Ʈ�� �Ҵ��� ��
    [SerializeField] GameObject parentGuideImages;

    //�⺻������ SetActive(false)�� Inspector���� üũ ���� �� ��
    public GameObject[] guideImages;

    [SerializeField] Image[] images;
    [SerializeField] Button[] buttons;

    void Awake()
    {
        parentGuideImages = this.gameObject;

        childCount = parentGuideImages.transform.childCount;

        guideImages = new GameObject[childCount];
        images = new Image[childCount];
        buttons = new Button[childCount];

        //���� ������ �ʱ�ȭ�Ͽ� �ڽ� ������Ʈ�� �ǵ��� �� �ְ� �ݺ��� ����
        for (int i = 0; i < childCount; i++)
        {
            Debug.Log("Start(), for�� ����!");
            guideImages[i] = parentGuideImages.transform.GetChild(i).gameObject;

            images[i] = guideImages[i].GetComponent<Image>();
            buttons[i] = guideImages[i].GetComponent<Button>();

            guideImages[i].SetActive(false);
        }
    }

    public void OffImages()
    {
        //�ڽ� ������Ʈ�� Button ������Ʈ���� ���˴ϴ�.
        //�ڽ� ������Ʈ�� - 1��° ������Ʈ�� ������, �ڽ� ������Ʈ�� �����ϴ�. �׸��� �ڷ�ƾ�� ����˴ϴ�.
        Debug.Log("OffImages()");
        
        if (childCount == 0)
        {
            guideImages[childCount].SetActive(false);
            return;
        }

        guideImages[childCount - 1].SetActive(true);
        guideImages[childCount].SetActive(false);
        childCount--;
        StartCoroutine(TurnOnGuide());

    }

    public IEnumerator TurnOnGuide()
    {
        //3�� �ڿ� ��ư�� �����ϴ�.
        Debug.Log("TurnOnGuide()");
        yield return new WaitForSeconds(3.0f);

        buttons[childCount].enabled = true;
        //nextButtons[childCount] = true;
        //childCount--;
        
        //yield return null;

        //yield break;
    }
}