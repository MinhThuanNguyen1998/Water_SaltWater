using DG.Tweening;
using UnityEngine;

public class StandTrigger : BaseTrigger
{
    [SerializeField] private Transform m_AnchorStand;
    [SerializeField] GameObject m_ParentStand;
    protected override void OnEnter(Collider other)
    {
        if(other.gameObject.tag == "Flask")
        {
            MouseDragLock.Block();
            Transform flask = other.transform.parent;
            flask.SetParent(m_ParentStand.transform);
            flask.DOMove(m_AnchorStand.position, 1f)
                 .SetEase(Ease.InOutSine)
                 .OnComplete(() =>
                 {
                     flask.localPosition = m_AnchorStand.localPosition;
                 });
            Step.GoToNextStep();

        }
    }
}
