using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    //public GameObject[] ground;
    public float speed;
    public float distance;
    SpriteRenderer temp;


    void Start()
    {
     temp = tiles[0];   
    }
    
    
    void Update()
    {
        if(GameManager.instance.isPlay)
        {
         for(int i = 0; i< tiles.Length; i++)
         {
            if(-18 >= tiles[i].transform.position.x)  //-18 끝지점 --> 화면에 바닥이 짤리면 숫자 조정하면 됨
            {
                for(int q =0; q<tiles.Length; q++)
                {
                    if(temp.transform.position.x < tiles[q].transform.position.x)
                    temp = tiles[q];
                }
                 tiles[i].transform.position = new Vector2(temp.transform.position.x + distance, 0);   //타일 다시 뒤로 돌리기 --> distance는 간격 ,0은 y값(뒤로 돌아간 블럭 높이)
                 //tiles[i].sprite = ground[Random.Range(0, ground.Length)];
            }
         }

         for(int i =0; i<tiles.Length; i++)
         {
            tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
         }
        }       
    }
}
