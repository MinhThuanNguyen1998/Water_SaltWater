using System.Collections;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public class CondensationEffectController : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_Liquid_Inside_Condenser;
    [SerializeField] private DropletSpawner m_DropletSpawner;
    [Header("StepPlaceObjects")]
    [SerializeField] private StepPlaceObjects m_StepPlaceObjects;
    [Header("LiquidAlpha")]
    private float m_DefaultLiquid = 0f;
    private float m_MaxLiquid = 1f;

    private Coroutine m_CondensationCoroutine;
    private Tween m_CondensationTween;
    private bool m_IsPlaying;
    private void Awake()
    {
        ResetEffect();
    }
    public void TurnOnCondensationEffect()
    {
        if (m_IsPlaying || !m_StepPlaceObjects.PipeConnectorPlaced || !m_StepPlaceObjects.BurnerUsed) return;
        m_IsPlaying = true;
        StopAllCondensation();
        m_CondensationCoroutine = StartCoroutine(CoroutinePlayCondensationAfterDelay());
    }
    public void TurnOffCondensationEffect()
    {
        m_IsPlaying = false;
        StopAllCondensation();
        ResetEffect();
    }
    private IEnumerator CoroutinePlayCondensationAfterDelay()
    {
        yield return new WaitForSeconds(Config.CondensationTime);
        if (!m_IsPlaying) yield break;
        PlayCondensationLoop();
    }
    private void PlayCondensationLoop()
    {
        m_CondensationTween?.Kill();
        m_Liquid_Inside_Condenser.level = m_MaxLiquid;
        m_Liquid_Inside_Condenser.alpha = m_MaxLiquid;
        m_CondensationTween = DOTween.Sequence()
            .Append(
                DOTween.To(
                    () => m_Liquid_Inside_Condenser.level,
                    x => m_Liquid_Inside_Condenser.level = x,
                    m_DefaultLiquid,
                    Config.CondensationTime
                ).SetEase(Ease.Linear)
            )
            .InsertCallback(Config.CondensationTime * 0.6f, () =>
            {
                m_DropletSpawner.SpawnDroplet();
            })
            .OnComplete(() =>
            {
                if (m_IsPlaying)
                    PlayCondensationLoop();
            });
        m_CondensationTween.Play();
    }
    private void StopAllCondensation()
    {
        if (m_CondensationCoroutine != null)
        {
            StopCoroutine(m_CondensationCoroutine);
            m_CondensationCoroutine = null;
        }
        m_CondensationTween?.Kill();
        m_CondensationTween = null;
    }
    private void ResetEffect()
    {
        m_Liquid_Inside_Condenser.alpha = m_DefaultLiquid;
        m_Liquid_Inside_Condenser.level = m_MaxLiquid; 
    }
    private void OnDisable() => StopAllCondensation();
}
