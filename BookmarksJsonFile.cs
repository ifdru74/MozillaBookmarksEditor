using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace MozillaBookmarksEditor
{
    public enum BookmarkField
    {
        Title,
        Guid,
        IconUri,
        Type,
        Uri,
        Root,
        Keyword,
        Label,
        Tags
    }
    public enum BookmarkType
    {
        None,
        URL,
        Separator,
        Container
    }
    public class Bookmark
    {
        string? Guid;
        string? Title;
        int Index;
        Int64 DateAdded;
        Int64 LastModified;
        int ID;
        int TypeCode;
        string? IconUri;
        string? Type;
        string? Uri;
        string? Root;
        List<Bookmark> Children;
        string? Keyword;
        string? Label;
        string? Tags;
        string? PostData;
        public Bookmark() {
            Children = [];
            Index = ID = TypeCode = 0;
            DateAdded = LastModified = 0;
            //Guid = Title = IconUri = Type = Uri = Root = "";
        }

        public string? guid { get => Guid; set => Guid = value; }
        public string? title { get => Title; set => Title = value; }
        public int index { get => Index; set => Index = value; }
        public Int64 dateAdded { get => DateAdded; set => DateAdded = value; }
        public Int64 lastModified { get => LastModified; set => LastModified = value; }
        public int id { get => ID; set => ID = value; }
        public int typeCode { get => TypeCode; set => TypeCode = value; }
        public string? iconUri { get => IconUri; set => IconUri = value; }
        public string? type { get => Type; set => Type = value; }
        public string? uri { get => Uri; set => Uri = value; }
        public string? keyword { get => Keyword; set => Keyword = value; }
        public string? label { get => Label; set => Label = value; }
        public string? root { get => Root; set => Root = value; }
        public string? tags { get => Tags; set => Tags = value; }
        public string? postData { get => PostData; set => PostData = value; }
        public List<Bookmark> children {
            get {
                if (Children!=null && Children.Count<1)
                {
                    return null;
                }
                return Children;
                }
    set {Children = value;} 
        }
        public bool hasChildren()
        {
            if (Children != null)
            {
                return Children.Count > 0;
            }
            return false;
        }
        public bool hasSubFolders()
        {
            if (Children != null)
            {
                foreach (Bookmark child in Children)
                {
                    if (child != null)
                    {
                        if (child.typeCode == 2 && (child.type ?? "") == "text/x-moz-place-container")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public BookmarkType getItemType()
        {
            if (typeCode == 1 || type == "text/x-moz-place")
            {
                return BookmarkType.URL;
            }
            if (typeCode == 2 || type == "text/x-moz-place-container")
            {
                return BookmarkType.Container;
            }
            if (typeCode == 3 || type == "text/x-moz-place-separator")
            {
                return BookmarkType.Separator;
            }
            return BookmarkType.None;
        }
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
