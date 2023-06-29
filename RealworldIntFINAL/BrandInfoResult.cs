using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
namespace RealworldIntFINAL;

public class BrandInfoResult
{
    public string name { get; set; }
    public string domain { get; set; }
    public bool claimed { get; set; }
    public string description { get; set; }
    public List<Link> links { get; set; }
    public List<Logo> logos { get; set; }
    public List<Color> colors { get; set; }
    public List<Font> fonts { get; set; }
    public List<Image> images { get; set; }
}
