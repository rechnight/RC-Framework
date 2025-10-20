// --------------- Copyright (C) RC --------------- //
// STRONG is what happens when you run out of weak! //

using UnityEngine.Audio;

namespace RCFramework.Tools
{
    public interface ISoundData
    {
        AudioResource Resource { get; }
        SoundChannel Channel { get; }
        SoundSettings Settings { get; }
    }
}
