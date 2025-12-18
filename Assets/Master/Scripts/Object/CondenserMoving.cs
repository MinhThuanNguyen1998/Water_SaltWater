using TMPro;
using UnityEngine;

public class CondenserMoving : MonoBehaviour
{
    [SerializeField] private Renderer m_BoundaryCube;
    [SerializeField] private DragCategory m_DragCategory = DragCategory.None;
    [SerializeField] private float m_RotateSpeed = 0.3f;

    [Header("Logic Flags")]
    [SerializeField] private bool m_EnableMoveY = true;
    [SerializeField] private bool m_EnableRotateZ = true;

    private Vector3 m_Offset;
    private Bounds m_Bounds;
    private float m_LastMouseY;
    public bool m_IsDragging = false;

    private void Awake()
    {
        if (m_BoundaryCube == null)
        {
            GameObject boundary = GameObject.FindGameObjectWithTag("BoundaryOfRing");
            if (boundary != null) m_BoundaryCube = boundary.GetComponent<Renderer>();
            else Debug.Log("Can not find Object with tag name is Boundary");
        }
    }
    private void Start()
    { 
        if (m_BoundaryCube != null) m_Bounds = m_BoundaryCube.bounds;
    }

    private void OnMouseDown()
    {
        if ((MouseDragLock.IsBlocked && m_DragCategory == DragCategory.ChemicalTools)|| MouseDragLock.IsLockedAfterStepsCompleted)return;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        m_Offset = transform.position - Camera.main.ScreenToWorldPoint(mousePosition);
        m_LastMouseY = Input.mousePosition.y;
        m_IsDragging = true;
    }
    private void OnMouseDrag()
    {
        if ((MouseDragLock.IsBlocked && m_DragCategory == DragCategory.ChemicalTools)|| MouseDragLock.IsLockedAfterStepsCompleted)
        {
            m_IsDragging = false;
            return;
        }
        if (!m_IsDragging) return;
        if (m_EnableMoveY) HandleMoveY();
        if (m_EnableRotateZ) HandleRotateZ();
        
    }
    private void OnMouseUp() => m_IsDragging = false;

    private void HandleMoveY()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePosition);
        float newY = worldMousePos.y + m_Offset.y;
        newY = Mathf.Clamp(newY, m_Bounds.min.y, m_Bounds.max.y);
        transform.position = new Vector3(
            transform.position.x,
            newY,
            transform.position.z
        );
    }
    private void HandleRotateZ()
    {
        float currentMouseY = Input.mousePosition.y;
        float deltaY = currentMouseY - m_LastMouseY;
        float zRotationDelta = -deltaY * m_RotateSpeed;
        transform.Rotate(0f, 0f, zRotationDelta, Space.Self);
        m_LastMouseY = currentMouseY;
    }
}
