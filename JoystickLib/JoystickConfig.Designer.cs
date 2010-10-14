namespace JoystickMach3Plugin {
    partial class JoystickConfig {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.portList = new System.Windows.Forms.ListBox();
            this.maxVelocity = new System.Windows.Forms.TextBox();
            this.acceleration = new System.Windows.Forms.TextBox();
            this.masterVelocity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.reverseAxesBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(186, 252);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(267, 252);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // portList
            // 
            this.portList.FormattingEnabled = true;
            this.portList.Location = new System.Drawing.Point(95, 12);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(247, 108);
            this.portList.TabIndex = 0;
            // 
            // maxVelocity
            // 
            this.maxVelocity.Location = new System.Drawing.Point(95, 137);
            this.maxVelocity.Name = "maxVelocity";
            this.maxVelocity.Size = new System.Drawing.Size(247, 20);
            this.maxVelocity.TabIndex = 2;
            // 
            // acceleration
            // 
            this.acceleration.Location = new System.Drawing.Point(95, 163);
            this.acceleration.Name = "acceleration";
            this.acceleration.Size = new System.Drawing.Size(247, 20);
            this.acceleration.TabIndex = 3;
            // 
            // masterVelocity
            // 
            this.masterVelocity.Location = new System.Drawing.Point(95, 189);
            this.masterVelocity.Name = "masterVelocity";
            this.masterVelocity.Size = new System.Drawing.Size(247, 20);
            this.masterVelocity.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Max Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Acceleration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Master Velocity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Port List";
            // 
            // reverseAxesBox
            // 
            this.reverseAxesBox.AutoSize = true;
            this.reverseAxesBox.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.reverseAxesBox.Location = new System.Drawing.Point(95, 215);
            this.reverseAxesBox.Name = "reverseAxesBox";
            this.reverseAxesBox.Size = new System.Drawing.Size(92, 17);
            this.reverseAxesBox.TabIndex = 10;
            this.reverseAxesBox.Text = "Reverse Axes";
            this.reverseAxesBox.UseVisualStyleBackColor = true;
            // 
            // JoystickConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 287);
            this.Controls.Add(this.reverseAxesBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.masterVelocity);
            this.Controls.Add(this.acceleration);
            this.Controls.Add(this.maxVelocity);
            this.Controls.Add(this.portList);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "JoystickConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DRO Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox portList;
        private System.Windows.Forms.TextBox maxVelocity;
        private System.Windows.Forms.TextBox masterVelocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox acceleration;
        private System.Windows.Forms.CheckBox reverseAxesBox;
    }
}