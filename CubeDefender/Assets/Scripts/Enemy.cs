using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyStats stats;
    float speed;
    int health;
    int instaKillsTanked;
    LayerMask tower;
    static float delay = .75f;
    public bool isAreal;
    public static Enemy Create(EnemyStats stats, Vector3 spawn){
        Transform instance = Instantiate(stats.prefab, spawn, Quaternion.identity);
        Enemy enem = instance.GetComponentInChildren<Enemy>();

        enem.tower = LayerMask.GetMask("Tower");
        
        enem.stats = stats;
        enem.health = stats.health;
        enem.speed = stats.movementSpeed;
        enem.isAreal = stats.isAreal;
        enem.transform.GetComponent<MeshFilter>().mesh = stats.mesh;
        enem.transform.GetComponent<MeshRenderer>().material = stats.material;

        enem.instaKillsTanked = Mathf.Max(1,stats.instaKillsTanked+1);
        return enem;
    }
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(Attack());
    }
    // Update is called once per frame
    void Update()
    {
        if (FindTower() == null){
            Move();
        }
    }

    void Move(){
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.Self);
    }

    IEnumerator Attack() {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            if (FindTower() != null)
            {
                FindTower().TakeDamage(stats.damage);
            }
        }
    }

    TowerMechanics FindTower(){
        if (Physics.BoxCast(transform.position, Vector3.one, transform.forward, out RaycastHit hit, Quaternion.identity, .1f, tower)){
            return hit.transform.GetComponent<TowerMechanics>();
        }
        else
        {
            return null;
        }
    }

    public void InstaKillEffect(){
      TakeDamage(Mathf.Max(stats.health/instaKillsTanked,1));
    }
    public void TakeDamage(int damage){
       
        health = health - damage;
        Debug.Log(health);
        if (health <= 0){
            Destroy(gameObject);
        }
    }
}
