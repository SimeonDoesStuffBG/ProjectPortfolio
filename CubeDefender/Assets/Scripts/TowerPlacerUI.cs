using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacerUI : MonoBehaviour
{
    public List<Tower> towers;
    [SerializeField]
    Button button;
    [SerializeField]
    Color ColorFull;
    [SerializeField]
    Color NEMColor;

    TowerBuild builder;

    private void Start()
    {
        builder = GameObject.Find("Game Manager").GetComponent<TowerBuild>();
        /*for(int i = 0; i < towers.Count; i++){
            AddButton(i);
        }*/
    }

    private void Update()
    {
        for(int i =0; i < towers.Count; i++)
        {
            UpdateTower(i);
        }
    }

    public void UpdateTower(int i){
        if (ImportantValues.CanAfford(towers[i].price)){
            transform.GetChild(i).GetComponent<Image>().color = ColorFull;
        }
        else
        {
            transform.GetChild(i).GetComponent<Image>().color = NEMColor;
        }
    }

    public void SetTower(int index){
        Debug.Log(index);
        if (ImportantValues.CanAfford(towers[index].price)){
            builder.tower = towers[index];
        }
        else
        {
            Debug.Log("Not Enough Money");
        }
    }

    public void AddButton(int i){
        /*GameObject button = new GameObject();
        button.transform.parent = gameObject.transform;
        button.name = "Button";
        button.AddComponent<RectTransform>();
        button.AddComponent<CanvasRenderer>();
        button.AddComponent<Button>();
        button.AddComponent<Image>();
        
        GameObject child = new GameObject();
        child.transform.parent = button.transform;
        child.AddComponent<RectTransform>();
        child.AddComponent<CanvasRenderer>();
        child.AddComponent<Text>();
        Text myText = child.GetComponent<Text>();
        myText.text = towers[i].name;
        myText.color = Color.black;
        myText.font = new Font("Arial");
        */
        Button curButton = Instantiate(button, gameObject.transform, false);
        curButton.transform.GetChild(0).GetComponent<Text>().text = towers[i].name;
        curButton.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = towers[i].showcaseTexture;
        curButton.transform.GetChild(2).GetComponent<Text>().text = towers[i].price.ToString();
        curButton.GetComponent<Button>().onClick.AddListener(delegate { SetTower(i); });
    }
}
