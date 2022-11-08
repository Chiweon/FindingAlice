using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Call_DeathCount : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("���ݱ����� �� ��� Ƚ���� " + GameObject.Find("Player").GetComponentInChildren<PlayerMovement>().deathCounter + "�� �����̽��ϴ�.");
        Debug.Log("���ݱ����� �� ��� Ƚ���� " + PlayerManager.Instance().GetDeathCount() + "�� �����̽��ϴ�.");
    }


    private void Update()
    {
        if(gameObject.GetComponent<Text>() != null)
        {
            gameObject.GetComponent<Text>().text =
                "��� Ƚ��  " + PlayerManager.Instance().GetDeathCount();
        }
    }
}