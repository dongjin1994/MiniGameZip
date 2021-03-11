using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   #region instance
   public static GameManager instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    #endregion
    
    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;
    public float gameSpeed =1;
    public bool isPlay = false;

    public GameObject startBtn;
    public GameObject gameOver;
    public float score = 0;
    public Text scoreText;
    
    IEnumerator Score()
    {
        while(isPlay)
        {
            scoreText.text = score.ToString();
            yield return new WaitForSeconds(0.1f);
        }

    }
    
    public void PlayStart()
    {
        startBtn.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        score = 0;
        scoreText.text = score.ToString();
        StartCoroutine(Score());
    }
    public void GameOver()
    {
        isPlay = false;
        gameOver.SetActive(true);
        onPlay.Invoke(isPlay);
    }

    public void Restart()
    {
        gameOver.SetActive(false);
        isPlay = true;
        onPlay.Invoke(isPlay);
        score = 0;
        scoreText.text = score.ToString();
        StartCoroutine(Score());
    }

    public void ExitGame()
    {
        Debug.Log("메인 선택 씬으로 이동~");
    }

}
