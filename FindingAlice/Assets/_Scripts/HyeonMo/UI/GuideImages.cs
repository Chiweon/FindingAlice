using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideImages : MonoBehaviour
{
    //���� �ڽĵ��� Inspector â���� �Ҵ�
    [SerializeField] GameObject[] guideImages;

    //���� Canvas�� �ִ� �͵� �Ҵ�
    [Header ("Player UI")]
    [SerializeField] GameObject joystick;
    [SerializeField] GameObject joystickLevel;
    [SerializeField] GameObject jumpButton;
    [SerializeField] GameObject clockTouchZone;

    Button[] buttons;

    void Start()
    {
        buttons = new Button[guideImages.Length];

        for (int i = 0; i < guideImages.Length; i++)
        {
            buttons[i] = guideImages[i].GetComponent<Button>();
            buttons[i].interactable = false;
            guideImages[i].transform.GetChild(0).gameObject.SetActive(false);
            guideImages[i].SetActive(false);
        }
    }

    //��ư������ �� �Լ� ȣ��ǵ��� �� �� �� ��, guideImages ������� Inspector â�� index ����
    public void OnButtonClicked(int index)
    {
        if (index == guideImages.Length - 1)
        {
            guideImages[index].SetActive(false);
            joystick.SetActive(true);
            joystickLevel.SetActive(true);
            jumpButton.SetActive(true);
            clockTouchZone.SetActive(true);
            Destroy(gameObject);
            return;
        }

        // ���� ���̵� �̹����� Ȱ��ȭ�ϰ� 3�� �ڿ� Button ������Ʈ�� Ȱ��ȭ
        guideImages[index + 1].SetActive(true);
        StartCoroutine(ActivateButton(index + 1));

        // ���� ���̵� �̹����� ��Ȱ��ȭ
        guideImages[index].SetActive(false);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // ù ��° ���̵� �̹����� Ȱ��ȭ�ϰ� 3�� �ڿ� Button ������Ʈ�� Ȱ��ȭ
            guideImages[0].SetActive(true);
            StartCoroutine(ActivateButton(0));

            joystick.SetActive(false);
            joystickLevel.SetActive(false);
            jumpButton.SetActive(false);
            clockTouchZone.SetActive(false);
        }
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        // ù ��° ���̵� �̹����� Ȱ��ȭ�ϰ� 3�� �ڿ� Button ������Ʈ�� Ȱ��ȭ
    //        guideImages[0].SetActive(true);
    //        StartCoroutine(ActivateButton(0));

    //        joystick.SetActive(false);
    //        joystickLevel.SetActive(false);
    //        jumpButton.SetActive(false);
    //        clockTouchZone.SetActive(false);
    //    }
    //}

    IEnumerator ActivateButton(int index)
    {
        yield return new WaitForSeconds(2.0f);
        buttons[index].interactable = true;
        guideImages[index].transform.GetChild(0).gameObject.SetActive(true);
    }
}