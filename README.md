**Circle Time Selector Control to use in WPF applications**

By finger or by mouse.

![Demo Application Look](https://i.ibb.co/8x8svBk/WPF-Circle-Time-Selector.png)

Project in develop. The control will work with the code of WPF and Xamarin.Forms applications, and  demonstrate the use of common logic and ViewModel layer for applications running on different platforms: Windows, Linux, Mac OSX, Android and iOS.

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
**Title** - control description  
**MinutesFaceColor** - color of the minute face  
**HoursFaceColor** - color of the hour face  
**MinutesFaceBackgroundColor** - background color for the minutes face  
**HoursFaceBackgroundColor** - background color for the hours face

4) fresh initialized control shows the current time
5) retrieving the current indication via an event
````
pickerTP.OnTimeChange + = (TimeSpan time) => { Time = time; };
````
Time is your local property - see MainWindow.xaml.cs for example.  
For simplicity, the control has been named. Use command binding in your code.  
An example is in my WpfMvvmTest repository.
