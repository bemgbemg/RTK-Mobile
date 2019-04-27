using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

public class Loading : MonoBehaviour {
    public Image progressBar;

    private int curProgressValue = 0;

    private AsyncOperation operation;

    public GameObject Dot;
    public int Dots;
    public GameObject dot0;
    public GameObject dot1;
    public GameObject dot2;

    // Use this for initialization
    void Start () {
        Dots = 0;
        StartCoroutine(Blue());
        StartCoroutine(AsyncLoading());
    }
	
	// Update is called once per frame
	void Update () {
        if (Dots == 3)
        {
            Dots = 0;
        }
        int progressValue = 100;

        if (curProgressValue < progressValue)
        {
            curProgressValue++;
        }


        progressBar.fillAmount = curProgressValue / 100f;//实时更新滑动进度图片的fillAmount值  

        if (curProgressValue == 100)
        {
            operation.allowSceneActivation = true;//启用自动加载场景  
        }

    }
    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(1);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }

    IEnumerator Blue()
    {
        for(; ; )
        {
            dot0.GetComponent<Image>().color = new Color32(130, 125, 121, 255);
            dot1.GetComponent<Image>().color = new Color32(130, 125, 121, 255);
            dot2.GetComponent<Image>().color = new Color32(130, 125, 121, 255);
            Dot.transform.Find(Dots.ToString()).GetComponent<Image>().color = new Color32(57, 120, 212, 255);
            Dots = Dots + 1;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
