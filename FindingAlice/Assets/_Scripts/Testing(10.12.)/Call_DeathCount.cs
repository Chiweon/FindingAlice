using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Call_DeathCount : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("���ݱ����� �� ��� Ƚ���� " + GameObject.Find("Player").GetComponentInChildren<PlayerMovement>().deathCounter + "�� �����̽��ϴ�.");
        Debug.Log("���ݱ����� �� ��� Ƚ���� " + PlayerMovement.deathCounter + "�� �����̽��ϴ�.");
    }
}