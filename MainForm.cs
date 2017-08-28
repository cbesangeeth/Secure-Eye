/******************************************************
                  DirectShow .NET
		     
*******************************************************/
//				 MainForm

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using ImgProcessing;
using Timing;

using DShowNET;
using DShowNET.Device;
using System.Media;

namespace CatchItV
{

/// <summary> Summary description for MainForm. </summary>
public class MainForm : System.Windows.Forms.Form, ISampleGrabberCB
{
	bool dontSaveNext=true,firstRun=true;
	private  Int32 cPercent=0,minSave=96,count=0,count2=0;
	string saveTime="";
	private Counter counter=new Counter();
	private  float sec=0;
	Bitmap a;
	Bitmap wanted;
	private System.Windows.Forms.Splitter splitter1;
	private System.Windows.Forms.ToolBar toolBar;
    private System.Windows.Forms.Panel videoPanel;
	private System.Windows.Forms.ToolBarButton toolBarBtnTune;
	private System.Windows.Forms.ToolBarButton toolBarBtnGrab;
	private System.Windows.Forms.ToolBarButton toolBarBtnSave;
	private System.Windows.Forms.ToolBarButton toolBarBtnSep;
    private System.Windows.Forms.ImageList imgListToolBar;
    private System.Windows.Forms.Timer timer1;
	private System.Windows.Forms.Label lblTimerValue;
	private System.Windows.Forms.TrackBar trckBarTimer;
	private System.Windows.Forms.TrackBar trckBarSaveValue;
    private ComponentFactory.Krypton.Toolkit.KryptonButton btnStart;
    private ComponentFactory.Krypton.Toolkit.KryptonButton btnStop;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel lblPercent;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
    private Label label1;
    private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel Time;
    private Label lblTotalTime;
    private Label lblTime;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel7;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCount;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel8;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSavePercent;
    private PictureBox pictureBox2;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
    private PictureBox pictureBox;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    private PictureBox pictureBox1;
    private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
    private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox2;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
    private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
	private System.ComponentModel.IContainer components;

	public MainForm()
	{
		// Required for Windows Form Designer support
		InitializeComponent();
		
		trckBarSaveValue.Value=cPercent;
		lblSavePercent.Text=cPercent+"%";
		
		timer1.Interval=trckBarTimer.Value;
		lblTimerValue.Text=trckBarTimer.Value.ToString();
		System.Windows.Forms.ToolBarButtonClickEventArgs ee=new ToolBarButtonClickEventArgs(toolBarBtnGrab);
		toolBar_ButtonClick(toolBarBtnGrab,ee);
	}

