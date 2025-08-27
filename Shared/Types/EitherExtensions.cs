namespace Shared.Types;

public static class EitherExtensions
{
   public static async Task<Either<TLeft, TRight>> OnRightAsync<TLeft, TRight>(
      this Task<Either<TLeft, TRight>> eitherAsync, Func<TRight, Task> rightFunc)
   {
      var either = await eitherAsync;

      if(either.IsRight) await rightFunc(either.Right);
      
      return either;
   }
   public static async Task<Either<TLeft, TNewRight>> MapAsync<TLeft, TRight, TNewRight>(this Task<Either<TLeft, TRight>> eitherAsync,
      Func<TRight, TNewRight> func)
   {
      var either = await eitherAsync;
     
      return either.IsLeft
         ? either.Left
         : func(either.Right);
   }

   public static async Task<TResult> MatchAsync<TLeft, TRight, TResult>(this Task<Either<TLeft, TRight>> eitherAsync,
      Func<TLeft, TResult> left, Func<TRight, TResult> right)
   {
      var either = await eitherAsync;
      
      return either.IsLeft
         ? left(either.Left)
         : right(either.Right);
   }
}