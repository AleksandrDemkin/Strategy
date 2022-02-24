using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UserControlSystem.Model;
using ISelectable = Abstractions.ISelectable;

namespace Assets.Scripts.UserControlSystem.Presenter
{
    public class BottomLeftPresenter : MonoBehaviour
    {
        [SerializeField] private Image _selectedImage;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _textHealth;
        [SerializeField] private Image _sliderBackground;
        [SerializeField] private Image _sliderFillImage;

        [SerializeField] private SelectableValue _selectedValue;

        private void Start()
        {
            _selectedValue.OnSelected += onSelected;
            onSelected(_selectedValue.CurrentValue);
        }

        private void onSelected(ISelectable selected)
        {
            _selectedImage.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _textHealth.enabled = selected != null;

            if (selected != null)
            {
                _selectedImage.sprite = selected.Icon;
                _textHealth.text = $"{selected.Health}/{selected.MaxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.MaxHealth;
                _healthSlider.value = selected.Health;
                var color = Color.Lerp(Color.red, Color.green, 
                    selected.Health / (float)selected.MaxHealth);
                _sliderBackground.color = color * 0.5f;
                _sliderFillImage.color = color;
            }
        }
    }


}
