using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnGuideImage : MonoBehaviour
{
    //GuideImage ���� �θ� ������Ʈ�� �Ҵ� �ؾ���
    [SerializeField] GameObject parent;

    IEnumerator turnOnGuide;

    void Start()
    {
        turnOnGuide = parent.GetComponent<GuideImage>().TurnOnGuide();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            parent.GetComponent<GuideImage>().childCount--;

            parent.GetComponent<GuideImage>().guideImages[parent.GetComponent<GuideImage>().childCount].SetActive(true);
            StartCoroutine(turnOnGuide);
            //this.gameObject.SetActive(false);
        }
    }
}