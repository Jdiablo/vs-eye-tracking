﻿using System;
using System.Windows;
using Eyetracking.NET;
using EyeTrackingVsix.Common;

namespace EyeTrackingVsix.Features.Scroll
{
    public class CenterOfElementGazeTransformer : IRelativeGazeTransformer
    {
        private readonly FrameworkElement _elm;
        private readonly IEyetracker _eyetracker;

        public CenterOfElementGazeTransformer(FrameworkElement elm, IEyetracker eyetracker)
        {
            _elm = elm;
            _eyetracker = eyetracker;

        }

        public bool HasGaze => _eyetracker.IsLookingAt(_elm);

        public (int X, int Y) Direction
        {
            get
            {
                var offset = NormalizedOffset;
                return (Math.Sign(offset.X), Math.Sign(offset.Y));
            }
        }
        
        public Vector NormalizedOffset
        {
            get
            {
                var gazePoint = _elm.GetRelativeGazePoint(_eyetracker);
                if (WpfHelpers.IsLookingAtElement(gazePoint, _elm))
                {
                    // 0 .. 1
                    var normalized = new Vector(
                        gazePoint.X / _elm.ActualWidth,
                        gazePoint.Y / _elm.ActualHeight);

                    // -1.0 .. 1.0
                    return new Vector(normalized.X - 0.5, normalized.Y - 0.5) * 2;
                }

                return new Vector();
            }
        }
    }
}
