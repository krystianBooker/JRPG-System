﻿using Localization;
using Models.Saving;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(DialogManager))]
    public class GameManager : MonoBehaviour
    {
        #region Singleton

        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                Initialize();
            }
        }

        #endregion

        [SerializeField]
        public Languages language;
    
        public LocalizationManager localizationManager;

        [SerializeField]
        public GameState gameState;
        
        private void Initialize()
        {
            localizationManager = new LocalizationManager(language);
            localizationManager.Initialize();

            SaveManager.SaveGame(gameState, true);
            SaveManager.SaveGame(gameState);
            SaveManager.GetSaveFileNames();
        }
    }
}