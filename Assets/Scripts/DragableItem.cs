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

    //Инициалищация полей и установка коллайдера в соответствии с размером картинки
    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rect = GetComponent<RectTransform>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = _rect.rect.size;
        _baseScale = _rect.localScale;
        _increasedScale = _rect.localScale * _scaleFactor;
    }

    //Перемещение объекта по физике во время Drag
    public void OnDrag(PointerEventData eventData) => _rigidbody.MovePosition(Input.mousePosition);

    //Событие на начало перемещения объекта
    public void OnBeginDrag(PointerEventData eventData)
    {
        _rigidbody.gravityScale = 0;
        _rect.DOScale(_increasedScale, _animDuration);
        OnDragItemBegin?.Invoke();
    }

    //Событие на конец перемещения объекта
    public void OnEndDrag(PointerEventData eventData)
    {
        _rigidbody.gravityScale = _gravityScale;
        _rect.DOScale(_baseScale, _animDuration);
        OnDragItemEnd?.Invoke();
    }
}
