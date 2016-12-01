using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CDnewTry : MonoBehaviour {

    public List<Skill> PhilippaSkills;
    public List<Skill> SimoneSkills;
    public List<Skill> SolveigSkills;
    public List<Skill> EliseSkills;
    // hardcoding- if there are more skills -> needs to do more dynamic

    private bool phiFluff = false;
    private bool phiAnger = false;

    void OnEnable()
    {
        Phillippa_Attack.FluffEvent += PhilippaFluff;
        Phillippa_Attack.RushEvent += PhilippaAnger;
    }

    void OnDisable()
    {
        Phillippa_Attack.FluffEvent -= PhilippaFluff;
        Phillippa_Attack.RushEvent -= PhilippaAnger;
    }

    void FixedUpdate()
    {
        PhilippaSkillsFixedUpdate();
        SimoneSkillsFixedUpdate();
        SolveigSkillsFixedUpdate();
        EliseSkillsFixedUpdate();
    }

    void Update()
    {
        SkillsUpdate();
    }

    public void SkillsUpdate()
    {
        foreach (Skill s in PhilippaSkills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
            }
        }
        foreach (Skill s in SimoneSkills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
            }
        }

        foreach (Skill s in SolveigSkills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
            }
        }

        foreach (Skill s in EliseSkills)
        {
            if (s.currentCoolDown < s.cooldown)
            {
                s.currentCoolDown += Time.deltaTime;
                s.skillIcon.fillAmount = s.currentCoolDown / s.cooldown;
            }
        } 

    }

    public void PhilippaSkillsFixedUpdate() // behövs skicka in tre bool om MArkus säger bools
    {
        if (phiFluff == true)
        {
            if (PhilippaSkills[0].currentCoolDown >= PhilippaSkills[0].cooldown)
            {
                //do something.
                PhilippaSkills[0].currentCoolDown = 0;
                phiFluff = false;
            }
        }
        else if (phiAnger == true)
        {
            if (PhilippaSkills[1].currentCoolDown >= PhilippaSkills[1].cooldown)
            {
                //do something.
                PhilippaSkills[1].currentCoolDown = 0;
                phiAnger = false;
                //Debug.Log("M is pressed");
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            if (PhilippaSkills[2].currentCoolDown >= PhilippaSkills[2].cooldown)
            {
                //do something.
                PhilippaSkills[2].currentCoolDown = 0;
            }
        }
    }

    public void SimoneSkillsFixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (SimoneSkills[0].currentCoolDown >= SimoneSkills[0].cooldown)
            {
                //do something.
                SimoneSkills[0].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            if (SimoneSkills[1].currentCoolDown >= SimoneSkills[1].cooldown)
            {
                //do something.
                SimoneSkills[1].currentCoolDown = 0;
                Debug.Log("M is pressed");
            }
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (SimoneSkills[2].currentCoolDown >= SimoneSkills[2].cooldown)
            {
                //do something.
                SimoneSkills[2].currentCoolDown = 0;
            }
        }
    }

    public void SolveigSkillsFixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (SolveigSkills[0].currentCoolDown >= SolveigSkills[0].cooldown)
            {
                //do something.
                SolveigSkills[0].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (SolveigSkills[1].currentCoolDown >= SolveigSkills[1].cooldown)
            {
                //do something.
                SolveigSkills[1].currentCoolDown = 0;
                Debug.Log("M is pressed");
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (SolveigSkills[2].currentCoolDown >= SolveigSkills[2].cooldown)
            {
                //do something.
                SolveigSkills[2].currentCoolDown = 0;
            }
        }
    }

    public void EliseSkillsFixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (EliseSkills[0].currentCoolDown >= EliseSkills[0].cooldown)
            {
                //do something.
                EliseSkills[0].currentCoolDown = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            if (EliseSkills[1].currentCoolDown >= EliseSkills[1].cooldown)
            {
                //do something.
                EliseSkills[1].currentCoolDown = 0;
                Debug.Log("M is pressed");
            }
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (EliseSkills[2].currentCoolDown >= EliseSkills[2].cooldown)
            {
                //do something.
                EliseSkills[2].currentCoolDown = 0;
            }
        }
    }

    #region PhilippaMethods
    public void PhilippaFluff()
    {
        phiFluff = true;
    }

    public void PhilippaAnger()
    {
        phiAnger = true;
    }
    #endregion
}

[System.Serializable]
public class Skill
{
    public float cooldown;
    public Image skillIcon;
    [HideInInspector]
    public float currentCoolDown;
}