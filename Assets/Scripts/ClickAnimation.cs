using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{
    [SerializeField] private float _animationTime = 1.5f;
    [SerializeField] private float _animationSpeed = 2;
    private TMP_Text _text;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        StartCoroutine(DiyngAnimation());
    }
    private IEnumerator DiyngAnimation()
    {
        for (float i = 0; i < _animationTime; i += Time.deltaTime)
        {
            transform.position += Vector3.up * _animationSpeed * Time.deltaTime;
            Color currentColor = _text.color;
            currentColor.a = 1 - i / _animationTime;
            _text.color = currentColor;
            yield return null;
        }
        Destroy(gameObject);
    }
}
