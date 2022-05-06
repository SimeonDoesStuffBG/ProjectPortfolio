using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPellet : MonoBehaviour
{
    int MoneyProduced;
    public static ManaPellet Create(RectTransform prefab, int Money, Vector3 position)
    {
        RectTransform Pellet = Instantiate(prefab, GameObject.Find("Canvas").transform,false);
        Pellet.position = Camera.main.WorldToScreenPoint(position);
        ManaPellet manaPellet = Pellet.GetComponent<ManaPellet>();

        manaPellet.MoneyProduced = Money;
        return manaPellet;
    }

    private void Start()
    {
       StartCoroutine(FadeAway());
    }
    IEnumerator FadeAway(){
        float lifetime = Random.Range(10, 15);
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
    public void CollectPellet()
    {
        ImportantValues.AddMoney(MoneyProduced);
        Destroy(gameObject);
    }
}