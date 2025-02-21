using UnityEngine;

public class enemyController : MonoBehaviour
{

    public int enemyHealth = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this function is called by the playerAttack script - OnTriggerEnter with player attackBox
    public void TakeDamage(int playerAttackPower)
    {
        if(enemyHealth > 0)
        {
            enemyHealth -= playerAttackPower;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
