using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reflection; 

namespace HSLInClass.Models
{
    public class NamedColor : IComparable<NamedColor> 
    {
        public string Name { private set; get; } 

        public string FriendlyName { private set; get; } 
        public Color Color { private set; get; } 
        public string RgbDisplay { private set; get; }
        
        public static IList <NamedColor> All { private set; get; } 
        public int CompareTo(NamedColor other)
        {
            return Name.CompareTo(other.Name); 
        }
        private NamedColor()
        {

        }
        static NamedColor()
        {
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();

            //Loop through the public static fields in the Color Structure
            foreach (FieldInfo fieldInfo in typeof(Color).GetRuntimeFields())
            {
                if(fieldInfo.IsPublic && fieldInfo.IsStatic)
                {
                    string name = fieldInfo.Name; 
                    stringBuilder.Clear(); 
                    int index=0; 
                    foreach(char ch in name)
                    {
                        if( index !=0 && char.IsUpper(ch))
                        {
                            stringBuilder.Append(' '); 
                        }
                        stringBuilder.Append(ch); 
                        index++; 
                    }

                    //Initiate a NamedColor Object
                    Color color = (Color)fieldInfo.GetValue(null);
                    NamedColor namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = $"{(int)(255 * color.R):X2}-{(int)(255 * color.G):X2}-{(int)(255 * color.B):X2}"
                    }; 
                  
                    
                    all.Add(namedColor); 
                }

                
               
                all.TrimExcess();
                all.Sort();
                All = all;
            }

        }
        public static string GetNearestColorName(Color color)
        {
            double shortestDistance = 1000;
            NamedColor closestColor = null; 
            foreach(NamedColor namedColor in All)
            {
                double distance = Math.Sqrt(Math.Pow(color.R - namedColor.Color.R, 2) + 
                                            Math.Pow(color.G - namedColor.Color.G, 2) +
                                            Math.Pow(color.B - namedColor.Color.B, 2)); 
                if(distance < shortestDistance)
                {
                    shortestDistance = distance; 
                    closestColor = namedColor; 
                }
            }

            return closestColor.FriendlyName; 
        } 
    }
}
