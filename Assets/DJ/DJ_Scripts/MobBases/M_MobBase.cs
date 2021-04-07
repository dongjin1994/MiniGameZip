using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_MobBase : MonoBehaviour
{
    [SerializeField]
   Transform MidSpawnPos;
    //public Vector2 StartPosition;

    void OnEnable()
    {
        MidSpawnPos = GameObject.Find("MidSpawn").GetComponent<Transform>();
        transform.position = MidSpawnPos.position;
        //transform.position = StartPosition;
    }
    
    void Update()
    {
        if(GameManager.instance.isPlay)
        {
            transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);
        }
        if(transform.position.x < -15.7f)               //15.7은 화면 밖으로 나가는 위치 >>> 화면 밖으로 나가기 전에 사라진다면 숫자 조정
        {
            gameObject.SetActive(false);
        }
    }
}
