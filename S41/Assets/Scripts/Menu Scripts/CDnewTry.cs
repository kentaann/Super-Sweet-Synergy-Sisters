using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CDnewTry : MonoBehaviour {

    public List<Skill> PhilippaSkills;
    public List<Skill> SimoneSkills;
    public List<Skill> SolveigSkills;
    public List<Skill> EliseSkills;
    public List<Skill> AllSkills;
    // hardcoding- if there are more skills -> needs to do more dynamic

    private bool phiFluff = false;
    private bool phiAnger = false;
    private bool simChannel = false;
    private bool solFlower = false;
    private bool solLove = false;
    private bool eliTrap = false;
    private bool eliMulti = false;

    void OnEnable()
    {
        Phillippa_Attack.FluffEvent += PhilippaFluff;
        Phillippa_Attack.RushEvent += PhilippaAnger;
        Simone_Attack.ChannelEvent += SimoneChannel;
        Solveig_Attack.FlowerEvent += SolveigFlower;
        Solveig_Attack.LoveEvent += SolveigLove;
        Elise_Attack.TrapEvent += EliseTrap;
        Elise_Attack.MultiEvent += EliseMulti;
    }

    void OnDisable()
    {
        Phillippa_Attack.FluffEvent -= PhilippaFluff;
        Phillippa_Attack.RushEvent -= PhilippaAnger;
        Simone_Attack.ChannelEvent -= SimoneChannel;
        Solveig_Attack.FlowerEvent -= SolveigFlower;
        Solveig_Attack.LoveEvent -= SolveigLove;
        Elise_Attack.TrapEvent -= EliseTrap;
        Elise_Attack.MultiEvent -= EliseMulti;
    }

    //void Start()
    //{
    //    foreach (Skill s in AllSkills)
    //    {
    //        s.cooldown = 100;
    //    }
    //}

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
        //else if (Input.GetKeyDown(KeyCode.N))
        //{
        //    if (PhilippaSkills[2].currentCoolDown >= PhilippaSkills[2].cooldown)
        //    {
        //        //do something.
        //        PhilippaSkills[2].currentCoolDown = 0;
        //    }
        //}
    }

    public void SimoneSkillsFixedUpdate()
    {
        if (simChannel == true)
        {
            if (SimoneSkills[0].currentCoolDown >= SimoneSkills[0].cooldown)
            {
                //do something.
                SimoneSkills[0].currentCoolDown = 0;
                simChannel = false;
            }
        }
        //else if (Input.GetKeyDown(KeyCode.X))
        //{
        //    if (SimoneSkills[1].currentCoolDown >= SimoneSkills[1].cooldown)
        //    {
        //        //do something.
        //        SimoneSkills[1].currentCoolDown = 0;
        //        Debug.Log("M is pressed");
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.C))
        //{
        //    if (SimoneSkills[2].currentCoolDown >= SimoneSkills[2].cooldown)
        //    {
        //        //do something.
        //        SimoneSkills[2].currentCoolDown = 0;
        //    }
        //}
    }

    public void SolveigSkillsFixedUpdate()
    {
        if (solFlower == true)
        {
            if (SolveigSkills[0].currentCoolDown >= SolveigSkills[0].cooldown)
            {
                //do something.
                SolveigSkills[0].currentCoolDown = 0;
                solFlower = false;
            }
        }
        else if (solLove == true)
        {
            if (SolveigSkills[1].currentCoolDown >= SolveigSkills[1].cooldown)
            {
                //do something.
                SolveigSkills[1].currentCoolDown = 0;
                solLove = false;
                //Debug.Log("M is pressed");
            }
        }
        //else if (Input.GetKeyDown(KeyCode.O))
        //{
        //    if (SolveigSkills[2].currentCoolDown >= SolveigSkills[2].cooldown)
        //    {
        //        //do something.
        //        SolveigSkills[2].currentCoolDown = 0;
        //    }
        //}
    }

    public void EliseSkillsFixedUpdate()
    {
        if (eliTrap == true)
        {
            if (EliseSkills[0].currentCoolDown >= EliseSkills[0].cooldown)
            {
                //do something.
                EliseSkills[0].currentCoolDown = 0;
                eliTrap = false;
            }
        }
        else if (eliMulti == true)
        {
            if (EliseSkills[1].currentCoolDown >= EliseSkills[1].cooldown)
            {
                //do something.
                EliseSkills[1].currentCoolDown = 0;
                eliMulti = false;
                //Debug.Log("M is pressed");
            }
        }
        //else if (Input.GetKeyDown(KeyCode.O))
        //{
        //    if (EliseSkills[2].currentCoolDown >= EliseSkills[2].cooldown)
        //    {
        //        //do something.
        //        EliseSkills[2].currentCoolDown = 0;
        //    }
        //}
    }

    #region Event Methods
    public void PhilippaFluff()
    {
        phiFluff = true;
    }

    public void PhilippaAnger()
    {
        phiAnger = true;
    }

    public void SimoneChannel()
    {
        simChannel = true;
    }

    public void SolveigFlower()
    {
        solFlower = true;
    }

    public void SolveigLove()
    {
        solLove = true;
    }

    public void EliseTrap()
    {
        eliTrap = true;
    }

    public void EliseMulti()
    {
        eliMulti = true;
    }
    #endregion
}

[System.Serializable]
public class Skill
{
    public float cooldown;
    public Image skillIcon;
    //[HideInInspector]
    public float currentCoolDown;
}