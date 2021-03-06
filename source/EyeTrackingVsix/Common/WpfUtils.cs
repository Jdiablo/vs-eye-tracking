﻿using System.Windows;
using Eyetracking.NET;

namespace EyeTrackingVsix.Common
{
    public static class IEyetrackerExtensions
    {
        public static bool IsLookingAt(this IEyetracker eyetracker, FrameworkElement element)
        {
            var wpfGazePoint = WpfHelpers.GetRelativeGazePointForElement(eyetracker, element);
            return WpfHelpers.IsLookingAtElement(wpfGazePoint, element);
        }
    }

    public static class ScreenHelpers
    {
        public static Point GetGazePointInScreenPixels(IEyetracker eyetracker)
        {
            var w = System.Windows.Forms.Screen.PrimaryScreen;
            var gx = eyetracker.X * w.Bounds.Width;
            var gy = eyetracker.Y * w.Bounds.Height;

            return new Point(gx, gy);
        }
    }

    public static class WpfHelpers
    {
        public static bool IsLookingAtElement(Point relativeGazePoint, FrameworkElement element)
        {
            var rect = new Rect(0, 0, element.ActualWidth, element.ActualHeight);
            return rect.Contains(relativeGazePoint);
        }

        public static Point GetRelativeGazePointForElement(IEyetracker eyetracker, FrameworkElement element)
        {
            var screenGazePoint = ScreenHelpers.GetGazePointInScreenPixels(eyetracker);
            return element.PointFromScreen(screenGazePoint);
        }
    }
}
