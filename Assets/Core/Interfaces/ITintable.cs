using UnityEngine;

namespace Core.Interfaces
{
    public interface ITintable
    {
        void SetTint(Color color);
        void ResetTint();
    }
}