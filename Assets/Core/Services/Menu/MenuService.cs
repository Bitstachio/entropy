using System;
using Core.Events.Channels;
using Core.Events.Interfaces;

namespace Core.Services.Menu
{
    public sealed class MenuService : IMenuService
    {
        private readonly IEventPublisher<MenuOptionSelected> _menuOptionSelectedPublisher;

        public MenuService(IEventPublisher<MenuOptionSelected> menuOptionSelectedPublisher) =>
            _menuOptionSelectedPublisher = menuOptionSelectedPublisher;

        public void SelectOption(Action action)
        {
            _menuOptionSelectedPublisher.Publish(new MenuOptionSelected());
            action();
        }
    }
}