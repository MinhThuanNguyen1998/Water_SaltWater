using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public class BurnerEffectController : MonoBehaviour
{
    [Header("Effect")]
    [SerializeField] private ParticleSystem m_FireParticleSystem;
    [SerializeField] private LiquidVolume m_LiquidVolume;

    [Header("GameObject")]
    [SerializeField] private GameObject m_LighterMovingObject;
    [SerializeField] private GameObject m_Thermometer_Inside_Object;

    [Header("SoundEffect")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_AudioBoilingWater;

    [Header("StepPlaceObjects")]
    [SerializeField] private StepPlaceObjects m_StepPlaceObjects;

    private float m_MaxTemperatureLevel = 165f;
    private float m_BoilingPoint = 0.32f;
    private Coroutine m_BoilingCoroutine;

    private void Awake() => m_FireParticleSystem.Stop();
    public void TurnOnBoilingEffect() 
    {
        if(!m_FireParticleSystem.isPlaying) return;
        m_BoilingCoroutine = StartCoroutine(CoroutinePlayBoilingEffectAfterDelay());
    } 
    public void TurnOnFireEfect()
    {
        if (!m_FireParticleSystem.isPlaying) m_FireParticleSystem.Play();
        if (m_StepPlaceObjects.IsStandPlaced && m_BoilingCoroutine == null) m_BoilingCoroutine = StartCoroutine(CoroutinePlayBoilingEffectAfterDelay());
    }
    private IEnumerator CoroutinePlayBoilingEffectAfterDelay()
    {
        m_StepPlaceObjects.SetBurnerUsed(true);
        yield return new WaitForSeconds(Config.TemperatureRiseTime);
        SetTemperatureLevel(m_MaxTemperatureLevel, Config.TemperatureRiseTime);
        PlayLoopSoundBoilingWater();
        m_LiquidVolume.sparklingAmount = m_BoilingPoint;
    }
    public void PlayLoopSoundBoilingWater()
    {
        m_AudioSource.loop = true;
        m_AudioSource.clip = m_AudioBoilingWater;
        m_AudioSource.Play();
    }
    public void SetTemperatureLevel(float value, float duration)
    {
         duration = Mathf.Max(0f,Config.BoilingTime - 5f);
         m_Thermometer_Inside_Object.transform
            .DOScaleY(value, duration);
    }
}
