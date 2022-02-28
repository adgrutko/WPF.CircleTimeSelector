**Circle Time Selector Control to use in WPF applications**
By finger or by mouse.

![Demo Application Look](https://i.ibb.co/8x8svBk/WPF-Circle-Time-Selector.png)

Project in develop. The control will work with the code of WPF and Xamarin.Forms applications, and  demonstrate the use of common logic and ViewModel layer for an application running on different platforms: Windows, Linux, Mac OSX, Android and iOS applications.

How to use:
1) Include a reference to CircleTimeSelector
2) in XAML declare a namespace reference as below:
```
xmlns: circleSelector = "clr-namespace: CircleTimeSelector; assembly = CircleTimeSelector"
```
3) in XAML insert a control
```
<circleSelector: TimePicker
Title = "from"
MinutesFaceColor = "# FF3BD1FF" HoursFaceColor = "# FF1CACD9"
MinutesFaceBackgroundColor = "# FFDDDDDD" HoursFaceBackgroundColor = "# FFCCCCCC" />
```
where:
**Title** - shield description
**MinutesFaceColor** - color of the minute dial
**HoursFaceColor** - the color of the hour dial
**MinutesFaceBackgroundColor** - background color for the minute wheel
**HoursFaceBackgroundColor** - The background color for the hour dial
4) light initiated shows the current hour
5) retrieving the current indication via an event
````
pickerTP.OnTimeChange + = (TimeSpan time) => { Time = time; };
````
Time is your local property - see MainWindow.xaml.cs for example.
For simplicity, the control has been named. Use command binding in your code.
An example is in my WpfMvvmTest repository.
