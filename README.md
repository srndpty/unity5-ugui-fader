Fader.cs
=========

This is a simple fader utility script for unity5 using uGUI.

How To Use
---------
1. Create Canvas, set Sort Order about 5000, and delete GraphicRaycaster component.
2. Create a new gameobject as a child of the canvas.
3. Attach this fader script to it.
4. Set its RectTransform like this: Anchor minX 0, maxX 1, minY 0, maxY 1, left top right buttom 0
5. Now you can call fader from other script simply like this:
// field
[SerializeField] Fader fader;
// in some function
fader.Begin(Fader.Style.BlackOut, 2f, "MainMenu");

where each arguments means:
1st arg specifies fader style.
    BlackOut
    BlackIn
    WhiteOut
    WhiteIn
    BlackOutHalf
    Clear
    Fill
2nd arg sets fade time by seconds.
3rd arg is optional. If you pass this argument, this script tries to switch to the scene specified by string.

License
---------
The code is available under the MIT license.
