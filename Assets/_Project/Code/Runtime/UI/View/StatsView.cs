using TMPro;
using UnityEngine;

namespace _Project.Code.Runtime.UI.View
{
    public class StatsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _strengthLabel;
        [SerializeField] private TextMeshProUGUI _staminaLabel;
        [SerializeField] private TextMeshProUGUI _wisdomLabel;

        public void SetAmountStrengthLabel(float value) => _strengthLabel.text = $"Strength: {value}";
        public void SetAmountStaminaLabel(float value)=> _staminaLabel.text = $"Stamina: {value}";
        public void SetAmountWisdomLabel(float value)=> _wisdomLabel.text = $"Wisdom: {value}";
    }
}