using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Atalasoft.Imaging;
using Atalasoft.Imaging.ImageProcessing.Document;
using WinDemoHelperMethods;


namespace ColorRegionDemo
{
	/// <summary>
	/// 	<para>This application demonstrates using the Atalasoft.dotImage.DocClean add-on
	///     for Atalasoft Document Imaging to split an image into separate color and grayscale
	///     sections, which can then be saved using different compressions for overall better
	///     compression ratios.</para>
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Atalasoft.Imaging.ImageProcessing.Document.ColorExtractionCommand _command;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuCommand;
		private System.Windows.Forms.MenuItem menuCommandSettings;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuCommandProcess;
		private System.Windows.Forms.ToolBarButton tbOpen;
		private System.Windows.Forms.ToolBarButton tbSettings;
		private System.Windows.Forms.ToolBarButton tbProcess;
		private System.Windows.Forms.ToolBarButton tbAbout;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuHelpAbout;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblColorLabel;
		private System.Windows.Forms.Panel panelOriginal;
		private Atalasoft.Imaging.WinControls.ImageViewer _originalViewer;
		private System.Windows.Forms.Panel panelColor;
		private Atalasoft.Imaging.WinControls.ImageViewer _colorViewer;
		private System.Windows.Forms.StatusBarPanel sbpImageFile;
		private System.Windows.Forms.StatusBarPanel sbpProcessingTime;
		private System.Windows.Forms.StatusBarPanel sbpPixelColor;
		private System.ComponentModel.IContainer components;

