using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public UnityEvent<float, int, int> ClickKing = new UnityEvent<float, int, int>();
    public UnityEvent<float, int, int> ClickEnemy = new UnityEvent<float, int, int>();

    public float damagePerSecond { get; set; }
    public int countOfDamage { get; set; }
    public int magicDamage { get; set; }


    private EnemyHealth enemyHealth;
    private KingHealth kingHealth;
    private PlayerState playerState;
    
    void Start()
    {
        enemyHealth = GameObject.Find("Enemy").GetComponent<EnemyHealth>();
        kingHealth = GameObject.Find("King").GetComponent<KingHealth>();

        playerState = GetComponent<PlayerState>();

        kingHealth.KingDie.AddListener(GoingToDie);
        enemyHealth.EnemyDie.AddListener(GoingToDie);

        playerState.BurnMagicState.AddListener(BurnMagicState);
        playerState.PoisonMagicState.AddListener(PoisonMagicState);
        playerState.CurseMagicState.AddListener(CurseMagicState);
        playerState.PhysicsMagicState.AddListener(PhysicsMagicState);
    }

    void Update()
    {
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.tag == "King")
            {
                ClickKing.Invoke(damagePerSecond, countOfDamage, magicDamage);
            }
            if (hit.transform.gameObject.tag == "Enemy")
            {
                ClickEnemy.Invoke(damagePerSecond, countOfDamage, magicDamage);
            }
        }
    }

    private void GoingToDie(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    private void BurnMagicState(float time, int count, int damage)
    {
        damagePerSecond = time;
        countOfDamage = count;
        magicDamage = damage;
    }

    private void PoisonMagicState(float time, int count, int damage)
    {
        damagePerSecond = time;
        countOfDamage = count;
        magicDamage = damage;
    }

    private void CurseMagicState()
    {
        
    }

    private void PhysicsMagicState(int damage)
    {
        magicDamage = damage;
    }
}
