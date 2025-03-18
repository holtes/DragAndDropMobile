using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private RectTransform _rect;
    private BoxCollider2D _collider;

    //Инициализация полей, выставление коллайдера в соответствии с размером объекта и подписка на события
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = _rect.rect.size;
        DragableItem.OnDragItemBegin += () => ChangeColliderState(false);
        DragableItem.OnDragItemEnd += () => ChangeColliderState(true);
    }

    //Включение/Выключение коллайдера у объекта
    private void ChangeColliderState(bool state) => _collider.enabled = state;
}
