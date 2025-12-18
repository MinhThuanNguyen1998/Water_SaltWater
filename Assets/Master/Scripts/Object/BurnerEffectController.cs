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
    private float m_WaitingTimeToPlayBoilingEffect = 15f;
    private float m_MaxTemperatureLevel = 165f;
    private float m_BoilingPoint = 0.32f;
    private Coroutine m_SmokeCoroutine;

    private void Awake() => m_FireParticleSystem.Stop();
   
    public void TurnOnEffect()
    {
        if (m_FireParticleSystem != null)
        {
            StopOutline();
            m_FireParticleSystem.Play();
            DeActiveLighter();
        }
        m_SmokeCoroutine = StartCoroutine(CoroutinePlayEffectAfterDelay());
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

         duration = Mathf.Max(
         0f,
         m_WaitingTimeToPlayBoilingEffect - 5f
     );

        m_Thermometer_Inside_Object.transform
            .DOScaleY(value, duration);
    }
}
