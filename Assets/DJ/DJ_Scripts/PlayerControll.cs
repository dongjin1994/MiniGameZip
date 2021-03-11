using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float jumpHeight = 0;            //점프 최대 높이
    public float jumpSpeed = 0;             //점프 스피드

    bool isJump = false;                    //점프 상태
    bool isTop = false;                     //최대 높이인지 확인

    Vector2 startPosition;                  //점프 후 돌아올 위치

    void Start()
    {
        startPosition = transform.position;
    } 
    void Update()
    {
        //if(GameManager.instance.isPlay)          //애니메이션 적용 후 사용
        //{
        //  animator.SetBool("run", true);
        //}
        //else
        //animator.SetBool("run", false);

        if (Input.GetMouseButtonDown(0)&&GameManager.instance.isPlay)                  //화면 터치 시
        {
            isJump = true;                                //점프 상태 True
        }
        else if(transform.position.y <= startPosition.y)  //점프 후 바닥으로 내려 왔을 경우 점프에 사용한 상태와 위치 초기화
        {
            isJump = false;
            isTop = false;
            transform.position = startPosition;
        }
        if (isJump)   //점프 했을 때
        {
            if (transform.position.y <= jumpHeight - 0.1f && !isTop)                 //점프 상태인데 최대 높이가 아닐 경우
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime); //최대 높이로 올라가는중~
            }
            else                                                                     //최대 높이 도달
            {
                isTop = true;
            }
            if (transform.position.y > startPosition.y && isTop)                     //최대 높이 일 경우
            {
                transform.position = Vector2.MoveTowards(transform.position, startPosition, jumpSpeed * Time.deltaTime *2); //다시 바닥을 향해 내려옴
            }
        }
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Finish"))
        {
            Debug.Log("아앗..");
            GameManager.instance.GameOver();
        }
    }
}
