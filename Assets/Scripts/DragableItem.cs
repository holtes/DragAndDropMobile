using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler ,IDragHandler
{
    [SerializeField] private float _scaleFactor = 2;
    [SerializeField] private float _animDuration = 1;
    [SerializeField] private float _gravityScale = 10;

    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private RectTransform _rect;
    private Vector3 _baseScale;
    private Vector3 _increasedScale;

    public static Action OnDragItemBegin;
    public static Action OnDragItemEnd;

    //������������� ����� � ��������� ���������� � ������������ � �������� ��������
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rect = GetComponent<RectTransform>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = _rect.rect.size;
        _baseScale = _rect.localScale;
        _increasedScale = _rect.localScale * _scaleFactor;
    }

    //����������� ������� �� ������ �� ����� Drag
    public void OnDrag(PointerEventData eventData) => _rigidbody.MovePosition(Input.mousePosition);

    //������� �� ������ ����������� �������
    public void OnBeginDrag(PointerEventData eventData)
    {
        _rigidbody.gravityScale = 0;
        _rect.DOScale(_increasedScale, _animDuration);
        OnDragItemBegin?.Invoke();
    }

    //������� �� ����� ����������� �������
    public void OnEndDrag(PointerEventData eventData)
    {
        _rigidbody.gravityScale = _gravityScale;
        _rect.DOScale(_baseScale, _animDuration);
        OnDragItemEnd?.Invoke();
    }
}
