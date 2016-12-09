using UnityEngine;
using System.Collections.Generic;

public class SpicyWhisk : MonoBehaviour 
{
    public List<Transform> m_targetList = new List<Transform>();
    MeshRenderer mr;
    private bool meshActive = false;
    private float meshTimer = 0;

	// Use this for initialization
	void Start ()
    {
        mr = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (meshActive == true)
        {
            meshTimer += Time.deltaTime;

            if (meshTimer >= 0.2f)
            {
                mr.enabled = false;
                meshActive = false;
                meshTimer = 0f;
            }
        }
	}

    //void OnEnable()
    //{
    //    Phillippa_Attack.SplashEvent += ;
    //}

    //void OnDisable()
    //{
    //    Phillippa_Attack.SplashEvent -= ;
    //}

    //public void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        if (m_rushActive == true)
    //        {
    //            other.gameObject.GetComponent<EnemyHealth>().Hit(10);
    //        }
    //    }
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        if (m_rushActive == true)
    //        {
    //            m_rushActive = false;
    //        }
    //    }
    //}

    //void RemoveNullTarget()
    //{
    //    foreach (var target in m_targetList)
    //    {
    //        if (target == null)
    //        {
    //            m_targetList.Remove(target);
    //        }
    //    }
    //}
}
