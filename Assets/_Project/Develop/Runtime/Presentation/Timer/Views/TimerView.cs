using UnityEngine;
using TMPro;

namespace _Project.Develop.Runtime.Presentation.TimerFeature.Views
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timerText;

        public void SetTimer(float timerValue)
        {
            var formattedTime = System.TimeSpan.FromSeconds(timerValue).ToString(@"mm\:ss\.ff");
            _timerText.text = formattedTime;
        }
    }
}