﻿using Eyetracking.NET;
using EyeTrackingVsix.Common.Configuration;

namespace EyeTrackingVsix.Features.Scroll
{
    public class StaticVelocityProvider : IVelocityProvider
    {
        private readonly IScrollSettings _settings;

        public StaticVelocityProvider(IScrollSettings settings)
        {
            _settings = settings;
        }

        public bool HasVelocity { get; private set; }

        public double Velocity { get; private set; }
        
        public void Start(IRelativeGazeTransformer relativeGaze)
        {
            Velocity = relativeGaze.Direction.Y * _settings.Velocity;
            HasVelocity = true;
        }

        public void Stop()
        {
            Velocity = 0;
            HasVelocity = false;
        }
    }
}
