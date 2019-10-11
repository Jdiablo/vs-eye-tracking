![Logo](source/EyeTrackingVsix/Resources/logo-eye-code-90.png)

# Eye Tracking for Visual Studio

Extension for Visual Studio using eye tracking

## Status

Branch | Status | Download
------ | ------ | --------
master |  [![Build Status](https://danielsa.visualstudio.com/vs-eye-tracking/_apis/build/status/vs-eye-tracking-CI?branchName=master)](https://danielsa.visualstudio.com/vs-eye-tracking/_build/latest?definitionId=14&branchName=master) | [CI Build](http://vsixgallery.com/extension/65bd244c-48a0-46af-953a-0fb433e5343d/)
develop | [![Build Status](https://danielsa.visualstudio.com/vs-eye-tracking/_apis/build/status/vs-eye-tracking-CI?branchName=develop)](https://danielsa.visualstudio.com/vs-eye-tracking/_build/latest?definitionId=14&branchName=develop)

See the [change log](CHANGELOG.md) for changes and road map.

## Configuration

All features can be enabled or disabled. Some features has more parameters that can be tweaked. All options are available under the VIsual Studio tools menu.

    Tools -> Options... -> Eye tracking

![Options GUI](docs/options_gui.png)

## Features

All features are a based on what you can do with your keyboard when it is augmented by the input from an eye tracker.

### Scrolling

Keyboard: Double-tap and hold the right Ctrl-key

Basic scrolling. While holding down the Ctrl-key the document will scroll. If your gaze was directed in the upper half of the editor view, the scroll direction is up. If your gaze is directed to the lower half of the editur view, the scroll direction is down.

Since version 0.3.0 it is possible to select different profiles for the scroll velocity.

In Visual Studio, goto Tools -> Options... -> Eye tracking.

There you will find three differnt scroll types:

- _Static_: with no fancy acceleration/deacceleration just a constant scroll speed.
- _Linear_: You can specify how long it will take to accelerate to max scroll speed.
- _Exponential_: Has both acceleration and deacceleration (inertial).
- _Dynamic_: Continously modifies the scroll speed depending on distance to the vertical center of the document window.

### Move caret

Keyboard: Double-tap (and release) the right Ctrl-key

Basic way of moving the caret to where you look.

### Window focus

Keyboard: (currently shares the same command as Move caret)

Will set the window you look at as the active/focused window. This only applies to Visual Studio windows. A Visual Studio window can be free floating or docked in a window frame set. Supported windows include Document windows (usually code files) and Tool windows (Solution Explorer Output, Team Explorer etc).
