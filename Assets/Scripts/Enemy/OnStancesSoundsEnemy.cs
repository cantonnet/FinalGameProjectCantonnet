using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnStancesSoundsEnemy : MonoBehaviour
{
    /* 
        Son eventos de aviso para el animator de los sonidos del enemigo
    
    */
    [SerializeField]
    AudioClip[] audioClip;
    
    [SerializeField]
    AudioClip magicClipON;

    [SerializeField]
    AudioClip magicClipOff;

    [SerializeField]
    AudioClip TensarBow;

    [SerializeField]
    AudioClip[] TiroArcoClip;

    [SerializeField]
    AudioClip DestensarBow;

    [SerializeField]
    AudioClip hitsound;

    [SerializeField]
    AudioClip Woosh1;

    [SerializeField]
    AudioClip Woosh2;

    [SerializeField]
    AudioClip Woosh3;

    [SerializeField]
    AudioClip muriendo;

    [SerializeField]
    AudioClip armormove1;

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

    private void prehechizo()
    {
        AudioClip smagic = premagic;
        MagicSource.PlayOneShot(smagic);
    }

    private void voicesuffering()
    {
        AudioClip smagic = muriendo;
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

    private void hitenemy()
    {
        AudioClip smagic = hitsound;
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

    private void footrun()
    { //aviso para animator para generar audio en los pasos al caminar
        AudioClip audioClip = GetRandomSound();
        MagicSource.PlayOneShot(audioClip);
    }

    private void walkrun()
    { //aviso para animator para generar audio en los pasos al correr
        AudioClip audioClip = GetRandomSound();
        MagicSource.PlayOneShot(audioClip);
    }

    private AudioClip GetRandomSound()
    {
        int index = Random.Range(0, audioClip.Length - 1);
        return audioClip[index];
    }
}
