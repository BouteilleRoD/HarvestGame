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
    //Movement Direction
    float Hdirection, Vdirection;
    float mouvementSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 sideTranslate = Vector3.right * Hdirection * mouvementSpeed * Time.deltaTime;
        Vector3 frontTranslate = Vector3.forward * Vdirection * mouvementSpeed * Time.deltaTime;
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
        if(GameManager.GetInteractingObject()) GameManager.GetInteractingObject().OnInteract();
    }
    public void PlantASeed(Seed seed)
    {
        GameManager.GetInteractingObject().GetComponent<PlantSlot>().seed = seed;
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
    }

    public void attackTriggerDisable()
    {
        attackScript.gameObject.SetActive(false);
        animator.ResetTrigger("Attack");
    }
}
