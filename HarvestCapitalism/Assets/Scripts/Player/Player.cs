using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Inventory inventory;
    [SerializeField] private AttackScript attackScript;
    [SerializeField] Animator animator;


    //Attack 
    bool canAttack = true;
    float attackCooldown = 1.5f;
    float lastAttackTimer = 0f;
    public float attackPower = 30f;
    private Rigidbody rb;
    //Movement Direction
    float Hdirection, Vdirection;
    float mouvementSpeed = 5f;
    Vector3 sideTranslate;
    Vector3 frontTranslate;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(transform.position + (sideTranslate + frontTranslate));
        //rb.velocity = (sideTranslate + frontTranslate) * mouvementSpeed;
        if (Hdirection == 0 && Vdirection == 0)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;


        }
    }
    // Update is called once per frame
    void Update()
    {

        //sideTranslate = GetComponentInChildren<CameraControler>().GetLateral() * Hdirection * Time.deltaTime;
        //frontTranslate = GetComponentInChildren<CameraControler>().GetVertical() * Vdirection * Time.deltaTime;
        sideTranslate = Vector3.right * Hdirection * mouvementSpeed * Time.deltaTime;
        frontTranslate = Vector3.forward * Vdirection * mouvementSpeed * Time.deltaTime;
        transform.Translate(sideTranslate + frontTranslate);

        if (Time.time - lastAttackTimer > attackCooldown && !canAttack)
        {
            canAttack = true;
        }
        if(Vdirection == 0 && Hdirection == 0 && !animator.GetBool("isIdle"))
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isWalking", false);
        }
    }
    public void OnHorizontal(InputValue val)
    {
        Hdirection = val.Get<float>();
        if(Hdirection != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
    }
    public void OnVertical(InputValue val)
    {
        Vdirection = val.Get<float>();
        if (Vdirection != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isIdle", false);
        }
    }

    public void OnAttack()
    {
        if (canAttack)
        {
            animator.SetTrigger("Attack");
            lastAttackTimer = Time.time;
            canAttack = false;
        }
    }

    public void OnInteract()
    {
        if (GameManager.GetInteractingObject())
        {
            GameManager.GetInteractingObject().OnInteract();
            if (AudioManager.instance) 
            {
                AudioManager.instance.PlaySFX("sfx_interact");
            }
        }
    }
    public void PlantASeed(Seed seed)
    {
        GameManager.GetInteractingObject().GetComponent<PlantSlot>().seed = seed;
        if (AudioManager.instance) 
        {
            AudioManager.instance.PlaySFX("sfx_plantseed");
        }
    }

    public void OnOpenInventory()
    {
        GameManager.GetInventoryPanel().SetActive(!GameManager.GetInventoryPanel().activeSelf);
        if (inventory.onItemsChangedCallBack != null)
        {
            inventory.onItemsChangedCallBack.Invoke();
        }
    }

    public void attackTriggerEnable()
    {
        attackScript.gameObject.SetActive(true);
        if (AudioManager.instance)
        {
            AudioManager.instance.PlaySFX("sfx_attack");
        }
    }

    public void attackTriggerDisable()
    {
        attackScript.gameObject.SetActive(false);
    }

    public void PlayWalk()
    {
        if (AudioManager.instance)
        {
            AudioManager.instance.PlaySFX("sfx_step");
        }
    }

    public void OnSetPause()
    {
        GameManager.SetPause(!GameManager.GetisPaused());
    }
}
