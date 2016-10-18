using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Elise_Attack : MonoBehaviour 
{
    #region Variables

    public Transform m_transformOrigin;                             // Where the attack will spawn on the character
    public List<Transform> m_targetList = new List<Transform>();    // List of all potential targets
    public Rigidbody m_bullet;                                      // The rigidbody of the projectile
    public Material m_bulletMaterial;

    Player_Movement m_playerMove;                                   // Used to manipulate movement from this class
    Bullet_Collide m_bulletCollision;

    private float m_AttackLaunchForce;                              // Speed of the projectile

    private bool m_autoAttackActive;                                // Flag for the Regular attack

    public double m_damage;                                         // Base damage per projectile
    private float timeStamp;
    private float coolDown;
    private float rateShoot;

    #endregion

    private void OnEnable()
    {
        m_AttackLaunchForce = 35f;
        m_damage = 10;
        m_playerMove = GetComponent<Player_Movement>();
        m_autoAttackActive = true;

    }
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
