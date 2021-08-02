﻿using TMPro;
using UnityEngine;

namespace Localization
{
    public class UITextLocalization : MonoBehaviour
    {
        private void Start()
        {
            if (GameManager.Instance.enableLocalization)
            {
                UpdateKeysWithText();
            }
        }

        /// <summary>
        /// Used to refresh UI text when language has changed
        /// </summary>
        public void RefreshText()
        {
            if (GameManager.Instance.enableLocalization)
            {
                UpdateKeysWithText();
            }
        }

        /// <summary>
        /// Will find all UI elements and replace the keys with the localized text 
        /// </summary>
        private void UpdateKeysWithText()
        {
            var uiTMPTexts = GetComponentsInChildren<TMP_Text>();
            foreach (var uiTMPText in uiTMPTexts)
            {
                uiTMPText.text = LocalizationManager.GetTranslatedString(uiTMPText.text);
            }
        }
    }
}