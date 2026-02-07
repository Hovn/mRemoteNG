
using System.Drawing;
using BrightIdeasSoftware;

namespace mRemoteNG.UI.Window
{
	public partial class ExternalToolsWindow : BaseWindow
	{
        #region  Windows Form Designer generated code
		internal BrightIdeasSoftware.OLVColumn FilenameColumnHeader;
        internal BrightIdeasSoftware.OLVColumn DisplayNameColumnHeader;
        internal BrightIdeasSoftware.OLVColumn ArgumentsColumnHeader;
        internal BrightIdeasSoftware.OLVColumn WaitForExitColumnHeader;
        internal BrightIdeasSoftware.OLVColumn TryToIntegrateColumnHeader;
	    internal BrightIdeasSoftware.OLVColumn WorkingDirColumnHeader;
	    internal BrightIdeasSoftware.OLVColumn RunElevateHeader;
		internal Controls.Base.NGTextBox DisplayNameTextBox;
        internal BrightIdeasSoftware.OLVColumn ShowOnToolbarColumnHeader;
		internal Controls.Base.NGLabel DisplayNameLabel;
		internal Controls.Base.NGTextBox ArgumentsTextBox;
		internal Controls.Base.NGTextBox FilenameTextBox;
		internal Controls.Base.NGLabel ArgumentsLabel;
		internal Controls.Base.NGLabel FilenameLabel;
		internal Controls.Base.NGButton BrowseButton; 
		internal System.Windows.Forms.ContextMenuStrip ToolsContextMenuStrip;
		internal System.Windows.Forms.ToolStripMenuItem NewToolMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem DeleteToolMenuItem;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ToolStripMenuItem LaunchToolMenuItem; 
		internal Controls.Base.NGCheckBox WaitForExitCheckBox;
		internal Controls.Base.NGLabel OptionsLabel;
		internal Controls.Base.NGCheckBox TryToIntegrateCheckBox;
        internal Controls.Base.NGCheckBox ShowOnToolbarCheckBox;
        internal Controls.Base.NGListView ToolsListObjView;
	    internal Controls.Base.NGLabel WorkingDirLabel;
	    internal Controls.Base.NGTextBox WorkingDirTextBox;
	    internal Controls.Base.NGButton BrowseWorkingDir;
	    internal Controls.Base.NGCheckBox RunElevatedCheckBox;

