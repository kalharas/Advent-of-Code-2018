namespace Helpers.Extensions
{
    public static class MyExtensions {
        public static bool CanReact(this char poly1, char poly2){
            var sameType = char.ToUpperInvariant(poly1) == char.ToUpperInvariant(poly2);
            if(sameType)
            {
                var oppositePolarity = (char.IsLower(poly1) && char.IsUpper(poly2)) || (char.IsUpper(poly1) && char.IsLower(poly2));
                return oppositePolarity;
            }            
            return false;
        }
    }
}