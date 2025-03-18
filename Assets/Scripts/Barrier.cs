using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    private RectTransform _rect;
    private BoxCollider2D _collider;

    //������������� �����, ����������� ���������� � ������������ � �������� ������� � �������� �� �������
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = _rect.rect.size;
        DragableItem.OnDragItemBegin += () => ChangeColliderState(false);
        DragableItem.OnDragItemEnd += () => ChangeColliderState(true);
    }

    //���������/���������� ���������� � �������
    private void ChangeColliderState(bool state) => _collider.enabled = state;
}
