using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MozillaBookmarksEditor
{
    internal class DrugData
    {
        public Bookmark? parentBm;
        public List<Bookmark> bookmarks;
        public DrugData(Bookmark? parent)
        {
            parentBm = parent;
            bookmarks = [];
        }
        public void AddBookmark(Bookmark? bookmark)
        {
            if (bookmark != null)
            {
                bookmarks.Add(bookmark);
            }
        }
        bool IsEmpty()
        {
            return !(bookmarks.Count > 0 && parentBm!=null);
        }
    }
}
