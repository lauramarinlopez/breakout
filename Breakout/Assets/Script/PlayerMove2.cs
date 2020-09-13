using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk,
    attack,
    interact
}


public class PlayerMove2 : MonoBehaviour {

    public PlayerState currenstate;
    public float speed;
    private Rigidbody2D myrigid;
    private Vector3 change;
    private Animator animator;
    float joyRotion;

    [SerializeField]
    GameObject playerBullet;

    [SerializeField]
    GameObject muzzlePos;

    [SerializeField]
    GameObject gun;

    // Start is called before the first frame update
    void Start()
    {
        currenstate = PlayerState.walk;
        animator = GetComponent<Animator>();
        myrigid = GetComponent<Rigidbody2D>();
        animator.SetFloat("moveX", 0);
        animator.SetFloat("moveY", -1);

    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = ControlFreak2.CF2Input.GetAxisRaw("Horizontal");
        change.y = ControlFreak2.CF2Input.GetAxisRaw("Vertical");
     
        if (ControlFreak2.CF2Input.GetButtonDown("attack") && currenstate != PlayerState.attack)
        {
            if (FindObjectOfType<GlobalVariables>().gun)
            {
                print("Firing");
                fire();
                currenstate = PlayerState.walk;
            }
            else
            {
                StartCoroutine(AttackCo());
            }
        }
        else if (currenstate == PlayerState.walk)
        {
            updateanimator();
        }
        themove();

    }

    void fire()
    {
        GameObject obj = Instantiate(playerBullet, muzzlePos.transform.position, Quaternion.identity);
        GameObject.Find("gunshoot").GetComponent<AudioSource>().Play();

        obj.transform.rotation = gun.transform.rotation;
        //yield return new WaitForSeconds(fireRate);
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("attack", true);
        GameObject.Find("swordSound").GetComponent<AudioSource>().Play();
        currenstate = PlayerState.attack;
        yield return null;
        animator.SetBool("attack", false);
        yield return new WaitForSeconds(.3f);
        currenstate = PlayerState.walk;
    }

    void updateanimator()
    {
        if (change != Vector3.zero)
        {
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void themove()
    {
        change.Normalize();
        myrigid.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
