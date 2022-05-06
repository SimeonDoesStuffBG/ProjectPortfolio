using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class TowerSelect : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    Tower[] towers;
    [SerializeField]
    int maxTowers = 8;
    int counter = 0;
    float timeScale;

    TowerPlacerUI placer;
    // Start is calle
    // d before the first frame update
    void Start()
    {
        timeScale = Time.timeScale;
        placer = GameObject.Find("Towers").GetComponent<TowerPlacerUI>();
        Time.timeScale = 0;
        if (towers.Length <= maxTowers){ 
            for(counter = 0; counter < towers.Length; counter++){
                placer.towers.Add(towers[counter]);
                
            }
            SetTowers();
        }
        else{
            for (int i = 0; i < towers.Length; i++)
            {
                AddButton(i);
            }
        }
    }

    void AddButton(int i){
        Button thisButton = Instantiate(button, gameObject.transform, false);
        thisButton.transform.GetChild(0).GetComponent<Text>().text = towers[i].name;
        thisButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = towers[i].showcaseTexture;
        thisButton.transform.GetChild(2).GetComponent<Text>().text = towers[i].price.ToString();
        thisButton.onClick.AddListener(delegate { SetButton(towers[i], thisButton); });
        thisButton.onClick.AddListener(() => thisButton.enabled = false);
    }

    void SetButton(Tower t, Button help){ 
        if(counter < maxTowers){
            placer.towers.Add(t);
            //placer.AddButton(counter);
            int index = counter;
            Button tempButton = Instantiate(button, placer.transform, false);
            tempButton.GetComponentInChildren<Text>().text = t.name;
            tempButton.onClick.AddListener(() => help.enabled = true);
            tempButton.onClick.AddListener(delegate {
                placer.towers.Remove(t);
                counter--;
            });
            tempButton.onClick.AddListener(() => Destroy(tempButton.gameObject));
            counter++;
        }
    }


    public void SetTowers(){
        Button[] buttons = placer.transform.GetComponentsInChildren<Button>();
        foreach(Button b in buttons)
        {
            Destroy(b.gameObject);
        }
        if(counter == maxTowers || towers.Length <= maxTowers){
          
            for(int i = 0; i < counter; i++){
                placer.AddButton(i);
            }
            gameObject.SetActive(false);
            GameObject.Find("Play").SetActive(false);
            Time.timeScale = timeScale;
        }
    }
}
