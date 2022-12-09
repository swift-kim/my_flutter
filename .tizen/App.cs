using Tizen.Flutter.Embedding;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

class App : NUIApplication
{
    NUIFlutterView flutterView1;
    NUIFlutterView flutterView2;

    protected override void OnCreate()
    {
        base.OnCreate();

        var container = new View();
        container.Layout = new LinearLayout()
        {
            LinearOrientation = LinearLayout.Orientation.Vertical,
        };
        Window.Instance.GetDefaultLayer().Add(container);
        FocusManager.Instance.EnableDefaultAlgorithm(true);

        // Button 1
        var button1 = new Button()
        {
            Text = "Button 1",
            IsSelectable = true,
            Focusable = true,
            FocusableInTouch = true,
        };
        container.Add(button1);
        FocusManager.Instance.SetCurrentFocusView(button1);

        // Button 2
        var button2 = new Button()
        {
            Text = "Button 2",
            IsSelectable = true,
            Focusable = true,
            FocusableInTouch = true,
        };
        container.Add(button2);

        // Run a Flutter view whose entry point is "main".
        flutterView1 = new NUIFlutterView()
        {
            Size2D = new Size2D(600, 400),
        };
        if (flutterView1.RunEngine())
        {
            GeneratedPluginRegistrant.RegisterPlugins(flutterView1.Engine);
            container.Add(flutterView1);
        }

        // Button 3
        var button3 = new Button()
        {
            Text = "Button 3",
            IsSelectable = true,
            Focusable = true,
            FocusableInTouch = true,
        };
        container.Add(button3);

        // Run another Flutter view whose entry point is "anotherMain".
        flutterView2 = new NUIFlutterView()
        {
            Engine = new FlutterEngine("anotherMain"),
            Size2D = new Size2D(600, 400),
        };
        if (flutterView2.RunEngine())
        {
            GeneratedPluginRegistrant.RegisterPlugins(flutterView2.Engine);
            container.Add(flutterView2);
        }
    }

    protected override void OnTerminate()
    {
        base.OnTerminate();

        if (flutterView1 != null)
        {
            flutterView1.Destroy();
        }
        if (flutterView2 != null)
        {
            flutterView2.Destroy();
        }
    }

    public void OnKeyEvent(object sender, Window.KeyEventArgs e)
    {
        if (e.Key.State == Key.StateType.Down)
        {
            Tizen.InternalLog.Info("ConsoleMessage", $"KeyEvent: ${e.Key.KeyPressedName}");
        }
    }

    static void Main(string[] args)
    {
        var app = new App();
        app.Run(args);
    }
}
