using UnityEngine;
using System.Collections;

public class Bullet_Behaviour : MonoBehaviour
{

    #region Variables
    public LayerMask m_TargetMask;

    public float m_damage = 100f;
    public float m_maxLifeTime = 5f;
    public float m_explosiveForce = 1f;
    public float m_explosionRadius = 1f;

    /* For Splash :
     * m_explosiveForce = 1000f;
     * m_ explosionRaidus = 5f;
     * m_maxDamage = m_damage;
    */
      
    #endregion

    // Use this for initialization
	void Start () 
    {
        Destroy(gameObject, m_maxLifeTime);
	}
	
    private void OnTriggerEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_TargetMask);

        for(int i=0; i < colliders.Length; i++)
        {
            Rigidbody targetRigidbody = colliders[i].GetComponent<Rigidbody>();

            if (!targetRigidbody)
                continue;

            targetRigidbody.AddExplosionForce(m_explosiveForce, transform.position, m_explosionRadius);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
