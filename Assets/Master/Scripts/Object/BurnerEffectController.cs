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

    [Header("Outline")]
    [SerializeField] private List<Outline> m_ListOutline;

    [Header("GameObject")]
    [SerializeField] private GameObject m_LighterMovingObject;
    [SerializeField] private GameObject m_Thermometer_Inside_Object;

    [Header("SoundEffect")]
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_AudioBoilingWater;

    [Header("SoundEffect")]
    [SerializeField] private StepPlaceObjects m_StepPlaceObjects;

    private float m_WaitingTimeToPlayBoilingEffect = 15f;
    private float m_MaxTemperatureLevel = 165f;
    private float m_BoilingPoint = 0.32f;
    private Coroutine m_BoilingCoroutine;

    private void Awake() => m_FireParticleSystem.Stop();
    public void TurnOnBoilingEffect() 
    {
        if(!m_FireParticleSystem.isPlaying) return;
        m_BoilingCoroutine = StartCoroutine(CoroutinePlayEffectAfterDelay());
    } 
    public void TurnOnFireEfect()
    {
        if (m_FireParticleSystem == null) return;
        if (!m_FireParticleSystem.isPlaying) m_FireParticleSystem.Play();
        if (m_StepPlaceObjects.IsStandPlaced && m_BoilingCoroutine == null) m_BoilingCoroutine = StartCoroutine(CoroutinePlayEffectAfterDelay());
    }
    private IEnumerator CoroutinePlayEffectAfterDelay()
    {
        yield return new WaitForSeconds(m_WaitingTimeToPlayBoilingEffect);
        SetTemperatureLevel(m_MaxTemperatureLevel, m_WaitingTimeToPlayBoilingEffect);
        yield return new WaitForSeconds(m_WaitingTimeToPlayBoilingEffect);
        PlayLoopSoundBoilingWater();
        m_LiquidVolume.sparklingAmount = m_BoilingPoint;
    }
    private void StopOutline()
    {
        foreach(Outline outline in m_ListOutline)
        {
            Color c = outline.OutlineColor;
            c.a = 0f;
            outline.OutlineColor = c;
        }
    }
    private void DeActiveLighter()
    {
        m_LighterMovingObject.transform
            .DOScale(Vector3.zero, 0.2f)
            .SetEase(Ease.InBack)
            .OnComplete(() =>
            {
                m_LighterMovingObject.SetActive(false);
            });
    }
    public void PlayLoopSoundBoilingWater()
    {
        m_AudioSource.loop = true;
        m_AudioSource.clip = m_AudioBoilingWater;
        m_AudioSource.Play();
    }
    public void SetTemperatureLevel(float value, float duration)
    {
         duration = Mathf.Max(0f,m_WaitingTimeToPlayBoilingEffect - 5f);
         m_Thermometer_Inside_Object.transform
            .DOScaleY(value, duration);
    }
}