	/// <summary> Clean up any resources being used. </summary>
	protected override void Dispose( bool disposing )
	{
		if( disposing )
		{
			CloseInterfaces();
			
			if (components != null) 
			{
				components.Dispose();
			}
		}
		base.Dispose( disposing );
	}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.toolBarBtnTune = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnGrab = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSep = new System.Windows.Forms.ToolBarButton();
            this.toolBarBtnSave = new System.Windows.Forms.ToolBarButton();
            this.imgListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.videoPanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.btnStop = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblTimerValue = new System.Windows.Forms.Label();
            this.trckBarTimer = new System.Windows.Forms.TrackBar();
            this.trckBarSaveValue = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPercent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.Time = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.kryptonLabel7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblCount = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblSavePercent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarSaveValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).BeginInit();
            this.kryptonGroupBox2.Panel.SuspendLayout();
            this.kryptonGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarBtnTune,
            this.toolBarBtnGrab,
            this.toolBarBtnSep,
            this.toolBarBtnSave});
            this.toolBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toolBar.DropDownArrows = true;
            this.toolBar.Enabled = false;
            this.toolBar.ImageList = this.imgListToolBar;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(1076, 42);
            this.toolBar.TabIndex = 0;
            this.toolBar.Visible = false;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // toolBarBtnTune
            // 
            this.toolBarBtnTune.Enabled = false;
            this.toolBarBtnTune.ImageIndex = 0;
            this.toolBarBtnTune.Name = "toolBarBtnTune";
            this.toolBarBtnTune.Text = "Tune";
            this.toolBarBtnTune.ToolTipText = "TV tuner dialog";
            // 
            // toolBarBtnGrab
            // 
            this.toolBarBtnGrab.ImageIndex = 1;
            this.toolBarBtnGrab.Name = "toolBarBtnGrab";
            this.toolBarBtnGrab.Text = "Grab";
            this.toolBarBtnGrab.ToolTipText = "Grab picture from stream";
            // 
            // toolBarBtnSep
            // 
            this.toolBarBtnSep.Enabled = false;
            this.toolBarBtnSep.Name = "toolBarBtnSep";
            this.toolBarBtnSep.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarBtnSave
            // 
            this.toolBarBtnSave.Enabled = false;
            this.toolBarBtnSave.ImageIndex = 2;
            this.toolBarBtnSave.Name = "toolBarBtnSave";
            this.toolBarBtnSave.Text = "Save";
            this.toolBarBtnSave.ToolTipText = "Save image to file";
            // 
            // imgListToolBar
            // 
            this.imgListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListToolBar.ImageStream")));
            this.imgListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListToolBar.Images.SetKeyName(0, "");
            this.imgListToolBar.Images.SetKeyName(1, "");
            this.imgListToolBar.Images.SetKeyName(2, "");
            // 
            // videoPanel
            // 
            this.videoPanel.BackColor = System.Drawing.Color.Black;
            this.videoPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.videoPanel.Location = new System.Drawing.Point(172, 108);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Size = new System.Drawing.Size(746, 290);
            this.videoPanel.TabIndex = 1;
            this.videoPanel.Resize += new System.EventHandler(this.videoPanel_Resize);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 42);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 561);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(44, 167);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 62);
            this.btnStop.TabIndex = 12;
            this.btnStop.Values.Text = "&Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(44, 85);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 59);
            this.btnStart.TabIndex = 11;
            this.btnStart.Values.Text = "&Start";
            this.btnStart.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // lblTimerValue
            // 
            this.lblTimerValue.Location = new System.Drawing.Point(975, 78);
            this.lblTimerValue.Name = "lblTimerValue";
            this.lblTimerValue.Size = new System.Drawing.Size(40, 24);
            this.lblTimerValue.TabIndex = 10;
            this.lblTimerValue.Text = "400";
            // 
            // trckBarTimer
            // 
            this.trckBarTimer.LargeChange = 300;
            this.trckBarTimer.Location = new System.Drawing.Point(969, 97);
            this.trckBarTimer.Maximum = 1000;
            this.trckBarTimer.Minimum = 7;
            this.trckBarTimer.Name = "trckBarTimer";
            this.trckBarTimer.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trckBarTimer.Size = new System.Drawing.Size(45, 240);
            this.trckBarTimer.SmallChange = 10;
            this.trckBarTimer.TabIndex = 9;
            this.trckBarTimer.Value = 400;
            this.trckBarTimer.ValueChanged += new System.EventHandler(this.trckBarTimer_ValueChanged);
            // 
            // trckBarSaveValue
            // 
            this.trckBarSaveValue.Enabled = false;
            this.trckBarSaveValue.Location = new System.Drawing.Point(969, 388);
            this.trckBarSaveValue.Maximum = 100;
            this.trckBarSaveValue.Name = "trckBarSaveValue";
            this.trckBarSaveValue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trckBarSaveValue.Size = new System.Drawing.Size(45, 206);
            this.trckBarSaveValue.TabIndex = 3;
            this.trckBarSaveValue.ValueChanged += new System.EventHandler(this.trckBarSaveValue_ValueChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 600;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPercent
            // 
            this.lblPercent.Location = new System.Drawing.Point(963, 362);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(51, 20);
            this.lblPercent.TabIndex = 19;
            this.lblPercent.Values.Text = "%%%%";
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel5.Location = new System.Drawing.Point(925, 336);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(139, 20);
            this.kryptonLabel5.TabIndex = 25;
            this.kryptonLabel5.Values.Text = "Difference Percentage";
            // 
            // kryptonLabel6
            // 
            this.kryptonLabel6.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.kryptonLabel6.Location = new System.Drawing.Point(947, 54);
            this.kryptonLabel6.Name = "kryptonLabel6";
            this.kryptonLabel6.Size = new System.Drawing.Size(91, 20);
            this.kryptonLabel6.TabIndex = 26;
            this.kryptonLabel6.Values.Text = "Shutter speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 43);
            this.label1.TabIndex = 27;
            this.label1.Text = "Secure Eye";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(12, 404);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.kryptonLabel1);
            this.kryptonGroupBox1.Panel.Controls.Add(this.Time);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblTotalTime);
            this.kryptonGroupBox1.Panel.Controls.Add(this.lblTime);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(144, 180);
            this.kryptonGroupBox1.TabIndex = 28;
            this.kryptonGroupBox1.Text = "Image Processing Time";
            this.kryptonGroupBox1.Values.Heading = "Image Processing Time";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(25, 71);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(105, 29);
            this.kryptonLabel1.TabIndex = 21;
            this.kryptonLabel1.Values.Text = "Total Time";
            // 
            // Time
            // 
            this.Time.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.Time.Location = new System.Drawing.Point(37, 12);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(56, 29);
            this.Time.TabIndex = 20;
            this.Time.Values.Text = "Time";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTotalTime.Location = new System.Drawing.Point(7, 103);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(123, 24);
            this.lblTotalTime.TabIndex = 18;
            this.lblTotalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotalTime.UseMnemonic = false;
            // 
            // lblTime
            // 
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTime.Location = new System.Drawing.Point(7, 45);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(123, 24);
            this.lblTime.TabIndex = 16;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTime.UseMnemonic = false;
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(741, 7);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(276, 20);
            this.kryptonLabel7.TabIndex = 29;
            this.kryptonLabel7.Values.Text = "No. Of Detected / Total No. Of Picture Processed";
            // 
            // lblCount
            // 
            this.lblCount.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
            this.lblCount.Location = new System.Drawing.Point(850, 32);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(42, 29);
            this.lblCount.TabIndex = 30;
            this.lblCount.Values.Text = "0/0";
            // 
            // kryptonLabel8
            // 
            this.kryptonLabel8.Location = new System.Drawing.Point(38, 15);
            this.kryptonLabel8.Name = "kryptonLabel8";
            this.kryptonLabel8.Size = new System.Drawing.Size(100, 20);
            this.kryptonLabel8.TabIndex = 31;
            this.kryptonLabel8.Values.Text = "Save Percentage";
            // 
            // lblSavePercent
            // 
            this.lblSavePercent.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldPanel;
            this.lblSavePercent.Location = new System.Drawing.Point(64, 42);
            this.lblSavePercent.Name = "lblSavePercent";
            this.lblSavePercent.Size = new System.Drawing.Size(32, 20);
            this.lblSavePercent.TabIndex = 32;
            this.lblSavePercent.Values.Text = "0 %";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(498, 3);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(104, 20);
            this.kryptonLabel2.TabIndex = 21;
            this.kryptonLabel2.Values.Text = "Grey Scale Image";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(6, 3);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(82, 20);
            this.kryptonLabel3.TabIndex = 22;
            this.kryptonLabel3.Values.Text = "Actual Image";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(254, 3);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(109, 20);
            this.kryptonLabel4.TabIndex = 23;
            this.kryptonLabel4.Values.Text = "Comparing Image";
            // 
            // kryptonGroupBox2
            // 
            this.kryptonGroupBox2.Location = new System.Drawing.Point(172, 404);
            this.kryptonGroupBox2.Name = "kryptonGroupBox2";
            // 
            // kryptonGroupBox2.Panel
            // 
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel4);
            this.kryptonGroupBox2.Panel.Controls.Add(this.pictureBox1);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel3);
            this.kryptonGroupBox2.Panel.Controls.Add(this.pictureBox);
            this.kryptonGroupBox2.Panel.Controls.Add(this.kryptonLabel2);
            this.kryptonGroupBox2.Panel.Controls.Add(this.pictureBox2);
            this.kryptonGroupBox2.Size = new System.Drawing.Size(752, 182);
            this.kryptonGroupBox2.TabIndex = 24;
            this.kryptonGroupBox2.Text = "Comparison";
            this.kryptonGroupBox2.Values.Heading = "Comparison";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(254, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(6, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(240, 88);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(498, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(240, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Location = new System.Drawing.Point(44, 255);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(75, 62);
            this.kryptonButton1.TabIndex = 33;
            this.kryptonButton1.Values.Text = "&Reset";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click_1);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.Location = new System.Drawing.Point(44, 336);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(75, 62);
            this.kryptonButton2.TabIndex = 34;
            this.kryptonButton2.Values.Text = "&Close";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1076, 603);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.trckBarSaveValue);
            this.Controls.Add(this.lblSavePercent);
            this.Controls.Add(this.trckBarTimer);
            this.Controls.Add(this.kryptonLabel8);
            this.Controls.Add(this.lblTimerValue);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.kryptonLabel6);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.kryptonGroupBox1);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kryptonGroupBox2);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.toolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Secure Eye";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.trckBarTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckBarSaveValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            this.kryptonGroupBox1.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2.Panel)).EndInit();
            this.kryptonGroupBox2.Panel.ResumeLayout(false);
            this.kryptonGroupBox2.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox2)).EndInit();
            this.kryptonGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new Form1());
	}

	private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		this.Hide();
		CloseInterfaces();
	}

		/// <summary> detect first form appearance, start grabber. </summary>
	private void MainForm_Activated(object sender, System.EventArgs e)
	{
		if( firstActive )
			return;
		firstActive = true;

		if( ! DsUtils.IsCorrectDirectXVersion() )
		{
			MessageBox.Show( this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			this.Close(); return;
		}

		if( ! DsDev.GetDevicesOfCat( FilterCategory.VideoInputDevice, out capDevices ) )
		{
			MessageBox.Show( this, "No video capture devices found!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
			this.Close(); return;
		}

		DsDevice dev = null;
		if( capDevices.Count == 1 )
			dev = capDevices[0] as DsDevice;
		else
		{
			DeviceSelector selector = new DeviceSelector( capDevices );
			selector.ShowDialog( this );
			dev = selector.SelectedDevice;
		}

		if( dev == null )
		{
			this.Close(); return;
		}

		if( ! StartupVideo( dev.Mon ) )
			this.Close();
	}

	private void videoPanel_Resize(object sender, System.EventArgs e)
	{
		ResizeVideoWindow();
	}


		/// <summary> handler for toolbar button clicks. </summary>
	private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
	{
		Trace.WriteLine( "!!BTN: toolBar_ButtonClick" );
		
		int hr;
		if( sampGrabber == null )
			return;

		if( e.Button == toolBarBtnGrab )
		{
			Trace.WriteLine( "!!BTN: toolBarBtnGrab" );

			if( savedArray == null )
			{
				int size = videoInfoHeader.BmiHeader.ImageSize;
				if( (size < 1000) || (size > 16000000) )
					return;
				savedArray = new byte[ size + 64000 ];
			}

			toolBarBtnSave.Enabled = false;
			Image old = pictureBox.Image;
			pictureBox.Image = null;
			if( old != null )
				old.Dispose();

			toolBarBtnGrab.Enabled = false;
			captured = false;
			hr = sampGrabber.SetCallback( this, 1 );
		}
		else if( e.Button == toolBarBtnSave )
		{
			Trace.WriteLine( "!!BTN: toolBarBtnSave" );

			SaveFileDialog sd = new SaveFileDialog();
			sd.FileName = @"DsNET.bmp";
			sd.Title = "Save Image as...";
			sd.Filter = "Bitmap file (*.bmp)|*.bmp";
			sd.FilterIndex = 1;
			if( sd.ShowDialog() != DialogResult.OK )
				return;

			pictureBox.Image.Save( sd.FileName, ImageFormat.Bmp );		// save to new bmp file
		}
		else if( e.Button == toolBarBtnTune )
		{
			if( capGraph != null )
				DsUtils.ShowTunerPinDialog( capGraph, capFilter, this.Handle );
		}

	}

    private void playSimpleSound()
    {
        SoundPlayer simpleSound = new SoundPlayer(@"C:\Users\Elcot\Desktop\Secure Eye\burglar_alarm.wav");
        simpleSound.Play();
    }


		/// <summary> capture event, triggered by buffer callback. </summary>
	
	void OnCaptureDone()
	{
		Trace.WriteLine( "!!DLG: OnCaptureDone" );
		try 
		{
			toolBarBtnGrab.Enabled = true;
			int hr;
			if( sampGrabber == null )
				return;
			hr = sampGrabber.SetCallback( null, 0 );

			int w = videoInfoHeader.BmiHeader.Width;
			int h = videoInfoHeader.BmiHeader.Height;
			if( ((w & 0x03) != 0) || (w < 32) || (w > 4096) || (h < 32) || (h > 4096) )
				return;
			//get Image
			int stride = w * 3;
			GCHandle handle = GCHandle.Alloc( savedArray, GCHandleType.Pinned );
			int scan0 = (int) handle.AddrOfPinnedObject();
			scan0 += (h - 1) * stride;
			Bitmap b = new Bitmap( w, h, -stride, PixelFormat.Format24bppRgb, (IntPtr) scan0 );
			handle.Free();	
			
				
			pictureBox1.Image = b;
			b=new Bitmap(pictureBox1.Image);
			
			if(firstRun)
			{
				firstRun=false;
				pictureBox.Image=b;
				a=new Bitmap(b);
			}
			else
			{
				count++;
				wanted=new Bitmap(b.Width,b.Height);
				Int32 percent;
				counter.Start();
				ImageProcessing imageProcessing=new ImageProcessing(a,b,wanted);
				imageProcessing.CompareUnsafeFaster(out percent);
				percent=(Int32)(percent*100/(b.Width*b.Height));
				counter.Stop();
				pictureBox2.Image=wanted;
				if((percent>=cPercent)&&!dontSaveNext)
				{
					//imageProcessing.Save(Application.StartupPath+"\\wanted\\Wanted"+count+"-"+percent+"-"+System.DateTime.Now.Millisecond.ToString()+".jpg");
					saveTime=count+"-"+percent+"-"+System.DateTime.Now.Millisecond.ToString()+".jpg";
					b.Save(Application.StartupPath+"\\Wanted\\first"+saveTime,System.Drawing.Imaging.ImageFormat.Jpeg);
					a.Save(Application.StartupPath+"\\Wanted\\second"+saveTime,System.Drawing.Imaging.ImageFormat.Jpeg);
					count2++;
				//	Microsoft.VisualBasic.Interaction.Beep();

                    playSimpleSound();
					dontSaveNext=true;
				//	lblSaveOrNot.Text="don'tSaveNext";
					
				}
				else
				{
					dontSaveNext=false;
					//lblSaveOrNot.Text="SaveNext";
				}
				this.lblTime.Text=counter.ToString();
				sec+=counter.Seconds;
				lblTotalTime.Text=sec.ToString()+" Seconds.";
				counter.Clear();
				
				lblCount.Text=count2+"/"+count;
				lblPercent.Text=percent+"%";
				
				//the below code compute the minimum save percent
				//because the difference between webcams,
				//daylight
				
				if((percent-minSave)>5)
				{
					try
					{
						trckBarSaveValue.Value=percent+5;
						minSave=percent;
					}
					catch{}
				}
				
				//else if(percent<minSave)
				try
				{
					minSave=(minSave+percent)/2;
					trckBarSaveValue.Value=minSave+5;
				}
				catch{}
				
				
			}
			
			pictureBox.Image=b;
			a=new Bitmap(pictureBox.Image);
			
			savedArray=null;
			
		}
		catch 
		{
			
		}
	}



		/// <summary> start all the interfaces, graphs and preview window. </summary>
	bool StartupVideo( UCOMIMoniker mon )
	{
		int hr;
		try {
			if( ! CreateCaptureDevice( mon ) )
				return false;

			if( ! GetInterfaces() )
				return false;

			if( ! SetupGraph() )
				return false;

			if( ! SetupVideoWindow() )
				return false;

			#if DEBUG
				DsROT.AddGraphToRot( graphBuilder, out rotCookie );		// graphBuilder capGraph
			#endif
			
			hr = mediaCtrl.Run();
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			bool hasTuner = DsUtils.ShowTunerPinDialog( capGraph, capFilter, this.Handle );
			toolBarBtnTune.Enabled = hasTuner;

			return true;
		}
		catch
		{
			return false;
		}
	}

		/// <summary> make the video preview window to show in videoPanel. </summary>
	bool SetupVideoWindow()
	{
		int hr;
		try {
			// Set the video window to be a child of the main window
			hr = videoWin.put_Owner( videoPanel.Handle );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			// Set video window style
			hr = videoWin.put_WindowStyle( WS_CHILD | WS_CLIPCHILDREN );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			// Use helper function to position video window in client rect of owner window
			ResizeVideoWindow();

			// Make the video window visible, now that it is properly positioned
			hr = videoWin.put_Visible( DsHlp.OATRUE );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
     
			return true;
		}
		catch
		{
			return false;
		}
	}


		/// <summary> build the capture graph for grabber. </summary>
	bool SetupGraph()
	{
		int hr;
		try {
			hr = capGraph.SetFiltergraph( graphBuilder );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			hr = graphBuilder.AddFilter( capFilter, "Ds.NET Video Capture Device" );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			DsUtils.ShowCapPinDialog( capGraph, capFilter, this.Handle );

			AMMediaType media = new AMMediaType();
			media.majorType	= MediaType.Video;
			media.subType	= MediaSubType.RGB24;
			media.formatType = FormatType.VideoInfo;		// ???
			hr = sampGrabber.SetMediaType( media );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			hr = graphBuilder.AddFilter( baseGrabFlt, "Ds.NET Grabber" );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			Guid cat = PinCategory.Preview;
			Guid med = MediaType.Video;
			hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, null ); // baseGrabFlt 
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			cat = PinCategory.Capture;
			med = MediaType.Video;
			hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, baseGrabFlt ); // baseGrabFlt 
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			media = new AMMediaType();
			hr = sampGrabber.GetConnectedMediaType( media );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );
			if( (media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero) )
				throw new NotSupportedException( "Unknown Grabber Media Format" );

			videoInfoHeader = (VideoInfoHeader) Marshal.PtrToStructure( media.formatPtr, typeof(VideoInfoHeader) );
			Marshal.FreeCoTaskMem( media.formatPtr ); media.formatPtr = IntPtr.Zero;

			hr = sampGrabber.SetBufferSamples( false );
			if( hr == 0 )
				hr = sampGrabber.SetOneShot( false );
			if( hr == 0 )
				hr = sampGrabber.SetCallback( null, 0 );
			if( hr < 0 )
				Marshal.ThrowExceptionForHR( hr );

			return true;
		}
		catch
		{
			return false;
		}
	}


		/// <summary> create the used COM components and get the interfaces. </summary>
	bool GetInterfaces()
	{
		Type comType = null;
		object comObj = null;
		try {
			comType = Type.GetTypeFromCLSID( Clsid.FilterGraph );
			if( comType == null )
				throw new NotImplementedException( @"DirectShow FilterGraph not installed/registered!" );
			comObj = Activator.CreateInstance( comType );
			graphBuilder = (IGraphBuilder) comObj; comObj = null;

			Guid clsid = Clsid.CaptureGraphBuilder2;
			Guid riid = typeof(ICaptureGraphBuilder2).GUID;
			comObj = DsBugWO.CreateDsInstance( ref clsid, ref riid );
			capGraph = (ICaptureGraphBuilder2) comObj; comObj = null;

			comType = Type.GetTypeFromCLSID( Clsid.SampleGrabber );
			if( comType == null )
				throw new NotImplementedException( @"DirectShow SampleGrabber not installed/registered!" );
			comObj = Activator.CreateInstance( comType );
			sampGrabber = (ISampleGrabber) comObj; comObj = null;

			mediaCtrl	= (IMediaControl)	graphBuilder;
			videoWin	= (IVideoWindow)	graphBuilder;
			mediaEvt	= (IMediaEventEx)	graphBuilder;
			baseGrabFlt	= (IBaseFilter)		sampGrabber;
			return true;
		}
		catch
		{
			return false;
		}
		finally
		{
			if( comObj != null )
				Marshal.ReleaseComObject( comObj ); comObj = null;
		}
	}

		/// <summary> create the user selected capture device. </summary>
	bool CreateCaptureDevice( UCOMIMoniker mon )
	{
		object capObj = null;
		try {
			Guid gbf = typeof( IBaseFilter ).GUID;
			mon.BindToObject( null, null, ref gbf, out capObj );
			capFilter = (IBaseFilter) capObj; capObj = null;
			return true;
		}
		catch
		{
			return false;
		}
		finally
		{
			if( capObj != null )
				Marshal.ReleaseComObject( capObj ); capObj = null;
		}

	}



		/// <summary> do cleanup and release DirectShow. </summary>
	void CloseInterfaces()
	{
		int hr;
		try {
			#if DEBUG
				if( rotCookie != 0 )
					DsROT.RemoveGraphFromRot( ref rotCookie );
			#endif

			if( mediaCtrl != null )
			{
				hr = mediaCtrl.Stop();
				mediaCtrl = null;
			}

			if( mediaEvt != null )
			{
				hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );
				mediaEvt = null;
			}

			if( videoWin != null )
			{
				hr = videoWin.put_Visible( DsHlp.OAFALSE );
				hr = videoWin.put_Owner( IntPtr.Zero );
				videoWin = null;
			}

			baseGrabFlt = null;
			if( sampGrabber != null )
				Marshal.ReleaseComObject( sampGrabber ); sampGrabber = null;

			if( capGraph != null )
				Marshal.ReleaseComObject( capGraph ); capGraph = null;

			if( graphBuilder != null )
				Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

			if( capFilter != null )
				Marshal.ReleaseComObject( capFilter ); capFilter = null;
			
			if( capDevices != null )
			{
				foreach( DsDevice d in capDevices )
					d.Dispose();
				capDevices = null;
			}
		}
		catch
		{}
	}

		/// <summary> resize preview video window to fill client area. </summary>
	void ResizeVideoWindow()
	{
		if( videoWin != null )
		{
			Rectangle rc = videoPanel.ClientRectangle;
			videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
		}
	}

		/// <summary> override window fn to handle graph events. </summary>
	protected override void WndProc( ref Message m )
	{
		if( m.Msg == WM_GRAPHNOTIFY )
			{
			if( mediaEvt != null )
				OnGraphNotify();
			return;
			}
		base.WndProc( ref m );
	}

		/// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
	void OnGraphNotify()
	{
		DsEvCode	code;
		int p1, p2, hr = 0;
		do
		{
			hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
			if( hr < 0 )
				break;
			hr = mediaEvt.FreeEventParams( code, p1, p2 );
		}
		while( hr == 0 );
	}

		/// <summary> sample callback, NOT USED. </summary>
	int ISampleGrabberCB.SampleCB( double SampleTime, IMediaSample pSample )
	{
		Trace.WriteLine( "!!CB: ISampleGrabberCB.SampleCB" );
		return 0;
	}

		/// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
	int ISampleGrabberCB.BufferCB( double SampleTime, IntPtr pBuffer, int BufferLen )
	{
		if( captured || (savedArray == null) )
		{
			Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB" );
			return 0;
		}

		captured = true;
		bufferedSize = BufferLen;
		Trace.WriteLine( "!!CB: ISampleGrabberCB.BufferCB  !GRAB! size = " + BufferLen.ToString() );
		if( (pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length) )
			Marshal.Copy( pBuffer, savedArray, 0, BufferLen );
		else
			Trace.WriteLine( "    !!!GRAB! failed " );
		this.BeginInvoke( new CaptureDone( this.OnCaptureDone ) );
		return 0;
	}


		/// <summary> flag to detect first Form appearance </summary>
	private bool					firstActive;

		/// <summary> base filter of the actually used video devices. </summary>
	private IBaseFilter				capFilter;

		/// <summary> graph builder interface. </summary>
	private IGraphBuilder			graphBuilder;

		/// <summary> capture graph builder interface. </summary>
	private ICaptureGraphBuilder2	capGraph;
	private ISampleGrabber			sampGrabber;

		/// <summary> control interface. </summary>
	private IMediaControl			mediaCtrl;

		/// <summary> event interface. </summary>
	private IMediaEventEx			mediaEvt;

		/// <summary> video window interface. </summary>
	private IVideoWindow			videoWin;

		/// <summary> grabber filter interface. </summary>
	private IBaseFilter				baseGrabFlt;

		/// <summary> structure describing the bitmap to grab. </summary>
	private	VideoInfoHeader			videoInfoHeader;
	private	bool					captured = true;
	private	int						bufferedSize;

		/// <summary> buffer for bitmap data. </summary>
	private	byte[]					savedArray;

		/// <summary> list of installed video devices. </summary>
	private ArrayList				capDevices;

	private const int WM_GRAPHNOTIFY	= 0x00008001;	// message from graph

	private const int WS_CHILD			= 0x40000000;	// attributes for video window
	private const int WS_CLIPCHILDREN	= 0x02000000;
	private const int WS_CLIPSIBLINGS	= 0x04000000;

		/// <summary> event when callback has finished (ISampleGrabberCB.BufferCB). </summary>
	private delegate void CaptureDone();

	#if DEBUG
		private int		rotCookie = 0;

	#endif
	private void timer1_Tick(object sender, System.EventArgs e)
	{
		System.Windows.Forms.ToolBarButtonClickEventArgs ee=new ToolBarButtonClickEventArgs(toolBarBtnGrab);
		toolBar_ButtonClick(toolBarBtnGrab,ee);
	}

	

	private void trckBarSaveValue_ValueChanged(object sender, System.EventArgs e)
	{
		cPercent=trckBarSaveValue.Value;
		lblSavePercent.Text=cPercent+"%";
	}

	private void btnStop_Click(object sender, System.EventArgs e)
    {
        btnStart.Enabled = true;
        btnStop.Enabled=false;
		timer1.Enabled=false;
		firstRun=true;
	}

	

	private void trckBarTimer_ValueChanged(object sender, System.EventArgs e)
	{
	    timer1.Interval=trckBarTimer.Value;
		lblTimerValue.Text=trckBarTimer.Value.ToString();
	}

    private void groupBoxImageProcTime_Enter(object sender, EventArgs e)
    {

    }

    private void kryptonButton1_Click(object sender, EventArgs e)
    {
        
        btnStart.Enabled = false;
        btnStop.Enabled = true;
        timer1.Enabled = true;
    }

   
    private void MainForm_Load(object sender, EventArgs e)
    {
        btnStop.Enabled = false;
    }

    private void btnStop_Click_1(object sender, EventArgs e)
    {
        btnStart.Enabled = true;
        btnStop.Enabled = false;
        timer1.Enabled = false;
        firstRun = true;
    }

    private void stillPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
    {

    }

    

    private void kryptonButton2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void kryptonButton1_Click_1(object sender, EventArgs e)
    {
        btnStop.Enabled = false;
        btnStart.Enabled = true;
        btnStop.Enabled = false;
        timer1.Enabled = false;
        firstRun = true;
        lblCount.Text = "0/0";
        pictureBox.Image = null;
        pictureBox1.Image = null;
        pictureBox2.Image = null;
        count = 0;
        count2 = 0;
        lblSavePercent.Text="0%";
        lblTime.Text = "";
        lblTotalTime.Text = "";


    }

    
   
	

	
}

internal enum PlayState
{
	Init, Stopped, Paused, Running
}

}
