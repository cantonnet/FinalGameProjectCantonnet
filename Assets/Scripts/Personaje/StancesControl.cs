using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StancesControl : MonoBehaviour
{
    [SerializeField] private GameObject Shield;
    [SerializeField] private GameObject Sword;
    [SerializeField] private GameObject Bow;
    [SerializeField] private GameObject Arrows;
    [SerializeField] private GameObject Flecha;

    [SerializeField] private GameObject MagicShield;
    [SerializeField] private GameObject MagicEnchant;
    [SerializeField] private GameObject MagicFire;
    [SerializeField] private GameObject MagicSphere;

    [SerializeField] private GameObject MagicShieldOFF;
    [SerializeField] private GameObject MagicEnter;
    [SerializeField] private GameObject PreShotMagic;

    public Animator anim;

    private void Start() 
    {
        anim = GetComponent<Animator>();
        
    }
        private void FlechaON()
    {
        Flecha.gameObject.SetActive (true);
    }

     private void FlechaOFF()
    {
        Flecha.gameObject.SetActive (false);
    }

        private void ProShotON()
    {
        PreShotMagic.gameObject.SetActive (true);
    }

     private void ProShotOFF()
    {
        PreShotMagic.gameObject.SetActive (false);
    }

    private void MagicEnterON()
    {
        MagicEnter.gameObject.SetActive (true);
    }

     private void MagicEnterOFF()
    {
        MagicEnter.gameObject.SetActive (false);
    }

        private void ONShieldTrue()
    {
        MagicShieldOFF.gameObject.SetActive (true);
    }

     private void ONShieldFalse()
    {
        MagicShieldOFF.gameObject.SetActive (false);
    }

    private void WarriorOFF()
    {
        Sword.gameObject.SetActive (false);
        Shield.gameObject.SetActive (false);
    }

    private void WarriorON()
    {
        Sword.gameObject.SetActive (true);
        Shield.gameObject.SetActive (true);
    }

    private void ArcherOFF()
    {
        Bow.gameObject.SetActive (false);
        Arrows.gameObject.SetActive (false);
    }
    private void ArcherON()
    {
        Bow.gameObject.SetActive (true);
        Arrows.gameObject.SetActive (true);
    }

    private void MagicON()
    {
        MagicFire.gameObject.SetActive (true);
    }

    private void MagicOFF()
    {
        MagicFire.gameObject.SetActive (false);
    }

    private void MShieldON()
    {
        MagicShield.gameObject.SetActive (true);
        MagicSphere.gameObject.SetActive (true);
    }

    private void MShieldOFF()
    {
        MagicShield.gameObject.SetActive (false);
        MagicSphere.gameObject.SetActive (false);
    }

    private void MEnchantON()
    {
        MagicEnchant.gameObject.SetActive (true);
    }

    private void MEnchantOFF()
    {
        MagicEnchant.gameObject.SetActive (false);
    }

    

}
