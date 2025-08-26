namespace Shared.Types;

public class Nothing
{
   private static readonly Nothing _nothing = new Nothing();
   public static Nothing AtAll => _nothing;
   private Nothing() { }

}