		public Form1()
		{			
			// Ensure decoders are setup
			HelperMethods.PopulateDecoders(Atalasoft.Imaging.Codec.RegisteredDecoders.Decoders);

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this._command = new Atalasoft.Imaging.ImageProcessing.Document.ColorExtractionCommand();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuOpen = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuCommand = new System.Windows.Forms.MenuItem();
			this.menuCommandSettings = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuCommandProcess = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuHelpAbout = new System.Windows.Forms.MenuItem();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbOpen = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbSettings = new System.Windows.Forms.ToolBarButton();
			this.tbProcess = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.tbAbout = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.sbpImageFile = new System.Windows.Forms.StatusBarPanel();
			this.sbpProcessingTime = new System.Windows.Forms.StatusBarPanel();
			this.sbpPixelColor = new System.Windows.Forms.StatusBarPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.lblColorLabel = new System.Windows.Forms.Label();
			this.panelOriginal = new System.Windows.Forms.Panel();
			this._originalViewer = new Atalasoft.Imaging.WinControls.ImageViewer();
			this.panelColor = new System.Windows.Forms.Panel();
			this._colorViewer = new Atalasoft.Imaging.WinControls.ImageViewer();
			((System.ComponentModel.ISupportInitialize)(this.sbpImageFile)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpProcessingTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpPixelColor)).BeginInit();
			this.panelOriginal.SuspendLayout();
			this.panelColor.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuCommand,
																					  this.menuHelp});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuOpen,
																					  this.menuExit});
			this.menuItem1.Text = "&File";
			// 
			// menuOpen
			// 
			this.menuOpen.Index = 0;
			this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuOpen.Text = "&Open";
			this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
			// 
			// menuExit
			// 
			this.menuExit.Index = 1;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuCommand
			// 
			this.menuCommand.Index = 1;
			this.menuCommand.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuCommandSettings,
																						this.menuItem5,
																						this.menuCommandProcess});
			this.menuCommand.Text = "&Command";
			// 
			// menuCommandSettings
			// 
			this.menuCommandSettings.Index = 0;
			this.menuCommandSettings.Text = "&Settings...";
			this.menuCommandSettings.Click += new System.EventHandler(this.menuCommandSettings_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "-";
			// 
			// menuCommandProcess
			// 
			this.menuCommandProcess.Index = 2;
			this.menuCommandProcess.Text = "&Process Image";
			this.menuCommandProcess.Click += new System.EventHandler(this.menuCommandProcess_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 2;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuHelpAbout});
			this.menuHelp.Text = "&Help";
			// 
			// menuHelpAbout
			// 
			this.menuHelpAbout.Index = 0;
			this.menuHelpAbout.Text = "&About...";
			this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbOpen,
																						this.toolBarButton1,
																						this.tbSettings,
																						this.tbProcess,
																						this.toolBarButton2,
																						this.tbAbout});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(920, 36);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbOpen
			// 
			this.tbOpen.ImageIndex = 4;
			this.tbOpen.ToolTipText = "Open";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbSettings
			// 
			this.tbSettings.ImageIndex = 2;
			this.tbSettings.ToolTipText = "Command Settings";
			// 
			// tbProcess
			// 
			this.tbProcess.Enabled = false;
			this.tbProcess.ImageIndex = 1;
			this.tbProcess.ToolTipText = "Process Command";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbAbout
			// 
			this.tbAbout.ImageIndex = 5;
			this.tbAbout.ToolTipText = "About...";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Fuchsia;
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 595);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbpImageFile,
																						  this.sbpProcessingTime,
																						  this.sbpPixelColor});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(920, 22);
			this.statusBar1.TabIndex = 1;
			// 
			// sbpImageFile
			// 
			this.sbpImageFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpImageFile.Text = "No Image Loaded";
			this.sbpImageFile.Width = 104;
			// 
			// sbpProcessingTime
			// 
			this.sbpProcessingTime.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpProcessingTime.Width = 10;
			// 
			// sbpPixelColor
			// 
			this.sbpPixelColor.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpPixelColor.Width = 790;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Original Image";
			// 
			// lblColorLabel
			// 
			this.lblColorLabel.AutoSize = true;
			this.lblColorLabel.Location = new System.Drawing.Point(456, 40);
			this.lblColorLabel.Name = "lblColorLabel";
			this.lblColorLabel.Size = new System.Drawing.Size(117, 16);
			this.lblColorLabel.TabIndex = 5;
			this.lblColorLabel.Text = "Extracted Color Image";
			// 
			// panelOriginal
			// 
			this.panelOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panelOriginal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelOriginal.Controls.Add(this._originalViewer);
			this.panelOriginal.Location = new System.Drawing.Point(0, 56);
			this.panelOriginal.Name = "panelOriginal";
			this.panelOriginal.Size = new System.Drawing.Size(448, 528);
			this.panelOriginal.TabIndex = 6;
			// 
			// _originalViewer
			// 
			this._originalViewer.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
			this._originalViewer.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFitShrinkOnly;
			this._originalViewer.Centered = true;
			this._originalViewer.DisplayProfile = null;
			this._originalViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this._originalViewer.Location = new System.Drawing.Point(0, 0);
			this._originalViewer.Magnifier.BackColor = System.Drawing.Color.White;
			this._originalViewer.Magnifier.BorderColor = System.Drawing.Color.Black;
			this._originalViewer.Magnifier.Size = new System.Drawing.Size(100, 100);
			this._originalViewer.Name = "_originalViewer";
			this._originalViewer.OutputProfile = null;
			this._originalViewer.Selection = null;
			this._originalViewer.Size = new System.Drawing.Size(446, 526);
			this._originalViewer.TabIndex = 3;
			this._originalViewer.Text = "_originalViewer";
			this._originalViewer.MouseMovePixel += new System.Windows.Forms.MouseEventHandler(this._originalViewer_MouseMovePixel);
			this._originalViewer.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Magnifier;
			// 
			// panelColor
			// 
			this.panelColor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panelColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelColor.Controls.Add(this._colorViewer);
			this.panelColor.Location = new System.Drawing.Point(456, 56);
			this.panelColor.Name = "panelColor";
			this.panelColor.Size = new System.Drawing.Size(456, 528);
			this.panelColor.TabIndex = 7;
			// 
			// _colorViewer
			// 
			this._colorViewer.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray;
			this._colorViewer.AutoZoom = Atalasoft.Imaging.WinControls.AutoZoomMode.BestFitShrinkOnly;
			this._colorViewer.Centered = true;
			this._colorViewer.DisplayProfile = null;
			this._colorViewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this._colorViewer.Location = new System.Drawing.Point(0, 0);
			this._colorViewer.Magnifier.BackColor = System.Drawing.Color.White;
			this._colorViewer.Magnifier.BorderColor = System.Drawing.Color.Black;
			this._colorViewer.Magnifier.Size = new System.Drawing.Size(100, 100);
			this._colorViewer.Name = "_colorViewer";
			this._colorViewer.OutputProfile = null;
			this._colorViewer.Selection = null;
			this._colorViewer.Size = new System.Drawing.Size(454, 526);
			this._colorViewer.TabIndex = 4;
			this._colorViewer.Text = "_colorViewer";
			this._colorViewer.MouseMovePixel += new System.Windows.Forms.MouseEventHandler(this._colorViewer_MouseMovePixel);
			this._colorViewer.MouseTool = Atalasoft.Imaging.WinControls.MouseToolType.Magnifier;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(920, 617);
			this.Controls.Add(this.panelColor);
			this.Controls.Add(this.panelOriginal);
			this.Controls.Add(this.lblColorLabel);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.MinimumSize = new System.Drawing.Size(384, 288);
			this.Name = "Form1";
			this.Text = "Color Extraction Demo";
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			((System.ComponentModel.ISupportInitialize)(this.sbpImageFile)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpProcessingTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpPixelColor)).EndInit();
			this.panelOriginal.ResumeLayout(false);
			this.panelColor.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			if (HelperMethods.HaveDotImage() && HelperMethods.HaveADC())
			{
				Application.EnableVisualStyles();
				Application.DoEvents();
				Application.Run(new Form1());
			}
		}

		#region Private Methods


		/// <summary>Clears the Image Viewers and disposes the images.</summary>
		private void DisposeImages()
		{

			if (this._colorViewer.Image != null)
			{
				this._colorViewer.Image.Dispose();
				this._colorViewer.Image = null;
			}

			if (this._originalViewer.Image != null)
			{
				this._originalViewer.Image.Dispose();
				this._originalViewer.Image = null;
			}
		}

		/// <summary>Displays a MessageBox with an Error icon.</summary>
		/// <param name="title">The title for the MessageBox.</param>
		/// <param name="message">
		/// The initial message to display. If the <em>ex</em> parameter is set the message
		/// will include additional content.
		/// </param>
		/// <param name="ex">
		/// The exception that was thrown or <strong>null</strong> (<strong>Nothing</strong>
		/// in VB) if there was no exception.
		/// </param>
		private void ShowErrorDialog(string title, string message, Exception ex)
		{
			if (ex != null)
			{
				message += ("\r\nException:  " + ex.Message);
				if (ex.InnerException != null)
					message += ("\r\nAdditional Information:  " + ex.InnerException.Message);
			}

			MessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		/// <summary>Displays a SaveFileDialog and returns the filename without an extension.</summary>
		/// <returns>The filename provided without its extension.</returns>
		private string GetSaveFileName()
		{
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.Title = "Save Image(s)";
				dlg.Filter = "Images (*.tif, *.jp2, *.jb2)|*.tif;*.jp2;*.jb2";
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					// Return the filename without an extension because it will
					// be added based on the type of image being saved.
					return System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
				}
				else
					return null;
			}
		}

		/// <summary>Updates the menu and toolbar items.</summary>
		private void UpdateMenusAndToolbar()
		{
			this.menuCommandProcess.Enabled = this._originalViewer.Image != null;
			this.tbProcess.Enabled = this.menuCommandProcess.Enabled;
		}

		/// <summary>
		/// Displays an OpenFileDialog and loads the image into the main
		/// ImageViewer.
		/// </summary>
		private void OpenImage()
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = HelperMethods.CreateDialogFilter(true);

			// try to locate images folder
			string imagesFolder = Application.ExecutablePath;
			
			// we assume we are running under the DotImage install folder
			int pos = imagesFolder.IndexOf("DotImage ");
			if (pos != -1)
			{
				imagesFolder = imagesFolder.Substring(0,imagesFolder.IndexOf(@"\",pos)) + @"\Images";
			}

			//use this folder as starting point			
			dlg.InitialDirectory = imagesFolder;

			try
			{
				if (dlg.ShowDialog(this) == DialogResult.OK)
				{
					this.Cursor = Cursors.WaitCursor;
					DisposeImages();
					this._originalViewer.Image = new AtalaImage(dlg.FileName);

					UpdateMenusAndToolbar();
					this.sbpImageFile.Text = "File:  " + System.IO.Path.GetFileName(dlg.FileName);
				}
			}
			catch (Exception ex)
			{
				ShowErrorDialog("Image Read Failed", "There was an error loading the image.", ex);
			}
			finally
			{
				dlg.Dispose();
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>Applies the ColorRegionDetectionCommand to the image.</summary>
		private void ProcessCommand()
		{
			if (this._originalViewer.Image == null)
			{
				MessageBox.Show(this, "Please load an image before processing.", "No Image");
				return;
			}

			try
			{
				int tick = System.Environment.TickCount;
				this.Cursor = Cursors.WaitCursor;
				ColorExtractionResults results = (ColorExtractionResults)this._command.Apply(this._originalViewer.Image);
				
				// Dispose any previous images.
				if (this._colorViewer.Image != null)
				{
					this._colorViewer.Image.Dispose();
					this._colorViewer.Image = null;
				}

				this.sbpProcessingTime.Text = "Processing Time: " + (System.Environment.TickCount - tick) + " ms";

				if (!results.HasColor)
				{
					MessageBox.Show(this, "No color was detected in this image", "Processing Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					this._colorViewer.Image = results.Image;
				}
				
				UpdateMenusAndToolbar();
			}
			catch (Exception ex)
			{
				ShowErrorDialog("Process Error", "There was an error processing the image.", ex);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// Displays a dialog that will allow the ColorRegionDetectionCommand property values
		/// to be modified.
		/// </summary>
		private void ShowCommandSettings()
		{
			// Pass in a copy of the command in case they cancel changes.
			ColorExtractionCommand cmd = new ColorExtractionCommand();
			
			cmd.ApplyToAnyPixelFormat = this._command.ApplyToAnyPixelFormat;
			cmd.MinMarkingSize = _command.MinMarkingSize;
			cmd.MinPhotoSize = _command.MinPhotoSize;
			cmd.VisualActivityWindowSize = _command.VisualActivityWindowSize;
			cmd.SpeedFactor = _command.SpeedFactor;
			cmd.GrayscaleSaturation = _command.GrayscaleSaturation;
			cmd.GrayscaleTolerance = _command.GrayscaleTolerance;
			cmd.VisualActivityThreshold = _command.VisualActivityThreshold;
			cmd.DetectColorMarkings = _command.DetectColorMarkings;
			cmd.DetectPhotos = _command.DetectPhotos;

			CommandSettings frm = new CommandSettings(cmd);
			try
			{
				if (frm.ShowDialog(this) == DialogResult.OK)
				{
					this._command = cmd;
				}
			}
			catch (Exception ex)
			{
				ShowErrorDialog("Setting Properties Failed", "There was an error while changing the command properties.", ex);
			}
			finally
			{
				frm.Dispose();
			}
		}

		/// <summary>Displays the About dialog.</summary>
		private void ShowAboutDialog()
		{
			AtalaDemos.AboutBox.About frm = new AtalaDemos.AboutBox.About("About...", "Color Extraction Demo");
			frm.Description = "This application provides a demonstration of the ColorExtractionCommand included in the Atalasoft DotImage Advanced Document Cleanup module.\r\n\r\nThis command is used to detect color in a color image, and returns a 32-bit BGRA image with the alpha channel covering the non-color regions.  This can be used to determine if a scanned image is actually grayscale, in which case the image can be thresholded to B&W and saved using CCIT or JBIG2 compression, or saved as 8-bit grayscale instead of 24-bit color.";
			frm.ShowDialog(this);
			frm.Dispose();
		}

		#endregion

		#region File Menu

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			OpenImage();
		}

		#endregion

		#region Command Menu

		private void menuCommandSettings_Click(object sender, System.EventArgs e)
		{
			ShowCommandSettings();
		}

		private void menuCommandProcess_Click(object sender, System.EventArgs e)
		{
			ProcessCommand();
		}

		#endregion

		#region Help Menu

		private void menuHelpAbout_Click(object sender, System.EventArgs e)
		{
			ShowAboutDialog();
		}

		#endregion

		#region Toolbar

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.ToolTipText)
			{
				case "Open":
					OpenImage();
					break;
				case "Command Settings":
					ShowCommandSettings();
					break;
				case "Process Command":
					ProcessCommand();
					break;
				case "About...":
					ShowAboutDialog();
					break;
			}
		}

		#endregion

		#region Form Events

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DisposeImages();
		}

		private void Form1_Resize(object sender, System.EventArgs e)
		{
			int halfSize = this.ClientSize.Width / 2;
			this.panelOriginal.Width = halfSize - 10;
			this.panelColor.Width = halfSize - 10;
			this.panelColor.Location = new Point(halfSize + 2, panelOriginal.Top);
			this.lblColorLabel.Left = this.panelColor.Location.X;
		}

		#endregion

		private void _originalViewer_MouseMovePixel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.sbpPixelColor.Text = _originalViewer.Image.GetPixelColor(e.X, e.Y).ToString();
		}

		private void _colorViewer_MouseMovePixel(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			this.sbpPixelColor.Text = _colorViewer.Image.GetPixelColor(e.X, e.Y).ToString();		
		}

	}
}
