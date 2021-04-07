using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.ImageUpload
{
    public class PathName
    {
        //public static string CarImagess = @"\WebAPI\Images\CarImages";
        public static string BaseName = @"\WebAPI\wwwroot\";

        public static string CarImages = @"Uploads\Images\CarImages";
        public static string AddCarImage = BaseName + CarImages;


        public static string CarDefaultImages =CarImages+"\\default.jpg";
    }
}
