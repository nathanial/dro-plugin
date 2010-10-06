using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Threading;

namespace JoystickMach3Plugin {

    public static class Joystick {
        readonly static JoystickListener _listener = new JoystickListener();
        static bool _initialized = false;
        readonly static object _joystickLock = new object();
        readonly static JoystickSettings _settings;
        const string SETTINGS_PATH = @"c:\Mach3\joystick.bin";

        static Joystick() {
            if (File.Exists(SETTINGS_PATH)) {
                using (var file = File.OpenRead(SETTINGS_PATH)) {
                    var formatter = new BinaryFormatter();
                    _settings = (JoystickSettings)formatter.Deserialize(file);
                }
            } else {
                _settings = new JoystickSettings();
                _settings.MaxVelocity = 1000000;
                _settings.Acceleration = 10000;
                _settings.MasterVelocity = 10000;
            }
        }

        public static void Init() {
            lock (_joystickLock) {
                if (!_initialized) {
                    _listener.Start(_settings.Port);
                    _initialized = true;
                }
            }
        }

        public static void Reinit() {
            lock (_joystickLock) {
                _listener.Stop();
                _listener.Start(_settings.Port);
                _initialized = true;
            }
        }

        public static Direction GetDirection(string axis) {
            return _listener.AxisState(axis).Direction;
        }

        public static void SetPort(string port) {
            _settings.Port = port;
        }

        public static void SetMaxVelocity(int velocity) {
            _settings.MaxVelocity = velocity;
        }

        public static void SetAcceleration(int accel) {
            _settings.Acceleration = accel;
        }

        public static void SetMasterVelocity(int velocity) {
            _settings.MasterVelocity = velocity;
        }

        public static int GetMaxVelocity() {
            return _settings.MaxVelocity;
        }

        public static int GetAcceleration() {
            return _settings.Acceleration;
        }

        public static int GetMasterVelocity() {
            return _settings.MasterVelocity;
        }

        public static void SaveSettings() {
            if (File.Exists(SETTINGS_PATH)) File.Delete(SETTINGS_PATH);
            using (var file = File.OpenWrite(SETTINGS_PATH)) {
                var formatter = new BinaryFormatter();
                formatter.Serialize(file, _settings);
            }
        }
    }

    [Serializable]
    class JoystickSettings {
        public string Port { get; set; }
        public int MaxVelocity { get; set; }
        public int Acceleration { get; set; }
        public int MasterVelocity { get; set; }
    }

    public enum Direction {
        NONE,
        FORWARD,
        BACKWARD
    }

    public class AxisState {
        public Direction Direction { get; set; }
        public AxisState Copy() {
            return new AxisState {
                Direction = this.Direction
            };
        }
    }

    public class JoystickState {
        public Dictionary<string, AxisState> AxisStates { get; private set; }
        public JoystickState() {
            AxisStates = new Dictionary<string, AxisState>();
            AxisStates["X1"] = new AxisState();
            AxisStates["X2"] = new AxisState();
            AxisStates["Y1"] = new AxisState();
            AxisStates["Y2"] = new AxisState();
            AxisStates["Z1"] = new AxisState();
            AxisStates["Z2"] = new AxisState();
            AxisStates["A1"] = new AxisState();
            AxisStates["A2"] = new AxisState();
        }
    }

    public class JoystickListener {
        readonly object _serialLock = new object();
        readonly object _stateLock = new object();

        readonly JoystickState _state = new JoystickState();
        SerialPort port;

        public void Start(string comport) {
            if (comport == null) return;
            lock (_serialLock) {
                if (port != null && port.IsOpen) {
                    port.Dispose();
                }
                port = new SerialPort(comport);
                port.BaudRate = 115200;
                port.DataReceived += OnDataReceived;
                try {
                    port.Open();
                } catch (Exception ex) {
                    MessageBox.Show("Error initializing Joystick: " + ex.Message);
                    port = null;
                }
            }
        }

        public void Stop() {
        }

        void OnDataReceived(object sender, SerialDataReceivedEventArgs args) {
            lock (_serialLock) {
                var lines = port.ReadExisting().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var l in lines) {
                    var line = l.Trim();
                    var axis = l.Substring(0, 2);
                    var direction = l.Substring(2, 1);
                    lock (_stateLock) {
                        var state = _state.AxisStates[axis];
                        switch (direction) {
                            case "0":
                                state.Direction = Direction.NONE;
                                break;
                            case "-":
                                state.Direction = Direction.BACKWARD;
                                break;
                            case "+":
                                state.Direction = Direction.FORWARD;
                                break;
                            default: break;
                        }
                    }
                }
            }
        }

        public AxisState AxisState(string axis) {
            lock (_stateLock) {
                return _state.AxisStates[axis].Copy();
            }
        }

        

    }
}
