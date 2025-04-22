using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Windows.Forms.AxHost;

namespace MozillaBookmarksEditor
{
    public class BookmarksFileStat
    {
        int folders;
        int bookmarks;
        public BookmarksFileStat()
        {
            folders = bookmarks = 0;
        }
        public void IncFolders() { folders++; }
        public void IncBookmarks() { bookmarks++; }
        public void CountChildren(List<Bookmark>? children)
        {
            if (children == null)
            {
                return;
            }
            foreach (Bookmark? bookmark in children)
            {
                if (bookmark != null)
                {
                    switch (bookmark.getItemType())
                    {
                        case BookmarkType.Container:
                            folders ++;
                            CountChildren(bookmark.children);
                            break;
                        case BookmarkType.URL:
                            bookmarks ++; break;
                    }
                }
            }
        }
        public void CountAll(Bookmark root) => CountChildren(root.children);
        public string FolderCount { get => folders.ToString(); }
        public string BookmarkCount { get => bookmarks.ToString(); }
    }
    internal class BookmarksJsonFile
    {
        public Bookmark root { get; set; }
        public BookmarksJsonFile()
        {
            root = new Bookmark();
        }
        public void ReadJsonFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            root = JsonSerializer.Deserialize<Bookmark>(jsonString) ?? new Bookmark();
        }
        public void WriteJsonFile(string filePath, Bookmark? root2Save = null)
        {
            if (root2Save == null)
            {
                root2Save = root;
            }
            string contents = JsonSerializer.Serialize(root2Save);
            // post processing
            string pattern = @"\,\s*\""[^\""]+\""\:\s*null";
            string substitution = @"";
            RegexOptions options = RegexOptions.Multiline;
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(contents, substitution);
            if (result.Length < 1)
            {
                File.WriteAllText(filePath, contents);
            }
            else
            {
                File.WriteAllText(filePath, result);
            }
        }
    }
}
