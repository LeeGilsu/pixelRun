using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingSceneController : MonoBehaviour //비기동 호출방식;
{
    static string nextScene;
    public Texture[] LoadingImageTexture = new Texture[2];
    [SerializeField]
    Image progressBar;
    [SerializeField]
    Texture Back_Image;

    
    
    public static void LoadScene(string sceneName) // 호출 시 string로 다음 scene의 이름을 받아온다.
    { 
        nextScene = sceneName; // 받아온 scene의 이름을 string로 넘겨준다.
        SceneManager.LoadScene("LoadingScene"); //씬을 로딩신으로 먼저 이동시켜 로딩 화면 출력.
    }

    private void Start()
    {
        StartCoroutine(LoadSceneProcess());

        //Back_Image = LoadingImageTexture[1];

    }

    IEnumerator LoadSceneProcess()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene); 
        //allowSceneActivation = 장면이 준비된 즉시 장면이 활성화되는 것을 허용
        op.allowSceneActivation = false; // 즉시 장면 전환을 false로 이동을 잠시 제한.

        float timer = 0f;

        while (!op.isDone)
        {
            yield return null;

            if (op.progress < 0.1f)
            { progressBar.fillAmount = op.progress; }
            else
            {
                timer += Time.unscaledDeltaTime;
                Debug.Log(timer);
                progressBar.fillAmount = Mathf.Lerp(0.1f, 1f, timer*0.8f);
                if (progressBar.fillAmount >= 1f) 
                {
                    op.allowSceneActivation = true; // fillamonut의 값을 최대치로 되면 allowSceneActivation = true로 이동 제한을 풀어준다.
                    yield break;
                }
            }
        }
    }
}
