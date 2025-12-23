using System.Collections;
using DG.Tweening;
using LiquidVolumeFX;
using UnityEngine;

public class CondensationEffect : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_Liquid_Inside_Condenser;
    [SerializeField] private float m_CondensationDuration = 10f;
    
    [Header("LiquidAlpha")]
    private float m_DefaultLiquid = 0f;
    private float m_MaxLiquid = 1f;
    
    private Coroutine m_CondensationCoroutine;
    private Tween m_CondensationTween;
    private bool m_IsPlaying;
    private void Awake() => ResetLiquid();
    
    public void TurnOnCondensationEffect()
    {
        if (m_IsPlaying) return;
        m_IsPlaying = true;
        StopAllCondensation();
        m_CondensationCoroutine = StartCoroutine(CoroutinePlayCondensationAfterDelay());
    }
    public void TurnOffCondensationEffect()
    {
        m_IsPlaying = false;
        StopAllCondensation();
        ResetLiquid();
    }
    private IEnumerator CoroutinePlayCondensationAfterDelay()
    {
        yield return new WaitForSeconds(Config.WAITING_TIME_TO_PLAY_CONDENSATION_EFFECT);
        if (!m_IsPlaying) yield break;
        PlayCondensationLoop();
    }
    private void PlayCondensationLoop()
    {
        m_CondensationTween?.Kill();
        m_Liquid_Inside_Condenser.level = m_MaxLiquid;
        m_Liquid_Inside_Condenser.alpha = m_MaxLiquid;
        m_CondensationTween = DOTween
            .To(
                () => m_Liquid_Inside_Condenser.level,
                x => m_Liquid_Inside_Condenser.level = x,
                m_DefaultLiquid,
                m_CondensationDuration
            )
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                if (m_IsPlaying)
                    PlayCondensationLoop();
            });
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
    private void ResetLiquid()
    {
        m_Liquid_Inside_Condenser.alpha = m_DefaultLiquid;
        m_Liquid_Inside_Condenser.level = m_MaxLiquid;
    }

    private void OnDisable() => StopAllCondensation();
}
