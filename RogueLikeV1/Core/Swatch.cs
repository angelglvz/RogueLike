using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLikeV1.Core
{
    public class Swatch
    {
        // Main Colours used for game design, based on a TablaColores
        // https://paletton.com/#uid=72T0I0kqrFO5PNDinFeLwKXTItz

        //Primary: #25D64C
        public static RLColor PrimaryLightest = new RLColor(187, 229, 197);
        public static RLColor PrimaryLighter = new RLColor(91, 213, 118);
        public static RLColor Primary = new RLColor(37, 214, 76);
        public static RLColor PrimaryDarker = new RLColor(0, 224, 49);
        public static RLColor PrimaryDarkest = new RLColor(0, 178, 39);

        //Secondary #1: #2F78C4
        public static RLColor SecondaryLightest = new RLColor(181, 199, 218);
        public static RLColor SecondaryLighter = new RLColor(91, 142, 194);
        public static RLColor Secondary = new RLColor(47, 120, 196);
        public static RLColor SecondaryDarker = new RLColor(8, 107, 210);
        public static RLColor SecondaryDarkest = new RLColor(3, 77, 153);

        //Secondary #2: #F5AB2C
        public static RLColor AlternateLightest = new RLColor(255, 236, 209);
        public static RLColor AlternateLighter = new RLColor(255, 196, 109);
        public static RLColor Alternate = new RLColor(255, 171, 44);
        public static RLColor AlternateDarker = new RLColor(255, 153, 0);
        public static RLColor AlternateDarkest = new RLColor(236, 141, 0);

        //Complimentary: #FF402C
        public static RLColor ComplimentLightest = new RLColor(255, 213, 209);
        public static RLColor ComplimentLighter = new RLColor(255, 123, 109);
        public static RLColor Compliment = new RLColor(255, 64, 44);
        public static RLColor ComplimentDarker = new RLColor(255, 24, 0);
        public static RLColor ComplimentDarkest = new RLColor(236, 22, 0);

        // Secondary pallete, used for rest of scenery, objects, and other elements, based on paletaColoresUsables
        // http://pixeljoint.com/forum/forum_posts.asp?TID=12795
        public static RLColor DbDark = new RLColor(20, 12, 28);
        public static RLColor DbOldBlood = new RLColor(68, 36, 52);
        public static RLColor DbDeepWater = new RLColor(48, 52, 109);
        public static RLColor DbOldStone = new RLColor(78, 74, 78);
        public static RLColor DbWood = new RLColor(133, 76, 48);
        public static RLColor DbVegetation = new RLColor(52, 101, 36);
        public static RLColor DbBlood = new RLColor(208, 70, 72);
        public static RLColor DbStone = new RLColor(117, 113, 97);
        public static RLColor DbWater = new RLColor(89, 125, 206);
        public static RLColor DbBrightWood = new RLColor(210, 125, 44);
        public static RLColor DbMetal = new RLColor(133, 149, 161);
        public static RLColor DbGrass = new RLColor(109, 170, 44);
        public static RLColor DbSkin = new RLColor(210, 170, 153);
        public static RLColor DbSky = new RLColor(109, 194, 202);
        public static RLColor DbSun = new RLColor(218, 212, 94);
        public static RLColor DbLight = new RLColor(222, 238, 214);
    }
}
