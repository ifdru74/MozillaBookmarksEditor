using System.Web;

namespace MozillaBookmarksEditor
{
    public partial class SimilarBookmarksFrm : Form
    {
        SimilarLinks links;
        public SimilarBookmarksFrm(SimilarLinks found)
        {
            links = found;
            InitializeComponent();
        }

        private void SimilarBookmarksFrm_Load(object sender, EventArgs e)
        {
            TreeNode root = treeView1.Nodes.Add("Links");
            foreach (string uri in links.links.Keys)
            {
                TreeNode node = root.Nodes.Add(HttpUtility.UrlDecode(uri), uri);
                node.ImageIndex = 1;
                bool bChecked = false;
                foreach (BookmarkWithPath bmwp in links.links[uri])
                {
                    TreeNode bmNode = node.Nodes.Add(bmwp.Bookmark.uri);
                    bmNode.Tag = bmwp;
                    bmNode.Checked = bChecked;
                    if (!bChecked)
                    {
                        bChecked = true;
                        node.Text = bmwp.Bookmark.uri;
                        bmNode.ImageIndex = 2;
                    }
                    else
                    {
                        bmNode.ImageIndex = 3;
                    }
                }
            }
        }
        void iterateTreeNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode tn in nodes)
            {
                if (tn.Checked)
                {
                    BookmarkWithPath? bmwp = tn.Tag as BookmarkWithPath;
                    if (bmwp != null)
                    {
                        bmwp.Checked = true;
                    }
                }
                if(tn.Nodes.Count > 0)
                {
                    iterateTreeNodes(tn.Nodes);
                }
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            iterateTreeNodes(treeView1.Nodes);
            foreach (string uri in links.links.Keys)
            {
                List<BookmarkWithPath> toDel = new List<BookmarkWithPath>();
                foreach (BookmarkWithPath bmwp in links.links[uri])
                {
                    if(!bmwp.Checked)
                    {
                        toDel.Add(bmwp);
                    }
                }
                foreach (BookmarkWithPath bmwp in toDel)
                {
                    links.links[uri].Remove(bmwp);
                }
            }
        }
    }
}
