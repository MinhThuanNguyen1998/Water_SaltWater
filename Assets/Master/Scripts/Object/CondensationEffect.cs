using System.Collections;
using LiquidVolumeFX;
using UnityEngine;

public class CondensationEffect : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_Liquid_Inside_Condenser;
    private float m_WaitingTimeToPlayCondensationEffect = 5f;
    private Coroutine m_CondensationCoroutine;
    
    public void TurnOnCondensationEffect()
    {
        m_CondensationCoroutine = StartCoroutine(CoroutinePlayCondensationtAfterDelay());
    }

    private IEnumerator CoroutinePlayCondensationtAfterDelay()
    {
        yield return new WaitForSeconds(m_WaitingTimeToPlayCondensationEffect);
        m_Liquid_Inside_Condenser.alpha = 1f;
    }
}
