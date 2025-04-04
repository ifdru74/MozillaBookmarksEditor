using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MozillaBookmarksEditor
{
    public class BookmarkWithPath
    {
        public Bookmark Bookmark;
        public string Path;
        public bool Checked;
        public BookmarkWithPath(Bookmark bookmark, string path)
        {
            Bookmark = bookmark;
            Path = path;
            Checked = false;
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
        public void Add(Bookmark? bookmark, string bmPath)
        {
            if (bookmark == null)
            {
                return;
            }
            string uri = bookmark.uri ?? "";
            if (uri.Length > 0)
            {
                if(bmPath.Length<1)
                {
                    bmPath = "/";
                }
                List<BookmarkWithPath> items;
                if (!links.TryGetValue(uri, out List<BookmarkWithPath>? value))
                {
                    items = [new BookmarkWithPath(bookmark, bmPath)];
                }
                else
                {
                    items = value;
                    items.Add(new BookmarkWithPath(bookmark, bmPath));
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
