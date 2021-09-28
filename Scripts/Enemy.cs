using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed;
    public float moveSpeed;
    public float atkRange;
    public float fieldOfVision;
    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg, float _atkSpeed, float _moveSpeed, float _atkRange, float _fieldOfVision)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        nowHp = _maxHp;
        atkDmg = _atkDmg;
        atkSpeed = _atkSpeed;
        moveSpeed = _moveSpeed;
        atkRange = _atkRange;
        fieldOfVision = _fieldOfVision;
    }

    public GameObject prfHpBar;
    public GameObject canvas;
    RectTransform hpBar;
    public float height = 1.7f;

    public Sword_Man sword_man;
    Image nowHpbar;
    public Animator enemyAnimator;

    void Start()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        sword_man = FindObjectOfType<Sword_Man>();
        if (name.Equals("Enemy1"))
        {
            SetEnemyStatus("Enemy1", 10, 10, 1.5f, 2, 2, 5);
        }
        else if (name.Equals("Enemy2"))
        {
            SetEnemyStatus("Enemy2", 10, 10, 1.5f, 2, 2, 5);
        }
        else if (name.Equals("Enemy3"))
        {
            SetEnemyStatus("Enemy3", 20, 5, 1.5f, 2, 2, 5);
        }
        else if (name.Equals("Enemy4"))
        {
            SetEnemyStatus("Enemy4", 20, 5, 1.5f, 2, 2, 5);
        }
        else if (name.Equals("Enemy5"))
        {
            SetEnemyStatus("Enemy4", 30,10, 1.5f, 2, 2, 5);
        }
        else if (name.Equals("Enemy6"))
        {
            SetEnemyStatus("Enemy6", 30, 10, 1.5f, 2, 2, 5);
        }
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();

        SetAttackSpeed(atkSpeed);
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint
            (new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpBarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Weapon"))
        {
            if (sword_man.attacked)
            {
                nowHp -= sword_man.atkDmg;
                sword_man.attacked = false;
                if (nowHp <= 0) // Àû »ç¸Á
                {
                    Die();
                }
            }
        }
    }

    void Die()
    {
        enemyAnimator.SetTrigger("die");            
        GetComponent<EnemyAI>().enabled = false;    
        GetComponent<Collider2D>().enabled = false; 
        Destroy(GetComponent<Rigidbody2D>());       
        Destroy(gameObject, 3);                     
        Destroy(hpBar.gameObject, 3);               
    }

    void SetAttackSpeed(float speed)
    {
        enemyAnimator.SetFloat("attackSpeed", speed);
    }
}
