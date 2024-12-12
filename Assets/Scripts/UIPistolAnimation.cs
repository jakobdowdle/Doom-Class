using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPistolAnimation : MonoBehaviour {
    public Image m_Image;
    public Sprite[] m_SpriteArray;

    private float _swaySpeed = 9f;
    private float _moveDistance = 50f;
    private float _lerpSpeed = 5f;

    private bool _isMovingRight = true;
    private bool _isMovingUp = true;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool IsDone;

    private float m_OriginalX;
    private float m_OriginalY;

    void Start() {
        if (m_Image != null) {
            m_OriginalX = m_Image.rectTransform.anchoredPosition.x;
            m_OriginalY = m_Image.rectTransform.anchoredPosition.y;
        }
    }

    void Update() {
        if (PlayerController.Instance.moveDirection.x > .02 || PlayerController.Instance.moveDirection.x < -.02
            || PlayerController.Instance.moveDirection.z > .02 || PlayerController.Instance.moveDirection.z < -.02) {
            GunSway();
        } else {
            Vector2 targetPosition = new Vector2(m_OriginalX, m_OriginalY);
            m_Image.rectTransform.anchoredPosition = Vector2.Lerp(m_Image.rectTransform.anchoredPosition, targetPosition, Time.deltaTime * _lerpSpeed);
        }
    }

    void GunSway() {
        if (m_Image != null) {
            float currentX = m_Image.rectTransform.anchoredPosition.x;
            float stepX = (_swaySpeed * Time.deltaTime * (_isMovingRight ? 1 : -1)) * _swaySpeed;
            float newX = currentX + stepX;

            if (newX > m_OriginalX + _moveDistance) {
                newX = m_OriginalX + _moveDistance;
                _isMovingRight = false;
            } else if (newX < m_OriginalX - _moveDistance) {
                newX = m_OriginalX - _moveDistance;
                _isMovingRight = true;
            }

            float currentY = m_Image.rectTransform.anchoredPosition.y;
            float stepY = (_swaySpeed * Time.deltaTime * (_isMovingUp ? 1 : -1)) * (_swaySpeed / 4);
            float newY = currentY + stepY;

            if ((_isMovingRight && newX >= m_OriginalX) || (!_isMovingRight && newX <= m_OriginalX)) {
                _isMovingUp = true;
            } else if ((_isMovingRight && newX <= m_OriginalX) || (!_isMovingRight && newX >= m_OriginalX)) {
                _isMovingUp = false;
            }

            m_Image.rectTransform.anchoredPosition = new Vector2(newX, newY);
        }
    }

    public void PlayGunShot() {
        IsDone = false;
        StartCoroutine(PlayGunShotAnimation());
    }

    public void StopGunShot() {
        IsDone = true;
        StopCoroutine(PlayGunShotAnimation());
    }

    IEnumerator PlayGunShotAnimation() {
        yield return new WaitForSeconds(_swaySpeed);
        if (m_IndexSprite >= m_SpriteArray.Length) {
            m_IndexSprite = 0;
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (IsDone == false)
            m_CorotineAnim = StartCoroutine(PlayGunShotAnimation());
    }
}