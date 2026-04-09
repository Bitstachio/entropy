using Core.Gameplay.Interfaces;
using UnityEngine;

namespace Features.Hazards.Rock.Interfaces
{
    public interface IRockFactory
    {
        ISpawnable Create();
    }
}