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
        public const int _TypeCodeURL = 1;
        public const int _TypeCodeContainer = 2;
        public const int _TypeCodeSeparator = 3;
        public const string _TypeStringURL = "text/x-moz-place";
        public const string _TypeStringContainer = "text/x-moz-place-container";
        public const string _TypeStringSeparator = "text/x-moz-place-separator";
        string? _Guid;
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
        public Bookmark()
        {
            Children = [];
            Index = ID = TypeCode = 0;
            DateAdded = LastModified = 0;
            //Guid = Title = IconUri = Type = Uri = Root = "";
        }

        public string? guid { get => _Guid; set => _Guid = value; }
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
        public List<Bookmark>? children
        {
            get
            {
                if (Children != null && Children.Count < 1)
                {
                    return null;
                }
                return Children;
            }
            set
            {
                if (value != null)
                {
                    Children = value;
                }
                else
                {
                    Children = [];
                }
            }
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
            if (typeCode == _TypeCodeURL || type == _TypeStringURL)
            {
                return BookmarkType.URL;
            }
            if (typeCode == _TypeCodeContainer || type == _TypeStringContainer)
            {
                return BookmarkType.Container;
            }
            if (typeCode == _TypeCodeSeparator || type == _TypeStringSeparator)
            {
                return BookmarkType.Separator;
            }
            return BookmarkType.None;
        }
        public void AddChild(Bookmark child)
        {
            if (Children != null)
            {
                Children.Add(child);
            }
            else
            {
                Children = [child];
            }
        }

        public void Remove(Bookmark child)
        {
            if (Children != null)
            {
                Children.Remove(child);
            }
        }

        public static Bookmark MakeBookmark(int iType)
        {
            Bookmark bm = new Bookmark();
            bm.lastModified = bm.dateAdded = DateTime.Now.Ticks;
            bm.title = "?";
            bm.guid = GuidGenerator.GenerateCustomGuid2();
            bm.id = 0;
            bm.index = 0;
            switch (iType)
            {
                case _TypeCodeSeparator:
                    bm.typeCode = _TypeCodeSeparator;
                    bm.type = _TypeStringSeparator;
                    break;
                case _TypeCodeContainer:
                    bm.typeCode = _TypeCodeContainer;
                    bm.type = _TypeStringContainer;
                    break;
                case _TypeCodeURL:
                default:
                    bm.typeCode = _TypeCodeURL;
                    bm.type = _TypeStringURL;
                    break;
            }
            return bm;
        }
        public int getMaxIndex()
        {
            int maxIndex = 0;
            if (hasChildren())
            {
                foreach (Bookmark child in Children)
                {
                    if (child != null)
                    {
                        if (maxIndex < child.Index)
                        {
                            maxIndex = child.Index;
                        }
                    }
                }
            }
            return maxIndex;
        }
        public int getMaxId()
        {
            int maxId = ID;
            foreach (Bookmark child in Children)
            {
                if (child != null)
                {
                    int cmid = child.getMaxId();
                    if (cmid > maxId)
                    {
                        maxId = cmid;
                    }
                    if (maxId < child.ID)
                    {
                        maxId = child.ID;
                    }
                }
            }
            return maxId;
        }
    }
}
