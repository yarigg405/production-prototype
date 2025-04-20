using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Assets.Code.Gameplay.SaveLoad.Infrastructure
{
    internal sealed class GameRepository : IGameRepository
    {
        private Dictionary<string, string> _serializedData = new();
        private JsonSerializerSettings _settings = new JsonSerializerSettings()
        {
            StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
        };

        void IGameRepository.SaveState(string savePath)
        {
            string json = JsonConvert.SerializeObject(_serializedData, Formatting.None, _settings);
            PlayerPrefs.SetString(savePath, json);
            PlayerPrefs.Save();
        }

        void IGameRepository.LoadState(string savePath)
        {
            if (PlayerPrefs.HasKey(savePath))
            {
                string json = PlayerPrefs.GetString(savePath);
                _serializedData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            else
            {
                _serializedData = new Dictionary<string, string>();
            }
        }

        void IGameRepository.SetData<T>(T value)
        {
            var json = JsonConvert.SerializeObject(value, Formatting.None, _settings);
            _serializedData[typeof(T).Name] = json;
        }

        T IGameRepository.GetData<T>()
        {
            if (_serializedData.TryGetValue(typeof(T).Name, out var json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default(T);
        }
    }
}