        private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExternalToolsWindow));
            this.ToolsListObjView = new mRemoteNG.UI.Controls.Base.NGListView();
            this.DisplayNameColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.FilenameColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ArgumentsColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.WorkingDirColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.WaitAfterStartColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.WaitForExitColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TryToIntegrateColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.RunElevateHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ShowOnToolbarColumnHeader = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ToolsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LaunchToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertiesGroupBox = new mRemoteNG.UI.Controls.Base.NGGroupBox();
            this.WaitAfterStartLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.WaitAfterStartTextBox = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.ShowOnToolbarCheckBox = new mRemoteNG.UI.Controls.Base.NGCheckBox();
            this.RunElevatedCheckBox = new mRemoteNG.UI.Controls.Base.NGCheckBox();
            this.BrowseWorkingDir = new mRemoteNG.UI.Controls.Base.NGButton();
            this.WorkingDirLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.WorkingDirTextBox = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.TryToIntegrateCheckBox = new mRemoteNG.UI.Controls.Base.NGCheckBox();
            this.OptionsLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.WaitForExitCheckBox = new mRemoteNG.UI.Controls.Base.NGCheckBox();
            this.BrowseButton = new mRemoteNG.UI.Controls.Base.NGButton();
            this.ArgumentsTextBox = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.FilenameTextBox = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.DisplayNameTextBox = new mRemoteNG.UI.Controls.Base.NGTextBox();
            this.ArgumentsLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.FilenameLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.DisplayNameLabel = new mRemoteNG.UI.Controls.Base.NGLabel();
            this.ToolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.NewToolToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.LaunchToolToolstripButton = new System.Windows.Forms.ToolStripButton();
            this.vsToolStripExtender = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ToolsListObjView)).BeginInit();
            this.ToolsContextMenuStrip.SuspendLayout();
            this.PropertiesGroupBox.SuspendLayout();
            this.ToolStripContainer.ContentPanel.SuspendLayout();
            this.ToolStripContainer.TopToolStripPanel.SuspendLayout();
            this.ToolStripContainer.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolsListObjView
            // 
            this.ToolsListObjView.AllColumns.Add(this.DisplayNameColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.FilenameColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.ArgumentsColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.WorkingDirColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.WaitAfterStartColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.WaitForExitColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.TryToIntegrateColumnHeader);
            this.ToolsListObjView.AllColumns.Add(this.RunElevateHeader);
            this.ToolsListObjView.AllColumns.Add(this.ShowOnToolbarColumnHeader);
            this.ToolsListObjView.AllowDrop = true;
            this.ToolsListObjView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolsListObjView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ToolsListObjView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.F2Only;
            this.ToolsListObjView.CellEditUseWholeCell = false;
            this.ToolsListObjView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayNameColumnHeader,
            this.FilenameColumnHeader,
            this.ArgumentsColumnHeader,
            this.WorkingDirColumnHeader,
            this.WaitAfterStartColumnHeader,
            this.WaitForExitColumnHeader,
            this.TryToIntegrateColumnHeader,
            this.RunElevateHeader,
            this.ShowOnToolbarColumnHeader});
            this.ToolsListObjView.ContextMenuStrip = this.ToolsContextMenuStrip;
            this.ToolsListObjView.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToolsListObjView.DecorateLines = true;
            this.ToolsListObjView.FullRowSelect = true;
            this.ToolsListObjView.GridLines = true;
            this.ToolsListObjView.HideSelection = false;
            this.ToolsListObjView.IsSimpleDragSource = true;
            this.ToolsListObjView.Location = new System.Drawing.Point(0, 0);
            this.ToolsListObjView.Name = "ToolsListObjView";
            this.ToolsListObjView.RenderNonEditableCheckboxesAsDisabled = true;
            this.ToolsListObjView.ShowCommandMenuOnRightClick = true;
            this.ToolsListObjView.ShowGroups = false;
            this.ToolsListObjView.Size = new System.Drawing.Size(901, 253);
            this.ToolsListObjView.TabIndex = 0;
            this.ToolsListObjView.UseCompatibleStateImageBehavior = false;
            this.ToolsListObjView.UseNotifyPropertyChanged = true;
            this.ToolsListObjView.View = System.Windows.Forms.View.Details;
            this.ToolsListObjView.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.ToolsListObjView_CellToolTipShowing);
            this.ToolsListObjView.SelectedIndexChanged += new System.EventHandler(this.ToolsListObjView_SelectedIndexChanged);
            this.ToolsListObjView.DragDrop += new System.Windows.Forms.DragEventHandler(this.ToolsListObjView_DragDrop);
            this.ToolsListObjView.DoubleClick += new System.EventHandler(this.ToolsListObjView_DoubleClick);
            // 
            // DisplayNameColumnHeader
            // 
            this.DisplayNameColumnHeader.AspectName = "DisplayName";
            this.DisplayNameColumnHeader.AutoCompleteEditor = false;
            this.DisplayNameColumnHeader.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.DisplayNameColumnHeader.Text = "Display Name";
            this.DisplayNameColumnHeader.UseInitialLetterForGroup = true;
            this.DisplayNameColumnHeader.Width = 100;
            // 
            // FilenameColumnHeader
            // 
            this.FilenameColumnHeader.AspectName = "FileName";
            this.FilenameColumnHeader.AutoCompleteEditor = false;
            this.FilenameColumnHeader.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.FilenameColumnHeader.Groupable = false;
            this.FilenameColumnHeader.Text = "Filename";
            this.FilenameColumnHeader.Width = 100;
            // 
            // ArgumentsColumnHeader
            // 
            this.ArgumentsColumnHeader.AspectName = "Arguments";
            this.ArgumentsColumnHeader.AutoCompleteEditor = false;
            this.ArgumentsColumnHeader.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.ArgumentsColumnHeader.Groupable = false;
            this.ArgumentsColumnHeader.Text = "Arguments";
            this.ArgumentsColumnHeader.Width = 100;
            // 
            // WorkingDirColumnHeader
            // 
            this.WorkingDirColumnHeader.AspectName = "WorkingDir";
            this.WorkingDirColumnHeader.AutoCompleteEditor = false;
            this.WorkingDirColumnHeader.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.WorkingDirColumnHeader.Groupable = false;
            this.WorkingDirColumnHeader.Text = "Working Directory";
            this.WorkingDirColumnHeader.Width = 120;
            // 
            // WaitAfterStartColumnHeader
            // 
            this.WaitAfterStartColumnHeader.AspectName = "WaitAfterStart";
            this.WaitAfterStartColumnHeader.AutoCompleteEditor = false;
            this.WaitAfterStartColumnHeader.AutoCompleteEditorMode = System.Windows.Forms.AutoCompleteMode.None;
            this.WaitAfterStartColumnHeader.Groupable = false;
            this.WaitAfterStartColumnHeader.Text = "Wait after start";
            this.WaitAfterStartColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WaitAfterStartColumnHeader.Width = 75;
            // 
            // WaitForExitColumnHeader
            // 
            this.WaitForExitColumnHeader.AspectName = "WaitForExit";
            this.WaitForExitColumnHeader.CheckBoxes = true;
            this.WaitForExitColumnHeader.Groupable = false;
            this.WaitForExitColumnHeader.Text = "Wait for exit";
            this.WaitForExitColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WaitForExitColumnHeader.Width = 75;
            // 
            // TryToIntegrateColumnHeader
            // 
            this.TryToIntegrateColumnHeader.AspectName = "TryIntegrate";
            this.TryToIntegrateColumnHeader.CheckBoxes = true;
            this.TryToIntegrateColumnHeader.Groupable = false;
            this.TryToIntegrateColumnHeader.Text = "Try To Integrate";
            this.TryToIntegrateColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TryToIntegrateColumnHeader.Width = 95;
            // 
            // RunElevateHeader
            // 
            this.RunElevateHeader.AspectName = "RunElevated";
            this.RunElevateHeader.CheckBoxes = true;
            this.RunElevateHeader.Groupable = false;
            this.RunElevateHeader.Text = "Run Elevated";
            this.RunElevateHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RunElevateHeader.Width = 95;
            // 
            // ShowOnToolbarColumnHeader
            // 
            this.ShowOnToolbarColumnHeader.AspectName = "ShowOnToolbar";
            this.ShowOnToolbarColumnHeader.CheckBoxes = true;
            this.ShowOnToolbarColumnHeader.Groupable = false;
            this.ShowOnToolbarColumnHeader.Text = "Show On Toolbar";
            this.ShowOnToolbarColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ShowOnToolbarColumnHeader.Width = 120;
            // 
            // ToolsContextMenuStrip
            // 
            this.ToolsContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolMenuItem,
            this.DeleteToolMenuItem,
            this.ToolStripSeparator1,
            this.LaunchToolMenuItem});
            this.ToolsContextMenuStrip.Name = "cMenApps";
            this.ToolsContextMenuStrip.Size = new System.Drawing.Size(299, 88);
            // 
            // NewToolMenuItem
            // 
            this.NewToolMenuItem.Image = global::mRemoteNG.Resources.ExtApp_Add;
            this.NewToolMenuItem.Name = "NewToolMenuItem";
            this.NewToolMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F4)));
            this.NewToolMenuItem.Size = new System.Drawing.Size(298, 26);
            this.NewToolMenuItem.Text = "New External Tool";
            this.NewToolMenuItem.Click += new System.EventHandler(this.NewTool_Click);
            // 
            // DeleteToolMenuItem
            // 
            this.DeleteToolMenuItem.Enabled = false;
            this.DeleteToolMenuItem.Image = global::mRemoteNG.Resources.ExtApp_Delete;
            this.DeleteToolMenuItem.Name = "DeleteToolMenuItem";
            this.DeleteToolMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteToolMenuItem.Size = new System.Drawing.Size(298, 26);
            this.DeleteToolMenuItem.Text = "Delete External Tool...";
            this.DeleteToolMenuItem.Click += new System.EventHandler(this.DeleteTool_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(295, 6);
            // 
            // LaunchToolMenuItem
            // 
            this.LaunchToolMenuItem.Enabled = false;
            this.LaunchToolMenuItem.Image = global::mRemoteNG.Resources.ExtApp_Start;
            this.LaunchToolMenuItem.Name = "LaunchToolMenuItem";
            this.LaunchToolMenuItem.Size = new System.Drawing.Size(298, 26);
            this.LaunchToolMenuItem.Text = "Launch External Tool";
            this.LaunchToolMenuItem.Click += new System.EventHandler(this.LaunchTool_Click);
            // 
            // PropertiesGroupBox
            // 
            this.PropertiesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertiesGroupBox.Controls.Add(this.WaitAfterStartLabel);
            this.PropertiesGroupBox.Controls.Add(this.WaitAfterStartTextBox);
            this.PropertiesGroupBox.Controls.Add(this.ShowOnToolbarCheckBox);
            this.PropertiesGroupBox.Controls.Add(this.RunElevatedCheckBox);
            this.PropertiesGroupBox.Controls.Add(this.BrowseWorkingDir);
            this.PropertiesGroupBox.Controls.Add(this.WorkingDirLabel);
            this.PropertiesGroupBox.Controls.Add(this.WorkingDirTextBox);
            this.PropertiesGroupBox.Controls.Add(this.TryToIntegrateCheckBox);
            this.PropertiesGroupBox.Controls.Add(this.OptionsLabel);
            this.PropertiesGroupBox.Controls.Add(this.WaitForExitCheckBox);
            this.PropertiesGroupBox.Controls.Add(this.BrowseButton);
            this.PropertiesGroupBox.Controls.Add(this.ArgumentsTextBox);
            this.PropertiesGroupBox.Controls.Add(this.FilenameTextBox);
            this.PropertiesGroupBox.Controls.Add(this.DisplayNameTextBox);
            this.PropertiesGroupBox.Controls.Add(this.ArgumentsLabel);
            this.PropertiesGroupBox.Controls.Add(this.FilenameLabel);
            this.PropertiesGroupBox.Controls.Add(this.DisplayNameLabel);
            this.PropertiesGroupBox.Enabled = false;
            this.PropertiesGroupBox.Location = new System.Drawing.Point(3, 259);
            this.PropertiesGroupBox.Name = "PropertiesGroupBox";
            this.PropertiesGroupBox.Size = new System.Drawing.Size(895, 210);
            this.PropertiesGroupBox.TabIndex = 1;
            this.PropertiesGroupBox.TabStop = false;
            this.PropertiesGroupBox.Text = "External Tool Properties";
            // 
            // WaitAfterStartLabel
            // 
            this.WaitAfterStartLabel.AutoSize = true;
            this.WaitAfterStartLabel.Location = new System.Drawing.Point(122, 143);
            this.WaitAfterStartLabel.Name = "WaitAfterStartLabel";
            this.WaitAfterStartLabel.Size = new System.Drawing.Size(139, 20);
            this.WaitAfterStartLabel.TabIndex = 13;
            this.WaitAfterStartLabel.Text = "Wait after start(ms):";
            this.WaitAfterStartLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WaitAfterStartTextBox
            // 
            this.WaitAfterStartTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WaitAfterStartTextBox.Location = new System.Drawing.Point(272, 143);
            this.WaitAfterStartTextBox.Name = "WaitAfterStartTextBox";
            //this.WaitAfterStartTextBox.NumberOnly = true;  //保存时再判断合法性
            this.WaitAfterStartTextBox.Size = new System.Drawing.Size(45, 20);
            this.WaitAfterStartTextBox.TabIndex = 7;
            this.WaitAfterStartTextBox.Text = "0";
            this.WaitAfterStartTextBox.Leave += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // ShowOnToolbarCheckBox
            // 
            this.ShowOnToolbarCheckBox._mice = mRemoteNG.UI.Controls.Base.NGCheckBox.MouseState.HOVER;
            this.ShowOnToolbarCheckBox.AutoSize = true;
            this.ShowOnToolbarCheckBox.Location = new System.Drawing.Point(358, 175);
            this.ShowOnToolbarCheckBox.Name = "ShowOnToolbarCheckBox";
            this.ShowOnToolbarCheckBox.Size = new System.Drawing.Size(141, 24);
            this.ShowOnToolbarCheckBox.TabIndex = 11;
            this.ShowOnToolbarCheckBox.Text = "Show on toolbar";
            this.ShowOnToolbarCheckBox.UseVisualStyleBackColor = true;
            this.ShowOnToolbarCheckBox.Click += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // RunElevatedCheckBox
            // 
            this.RunElevatedCheckBox._mice = mRemoteNG.UI.Controls.Base.NGCheckBox.MouseState.HOVER;
            this.RunElevatedCheckBox.AutoSize = true;
            this.RunElevatedCheckBox.Location = new System.Drawing.Point(126, 175);
            this.RunElevatedCheckBox.Name = "RunElevatedCheckBox";
            this.RunElevatedCheckBox.Size = new System.Drawing.Size(117, 24);
            this.RunElevatedCheckBox.TabIndex = 10;
            this.RunElevatedCheckBox.Text = "Run Elevated";
            this.RunElevatedCheckBox.UseVisualStyleBackColor = true;
            this.RunElevatedCheckBox.Click += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // BrowseWorkingDir
            // 
            this.BrowseWorkingDir._mice = mRemoteNG.UI.Controls.Base.NGButton.MouseState.HOVER;
            this.BrowseWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseWorkingDir.AutoSize = true;
            this.BrowseWorkingDir.Location = new System.Drawing.Point(791, 110);
            this.BrowseWorkingDir.MaximumSize = new System.Drawing.Size(96, 30);
            this.BrowseWorkingDir.MinimumSize = new System.Drawing.Size(94, 20);
            this.BrowseWorkingDir.Name = "BrowseWorkingDir";
            this.BrowseWorkingDir.Size = new System.Drawing.Size(95, 30);
            this.BrowseWorkingDir.TabIndex = 6;
            this.BrowseWorkingDir.Text = "Browse...";
            this.BrowseWorkingDir.UseVisualStyleBackColor = true;
            this.BrowseWorkingDir.Click += new System.EventHandler(this.BrowseWorkingDir_Click);
            // 
            // WorkingDirLabel
            // 
            this.WorkingDirLabel.AutoSize = true;
            this.WorkingDirLabel.Location = new System.Drawing.Point(6, 115);
            this.WorkingDirLabel.Name = "WorkingDirLabel";
            this.WorkingDirLabel.Size = new System.Drawing.Size(132, 20);
            this.WorkingDirLabel.TabIndex = 11;
            this.WorkingDirLabel.Text = "Working Directory:";
            this.WorkingDirLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WorkingDirTextBox
            // 
            this.WorkingDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WorkingDirTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WorkingDirTextBox.Location = new System.Drawing.Point(126, 111);
            this.WorkingDirTextBox.Name = "WorkingDirTextBox";
            this.WorkingDirTextBox.Size = new System.Drawing.Size(659, 27);
            this.WorkingDirTextBox.TabIndex = 5;
            this.WorkingDirTextBox.Leave += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // TryToIntegrateCheckBox
            // 
            this.TryToIntegrateCheckBox._mice = mRemoteNG.UI.Controls.Base.NGCheckBox.MouseState.HOVER;
            this.TryToIntegrateCheckBox.AutoSize = true;
            this.TryToIntegrateCheckBox.Location = new System.Drawing.Point(591, 141);
            this.TryToIntegrateCheckBox.Name = "TryToIntegrateCheckBox";
            this.TryToIntegrateCheckBox.Size = new System.Drawing.Size(132, 24);
            this.TryToIntegrateCheckBox.TabIndex = 9;
            this.TryToIntegrateCheckBox.Text = "Try to integrate";
            this.TryToIntegrateCheckBox.UseVisualStyleBackColor = true;
            this.TryToIntegrateCheckBox.Click += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // OptionsLabel
            // 
            this.OptionsLabel.AutoSize = true;
            this.OptionsLabel.Location = new System.Drawing.Point(6, 142);
            this.OptionsLabel.Name = "OptionsLabel";
            this.OptionsLabel.Size = new System.Drawing.Size(64, 20);
            this.OptionsLabel.TabIndex = 7;
            this.OptionsLabel.Text = "Options:";
            this.OptionsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // WaitForExitCheckBox
            // 
            this.WaitForExitCheckBox._mice = mRemoteNG.UI.Controls.Base.NGCheckBox.MouseState.HOVER;
            this.WaitForExitCheckBox.AutoSize = true;
            this.WaitForExitCheckBox.Location = new System.Drawing.Point(358, 141);
            this.WaitForExitCheckBox.Name = "WaitForExitCheckBox";
            this.WaitForExitCheckBox.Size = new System.Drawing.Size(112, 24);
            this.WaitForExitCheckBox.TabIndex = 8;
            this.WaitForExitCheckBox.Text = "Wait for exit";
            this.WaitForExitCheckBox.UseVisualStyleBackColor = true;
            this.WaitForExitCheckBox.Click += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            this.WaitForExitCheckBox.LostFocus += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // BrowseButton
            // 
            this.BrowseButton._mice = mRemoteNG.UI.Controls.Base.NGButton.MouseState.HOVER;
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.AutoSize = true;
            this.BrowseButton.Location = new System.Drawing.Point(791, 53);
            this.BrowseButton.MaximumSize = new System.Drawing.Size(96, 30);
            this.BrowseButton.MinimumSize = new System.Drawing.Size(94, 20);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(95, 30);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse...";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            this.BrowseButton.LostFocus += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgumentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArgumentsTextBox.Location = new System.Drawing.Point(126, 83);
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.Size = new System.Drawing.Size(659, 27);
            this.ArgumentsTextBox.TabIndex = 4;
            this.ArgumentsTextBox.LostFocus += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilenameTextBox.Location = new System.Drawing.Point(126, 54);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.Size = new System.Drawing.Size(659, 27);
            this.FilenameTextBox.TabIndex = 2;
            this.FilenameTextBox.LostFocus += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // DisplayNameTextBox
            // 
            this.DisplayNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DisplayNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayNameTextBox.Location = new System.Drawing.Point(126, 26);
            this.DisplayNameTextBox.Name = "DisplayNameTextBox";
            this.DisplayNameTextBox.Size = new System.Drawing.Size(659, 27);
            this.DisplayNameTextBox.TabIndex = 1;
            this.DisplayNameTextBox.LostFocus += new System.EventHandler(this.PropertyControl_ChangedOrLostFocus);
            // 
            // ArgumentsLabel
            // 
            this.ArgumentsLabel.AutoSize = true;
            this.ArgumentsLabel.Location = new System.Drawing.Point(6, 85);
            this.ArgumentsLabel.Name = "ArgumentsLabel";
            this.ArgumentsLabel.Size = new System.Drawing.Size(84, 20);
            this.ArgumentsLabel.TabIndex = 5;
            this.ArgumentsLabel.Text = "Arguments:";
            this.ArgumentsLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FilenameLabel
            // 
            this.FilenameLabel.AutoSize = true;
            this.FilenameLabel.Location = new System.Drawing.Point(6, 57);
            this.FilenameLabel.Name = "FilenameLabel";
            this.FilenameLabel.Size = new System.Drawing.Size(72, 20);
            this.FilenameLabel.TabIndex = 2;
            this.FilenameLabel.Text = "Filename:";
            this.FilenameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoSize = true;
            this.DisplayNameLabel.Location = new System.Drawing.Point(6, 28);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(105, 20);
            this.DisplayNameLabel.TabIndex = 0;
            this.DisplayNameLabel.Text = "Display Name:";
            this.DisplayNameLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ToolStripContainer
            // 
            // 
            // ToolStripContainer.ContentPanel
            // 
            this.ToolStripContainer.ContentPanel.Controls.Add(this.PropertiesGroupBox);
            this.ToolStripContainer.ContentPanel.Controls.Add(this.ToolsListObjView);
            this.ToolStripContainer.ContentPanel.Size = new System.Drawing.Size(901, 468);
            this.ToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.ToolStripContainer.Name = "ToolStripContainer";
            this.ToolStripContainer.Size = new System.Drawing.Size(901, 495);
            this.ToolStripContainer.TabIndex = 0;
            this.ToolStripContainer.Text = "ToolStripContainer";
            // 
            // ToolStripContainer.TopToolStripPanel
            // 
            this.ToolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ToolStripContainer.TopToolStripPanel.Controls.Add(this.ToolStrip);
            // 
            // ToolStrip
            // 
            this.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolToolstripButton,
            this.DeleteToolToolstripButton,
            this.ToolStripSeparator2,
            this.LaunchToolToolstripButton});
            this.ToolStrip.Location = new System.Drawing.Point(4, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(240, 27);
            this.ToolStrip.TabIndex = 0;
            // 
            // NewToolToolstripButton
            // 
            this.NewToolToolstripButton.Image = global::mRemoteNG.Resources.ExtApp_Add;
            this.NewToolToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewToolToolstripButton.Name = "NewToolToolstripButton";
            this.NewToolToolstripButton.Size = new System.Drawing.Size(66, 24);
            this.NewToolToolstripButton.Text = "New";
            this.NewToolToolstripButton.Click += new System.EventHandler(this.NewTool_Click);
            // 
            // DeleteToolToolstripButton
            // 
            this.DeleteToolToolstripButton.Enabled = false;
            this.DeleteToolToolstripButton.Image = global::mRemoteNG.Resources.ExtApp_Delete;
            this.DeleteToolToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolToolstripButton.Name = "DeleteToolToolstripButton";
            this.DeleteToolToolstripButton.Size = new System.Drawing.Size(81, 24);
            this.DeleteToolToolstripButton.Text = "Delete";
            this.DeleteToolToolstripButton.Click += new System.EventHandler(this.DeleteTool_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // LaunchToolToolstripButton
            // 
            this.LaunchToolToolstripButton.Enabled = false;
            this.LaunchToolToolstripButton.Image = global::mRemoteNG.Resources.ExtApp_Start;
            this.LaunchToolToolstripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LaunchToolToolstripButton.Name = "LaunchToolToolstripButton";
            this.LaunchToolToolstripButton.Size = new System.Drawing.Size(84, 24);
            this.LaunchToolToolstripButton.Text = "Launch";
            this.LaunchToolToolstripButton.Click += new System.EventHandler(this.LaunchTool_Click);
            // 
            // vsToolStripExtender
            // 
            this.vsToolStripExtender.DefaultRenderer = null;
            // 
            // ExternalToolsWindow
            // 
            this.ClientSize = new System.Drawing.Size(901, 495);
            this.Controls.Add(this.ToolStripContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExternalToolsWindow";
            this.TabText = "External Applications";
            this.Text = "External Tools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ExternalTools_FormClosed);
            this.Load += new System.EventHandler(this.ExternalTools_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ToolsListObjView)).EndInit();
            this.ToolsContextMenuStrip.ResumeLayout(false);
            this.PropertiesGroupBox.ResumeLayout(false);
            this.PropertiesGroupBox.PerformLayout();
            this.ToolStripContainer.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.ToolStripContainer.TopToolStripPanel.PerformLayout();
            this.ToolStripContainer.ResumeLayout(false);
            this.ToolStripContainer.PerformLayout();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.ToolStripContainer ToolStripContainer;
		internal System.Windows.Forms.ToolStrip ToolStrip;
		internal System.Windows.Forms.ToolStripButton NewToolToolstripButton;
		internal System.Windows.Forms.ToolStripButton DeleteToolToolstripButton;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.ToolStripButton LaunchToolToolstripButton;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender vsToolStripExtender;
        #endregion

        private System.ComponentModel.IContainer components;
        internal Controls.Base.NGGroupBox PropertiesGroupBox;
        internal Controls.Base.NGTextBox WaitAfterStartTextBox;
        internal BrightIdeasSoftware.OLVColumn WaitAfterStartColumnHeader;
        internal Controls.Base.NGLabel WaitAfterStartLabel;
    }
}
