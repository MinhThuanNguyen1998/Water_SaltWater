using DG.Tweening;
using UnityEngine;

public class StandTrigger : BaseTrigger
{
    [SerializeField] private BurnerEffectController m_BurnerEffectController;
    [SerializeField] private Transform m_AnchorStand;
    [SerializeField] GameObject m_ParentStand;
    protected override void OnEnter(Collider other)
    {
        if(other.gameObject.tag == "Flask")
        {
            MouseDragLock.Block();
            Transform flask = other.transform.parent;
            flask.SetParent(m_ParentStand.transform);
            flask.DOLocalMove(m_AnchorStand.localPosition, 1f)
                 .SetEase(Ease.InOutSine);
            StepPlaceObjects.SetStandPlaced(true);
            m_BurnerEffectController.TurnOnBoilingEffect();
            AudioMainManager.Instance.PlayOnShot(SoundType.Place_Flask);
        }
    }
}
