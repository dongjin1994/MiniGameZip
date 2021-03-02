using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpHeight = 0;            //점프 높이
    public float jumpSpeed = 0;             //점프 스피드

    bool isJump = false;                    //점프 상태
    bool isTop = false;                     //일정 높이에 도달하면 함수작동멈추게 하기 위함

    Vector2 startPosition;                  //점프후 돌아올 포지션 초기값

    void Start()
    {
        startPosition = transform.position;
    } 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))                  //클릭 했을 경우
        {
            isJump = true;                                //점프상태 True
        }
        else if(transform.position.y <= startPosition.y)  //점프 후 땅으로 내려왔을 때 점프에 활용된 값 초기화
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        if (isJump)   //점프 상태
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)                 //점프상태일 때 최고 점에 도달하기 전
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime); //최고점까지 올라감
            }
            else                                                                     //최고점까지 올라갔을 때
            {
                isTop = true;
            }
            if (transform.position.y > startPosition.y && isTop)                     //최고 높이로 올라갔다 내려올 때
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime *2); //다시 StartPosition으로 내려옴
            }
        }
       
    }
}
