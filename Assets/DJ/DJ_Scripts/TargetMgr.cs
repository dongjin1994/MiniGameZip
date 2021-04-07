using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMgr : MonoBehaviour
{
   public GameObject target;
   private Vector2 initMousePos;
    public float jumpSpeed = 0;             //점프 스피드

    public GameObject top;
    public GameObject mid;
    public GameObject bot;

    bool isJump = false;                    //점프 상태
    bool isTop = false;                     //최대 높이인지 확인
    float jumpHeight;             //점프 최대 높이

    bool isMJump = false;                    //점프 상태
    bool isMTop = false;                     //최대 높이인지 확인
    float jumpHeight_M;             //점프 최대 높이
    bool isBJump = false;                    //점프 상태
    bool isBTop = false;                     //최대 높이인지 확인
    float jumpHeight_B;             //점프 최대 높이

    Vector2 startPosition;                  //점프 후 돌아올 위치
    Vector2 startPosition_M;                  
    Vector2 startPosition_B;                  
     void OnMouseDown()
    {
        initMousePos = Input.mousePosition;
        initMousePos = Camera.main.ScreenToWorldPoint(initMousePos);
        Debug.Log("클릭?");

    }
    void Start()
    {
        
        startPosition = top.transform.position;
        startPosition_M = mid.transform.position;
        startPosition_B = bot.transform.position;
        jumpHeight = startPosition.y + 1.5f;
        jumpHeight_M =startPosition_M.y + 1.5f;
        jumpHeight_B =startPosition_B.y + 1.5f;
    }


    void Update()
    {
        Top_touch();
        Mid_touch();
        Bot_Touch();
    }

    void Top_touch()
    {
         if (Input.GetMouseButtonDown (0) && GameManager.instance.isPlay) 
        {
           CastRay ();

            if (target.CompareTag("GameController"))   //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
            {  
                isJump = true;             
            }
            else
            {
                return;
            }        
        
        }
        else if(top.transform.position.y <= startPosition.y)
        {
            isJump = false;
            isTop = false;
            top.transform.position = startPosition;
            Debug.Log("초기화!");
        }

        if(isJump)
        {
            if(top.transform.position.y <= jumpHeight -0.1f && !isTop)
            {
                 top.transform.position = Vector2.Lerp(top.transform.position, 
                                                  new Vector2(top.transform.position.x, jumpHeight), jumpSpeed * Time.deltaTime);
                                                  Debug.Log("점프했다");
            }
            else
            {
                isTop = true;
                Debug.Log("최고점이다");
            }
            if(top.transform.position.y > startPosition.y && isTop)
            {
                top.transform.position = Vector2.MoveTowards(top.transform.position, startPosition, jumpSpeed * Time.deltaTime);
                Debug.Log("떨어진다");
            }

        }



        void CastRay() // 유닛 히트처리 부분.  레이를 쏴서 처리합니다. 

        {
            target = null;

            Vector2 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);


            if (hit.collider != null)         //히트되었다면 여기서 실행
            { 
                Debug.Log (hit.collider.name);  //이 부분을 활성화 하면, 선택된 오브젝트의 이름이 찍혀 나옵니다. 
                target = hit.collider.gameObject;  //히트 된 게임 오브젝트를 타겟으로 지정
            }                          
        }
    }

    void Mid_touch()
    {
       if (Input.GetMouseButtonDown (0) && GameManager.instance.isPlay) 
        {
            if (target.CompareTag("EditorOnly"))   //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
            {  
                isMJump = true;             
            }  
            else
            {
                return;
            }                   
        }
        else if(mid.transform.position.y <= startPosition_M.y)
        {
            isMJump = false;
            isMTop = false;
            mid.transform.position = startPosition_M;
        }

        if(isMJump)
        {
            if(mid.transform.position.y <= jumpHeight_M -0.1f && !isMTop)
            {
                 mid.transform.position = Vector2.Lerp(mid.transform.position, 
                                                  new Vector2(mid.transform.position.x, jumpHeight_M), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isMTop = true;
            }
            if(mid.transform.position.y > startPosition_M.y && isMTop)
            {
                mid.transform.position = Vector2.MoveTowards(mid.transform.position, startPosition_M, jumpSpeed * Time.deltaTime);
            }

        }

    }
    
    void Bot_Touch()
    {
         if (Input.GetMouseButtonDown (0) && GameManager.instance.isPlay) 
        {
            if (target.CompareTag("Player"))   //타겟 오브젝트가 스크립트가 붙은 오브젝트라면
            {  
                isBJump = true;             
            }  
            else
            {
                return;
            }                   
        }
        else if(bot.transform.position.y <= startPosition_B.y)
        {
            isBJump = false;
            isBTop = false;
            bot.transform.position = startPosition_B;
        }

        if(isBJump)
        {
            if(bot.transform.position.y <= jumpHeight_B -0.1f && !isBTop)
            {
                 bot.transform.position = Vector2.Lerp(bot.transform.position, 
                                                  new Vector2(bot.transform.position.x, jumpHeight_B), jumpSpeed * Time.deltaTime);
            }
            else
            {
                isBTop = true;
            }
            if(bot.transform.position.y > startPosition_B.y && isBTop)
            {
                bot.transform.position = Vector2.MoveTowards(bot.transform.position, startPosition_B, jumpSpeed * Time.deltaTime);
            }

        }
    }
}

