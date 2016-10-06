using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CDnewTry : MonoBehaviour {

    public List<Skill> skills;
    // hardcoding- if there are more skills -> needs to do more dynamic
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(skills[0].currentCoolDown >= skills[0].cooldown)
            {
                //do something.
                skills[0].currentCoolDown = 0;
            }
        }
    }

    void Update()
    {
        foreach (Skill s in skills)
        {
            if(s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
            }
        }
    }
}

[System.Serializable]
public class Skill
{
    public float cooldown;
    public Image skillIcon;
    [HideInInspector]
    public float currentCoolDown;
}