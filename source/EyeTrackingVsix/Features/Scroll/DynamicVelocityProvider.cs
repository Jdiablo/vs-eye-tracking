﻿using System;
using EyeTrackingVsix.Common.Configuration;

namespace EyeTrackingVsix.Features.Scroll
{
    public class DynamicVelocityProvider : IVelocityProvider
    {
        private readonly IScrollSettings _settings;

        private IRelativeGazeTransformer _relativeGaze;
        private VelocityCurve _curve;

        public DynamicVelocityProvider(IScrollSettings settings)
        {
            _settings = settings;
        }

        public bool HasVelocity => _relativeGaze != null;

        public double Velocity => HasVelocity ? CalculateVelocityBasedOnCurrentGaze() : 0;

        public void Start(IRelativeGazeTransformer relativeGaze)
        {
            _relativeGaze = relativeGaze;
            _curve = _settings.DynamicVelocityCurve;
        }

        public void Stop()
        {
            _relativeGaze = null;
        }

        private double CalculateVelocityBasedOnCurrentGaze()
        {
            var verticalOffset = _relativeGaze.NormalizedOffset.Y;

            // visualization of the curves: https://www.desmos.com/calculator/x8us9obuu0
            switch (_curve)
            {
                case VelocityCurve.Linear:
                    // nothing to do...
                    break;
                case VelocityCurve.Quadratic:
                    // apply Quadratic curve
                    verticalOffset = Math.Sign(verticalOffset) * (verticalOffset * verticalOffset);
                    break;
                case VelocityCurve.Sine:
                    // apply sine curve
                    verticalOffset = 0.5 * Math.Sign(verticalOffset) * (1 - Math.Cos(Math.PI * verticalOffset));
                    break;
                case VelocityCurve.Cubic:
                    // apply cubic curve
                    verticalOffset = verticalOffset * verticalOffset * verticalOffset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return _settings.Velocity * verticalOffset;
        }
    }
}
