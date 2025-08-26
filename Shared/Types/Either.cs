namespace Shared.Types;

public class Either<TLeft, TRight>
{
    private readonly TLeft _left = default!;
    private readonly TRight _right = default!;
    private readonly bool _isLeft;

    public bool IsLeft => _isLeft;
    public bool IsRight => !_isLeft;

    private Either(TLeft left)
    {
        _left = left;
        _isLeft = true;
    }

    private Either(TRight right)
    {
        _right = right;
        _isLeft = false;
    }


    public Either<TLeft, TNewRight> Map<TNewRight>(Func<TRight, TNewRight> mapFunc) => _isLeft
        ? new Either<TLeft, TNewRight>(_left)
        : new Either<TLeft, TNewRight>(mapFunc(_right));

    public Either<TLeft, TNewRight> Bind<TNewRight>(Func<TRight, Either<TLeft, TNewRight>> bindFunc) =>
        _isLeft
            ? new Either<TLeft, TNewRight>(_left)
            : bindFunc(_right);

    public T Match<T>(Func<TLeft, T> leftFunc, Func<TRight, T> rightFunc) => _isLeft
        ? leftFunc(_left)
        : rightFunc(_right);

    public Either<TLeft, TRight> OnRight(Action<TRight> onRightAction)
    {
        if (!_isLeft) onRightAction(_right);
        return this;
    }
    
    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left);
    public static implicit operator Either<TLeft, TRight>(TRight right) => new(right);
}