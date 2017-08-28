namespace CatchItV
{
    partial class Timer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnClose = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtBox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.btnReset);
            this.kryptonPanel.Controls.Add(this.btnClose);
            this.kryptonPanel.Controls.Add(this.btnStop);
            this.kryptonPanel.Controls.Add(this.lblCounter);
            this.kryptonPanel.Controls.Add(this.label1);
            this.kryptonPanel.Controls.Add(this.btnStart);
            this.kryptonPanel.Controls.Add(this.txtBox);
            this.kryptonPanel.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(464, 317);
            this.kryptonPanel.TabIndex = 0;
            this.kryptonPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel_Paint);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(333, 185);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 9;
            this.btnClose.Values.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(141, 185);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(90, 25);
            this.btnStop.TabIndex = 8;
            this.btnStop.Values.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblCounter
            // 
            this.lblCounter.Font = new System.Drawing.Font("Papyrus", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCounter.Location = new System.Drawing.Point(249, 6);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(203, 55);
            this.lblCounter.TabIndex = 7;
            this.lblCounter.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "Count Down";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(46, 185);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(90, 25);
            this.btnStart.TabIndex = 3;
            this.btnStart.Values.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnButton_Click);
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(217, 128);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(100, 20);
            this.txtBox.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(132, 128);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(55, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Starts in";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(237, 185);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 25);
            this.btnReset.TabIndex = 10;
            this.btnReset.Values.Text = "Reset";
            this.btnReset.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // Timer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 317);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Timer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCounter;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnClose;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnStart;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnReset;
        public ComponentFactory.Krypton.Toolkit.KryptonButton btnStop;
        public System.Windows.Forms.Timer timer1;
    }
}

