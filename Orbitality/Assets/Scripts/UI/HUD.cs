using Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoSingleton<HUD>
    {
        [SerializeField] private Image _hp;
        [SerializeField] private Image _cd;
        
        public void UpdateHealth(float healthPercent)
        {
            _hp.fillAmount = healthPercent;
        }
        
        public void UpdateCooldown(float cooldownPercent)
        {
            _cd.fillAmount = cooldownPercent;
        }
    }
}