using Microsoft.AspNetCore.Mvc;

namespace Shared.Types;

public static class ControllerEitherExtensions
{
    public static IActionResult ToActionResult<TLeft, TRight>(this ControllerBase controller,
        Either<TLeft, TRight> either, Func<TLeft, IActionResult>? leftMapper = null,
        Func<TRight, IActionResult>? rightMapper = null)
    {

        if (either.IsLeft)
        {
            if(leftMapper != null) return leftMapper(either.Left);
            
            return controller.BadRequest(either.Left);
        }
       
        if (rightMapper != null) return rightMapper(either.Right);
        
        return controller.Ok(either.Right);
    }


    public static async Task<IActionResult> ToActionResult<TLeft, TRight>(this ControllerBase controller,
        Task<Either<TLeft, TRight>> eitherTask, Func<TLeft, IActionResult>? leftMapper = null,
        Func<TRight, IActionResult>? rightMapper = null)
    {
        var either = await eitherTask;
        return controller.ToActionResult(either, leftMapper, rightMapper);
    }
}