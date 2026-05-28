using System;
using System.Threading.Tasks;
using Core.Events.Channels;
using Core.Events.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Features.Menu
{
    public static class MenuUtils
    {
        public static async void SelectScene(string scene, IEventPublisher<MenuOptionSelected> publisher, int delay = 0)
        {
            try
            {
                publisher.Publish(new MenuOptionSelected());
                await Task.Delay(delay);
                SceneManager.LoadScene(scene);
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load scene '{scene}': {e.Message}");
            }
        }
    }
}