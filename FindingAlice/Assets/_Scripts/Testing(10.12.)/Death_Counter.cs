using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Counter : MonoBehaviour
{
    //�ӽ� ���


    //[SerializeField] uint[] deathCounter = new uint[30];
    public ushort deathCounter;
    string changeInteger;

    void OnEnable()
    {
        //changeInteger = this.gameObject.name;
        //deathCounter = ushort.Parse(changeInteger);
        //Debug.Log(deathCounter); ���������� �� ��
    }

    void Start()
    {
        
    }

}
