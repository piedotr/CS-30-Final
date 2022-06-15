
using UnityEngine;

public class Target : MonoBehaviour
{
	public int CrateCounter;
    public float health = 50f;
	public void TakeDamage(float amount)
	{
		health -= amount;
		if(health <= 0f)
		{
			Die();
		}
	}
	void Die()
	{
        if (CrateCounter <= 5)
        {
			CrateCounter++;
        }
		Destroy(gameObject);
	}
}
