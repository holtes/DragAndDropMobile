using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour
{
    //������������� ����� � ��������� ���������� � ������������ � �������� �������
    private void Awake()
    {
        var rect = GetComponent<RectTransform>();
        var collider = GetComponent<BoxCollider2D>();
        collider.size = rect.rect.size;
    }
}
