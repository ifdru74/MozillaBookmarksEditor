using MozillaBookmarksEditor.Properties;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MozillaBookmarksEditor
{
    public partial class MainForm : Form
    {
        BookmarksJsonFile bookmarksJsonFile;
        private ListViewColumnSorter lvwColumnSorter;
        private Bookmark? editedBookmark;
        private bool editedBookmarkChanged;
        private bool editedBookmarkLocked;
        private List<Bookmark> clippedBoormarks;
        private bool clipToMove;
        Bookmark? clipSrc;
        public MainForm()
        {
            clipToMove = editedBookmarkChanged = editedBookmarkLocked = false;
            bookmarksJsonFile = new BookmarksJsonFile();
            lvwColumnSorter = new ListViewColumnSorter();
            clippedBoormarks = new List<Bookmark>();
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treeView1.Nodes.Clear();
                menuItemFindDuplicated.Enabled = toolStripFind.Enabled = false;
                try
                {
                    bookmarksJsonFile.ReadJsonFile(openFileDialog1.FileName);
                    CreateTreeNode(bookmarksJsonFile.root);
                    Text = openFileDialog1.FileName;
                    toolStripEditStatus.Text = "Loaded";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            menuItemFindDuplicated.Enabled = toolStripFind.Enabled = saveAsToolStripMenuItem.Enabled = toolStripSave.Enabled = bookmarksJsonFile.root != null;
        }

        private void CreateTreeNode(Bookmark root)
        {
            treeView1.Nodes.Clear();
            TreeNode node = new TreeNode("Top");
            node.Tag = root;
            node.ImageIndex = 2;
            node.SelectedImageIndex = 2;
            treeView1.Nodes.Add(node);
            AddChildren(node, root);
            node.Expand();
        }

        private int AddChildren(TreeNode node, Bookmark root)
        {
            if (root.children == null) return -2;
            foreach (Bookmark child in root.children)
            {
                if (child.typeCode == 2 && (child.type ?? "") == "text/x-moz-place-container")
                {
                    TreeNode childNode = new TreeNode(child.title);
                    childNode.Tag = child;
                    node.Nodes.Add(childNode);
                    childNode.ImageIndex = 0;
                    childNode.SelectedImageIndex = 0;
                    if (child.hasSubFolders())
                    {
                        childNode.Nodes.Add("");
                    }
                    continue;
                }
            }
            return node.Nodes.Count - 1;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node == null) return;
            TreeNode tNode = e.Node;
            Bookmark? bookmark = tNode.Tag as Bookmark;
            if (tNode.Nodes.Count == 1 && bookmark != null)
            {
                TreeNode fNode = tNode.Nodes[0];
                if (fNode == null) return;
                if (fNode.Tag == null && fNode.Text == "")
                {
                    if (AddChildren(tNode, bookmark) != -2)
                    {
                        tNode.Nodes.Remove(fNode);
                    }
                }
            }
        }
        private void updateListView(Bookmark? bookmark)
        {
            listView1.Items.Clear();
            txtAddress.Text =
                txtKeywords.Text =
                txtLabels.Text =
                txtName.Text =
                txtTags.Text = "";
            enableGoto();
            listView1.Tag = bookmark;
            toolStripDelete.Enabled =
                deleteToolStripMenuItem.Enabled =
                addNewToolStripMenuItem.Enabled =
                toolStripAdd.Enabled = true;
            if (bookmark != null && bookmark.hasChildren())
            {
                foreach (Bookmark bm in bookmark.children)
                {
                    if (bm == null) continue;
                    if (bm.typeCode == 1 || bm.type == "text/x-moz-place")
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = bm;
                        lvi.Text = bm.title ?? "";
                        lvi.SubItems.Add(bm.keyword ?? "");
                        lvi.SubItems.Add(bm.uri ?? "");
                        lvi.ImageIndex = 1;
                        listView1.Items.Add(lvi);
                        continue;
                    }
                    if (bm.typeCode == 3 || bm.type == "text/x-moz-place-separator")
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Tag = bm;
                        lvi.ImageIndex = 3;
                        listView1.Items.Add(lvi);
                        continue;
                    }
                }
            }

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Tag = null;
            if (e.Node == null)
            {
                addNewToolStripMenuItem.Enabled = toolStripAdd.Enabled = false;
                return;
            }
            updateListView(e.Node.Tag as Bookmark);
            // fill status bar
            toolStripStatusLabel1.Text = e.Node.FullPath.Substring(3);
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            editedBookmarkLocked = true;
            btnRevert.Enabled = btnStore.Enabled = editedBookmarkChanged = false;
            toolStripDelete.Enabled = deleteToolStripMenuItem.Enabled = (listView1.SelectedIndices.Count > 0);
            if (e.Item == null || !e.IsSelected || listView1.SelectedItems.Count > 1)
            {
                editedBookmark = null;
                txtAddress.Text =
                    txtKeywords.Text =
                    txtLabels.Text =
                    txtName.Text =
                    txtTags.Text = "";
            }
            else
            {
                editedBookmark = e.Item.Tag as Bookmark;
                if (editedBookmark != null)
                {
                    txtAddress.Text = editedBookmark.uri ?? "";
                    txtKeywords.Text = editedBookmark.keyword ?? "";
                    txtLabels.Text = editedBookmark.label ?? "";
                    txtName.Text = editedBookmark.title ?? "";
                    txtTags.Text = editedBookmark.tags ?? "";
                }
            }
            enableGoto();
            editedBookmarkLocked = false;
        }
        void enableGoto()
        {
            gotoURI.Enabled = gotoURIToolStripMenuItem.Enabled = txtAddress.Text.Length > 0 && txtAddress.Text.StartsWith("http");
        }
        private void gotoURIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.Length > 0 && txtAddress.Text.StartsWith("http"))
            {
                Process.Start(new ProcessStartInfo(txtAddress.Text) { UseShellExecute = true });
            }
        }
        bool isVisible(int coord, bool bY = false)
        {
            if (coord == 0) return false;
            foreach (Screen scr in Screen.AllScreens)
            {
                if (bY)
                {
                    if (scr.Bounds.Top <= coord && scr.Bounds.Bottom >= coord) return true;
                }
                else
                {
                    if (scr.Bounds.Left <= coord && scr.Bounds.Right >= coord) return true;
                }
            }
            return false;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.upgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.upgradeRequired = true;
                Properties.Settings.Default.Save();
            }
            openFileDialog1.InitialDirectory = Properties.Settings.Default.OpenFileFolder;
            saveFileDialog1.InitialDirectory = Properties.Settings.Default.SaveFileFolder;
            if (isVisible(Properties.Settings.Default.Top, true))
            {
                Top = Properties.Settings.Default.Top;
            }
            if (isVisible(Properties.Settings.Default.Left))
            {
                Left = Properties.Settings.Default.Left;
            }
            if (Properties.Settings.Default.Height != 0 && isVisible(Properties.Settings.Default.Height + Top, true))
            {
                Height = Properties.Settings.Default.Height;
            }
            if (Properties.Settings.Default.Width != 0 && isVisible(Properties.Settings.Default.Width + Left))
            {
                Width = Properties.Settings.Default.Width;
            }
            string wsl = Properties.Settings.Default.listView1;
            if (wsl.Length > 0)
            {
                string[] acw = wsl.Split(',');
                if (acw != null)
                {
                    for (int i = 0; i < acw.Length; i++)
                    {
                        if (int.TryParse(acw[i], out int value))
                        {
                            if (value > 0)
                            {
                                listView1.Columns[i].Width = value;
                            }
                        }
                    }
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.OpenFileFolder = openFileDialog1.InitialDirectory;
            Properties.Settings.Default.SaveFileFolder = saveFileDialog1.InitialDirectory;
            Properties.Settings.Default.Top = Top;
            Properties.Settings.Default.Left = Left;
            Properties.Settings.Default.Height = Height;
            Properties.Settings.Default.Width = Width;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
                if (i != 0)
                {
                    sb.Append(",");
                }
                sb.Append(listView1.Columns[i].Width.ToString());
            }
            Properties.Settings.Default.listView1 = sb.ToString();
            Properties.Settings.Default.Save();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Focused && treeView1.SelectedNode != null)
            {
                TreeNode sn = treeView1.SelectedNode;
                Bookmark? selContainer = treeView1.SelectedNode.Tag as Bookmark;
                if (selContainer != null)
                {
                    TreeNode pn = treeView1.SelectedNode.Parent;
                    if (pn != null)
                    {
                        Bookmark? parentContainer = pn.Tag as Bookmark;
                        if (parentContainer != null)
                        {
                            parentContainer.children.Remove(selContainer);
                            treeView1.SelectedNode = pn;
                            pn.Nodes.Remove(sn);
                            toolStripEditStatus.Text = "Altered";
                            return;
                        }
                    }
                }
            }
            if (listView1.Tag == null || listView1.SelectedIndices.Count == 0) { return; }
            Bookmark? folder = listView1.Tag as Bookmark;
            if (folder != null)
            {
                foreach (ListViewItem lvi in listView1.SelectedItems)
                {
                    Bookmark? item = lvi.Tag as Bookmark;
                    if (item != null)
                    {
                        listView1.Items.Remove(lvi);
                        folder.children.Remove(item);
                        toolStripEditStatus.Text = "Altered";
                    }
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.Nodes.Count == 0) { return; }
            TreeNode rootNode = treeView1.Nodes[0];
            if (rootNode == null) { return; }
            Bookmark? root = rootNode.Tag as Bookmark;
            if (root == null) { return; }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                menuItemFindDuplicated.Enabled = toolStripFind.Enabled = false;
                try
                {
                    bookmarksJsonFile.WriteJsonFile(saveFileDialog1.FileName, root);
                    Text = saveFileDialog1.FileName;
                    toolStripEditStatus.Text = "Saved";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (lvwColumnSorter != listView1.ListViewItemSorter)
            {
                listView1.ListViewItemSorter = lvwColumnSorter;
            }
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            try
            {
                listView1.Sort();

            }
            catch (Exception)
            {
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            compareStringFromUI(txtName.Text, BookmarkField.Title);
        }

        private void txtAddress_Leave(object sender, EventArgs e)
        {
            compareStringFromUI(txtAddress.Text, BookmarkField.Uri);
        }
        private void compareStringFromUI(string uiVal, BookmarkField field)
        {
            if (!editedBookmarkChanged && !editedBookmarkLocked)
            {
                if (editedBookmark != null)
                {
                    string bmVal = "";
                    switch (field)
                    {
                        case BookmarkField.Title:
                            bmVal = editedBookmark.title ?? string.Empty;
                            break;
                        case BookmarkField.Uri:
                            bmVal = editedBookmark.uri ?? string.Empty;
                            break;
                        case BookmarkField.Guid:
                            bmVal = editedBookmark.guid ?? string.Empty;
                            break;
                        case BookmarkField.Label:
                            bmVal = editedBookmark.label ?? string.Empty;
                            break;
                        case BookmarkField.IconUri:
                            bmVal = editedBookmark.iconUri ?? string.Empty;
                            break;
                        case BookmarkField.Keyword:
                            bmVal = editedBookmark.keyword ?? string.Empty;
                            break;
                        case BookmarkField.Root:
                            bmVal = editedBookmark.root ?? string.Empty;
                            break;
                        case BookmarkField.Type:
                            bmVal = editedBookmark.type ?? string.Empty;
                            break;
                    }
                    if (uiVal != bmVal)
                    {
                        btnRevert.Enabled = btnStore.Enabled = editedBookmarkChanged = true;
                    }
                }
            }
        }
        private void txtLabels_Leave(object sender, EventArgs e)
        {
            compareStringFromUI(txtLabels.Text, BookmarkField.Label);
        }

        private void txtKeywords_Leave(object sender, EventArgs e)
        {
            compareStringFromUI(txtKeywords.Text, BookmarkField.Keyword);
        }

        private void txtTags_Leave(object sender, EventArgs e)
        {
            compareStringFromUI(txtKeywords.Text, BookmarkField.Tags);
        }

        private void btnStore_Click(object sender, EventArgs e)
        {
            if (editedBookmark != null)
            {
                editedBookmark.uri = txtAddress.Text;
                editedBookmark.keyword = txtKeywords.Text;
                editedBookmark.label = txtLabels.Text;
                editedBookmark.title = txtName.Text;
                editedBookmark.tags = txtTags.Text;
                btnRevert.Enabled = btnStore.Enabled = editedBookmarkChanged = false;
                toolStripEditStatus.Text = "Edited";
            }

        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (editedBookmark != null)
            {
                txtAddress.Text = editedBookmark.uri ?? "";
                txtKeywords.Text = editedBookmark.keyword ?? "";
                txtLabels.Text = editedBookmark.keyword ?? "";
                txtName.Text = editedBookmark.title ?? "";
                txtTags.Text = editedBookmark.tags ?? "";
                btnRevert.Enabled = btnStore.Enabled = editedBookmarkChanged = false;
            }

        }
        void iterateContainer(SimilarLinks links, Bookmark cont, string bmPath)
        {
            if (cont.children == null)
            {
                return;
            }
            foreach (Bookmark bm in cont.children)
            {
                switch (bm.getItemType())
                {
                    case BookmarkType.URL:
                        links.Add(bm, bmPath);
                        break;
                    case BookmarkType.Container:
                        iterateContainer(links, bm, bmPath + "/" + bm.title);
                        break;
                    default:
                        break;
                }
            }
        }
        private void menuItemFindDuplicated_Click(object sender, EventArgs e)
        {
            SimilarLinks links = new SimilarLinks();
            Bookmark? bmroot = null;
            Bookmark? bm = null;
            if (treeView1.SelectedNode != null)
            {
                bm = treeView1.SelectedNode.Tag as Bookmark;
                if (bm != null)
                {
                    iterateContainer(links, bm, treeView1.SelectedNode.FullPath.Substring(3));
                    bmroot = bm;
                }
            }
            if (bmroot == null)
            {
                iterateContainer(links, bookmarksJsonFile.root, "");
                bmroot = bookmarksJsonFile.root;
            }
            if (links.links.Count < 1)
            {
                MessageBox.Show("Unable to find items under selected tree node", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            links.RemoveUnique();
            if (links.links.Count < 1)
            {
                MessageBox.Show("No duplicated items found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SimilarBookmarksFrm smf = new SimilarBookmarksFrm(links);
            if (smf.ShowDialog() == DialogResult.OK)
            {
                int deletedCount = 0;
                foreach (string uri in links.links.Keys)
                {
                    foreach (BookmarkWithPath bmwp in links.links[uri])
                    {
                        if (bmwp.Checked)
                        {
                            deleteBookmarkByTreePath(bmwp.Bookmark, bmwp.Path);
                            deletedCount++;
                        }
                    }
                }
                if (deletedCount > 0)
                {
                    updateListView(bm);
                    toolStripEditStatus.Text = "Altered";
                }
                else
                {
                    MessageBox.Show("No items selected for removal", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void deleteBookmarkByTreePath(Bookmark bookmark, string Path)
        {
            TreeNode? tn = gotoTreeNode(Path);
            if (tn != null)
            {
                Bookmark? bm = tn.Tag as Bookmark;
                if (bm != null)
                {
                    bm.children.Remove(bookmark);
                }
            }
        }

        private TreeNode? gotoTreeNode(string Path)
        {
            if (Path.Length < 1)
            {
                return null;
            }
            string[] aparts = Path.Split('/');
            if (aparts.Length < 1)
            {
                return null;
            }
            int idx = 0;
            TreeNode? tnRet = null;
            TreeNodeCollection nodes = treeView1.Nodes;
            while (idx < aparts.Length)
            {
                bool bFound = false;
                foreach (TreeNode tn in nodes)
                {
                    if (aparts[idx] == string.Empty || tn.Text == aparts[idx])
                    {
                        if (idx == aparts.Length - 1)
                        {
                            tnRet = tn;
                        }
                        idx++;
                        nodes = tn.Nodes;
                        bFound = true;
                        break;
                    }
                }
                if (!bFound)
                {
                    break;
                }
            }
            return tnRet;
        }
        /**
         * Copy/Cut/Paste have nothing to do with Windows clipboard.
         * They use internal list (clippedBoormarks) and move flag (clipToMove)
         * to make bookmarks copy or movement.
         * Please be noticed: if listView focused then list view selected items 
         * will go to the list (clippedBoormarks), otherwise selected tree node does.
         */
        private void updateClippedBoormarks(bool bMove)
        {
            clipSrc = null;
            clippedBoormarks.Clear();
            if (listView1.SelectedItems != null && listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    Bookmark? bm = item.Tag as Bookmark;
                    if (bm != null)
                    {
                        clippedBoormarks.Add(bm);
                    }
                }
                clipSrc = listView1.Tag as Bookmark;
            }
            else
            {
                if (treeView1.SelectedNode != null)
                {
                    Bookmark? bm = treeView1.SelectedNode.Tag as Bookmark;
                    if (bm != null)
                    {
                        clippedBoormarks.Add(bm);
                        if (treeView1.SelectedNode.Parent != null)
                        {
                            clipSrc = treeView1.SelectedNode.Parent.Tag as Bookmark;
                        }

                    }
                }
            }
            pasteToolStripMenuItem.Enabled = toolStripPaste.Enabled = (clippedBoormarks.Count > 0 && clipSrc != null);
            clipToMove = bMove;
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateClippedBoormarks(false); // ask for a copy
        }

        private void toolStripCut_Click(object sender, EventArgs e)
        {
            updateClippedBoormarks(true); // ask for a move
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null && clipSrc != null)
            {
                Bookmark? bm = treeView1.SelectedNode.Tag as Bookmark;
                if (bm != null && bm != clipSrc && bm.getItemType() == BookmarkType.Container)
                {
                    if (clippedBoormarks.Count > 0)
                    {
                        foreach (Bookmark cbm in clippedBoormarks)
                        {
                            bm.AddChild(cbm);
                            if (clipToMove)
                            {
                                clipSrc.children.Remove(cbm);
                            }
                        }
                    }
                    updateListView(bm);
                }
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Focused)
            {
                foreach (ListViewItem lvi in listView1.Items)
                {
                    lvi.Selected = true;
                }
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Focused)
            {
                foreach (ListViewItem lvi in listView1.Items)
                {
                    lvi.Selected = !lvi.Selected;
                }
            }
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.Focused)
            {
                foreach (ListViewItem lvi in listView1.Items)
                {
                    lvi.Selected = false;
                }
            }
            else
            {
                if (treeView1.SelectedNode != null)
                {
                    treeView1.SelectedNode = null;
                }
            }
        }

        private void treeView1_Enter(object sender, EventArgs e)
        {
            noneToolStripMenuItem.Enabled = true;
            invertToolStripMenuItem.Enabled = allToolStripMenuItem.Enabled = !noneToolStripMenuItem.Enabled;
            renameToolStripMenuItem.Enabled = toolStripRename.Enabled = true;
        }

        private void treeView1_Leave(object sender, EventArgs e)
        {
            renameToolStripMenuItem.Enabled = toolStripRename.Enabled = false;
            invertToolStripMenuItem.Enabled = allToolStripMenuItem.Enabled = noneToolStripMenuItem.Enabled = false;
        }

        private void listView1_Enter(object sender, EventArgs e)
        {
            invertToolStripMenuItem.Enabled = allToolStripMenuItem.Enabled = noneToolStripMenuItem.Enabled = true;
        }

        private void listView1_Leave(object sender, EventArgs e)
        {
            invertToolStripMenuItem.Enabled = allToolStripMenuItem.Enabled = noneToolStripMenuItem.Enabled = false;
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                if (!treeView1.SelectedNode.IsEditing)
                {
                    treeView1.SelectedNode.BeginEdit();
                }
            }
        }

        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            bool bCancel = true;
            if (e.Node != null)
            {
                Bookmark? bm = e.Node.Tag as Bookmark;
                if (bm != null)
                {
                    bCancel = false;
                }
            }
            e.CancelEdit = bCancel;
        }

        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node != null)
            {
                Bookmark? bm = e.Node.Tag as Bookmark;
                if (bm != null)
                {
                    bm.title = e.Label ?? e.Node.Text;
                }
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bookmark? bm = null;
            if (treeView1.SelectedNode != null)
            {
                Bookmark? bc = treeView1.SelectedNode.Tag as Bookmark;
                if (listView1.Focused)
                {
                    bm = Bookmark.MakeBookmark(Bookmark._TypeCodeURL);
                }
                else
                {
                    bm = Bookmark.MakeBookmark(Bookmark._TypeCodeContainer);
                }
                bm.id = bookmarksJsonFile.root.getMaxId() + 1;
                if (bc != null)
                {
                    bm.index = bc.getMaxIndex();
                    bc.AddChild(bm);
                }
            }
            if (treeView1.Focused)
            {
                if(treeView1.SelectedNode!=null && bm!=null)
                {
                    TreeNode tn = treeView1.SelectedNode.Nodes.Add("?");
                    tn.Tag = bm;
                }
                return;
            }
            if(listView1.Focused && bm != null)
            {
                ListViewItem lvi = listView1.Items.Add("?");
                lvi.Tag = bm;
                listView1.EnsureVisible(lvi.Index);
                listView1.SelectedItems.Clear();
                lvi.Selected = true;
            }
        }
    }
}
