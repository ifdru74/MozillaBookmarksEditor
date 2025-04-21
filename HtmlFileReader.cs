using System.Text.RegularExpressions;

namespace MozillaBookmarksEditor
{
    internal class HtmlFileReader
    {
        static string pTitle = @"^\s*\<TITLE\>.+\<\/TITLE\>\s*$";
        static string pHead = @"^\s*\<H1\>.+\<\/H1\>\s*$";
        static string pFileTitle = @"^\<\!DOCTYPE\s+NETSCAPE\-Bookmark\-file\-\d\>$";
        static string pSubFolder = @"^\s*<DL><p>$";
        static string pMainFolder = @"^\s*\<DT\>\<H3\s+ADD_DATE\=\""(?'adate'\d+)\""\s+LAST_MODIFIED\=\""(?'mdate'\d+)\""\s+(?:PERSONAL_TOOLBAR_FOLDER\=\""(?'ptf'true|false)\"")\>(?'title'.+)\<\/H3\>$";
        static string pFolder = @"^\s*\<DT\>\<H3\s+ADD_DATE\=\""(?'adate'\d+)\""\s+LAST_MODIFIED\=\""(?'mdate'\d+)\""\>(?'title'.+)\<\/H3\>$";
        static string pUpFolder = @"^\s*\<\/DL\>\<p\>$";
        static string pBookMark = @"^\s+\<DT\>\<A\s+HREF\=\""(?'href'[\w\d\/\:\,\.\%\&\=\<\>\-]+)\""\s+ADD_DATE\=\""(?'adate'\d+)\""(?:\s+ICON\=\""(?'icon'.+)\"")?\>(?'title'.+)\<\/A\>$";
        static int stringToTime(string? intStr)
        {
            int rt;
            if(!int.TryParse(intStr, out rt))
            {
                rt = (int)DateTime.Now.Ticks/1000;
            }
            return rt;
        }
        public static BookmarksJsonFile ReadHtmlFile(string filePath)
        {
            int rowNum = 0;
            bool bMainFolded = false;
            BookmarksJsonFile bookmarksJsonFile = new BookmarksJsonFile();
            Bookmark current = bookmarksJsonFile.root;
            Dictionary<Bookmark, Bookmark?> parents = new Dictionary<Bookmark, Bookmark?>();
            parents[current] = null;
            foreach (string line in File.ReadLines(filePath))
            {
                rowNum++;
                if(rowNum == 1)
                {
                    Match ftm = Regex.Match(line, pFileTitle);
                    if (!ftm.Success)
                    {
                        throw new Exception("This is not a Netscape Bookmark file.");
                    }
                    continue;
                }
                Match m = Regex.Match(line, pTitle);
                if (m.Success)
                {
                    bookmarksJsonFile.root.label = m.Value;
                    continue;
                }
                m = Regex.Match(line, pHead);
                if (m.Success)
                {
                    bookmarksJsonFile.root.label = m.Value;
                    continue;
                }
                m = Regex.Match(line, pSubFolder);
                if (m.Success)
                {
                    current.children = [];
                    continue;
                }
                if (!bMainFolded)
                {
                    m = Regex.Match(line, pMainFolder);
                    if (m.Success)
                    {
                        Bookmark bm = new Bookmark();
                        bm.type = Bookmark._TypeStringContainer;
                        bm.typeCode = Bookmark._TypeCodeContainer;
                        bm.dateAdded = stringToTime(m.Groups["adate"].Value);
                        bm.lastModified = stringToTime(m.Groups["mdate"].Value);
                        bm.title = m.Groups["title"].Value;
                        bMainFolded = true;
                        current.AddChild(bm);
                        // push container
                        parents[bm] = current;
                        current = bm;
                        continue;
                    }
                }
                m = Regex.Match(line, pFolder);
                if (m.Success)
                {
                    Bookmark bm = new Bookmark();
                    bm.type = Bookmark._TypeStringContainer;
                    bm.typeCode = Bookmark._TypeCodeContainer;
                    bm.dateAdded = stringToTime(m.Groups["adate"].Value);
                    bm.lastModified = stringToTime(m.Groups["mdate"].Value);
                    bm.title = m.Groups["title"].Value;
                    current.AddChild(bm);
                    // push container
                    parents[bm] = current;
                    current = bm;
                    continue;
                }
                m = Regex.Match(line, pUpFolder);
                if (m.Success)
                {
                    Bookmark? bm = parents[current];
                    if(bm!=null)
                    {
                        current = bm;
                    }
                    continue;
                }
                m = Regex.Match(line, pBookMark);
                if (m.Success)
                {
                    Bookmark bm = new Bookmark();
                    bm.type = Bookmark._TypeStringURL;
                    bm.typeCode = Bookmark._TypeCodeURL;
                    bm.dateAdded = stringToTime(m.Groups["adate"].Value);
                    bm.lastModified = (int)DateTime.Now.Ticks / 1000;
                    bm.title = m.Groups["title"].Value;
                    bm.uri = m.Groups["href"].Value;
                    bm.iconUri = m.Groups["icon"].Value;
                    // push to container
                    current.AddChild(bm);
                    continue;
                }
            }
            return bookmarksJsonFile;
        }
    }
}
