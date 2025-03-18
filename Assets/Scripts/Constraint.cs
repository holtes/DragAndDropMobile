using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constraint : MonoBehaviour
{
    //Инициалищация полей и установка коллайдера в соответствии с размером объекта
    private void Awake()
    {
        var rect = GetComponent<RectTransform>();
        var collider = GetComponent<BoxCollider2D>();
        collider.size = rect.rect.size;
    }
}
