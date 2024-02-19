using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    public string sceneName;
    public Animator transition;
    public float transitionTime = 1f;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(LoadNextScene); // Hapus tanda kurung di LoadScene
    }

    void Update()
    {
/*        if (Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }*/
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }
}
