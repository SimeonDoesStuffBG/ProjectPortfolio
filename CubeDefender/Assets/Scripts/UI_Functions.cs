using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Functions : MonoBehaviour
{
    [SerializeField]
    RectTransform manaPellet = null;
    static Text Money;

    float timeScale;
    private void Start()
    {
        timeScale = Time.timeScale;
        if (manaPellet != null)
        {
            StartCoroutine(SpawnPellet(20));
            Money = GameObject.Find("Currency").transform.GetChild(0).GetComponent<Text>();
            SetMoney();
        }
    }
    public static void SetMoney(){
        Money.text = ImportantValues.GetMoney();
    }
    // Start is called before the first frame update
    public void AppQuit(){
        Debug.Log("Exit");
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause(){
        Time.timeScale = timeScale;
    }

    public void MainMenu(){
        SceneManager.LoadScene(0);
    }

    public void GoToLevel(){
        SceneManager.LoadScene(1);
    }

    IEnumerator SpawnPellet(float spawn){
        while (true){
            yield return new WaitForSeconds(spawn);
            ManaPellet.Create(manaPellet, 25,Random.insideUnitSphere * 10);
        }
    }
}
