using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnStancesSounds : MonoBehaviour
{
    /* 
        Son eventos de aviso para el animator de los sonidos del personaje
    
    */
    [SerializeField]
    AudioClip magicClipON;

    [SerializeField]
    AudioClip magicClipOff;

    [SerializeField]
    AudioClip magicfireON;

    [SerializeField]
    AudioClip magicshieldON;

    [SerializeField]
    AudioClip magicshieldOFF;

    [SerializeField]
    AudioClip SwordClipON;

    [SerializeField]
    AudioClip SwordClipOff;

    [SerializeField]
    AudioClip BowClipON;

    [SerializeField]
    AudioClip BowClipOff;

    [SerializeField]
    AudioClip TensarBow;

    [SerializeField]
    AudioClip[] TiroArcoClip;

    [SerializeField]
    AudioClip SonidoEquipar;

    [SerializeField]
    AudioClip DestensarBow;

    [SerializeField]
    AudioClip Woosh1;

    [SerializeField]
    AudioClip Woosh2;

    [SerializeField]
    AudioClip Woosh3;

    [SerializeField]
    AudioClip armormove1;

    [SerializeField]
    AudioClip EquiparEscudo;

    [SerializeField]
    AudioClip DesequiparEscudo;

    [SerializeField]
    AudioClip burstmagic;

    [SerializeField]
    AudioClip premagic;
    public bool burston = false;

    private AudioSource MagicSource;

    private void Awake()
    {
        MagicSource = GetComponent<AudioSource>();
    }

    private void BurstOn()
    {
        burston = true;
    }

    private void BurstOff()
    {
        burston = false;
    }

    private void burstsound()
    {
        AudioClip smagic = burstmagic;
        MagicSource.PlayOneShot(smagic);
    }

    private void prehechizo()
    {
        AudioClip smagic = premagic;
        MagicSource.PlayOneShot(smagic);
    }

    private void firemage()
    {
        AudioClip smagic = magicfireON;
        MagicSource.PlayOneShot(smagic);
    }

    private void shieldmageon()
    {
        AudioClip smagic = magicshieldON;
        MagicSource.PlayOneShot(smagic);
    }

    private void shieldmageoff()
    {
        AudioClip smagic = magicshieldOFF;
        MagicSource.PlayOneShot(smagic);
    }

    private void SonidoEquipo()
    {
        AudioClip smagic = SonidoEquipar;
        MagicSource.PlayOneShot(smagic);
    }

    private void Shieldup()
    {
        AudioClip smagic = EquiparEscudo;
        MagicSource.PlayOneShot(smagic);
    }

    private void Shielddown()
    {
        AudioClip smagic = DesequiparEscudo;
        MagicSource.PlayOneShot(smagic);
    }

    private void OnTensar()
    {
        AudioClip smagic = DestensarBow;
        MagicSource.PlayOneShot(smagic);
    }

    private void OffTensar()
    {
        AudioClip smagic = TensarBow;
        MagicSource.PlayOneShot(smagic);
    }

    private void Armormove1()
    {
        AudioClip smagic = armormove1;
        MagicSource.PlayOneShot(smagic);
    }

    private void Onmagic()
    {
        AudioClip smagic = magicClipON;
        MagicSource.PlayOneShot(smagic);
    }

    private void Offmagic()
    {
        AudioClip smagic = magicClipOff;
        MagicSource.PlayOneShot(smagic);
    }

    private void OnSword()
    {
        AudioClip smagic = SwordClipON;
        MagicSource.PlayOneShot(smagic);
    }

    private void OffSword()
    {
        AudioClip smagic = SwordClipOff;
        MagicSource.PlayOneShot(smagic);
    }

    private void OnBow()
    {
        AudioClip smagic = BowClipON;
        MagicSource.PlayOneShot(smagic);
    }

    private void OffBow()
    {
        AudioClip smagic = BowClipOff;
        MagicSource.PlayOneShot(smagic);
    }

    private void woosh1()
    {
        AudioClip smagic = Woosh1;
        MagicSource.PlayOneShot(smagic);
    }

    private void woosh2()
    {
        AudioClip smagic = Woosh2;
        MagicSource.PlayOneShot(smagic);
    }

    private void woosh3()
    {
        AudioClip smagic = Woosh3;
        MagicSource.PlayOneShot(smagic);
    }

    private void Shotbow()
    {
        AudioClip smagic = GetRandomClip();
        MagicSource.PlayOneShot(smagic);
    }

    private AudioClip GetRandomClip()
    {
        int index = Random.Range(0, TiroArcoClip.Length - 1);
        return TiroArcoClip[index];
    }
}
