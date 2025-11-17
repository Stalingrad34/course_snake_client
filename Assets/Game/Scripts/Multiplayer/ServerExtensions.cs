using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Multiplayer
{
  public static class ServerExtensions
  {
    public static List<TypeColor> ConvertColors(this IEnumerable<Color> colors)
    {
      var result = new List<TypeColor>();
      foreach (var color in colors)
      {
        result.Add(color.ConvertColor());
      }

      return result;
    } 
    
    public static TypeColor ConvertColor(this Color color)
    {
      return new TypeColor()
      {
        r = color.r,
        g = color.g,
        b = color.b,
      };
    } 
  }
}