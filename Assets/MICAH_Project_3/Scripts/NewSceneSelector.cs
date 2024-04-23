using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSceneSelector : MonoBehaviour
{

    public CanvasGroup mainScreenGroup;

    public int sceneSelector = 1;

    public float fadeSpeed = 1.5f;

    private Coroutine fadeToBlack;

    public bool isNewScene = false;

    // Start is called before the first frame update
    void Start()
    {

        mainScreenGroup = FindAnyObjectByType<CanvasGroup>();

        if(mainScreenGroup != null)
        {
            if (fadeToBlack == null)
            {
                fadeToBlack = StartCoroutine(FadeInOutRoutine());
            }
        }

        else
        {
            Debug.Log("No Canvas Group found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger active");

        if(other.CompareTag("Player"))
        {
            isNewScene = true;
            SceneManager.LoadScene(sceneSelector);
        }
        
    }

    private IEnumerator FadeInOutRoutine()
    {

        while (mainScreenGroup.alpha > 0)
        {
            mainScreenGroup.alpha = Mathf.MoveTowards(mainScreenGroup.alpha, 0, Time.deltaTime * fadeSpeed);
            yield return null;
        }

        mainScreenGroup.interactable = false;
        mainScreenGroup.blocksRaycasts = false;

        yield return new WaitForSeconds(2);

        while (mainScreenGroup.alpha < 1)
        {
            mainScreenGroup.alpha = Mathf.MoveTowards(mainScreenGroup.alpha, 1, Time.deltaTime * fadeSpeed);
            yield return null;
        }

        mainScreenGroup.interactable = true;
        mainScreenGroup.blocksRaycasts = true;

        fadeToBlack = null;

        yield return null;
    }
}
