using UnityEngine;
using System.Collections;

public class Weapon_Trigger : MonoBehaviour {

    GameObject m_player;
    Enemy_Health m_enemyHP;
    //public string button;
    public int m_playerNumber = 1;

    private int m_damage = 50;


    #region Start
    /// <summary>
    /// Prevents the weapon from triggering with the player
    /// </summary>
    void Start ()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), m_player.GetComponent<Collider>());
        //button = "Fire" + m_playerNumber;
	}

    #endregion

    /// <summary>
    /// On Trigger Stay checks EVERY frame not just on initial collision
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        //if(other.gameObject.CompareTag("Pick Up"))
        if(other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Ost");


            #region Fix later?
            //other.gameObject.SetActive(false);
            //if(Input.GetKeyUp(button))
            //{         
            //    Destroy(other.gameObject);
            //    Debug.Log("Bern");
            //}
            #endregion

            if (Input.GetKeyDown(KeyCode.C))
            {
                Destroy(other.gameObject);
                Debug.Log("kaka");      
            }

        }
        //if (other.GetComponent<Enemy_Health>())
        //{
        //    other.gameObject.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
        //    gameObject.SetActive(false);
        //}
    }
}
