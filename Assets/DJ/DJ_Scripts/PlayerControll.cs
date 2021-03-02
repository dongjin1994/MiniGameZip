using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpHeight = 0;            //���� ����
    public float jumpSpeed = 0;             //���� ���ǵ�

    bool isJump = false;                    //���� ����
    bool isTop = false;                     //���� ���̿� �����ϸ� �Լ��۵����߰� �ϱ� ����

    Vector2 startPosition;                  //������ ���ƿ� ������ �ʱⰪ

    void Start()
    {
        startPosition = transform.position;
    } 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                  //Ŭ�� ���� ���
        {
            isJump = true;                                //�������� True
        }
        else if(transform.position.y <= startPosition.y)  //���� �� ������ �������� �� ������ Ȱ��� �� �ʱ�ȭ
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        if (isJump)   //���� ����
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)                 //���������� �� �ְ� ���� �����ϱ� ��
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime); //�ְ������� �ö�
            }
            else                                                                     //�ְ������� �ö��� ��
            {
                isTop = true;
            }
            if (transform.position.y > startPosition.y && isTop)                     //�ְ� ���̷� �ö󰬴� ������ ��
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime *2); //�ٽ� StartPosition���� ������
            }
        }
       
    }
}
