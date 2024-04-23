using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coroutines : MonoBehaviour
{

    public CanvasGroup mainScreenGroup;

    public float fadeSpeen = 1.5f;

    private Coroutine fadeRoutine;

    // Start is called before the first frame update
    void Start()
    {
        if(fadeRoutine == null)
        {
            fadeRoutine = StartCoroutine(FadeInOutRoutine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //mainScreenGroup.alpha = Mathf.MoveTowards(mainScreenGroup.alpha, 0, Time.deltaTime * fadeSpeen);

        //if(mainScreenGroup.alpha <= 0)
        //{
        //    mainScreenGroup.interactable = false;
        //    mainScreenGroup.blocksRaycasts = false;
        //}
    }

    private IEnumerator FadeInOutRoutine()
    {
        bool gameStarted = false;

        while(!gameStarted)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameStarted = true;
            }

            yield return null;
        }

        while(mainScreenGroup.alpha>0)
        {
            mainScreenGroup.alpha = Mathf.MoveTowards(mainScreenGroup.alpha, 0, Time.deltaTime * fadeSpeen);
            yield return null;
        }

        mainScreenGroup.interactable = false;
        mainScreenGroup.blocksRaycasts = false;

        yield return new WaitForSeconds(2);

        while (mainScreenGroup.alpha < 1)
        {
            mainScreenGroup.alpha = Mathf.MoveTowards(mainScreenGroup.alpha, 1, Time.deltaTime * fadeSpeen);
            yield return null;
        }

        mainScreenGroup.interactable = true;
        mainScreenGroup.blocksRaycasts = true;

        fadeRoutine = null;

        yield return null;
    }
}
