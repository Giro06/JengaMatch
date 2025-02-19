using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    [SerializeField] private GameObject handObject;

    [SerializeField] private Vector3 followOffset;

    public bool followMouseAnyway;
    public bool followMouse;
    public bool disableHand;

    private RectTransform _objectRect;
    private Camera _mainCam;
    private Vector3 _initHandScale;

    public float handAnimTime = 0.1f;

    private void Awake()
    {
        _mainCam = Camera.main;
        _objectRect = handObject.GetComponent<RectTransform>();

        _initHandScale = _objectRect.localScale;

        if (disableHand)
        {
            handObject.SetActive(false);
            
        }
    }

    private void Update()
    {
        Follow(_objectRect, handObject);

        if (Input.GetKeyDown(KeyCode.A))
        {
            ClickAnimation();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            DisableImage();
        }
        
        var view = _mainCam.ScreenToViewportPoint(Input.mousePosition);
        var isOutside = view.x < 0 || view.x > 1 || view.y < 0 || view.y > 1;
        
        if (followMouseAnyway && !isOutside)
        {
            _objectRect.position = Input.mousePosition + followOffset;
        }
    }

    private void Follow(RectTransform rectTransform, GameObject image)
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeHandScale(_initHandScale * 0.8f, true, animTime: handAnimTime);
        }
        else if (Input.GetMouseButton(0))
        {
            if (!image.activeSelf)
            {
                image.SetActive(true);
            }

            if (followMouse)
            {
                rectTransform.position = Input.mousePosition + followOffset;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ChangeHandScale(_initHandScale, true, () =>
            {
                if (disableHand)
                {
                    image.SetActive(false);
                }
            }
                ,animTime: handAnimTime);
        }
        
        
    }

    public void ClickAnimation()
    {
        ChangeHandScale(_initHandScale * 0.8f, true,
            () => ChangeHandScale(_initHandScale, true, DisableImage, animTime: handAnimTime), animTime: handAnimTime);
    }

    private void DisableImage()
    {
        if (disableHand)
        {
            handObject.SetActive(false);
        }
    }
    private void ChangeHandScale(Vector3 targetScale, bool animate = false, Action onComplete = null, float animTime = 1f, float delay = 0)
    {
        if (animate)
        {
            _objectRect.DOKill(true);
            _objectRect.DOScale(targetScale, animTime).SetDelay(delay).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
        }
        else
        {
            _objectRect.localScale = targetScale;
        }
    }
}
