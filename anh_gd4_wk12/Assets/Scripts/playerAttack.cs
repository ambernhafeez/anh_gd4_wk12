using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    public int attackPower = 1;
    public BoxCollider2D attackBox;
    float attackTimer = 2;

    enemyController enemyControllerScript; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackBox = GetComponent<BoxCollider2D>();
        attackBox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
    }

    // only activate attack box for 2 seconds after attack action occurs
    // attack action is called from player movement script
    public void ActivateAttackBox()
    {
        Debug.Log("ActivateAttackBox function called");
        attackBox.enabled = true;
        StartCoroutine(DisableAttackBox());
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<enemyController>() != null)
        {
            other.GetComponent<enemyController>().TakeDamage(attackPower);
        }

    }

    public void TestFunction()
    {
        Debug.Log("Script accessed by playerMovement script");
    }

    private IEnumerator DisableAttackBox()
    {
        yield return new WaitForSeconds(0.5f);
        attackBox.enabled = false;
    }
}
