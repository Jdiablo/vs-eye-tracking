﻿using System.Diagnostics;
using System.Windows;
using Eyetracking.NET;
using EyeTrackingVsix.Common;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;

namespace EyeTrackingVsix.Features.MoveCarret
{
    internal class GazeCaret
    {
        private readonly IWpfTextView _textView;
        private readonly KeyboardListener _keyboard;
        private readonly IEyetracker _eyetracker;

        public GazeCaret(IWpfTextView textView, KeyboardListener keyboard, IEyetracker eyetracker)
        {
            _textView = textView;
            _keyboard = keyboard;
            _eyetracker = eyetracker;

            _keyboard.CarretAction += OnCarretAction;
        }

        private void OnCarretAction()
        {
            var elm = _textView.VisualElement;
            if (!_eyetracker.IsLookingAt(elm)) return;

            var gazePoint = elm.GetRelativeGazePoint(_eyetracker);
            var gazePointInText = new Point(gazePoint.X + _textView.ViewportLeft, gazePoint.Y + _textView.ViewportTop);

            var lookingAtLine = _textView.TextViewLines.GetTextViewLineContainingYCoordinate(gazePointInText.Y);

            if (lookingAtLine == null)
            {
                Debug.WriteLine("Not found...");
                return;
            }

            SnapshotPoint? snapshotPoint = lookingAtLine.GetBufferPositionFromXCoordinate(gazePointInText.X);
            if (snapshotPoint.HasValue)
            {
                _textView.Caret.MoveTo(snapshotPoint.Value);
            }
        }
    }
}
