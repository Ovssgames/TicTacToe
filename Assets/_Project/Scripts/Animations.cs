using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts
{
    public static class Animations
    {
        public static void AnimateSign(Transform obj, float duration = 0.5f, float rotationAngle = 30f)
        {
            Vector3 startScale = obj.localScale;
            Quaternion startRotation = obj.rotation;

            obj.localScale = Vector3.zero;
            obj.rotation = Quaternion.Euler(0, 0, rotationAngle);

            Sequence seq = DOTween.Sequence();
            seq.Append(obj.DOScale(startScale, duration).SetEase(Ease.OutBack));
            seq.Join(obj.DORotateQuaternion(startRotation, duration).SetEase(Ease.OutBack));
        }
    }
}