using System;

namespace Core.Services.Menu
{
    public interface IMenuService
    {
        void SelectOption(Action action);
    }
}