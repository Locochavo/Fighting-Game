
using UnityEngine;
using UnityEngine.UI;

public class HealhBar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprite;

    public void UpdateHealthBar(float maxhealth, float currenthealth)
    {
        _healthbarSprite.fillAmount = currenthealth / maxhealth;
    }
}

  
