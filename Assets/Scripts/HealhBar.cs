using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthBar(float currenthealth, float maxhealth)
    {
        float health = currenthealth / maxhealth;
        _healthbarSprite.fillAmount = Mathf.Clamp(health, 0f, 1f);
    }

    public void ResetHealthBar()
    {
        _healthbarSprite.fillAmount = Mathf.Clamp(1f, 0f, 1f);
    }
}


