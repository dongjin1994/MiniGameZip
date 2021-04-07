using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
     public Transform startPosition;
    public Transform endPosition;
    public float addSpeed = 1;

    void Update()
    {
         if(GameManager.instance.isPlay)
         {
             // x포지션을 조금씩 이동
             transform.Translate(-1 * GameManager.instance.gameSpeed * Time.deltaTime * addSpeed, 0, 0);

             // 목표 지점에 도달했다면
              if (transform.position.x <= endPosition.position.x)
            {
             ScrollEnd();
            }
         }
    }

    void ScrollEnd()
    {
        // 원래 위치로 초기화 시킨다.
        transform.Translate(-1 * (endPosition.position.x - startPosition.position.x), 0, 0);
    }
}
