using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sword_Man : MonoBehaviour
{
    Animator animator;
    public int maxHP;
    public int nowHp;
    public int atkDmg;
    public float atkSpeed = 1;
    public bool attacked = false;
    public Image nowHpbar;
    bool inputRight = false;
    bool inputLeft = false;
    bool inputJump = false;
    Rigidbody2D rigid2D;
    public float jumpPower;
    public float moveSpeed;
    public ship boat;
    Collider2D col2D;
    public string currentMapName;
    public string scenename;
    public CameraFollow cams;
    bool isSwordManDead = false;
    public float deathtime;
    public Vector2 ship_dist;
    void AttackTrue()
    {
        attacked = true;
    }
        void AttackFalse()
    {
        attacked = false;
    }

    void SetAttackSpeed(float speed)
    {
        animator.SetFloat("attackSpeed", speed);
        atkSpeed = speed;

    }
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        col2D = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        SetAttackSpeed(1.5f);
        cams = FindObjectOfType<CameraFollow>();
    }
    
    void Update()
    {
        if (GameObject.Find("/Canvas/bghp_bar/hp_bar"))
        {
            nowHpbar = GameObject.Find("/Canvas/bghp_bar/hp_bar").GetComponent<Image>();
            nowHpbar.fillAmount = (float)nowHp / (float)maxHP;
        }
        currentMapName = SceneManager.GetActiveScene().name;
        if (!isSwordManDead && currentMapName != "Ending"&& currentMapName != "Main")
            CheckSwordManDeath();
        if (isSwordManDead)
        {
            if (Time.time - deathtime > 2)
            {
                isSwordManDead = false;
                animator.SetTrigger("normal");
                SceneManager.LoadScene("Ending");
            }
            else
                return;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            inputRight = true;
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            inputLeft = true;
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("moving", true);
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            
            if ((currentMapName == "Stage1") && transform.position.x < 74.5 && transform.position.x > 73.5)
            {
                SceneManager.LoadScene("1to2");
                transform.position = new Vector3(-0.5f, 0, 0);
                cams.transform.position = new Vector3(-0.5f, 0, 0);
            }
            else if ((currentMapName == "Stage2") && transform.position.x < 70 && transform.position.x > 69)
            {
                SceneManager.LoadScene("Clear");
            }
        }
        else animator.SetBool("moving", false);

        if (Input.GetKeyDown(KeyCode.X) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animator.SetTrigger("attack");
        }
        if (Input.GetKeyDown(KeyCode.C) && !animator.GetBool("jumping"))
        {
            inputJump = true;
        }
        RaycastHit2D raycastHit = Physics2D.BoxCast(col2D.bounds.center, col2D.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground"));

        if (raycastHit.collider != null)
        {
            animator.SetBool("jumping", false);
        }
        else animator.SetBool("jumping", true);
    }
    void FixedUpdate()
    {
        if(inputRight)
        {
            inputRight = false;
            
            if (currentMapName=="Stage2")
            {
                boat = FindObjectOfType<ship>();
                ship_dist = new Vector2(boat.transform.position.x - transform.position.x, boat.transform.position.y - transform.position.y);
                if (ship_dist.x >= 31.5f && ship_dist.x <= 40.5f&&ship_dist.y>2.5f&&ship_dist.y<6)
                {
                    moveSpeed = 3;
                }
                else
                {
                    moveSpeed = 2;
                }
            }
            rigid2D.velocity = new Vector2(moveSpeed, rigid2D.velocity.y);
        }
        if(inputLeft)
        {
            inputLeft = false;
            rigid2D.velocity = new Vector2(-moveSpeed, rigid2D.velocity.y);
        }
        if (inputJump)
        {
            inputJump = false;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, 0.2f * jumpPower);
        }
    }
    void CheckSwordManDeath()
    {
        if (nowHp <= 0)
        {
            deathtime = Time.time;
            isSwordManDead = true;
            animator.SetTrigger("die");
        }
        if (transform.position.y < -10)
        {
            isSwordManDead = false;
            SceneManager.LoadScene("Ending");
        } 

    }
}
