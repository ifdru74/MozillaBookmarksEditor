namespace MozillaBookmarksEditor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripEditStatus = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            cutToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            addNewToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            renameToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripMenuItem1 = new ToolStripMenuItem();
            allToolStripMenuItem = new ToolStripMenuItem();
            invertToolStripMenuItem = new ToolStripMenuItem();
            noneToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            menuItemFindDuplicated = new ToolStripMenuItem();
            gotoURIToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            toolStripExit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripOpen = new ToolStripButton();
            toolStripSave = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripFind = new ToolStripButton();
            gotoURI = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripCopy = new ToolStripButton();
            toolStripPaste = new ToolStripButton();
            toolStripCut = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripAdd = new ToolStripButton();
            toolStripDelete = new ToolStripButton();
            toolStripRename = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            treeView1 = new TreeView();
            smallImagesList = new ImageList(components);
            splitContainer2 = new SplitContainer();
            listView1 = new ListView();
            columnHeaderName = new ColumnHeader();
            columnHeaderLabels = new ColumnHeader();
            columnHeaderAddress = new ColumnHeader();
            bigImageList = new ImageList(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtAddress = new TextBox();
            label3 = new Label();
            txtLabels = new TextBox();
            label4 = new Label();
            txtKeywords = new TextBox();
            label5 = new Label();
            txtTags = new TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnStore = new Button();
            btnRevert = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripEditStatus });
            statusStrip1.Location = new Point(0, 409);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(785, 17);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "Ready";
            toolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // toolStripEditStatus
            // 
            toolStripEditStatus.ImageAlign = ContentAlignment.MiddleLeft;
            toolStripEditStatus.Name = "toolStripEditStatus";
            toolStripEditStatus.Size = new Size(0, 17);
            toolStripEditStatus.TextAlign = ContentAlignment.MiddleLeft;
            toolStripEditStatus.ToolTipText = "Editing status";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator5, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Image = Properties.Resources.Folder_32x32;
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            openToolStripMenuItem.Size = new Size(164, 22);
            openToolStripMenuItem.Text = "&Open";
            openToolStripMenuItem.ToolTipText = "Open bookmarks file";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Image = Properties.Resources.Save_32x32;
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(164, 22);
            saveAsToolStripMenuItem.Text = "&Save as ...";
            saveAsToolStripMenuItem.ToolTipText = "Save current changes into a new file";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(161, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Image = Properties.Resources.Log_Out_32x32;
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Q;
            exitToolStripMenuItem.Size = new Size(164, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.ToolTipText = "Exit application";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { copyToolStripMenuItem, pasteToolStripMenuItem, cutToolStripMenuItem, toolStripSeparator6, addNewToolStripMenuItem, deleteToolStripMenuItem, renameToolStripMenuItem, toolStripSeparator7, toolStripMenuItem1 });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.Copy_32x32;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
            copyToolStripMenuItem.Size = new Size(157, 22);
            copyToolStripMenuItem.Text = "&Copy";
            copyToolStripMenuItem.ToolTipText = "Copy selected into clipboard";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Enabled = false;
            pasteToolStripMenuItem.Image = Properties.Resources.Paste_32x32;
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            pasteToolStripMenuItem.Size = new Size(157, 22);
            pasteToolStripMenuItem.Text = "&Paste";
            pasteToolStripMenuItem.ToolTipText = "Paste into current selection";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Image = Properties.Resources.Cut_32x32;
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.X;
            cutToolStripMenuItem.Size = new Size(157, 22);
            cutToolStripMenuItem.Text = "C&ut";
            cutToolStripMenuItem.ToolTipText = "Cut seleted";
            cutToolStripMenuItem.Click += toolStripCut_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(154, 6);
            // 
            // addNewToolStripMenuItem
            // 
            addNewToolStripMenuItem.Enabled = false;
            addNewToolStripMenuItem.Image = Properties.Resources.Add_32x32;
            addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            addNewToolStripMenuItem.ShortcutKeys = Keys.Insert;
            addNewToolStripMenuItem.Size = new Size(157, 22);
            addNewToolStripMenuItem.Text = "&Add new";
            addNewToolStripMenuItem.ToolTipText = "Add new link to bookmarks";
            addNewToolStripMenuItem.Click += addNewToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Enabled = false;
            deleteToolStripMenuItem.Image = Properties.Resources.Delete_32x32;
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys = Keys.Delete;
            deleteToolStripMenuItem.Size = new Size(157, 22);
            deleteToolStripMenuItem.Text = "&Delete";
            deleteToolStripMenuItem.ToolTipText = "Delete selected";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // renameToolStripMenuItem
            // 
            renameToolStripMenuItem.Enabled = false;
            renameToolStripMenuItem.Image = Properties.Resources.Rename_32x32;
            renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            renameToolStripMenuItem.ShortcutKeys = Keys.F2;
            renameToolStripMenuItem.Size = new Size(157, 22);
            renameToolStripMenuItem.Text = "&Rename";
            renameToolStripMenuItem.ToolTipText = "Rename selected item";
            renameToolStripMenuItem.Click += renameToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(154, 6);
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { allToolStripMenuItem, invertToolStripMenuItem, noneToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(157, 22);
            toolStripMenuItem1.Text = "&Select";
            toolStripMenuItem1.ToolTipText = "Selection menu";
            // 
            // allToolStripMenuItem
            // 
            allToolStripMenuItem.Name = "allToolStripMenuItem";
            allToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            allToolStripMenuItem.Size = new Size(168, 22);
            allToolStripMenuItem.Text = "&All";
            allToolStripMenuItem.Click += allToolStripMenuItem_Click;
            // 
            // invertToolStripMenuItem
            // 
            invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            invertToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            invertToolStripMenuItem.Size = new Size(168, 22);
            invertToolStripMenuItem.Text = "&Invert";
            invertToolStripMenuItem.ToolTipText = "Invert selection";
            invertToolStripMenuItem.Click += invertToolStripMenuItem_Click;
            // 
            // noneToolStripMenuItem
            // 
            noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            noneToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Space;
            noneToolStripMenuItem.Size = new Size(168, 22);
            noneToolStripMenuItem.Text = "&None";
            noneToolStripMenuItem.ToolTipText = "Clear selection";
            noneToolStripMenuItem.Click += noneToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuItemFindDuplicated, gotoURIToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // menuItemFindDuplicated
            // 
            menuItemFindDuplicated.Enabled = false;
            menuItemFindDuplicated.Image = Properties.Resources.Search_32x32;
            menuItemFindDuplicated.Name = "menuItemFindDuplicated";
            menuItemFindDuplicated.ShortcutKeys = Keys.Control | Keys.F;
            menuItemFindDuplicated.Size = new Size(196, 22);
            menuItemFindDuplicated.Text = "&Find duplicated";
            menuItemFindDuplicated.ToolTipText = "Find duplicates among bookmarks";
            menuItemFindDuplicated.Click += menuItemFindDuplicated_Click;
            // 
            // gotoURIToolStripMenuItem
            // 
            gotoURIToolStripMenuItem.Enabled = false;
            gotoURIToolStripMenuItem.Image = Properties.Resources.Globe_32x32;
            gotoURIToolStripMenuItem.Name = "gotoURIToolStripMenuItem";
            gotoURIToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            gotoURIToolStripMenuItem.Size = new Size(196, 22);
            gotoURIToolStripMenuItem.Text = "Goto URI";
            gotoURIToolStripMenuItem.ToolTipText = "Goto selected URI";
            gotoURIToolStripMenuItem.Click += gotoURIToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripExit, toolStripSeparator1, toolStripOpen, toolStripSave, toolStripSeparator2, toolStripFind, gotoURI, toolStripSeparator4, toolStripCopy, toolStripPaste, toolStripCut, toolStripSeparator3, toolStripAdd, toolStripDelete, toolStripRename });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripExit
            // 
            toolStripExit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripExit.Image = Properties.Resources.Log_Out_32x32;
            toolStripExit.ImageTransparentColor = Color.Magenta;
            toolStripExit.Name = "toolStripExit";
            toolStripExit.Size = new Size(23, 22);
            toolStripExit.Text = "Exit";
            toolStripExit.ToolTipText = "Exit application";
            toolStripExit.Click += exitToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripOpen
            // 
            toolStripOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripOpen.Image = Properties.Resources.Folder_32x32;
            toolStripOpen.ImageTransparentColor = Color.Magenta;
            toolStripOpen.Name = "toolStripOpen";
            toolStripOpen.Size = new Size(23, 22);
            toolStripOpen.Text = "Open...";
            toolStripOpen.ToolTipText = "Open bookmarks file";
            toolStripOpen.Click += openToolStripMenuItem_Click;
            // 
            // toolStripSave
            // 
            toolStripSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripSave.Enabled = false;
            toolStripSave.Image = Properties.Resources.Save_32x32;
            toolStripSave.ImageTransparentColor = Color.Magenta;
            toolStripSave.Name = "toolStripSave";
            toolStripSave.Size = new Size(23, 22);
            toolStripSave.Text = "Save";
            toolStripSave.ToolTipText = "Save bookmarks file";
            toolStripSave.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // toolStripFind
            // 
            toolStripFind.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripFind.Enabled = false;
            toolStripFind.Image = Properties.Resources.Search_32x32;
            toolStripFind.ImageTransparentColor = Color.Magenta;
            toolStripFind.Name = "toolStripFind";
            toolStripFind.Size = new Size(23, 22);
            toolStripFind.Text = "Find duplicates";
            toolStripFind.ToolTipText = "Find duplicates among bookmarks";
            toolStripFind.Click += menuItemFindDuplicated_Click;
            // 
            // gotoURI
            // 
            gotoURI.DisplayStyle = ToolStripItemDisplayStyle.Image;
            gotoURI.Enabled = false;
            gotoURI.Image = Properties.Resources.Globe_32x32;
            gotoURI.ImageTransparentColor = Color.Magenta;
            gotoURI.Name = "gotoURI";
            gotoURI.Size = new Size(23, 22);
            gotoURI.Text = "Go to selected URI";
            gotoURI.ToolTipText = "Go to selected URI";
            gotoURI.Click += gotoURIToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripCopy
            // 
            toolStripCopy.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripCopy.Image = Properties.Resources.Copy_32x32;
            toolStripCopy.ImageTransparentColor = Color.Magenta;
            toolStripCopy.Name = "toolStripCopy";
            toolStripCopy.Size = new Size(23, 22);
            toolStripCopy.Text = "Copy selected";
            toolStripCopy.Click += copyToolStripMenuItem_Click;
            // 
            // toolStripPaste
            // 
            toolStripPaste.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripPaste.Enabled = false;
            toolStripPaste.Image = Properties.Resources.Paste_32x32;
            toolStripPaste.ImageTransparentColor = Color.Magenta;
            toolStripPaste.Name = "toolStripPaste";
            toolStripPaste.Size = new Size(23, 22);
            toolStripPaste.Text = "Paste copied";
            toolStripPaste.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripCut
            // 
            toolStripCut.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripCut.Image = Properties.Resources.Cut_32x32;
            toolStripCut.ImageTransparentColor = Color.Magenta;
            toolStripCut.Name = "toolStripCut";
            toolStripCut.Size = new Size(23, 22);
            toolStripCut.Text = "Cut selected";
            toolStripCut.Click += toolStripCut_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // toolStripAdd
            // 
            toolStripAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripAdd.Enabled = false;
            toolStripAdd.Image = Properties.Resources.Add_32x32;
            toolStripAdd.ImageTransparentColor = Color.Magenta;
            toolStripAdd.Name = "toolStripAdd";
            toolStripAdd.Size = new Size(23, 22);
            toolStripAdd.Text = "Add new bookmark";
            // 
            // toolStripDelete
            // 
            toolStripDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripDelete.Enabled = false;
            toolStripDelete.Image = Properties.Resources.Delete_32x32;
            toolStripDelete.ImageTransparentColor = Color.Magenta;
            toolStripDelete.Name = "toolStripDelete";
            toolStripDelete.Size = new Size(23, 22);
            toolStripDelete.Text = "Delete selected";
            toolStripDelete.Click += deleteToolStripMenuItem_Click;
            // 
            // toolStripRename
            // 
            toolStripRename.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripRename.Enabled = false;
            toolStripRename.Image = (Image)resources.GetObject("toolStripRename.Image");
            toolStripRename.ImageTransparentColor = Color.Magenta;
            toolStripRename.Name = "toolStripRename";
            toolStripRename.Size = new Size(23, 22);
            toolStripRename.Text = "Rename";
            toolStripRename.ToolTipText = "Rename selected item";
            toolStripRename.Click += renameToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 49);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(treeView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new Size(800, 360);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 3;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.FullRowSelect = true;
            treeView1.HideSelection = false;
            treeView1.ImageIndex = 0;
            treeView1.ImageList = smallImagesList;
            treeView1.LabelEdit = true;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.PathSeparator = "/";
            treeView1.SelectedImageIndex = 0;
            treeView1.ShowRootLines = false;
            treeView1.Size = new Size(266, 360);
            treeView1.StateImageList = smallImagesList;
            treeView1.TabIndex = 0;
            treeView1.BeforeLabelEdit += treeView1_BeforeLabelEdit;
            treeView1.AfterLabelEdit += treeView1_AfterLabelEdit;
            treeView1.BeforeExpand += treeView1_BeforeExpand;
            treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.Enter += treeView1_Enter;
            treeView1.Leave += treeView1_Leave;
            // 
            // smallImagesList
            // 
            smallImagesList.ColorDepth = ColorDepth.Depth32Bit;
            smallImagesList.ImageStream = (ImageListStreamer)resources.GetObject("smallImagesList.ImageStream");
            smallImagesList.TransparentColor = Color.Transparent;
            smallImagesList.Images.SetKeyName(0, "Star-Full.ico");
            smallImagesList.Images.SetKeyName(1, "Star-Empty.ico");
            smallImagesList.Images.SetKeyName(2, "Globe.ico");
            smallImagesList.Images.SetKeyName(3, "Star-Half-Full.ico");
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.MinimumSize = new Size(500, 200);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(listView1);
            splitContainer2.Panel1MinSize = 50;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer2.Panel2MinSize = 220;
            splitContainer2.Size = new Size(530, 360);
            splitContainer2.SplitterDistance = 136;
            splitContainer2.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeaderName, columnHeaderLabels, columnHeaderAddress });
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.LargeImageList = bigImageList;
            listView1.Location = new Point(0, 0);
            listView1.Name = "listView1";
            listView1.Size = new Size(530, 136);
            listView1.SmallImageList = smallImagesList;
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ColumnClick += listView1_ColumnClick;
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            listView1.Enter += listView1_Enter;
            listView1.Leave += listView1_Leave;
            // 
            // columnHeaderName
            // 
            columnHeaderName.Text = "Name";
            columnHeaderName.Width = 200;
            // 
            // columnHeaderLabels
            // 
            columnHeaderLabels.Text = "Labels";
            columnHeaderLabels.Width = 100;
            // 
            // columnHeaderAddress
            // 
            columnHeaderAddress.Text = "Address";
            columnHeaderAddress.Width = 200;
            // 
            // bigImageList
            // 
            bigImageList.ColorDepth = ColorDepth.Depth32Bit;
            bigImageList.ImageStream = (ImageListStreamer)resources.GetObject("bigImageList.ImageStream");
            bigImageList.TransparentColor = Color.Transparent;
            bigImageList.Images.SetKeyName(0, "Star-Full.ico");
            bigImageList.Images.SetKeyName(1, "Star-Empty.ico");
            bigImageList.Images.SetKeyName(2, "Globe.ico");
            bigImageList.Images.SetKeyName(3, "Star-Half-Full.ico");
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(txtAddress, 1, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(txtLabels, 1, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(txtKeywords, 1, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(txtTags, 1, 4);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.MinimumSize = new Size(500, 120);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(530, 220);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 3);
            label1.Margin = new Padding(3, 3, 3, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "&Name:";
            // 
            // txtName
            // 
            txtName.Dock = DockStyle.Top;
            txtName.Location = new Point(70, 3);
            txtName.Name = "txtName";
            txtName.Size = new Size(457, 23);
            txtName.TabIndex = 1;
            txtName.Enter += txtName_Enter;
            txtName.Leave += txtName_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 32);
            label2.Margin = new Padding(3, 3, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "&Address:";
            // 
            // txtAddress
            // 
            txtAddress.Dock = DockStyle.Top;
            txtAddress.Location = new Point(70, 32);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(457, 23);
            txtAddress.TabIndex = 3;
            txtAddress.Enter += txtName_Enter;
            txtAddress.Leave += txtAddress_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 61);
            label3.Margin = new Padding(3, 3, 3, 0);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 4;
            label3.Text = "&Labels:";
            // 
            // txtLabels
            // 
            txtLabels.Dock = DockStyle.Top;
            txtLabels.Location = new Point(70, 61);
            txtLabels.Name = "txtLabels";
            txtLabels.Size = new Size(457, 23);
            txtLabels.TabIndex = 5;
            txtLabels.Enter += txtName_Enter;
            txtLabels.Leave += txtLabels_Leave;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 90);
            label4.Margin = new Padding(3, 3, 3, 0);
            label4.Name = "label4";
            label4.Size = new Size(61, 15);
            label4.TabIndex = 6;
            label4.Text = "&Keywords:";
            // 
            // txtKeywords
            // 
            txtKeywords.Dock = DockStyle.Top;
            txtKeywords.Location = new Point(70, 90);
            txtKeywords.Name = "txtKeywords";
            txtKeywords.Size = new Size(457, 23);
            txtKeywords.TabIndex = 7;
            txtKeywords.Enter += txtName_Enter;
            txtKeywords.Leave += txtKeywords_Leave;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 119);
            label5.Margin = new Padding(3, 3, 3, 0);
            label5.Name = "label5";
            label5.Size = new Size(34, 15);
            label5.TabIndex = 8;
            label5.Text = "&Tags:";
            // 
            // txtTags
            // 
            txtTags.Dock = DockStyle.Top;
            txtTags.Location = new Point(70, 119);
            txtTags.Name = "txtTags";
            txtTags.Size = new Size(457, 23);
            txtTags.TabIndex = 9;
            txtTags.Enter += txtName_Enter;
            txtTags.Leave += txtTags_Leave;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnStore);
            flowLayoutPanel1.Controls.Add(btnRevert);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(70, 139);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(457, 37);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // btnStore
            // 
            btnStore.Enabled = false;
            btnStore.Location = new Point(5, 5);
            btnStore.Margin = new Padding(5, 5, 3, 3);
            btnStore.Name = "btnStore";
            btnStore.Size = new Size(75, 23);
            btnStore.TabIndex = 0;
            btnStore.Text = "&Store";
            btnStore.UseVisualStyleBackColor = true;
            btnStore.Click += btnStore_Click;
            // 
            // btnRevert
            // 
            btnRevert.Enabled = false;
            btnRevert.Location = new Point(88, 5);
            btnRevert.Margin = new Padding(5, 5, 3, 3);
            btnRevert.Name = "btnRevert";
            btnRevert.Size = new Size(75, 23);
            btnRevert.TabIndex = 1;
            btnRevert.Text = "&Revert";
            btnRevert.UseVisualStyleBackColor = true;
            btnRevert.Click += btnRevert_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "json";
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Filter = "Bookmark files|*.json";
            openFileDialog1.Title = "Open Mozilla Firefox bookmarks file";
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.DefaultExt = "json";
            saveFileDialog1.Filter = "Bookmarks file|*.json";
            saveFileDialog1.Title = "Save edited bookmarks to";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 431);
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Bookmarks";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private SplitContainer splitContainer1;
        private TreeView treeView1;
        private SplitContainer splitContainer2;
        private ListView listView1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtName;
        private Label label2;
        private TextBox txtAddress;
        private Label label3;
        private TextBox txtLabels;
        private Label label4;
        private TextBox txtKeywords;
        private ColumnHeader columnHeaderName;
        private ColumnHeader columnHeaderLabels;
        private ColumnHeader columnHeaderAddress;
        private ToolStripButton toolStripExit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripOpen;
        private ToolStripButton toolStripSave;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripCopy;
        private ToolStripButton toolStripPaste;
        private ToolStripButton toolStripFind;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton toolStripCut;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripAdd;
        private ToolStripButton toolStripDelete;
        private ImageList smallImagesList;
        private ImageList bigImageList;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem addNewToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem menuItemFindDuplicated;
        private ToolStripMenuItem gotoURIToolStripMenuItem;
        private ToolStripButton gotoURI;
        private SaveFileDialog saveFileDialog1;
        private Label label5;
        private TextBox txtTags;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnStore;
        private Button btnRevert;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripEditStatus;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem allToolStripMenuItem;
        private ToolStripMenuItem invertToolStripMenuItem;
        private ToolStripMenuItem noneToolStripMenuItem;
        private ToolStripMenuItem renameToolStripMenuItem;
        private ToolStripButton toolStripRename;
    }
}
