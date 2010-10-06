using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace JoystickMach3Plugin {
    public partial class JoystickConfig : Form {
        public JoystickConfig() {
            InitializeComponent();

            var ports = SerialPort.GetPortNames();
            foreach (var port in ports) {
                portList.Items.Add(port);
            }
            masterVelocity.Text = Joystick.GetMasterVelocity().ToString();
            acceleration.Text = Joystick.GetAcceleration().ToString();
            maxVelocity.Text = Joystick.GetMaxVelocity().ToString();
        }

        private void okButton_Click(object sender, EventArgs e) {
            if (portList.SelectedItem != null) {
                var port = portList.SelectedItem;
                Joystick.SetPort((string)port);
            }
            try {
                Joystick.SetMasterVelocity(int.Parse(masterVelocity.Text));
            } catch (Exception ex) {
                MessageBox.Show("Could not set Master Velocity: " + ex.Message);
            }
            try {
                Joystick.SetAcceleration(int.Parse(acceleration.Text));
            } catch (Exception ex) {
                MessageBox.Show("Could not set Acceleration: " + ex.Message);
            }
            try {
                Joystick.SetMaxVelocity(int.Parse(maxVelocity.Text));
            } catch (Exception ex) {
                MessageBox.Show("Could not set MaxVelocity: " + ex.Message);
            }
            Joystick.SaveSettings();
            Joystick.Reinit();
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
