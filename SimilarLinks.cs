using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MozillaBookmarksEditor
{
    public class BookmarkWithPath
    {
        public Bookmark? parentBm;
        public Bookmark Bookmark;
        public string Path;
        public bool Checked;
        public BookmarkWithPath(Bookmark bookmark, string path, Bookmark? pbm)
        {
            Bookmark = bookmark;
            Path = HttpUtility.UrlEncode(path) ?? path;
            Checked = false;
            parentBm = pbm;
        }
        public override string ToString() => Path + ":" + Bookmark.title;
    }
    public class SimilarLinks
    {
        public Dictionary<string, List<BookmarkWithPath>> links;
        public SimilarLinks()
        {
            links = new Dictionary<string, List<BookmarkWithPath>>();
        }
        public void Add(Bookmark? bookmark, string bmPath, Bookmark? pbm)
        {
            if (bookmark == null)
            {
                return;
            }
            string uri = HttpUtility.UrlEncode(bookmark.uri) ?? string.Empty;
            if (uri.Length > 0)
            {
                if(bmPath.Length<1)
                {
                    bmPath = "/";
                }
                List<BookmarkWithPath> items;
                if (!links.TryGetValue(uri, out List<BookmarkWithPath>? value))
                {
                    items = [new BookmarkWithPath(bookmark, bmPath, pbm)];
                }
                else
                {
                    items = value;
                    items.Add(new BookmarkWithPath(bookmark, bmPath, pbm));
                }
                links[uri] = items;
            }
        }
        public void RemoveUnique()
        {
            foreach (string uri in links.Keys)
            {
                if (links.TryGetValue(uri, out List<BookmarkWithPath>? value))
                {
                    if (value.Count < 2)
                    {
                        links.Remove(uri);
                    }
                }
            }
        }
    }
}
