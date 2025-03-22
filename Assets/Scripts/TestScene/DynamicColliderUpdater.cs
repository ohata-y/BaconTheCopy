using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class DynamicColliderUpdater : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        Vector2[] tmp = spriteRenderer.sprite.vertices;
        Debug.Log(string.Join(",", tmp.Select(n => n.ToString())));
    }

    void Update()
    {
        //Vector2[] tmp = spriteRenderer.sprite.vertices;
        //List<Vector2> path = new List<Vector2>();
        // Spriteが変更されたらColliderを更新
        //spriteRenderer.sprite.GetPhysicsShape(0, path);
        //Debug.Log(string.Join(",", tmp.Select(n => n.ToString())));
    }
}
