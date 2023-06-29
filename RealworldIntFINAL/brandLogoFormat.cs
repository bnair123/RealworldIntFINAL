using System;
using System.Collections.Generic;

namespace RealworldIntFINAL;

public class Format
{
    public string src { get; set; }
    public string background { get; set; }
    public string format { get; set; }
    public int? height { get; set; }
    public int? width { get; set; }
    public int size { get; set; }
}
public class Color
{
    public string hex { get; set; }
    public string type { get; set; }
    public int brightness { get; set; }
}

public class Font
{
    public string name { get; set; }
    public string type { get; set; }
    public string origin { get; set; }
    public string originId { get; set; }
    public List<string> weights { get; set; }
}

public class Image
{
    public List<Format> formats { get; set; }
    public List<string> tags { get; set; }
    public string type { get; set; }
}
