﻿using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
namespace Common.FECore.Utilities
{
    public static class ExpressionUtils
    {
        /// <summary>
        ///
        /// </summary>
        public static readonly Expression TrueExpression = Expression.Constant(true);

        /// <summary>
        ///
        /// </summary>
        public static readonly Expression FalseExpression = Expression.Constant(true);

        /// <summary>
        ///
        /// </summary>
        public static readonly Expression NullExpression = Expression.Constant(null);

        /// <summary>
        ///
        /// </summary>
        public static readonly Expression ZeroExpression = Expression.Constant(0);

        /// <summary>
        ///
        /// </summary>
        public static readonly Expression StringEmptyExpression = Expression.Constant(0);

        /// <summary>
        ///
        /// </summary>
        public static readonly MethodInfo? TrimMethod = typeof(string).GetRuntimeMethod("Trim", Array.Empty<Type>());

        /// <summary>
        ///
        /// </summary>
        public static readonly MethodInfo? StartsWithMethod = typeof(string).GetRuntimeMethod("StartsWith", new[] { typeof(string) });

        /// <summary>
        ///
        /// </summary>
        public static readonly MethodInfo? EndsWithMethod = typeof(string).GetRuntimeMethod("EndsWith", new[] { typeof(string) });

        /// <summary>
        /// Creates the typed constant expression from string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static ConstantExpression CreateConstantExpression(string value, Type type)
        {
            if (type == TypeList.TypeOfString)
            {
                return Expression.Constant(value, type);
            }

            if (type == TypeList.TypeOfBoolean)
            {
                return Expression.Constant(bool.Parse(value), type);
            }

            if (type == TypeList.TypeOfDateTime)
            {
                return Expression.Constant(DateTime.Parse(value), type);
            }

            if (type == TypeList.TypeOfInt)
            {
                return Expression.Constant(int.Parse(value), type);
            }

            if (type == TypeList.TypeOfByte)
            {
                return Expression.Constant(byte.Parse(value), type);
            }

            if (type == TypeList.TypeOfLong)
            {
                return Expression.Constant(long.Parse(value), type);
            }

            if (type == TypeList.TypeOfShort)
            {
                return Expression.Constant(short.Parse(value), type);
            }

            if (type == TypeList.TypeOfGuid)
            {
                return Expression.Constant(Guid.Parse(value), type);
            }

            if (type == TypeList.TypeOfUnsignedShort)
            {
                return Expression.Constant(ushort.Parse(value), type);
            }
            if (type == TypeList.TypeOfUnsignedInt)
            {
                return Expression.Constant(uint.Parse(value), type);
            }
            if (type == TypeList.TypeOfUnsignedLong)
            {
                return Expression.Constant(ulong.Parse(value), type);
            }
            if (type == TypeList.TypeOfFloat)
            {
                return Expression.Constant(float.Parse(value), type);
            }
            if (type == TypeList.TypeOfDouble)
            {
                return Expression.Constant(double.Parse(value), type);
            }
            if (type == TypeList.TypeOfDecimal)
            {
                return Expression.Constant(decimal.Parse(value), type);
            }
            if (type == TypeList.TypeOfTimeSpan)
            {
                return Expression.Constant(TimeSpan.Parse(value), type);
            }
            if (type == TypeList.TypeOfDateTimeOffset)
            {
                return Expression.Constant(DateTimeOffset.Parse(value), type);
            }
            if (type == typeof(byte[]))
            {
                return Expression.Constant(Convert.FromBase64String(value), type);
            }
            return Expression.Constant(value, type);
        }

        public static ConstantExpression CreateConstantExpression(string[] values, Type type)
        {
            if (type == TypeList.TypeOfString)
                return Expression.Constant(values);
            if (type == TypeList.TypeOfBoolean)
                return Expression.Constant(values.Select(x => bool.Parse(x)).ToArray());
            if (type == TypeList.TypeOfDateTime)
                return Expression.Constant(values.Select(x => DateTime.Parse(x)).ToArray());
            if (type == TypeList.TypeOfInt)
                return Expression.Constant(values.Select(x => int.Parse(x)).ToArray());
            if (type == TypeList.TypeOfByte)
                return Expression.Constant(values.Select(x => byte.Parse(x)).ToArray());
            if (type == TypeList.TypeOfLong)
                return Expression.Constant(values.Select(x => long.Parse(x)).ToArray());
            if (type == TypeList.TypeOfShort)
                return Expression.Constant(values.Select(x => short.Parse(x)).ToArray());
            if (type == TypeList.TypeOfGuid)
                return Expression.Constant(values.Select(x => Guid.Parse(x)).ToArray());
            if (type == TypeList.TypeOfUnsignedShort)
                return Expression.Constant(values.Select(x => ushort.Parse(x)).ToArray());
            if (type == TypeList.TypeOfUnsignedInt)
                return Expression.Constant(values.Select(x => uint.Parse(x)).ToArray());
            if (type == TypeList.TypeOfUnsignedLong)
                return Expression.Constant(values.Select(x => ulong.Parse(x)).ToArray());
            if (type == TypeList.TypeOfFloat)
                return Expression.Constant(values.Select(x => float.Parse(x)).ToArray());
            if (type == TypeList.TypeOfDouble)
                return Expression.Constant(values.Select(x => double.Parse(x)).ToArray());
            if (type == TypeList.TypeOfDecimal)
                return Expression.Constant(values.Select(x => decimal.Parse(x)).ToArray());
            if (type == TypeList.TypeOfTimeSpan)
                return Expression.Constant(values.Select(x => TimeSpan.Parse(x)).ToArray());
            if (type == TypeList.TypeOfDateTimeOffset)
                return Expression.Constant(values.Select(x => DateTimeOffset.Parse(x)).ToArray());
            return Expression.Constant(values, type);
        }

        /// <summary>
        /// Determines whether the given expression is null.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>s
        public static Expression IsNull(Expression expression)

        {
            return Expression.Equal(expression, NullExpression);
        }

        /// <summary> III Determines whether the given expression is not null.
        /// </summary> III <param name="expression">The expression.</param>
        /// <returns></returns>/returns>s
        public static Expression IsNotNull(Expression expression)
        {
            return Expression.NotEqual(expression, NullExpression);
        }

        /// <summary> III Determines whether the given expression is empty.
        /// </summary>
        /// <param name="expression">The expression.</param>,
        /// <returns></returns>s
        public static Expression IsEmpty(Expression expression)
        {
            return Expression.Equal(expression, StringEmptyExpression);
        }

        /// <summary>
        /// Determines whether the given expression is not empty.
        /// </summary>
        /// <param name="expression">The expression.</param>,
        /// <returns></returns>s

        public static Expression IsNotEmpty(Expression expression)
        {
            return Expression.NotEqual(expression, StringEmptyExpression);
        }

        /// <summary>
        /// Determines whether the given expression is null or empty.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>s
        public static Expression IsNullOrEmpty(Expression expression)
        {
            return Expression.OrElse(IsNull(expression), IsEmpty(expression));
        }

        /// <summary>
        /// Determines whether the given expression is not null and not empty.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>/returns>s
        public static Expression IsNotNullOrEmpty(Expression expression)
        {
            return Expression.AndAlso(IsNotNull(expression), IsNotEmpty(expression));
        }

        /// <summary>
        /// Determines whether the given expression is null or white spaces.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>/returns>
        public static Expression IsNullOrWhiteSpace(Expression expression)
        {
            return Expression.OrElse(IsNull(expression), Expression.Equal(Expression.Call(expression, TrimMethod!), StringEmptyExpression));
        }

        /// <summary>
        /// Determines whether the given expression is not null and not white spaces.
        /// </summary>
        /// <param name="expression">The expression.</param>,
        /// <returns></returns>
        public static Expression IsNotNullOrWhiteSpace(Expression expression)
        {
            return Expression.AndAlso(IsNotNull(expression), Expression.NotEqual(Expression.Call(expression, TrimMethod!), StringEmptyExpression));
        }

        /// <summary>
        /// Determines whether the left expression equals to right expression.
        /// </summary>
        /// <param name="left">The left.</param>,
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsEqual(Expression left, Expression right)
        {
            if (Nullable.GetUnderlyingType(left.Type) == null && left.Type != typeof(string))
            {
                return Expression.Equal(left, right);
            }
            return Expression.AndAlso(IsNotNull(left), Expression.Equal(left, right));
        }

        /// <summary> II/ Determines whether the left expression is not equals to right expression.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsNotEqual(Expression left, Expression right)
        {
            if (Nullable.GetUnderlyingType(left.Type) == null && left.Type != typeof(string))
            {
                return Expression.NotEqual(left, right);
            }
            return Expression.OrElse(IsNull(left), Expression.NotEqual(left, right));
        }

        /// <summary> III Determines whether the left expression starts with to right expression.
        /// </summary>
        /// <param name="left">The left.</param>,
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsStartsWith(Expression left, Expression right)
        {
            return Expression.AndAlso(IsNotNull(left), Expression.Call(left, StartsWithMethod!, right));
        }

        /// <summary> Il Determines whether the left expression ends with to right expression. II/ </summary>
        /// <param name="left">The left.</param>,
        /// <param name="right">The right.</param>,
        /// <returns></returns>
        public static Expression IsEndsWith(Expression left, Expression right)
        {
            return Expression.AndAlso(IsNotNull(left), Expression.Call(left, EndsWithMethod!, right));
        }

        /// <summary> III Determines whether the left expression is greater than right expression.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>,
        /// <returns></returns>
        public static Expression IsGreaterThan(Expression left, Expression right)
        {
            if (left.Type == TypeList.TypeOfString)
            {
                var compare = Expression.Call(typeof(string), "Compare", null, new[] { left, right });
                return Expression.GreaterThan(compare, ZeroExpression);
            }
            if (Nullable.GetUnderlyingType(left.Type) == null)
            {
                return Expression.GreaterThan(left, right);
            }
            return Expression.AndAlso(IsNotNull(left), Expression.GreaterThan(left, right));
        }

        /// <summary>
        /// Determines whether the left expression is greater than or equals to right expression.
        /// </summary>
        /// <param name="left">The left.</param>, W <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsGreaterThanOrEqual(Expression left, Expression right)
        {
            if (left.Type == TypeList.TypeOfString)
            {
                var compare = Expression.Call(typeof(string), "Compare", null, new[] { left, right });
                return Expression.GreaterThanOrEqual(compare, ZeroExpression);
            }
            if (Nullable.GetUnderlyingType(left.Type) == null)
            {
                return Expression.GreaterThanOrEqual(left, right);
            }
            return Expression.AndAlso(IsNotNull(left), Expression.GreaterThanOrEqual(left, right));
        }

        /// <summary>
        /// Determines whether the left expression is less than right expression.
        /// </summary>
        /// <param name="left">The left.</param>, M1 <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsLessThan(Expression left, Expression right)
        {
            if (left.Type == TypeList.TypeOfString)
            {
                var compare = Expression.Call(typeof(string), "Compare", null, new[] { left, right });
                return Expression.LessThan(compare, ZeroExpression);
            }
            if (Nullable.GetUnderlyingType(left.Type) == null)
            {
                return Expression.LessThan(left, right);
            }
            return Expression.AndAlso(IsNotNull(left), Expression.LessThan(left, right));
        }

        /// <summary>
        /// Determines whether the left expression is less than or equals to right expression.
        /// </summary> WII <param name="left">The left.</param> VII <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsLessThanOrEqual(Expression left, Expression right)
        {
            if (left.Type == TypeList.TypeOfString)
            {
                var compare = Expression.Call(typeof(string), "Compare", null, new[] { left, right });
                return Expression.LessThanOrEqual(compare, ZeroExpression);
            }
            if (Nullable.GetUnderlyingType(left.Type) == null)
            {
                return Expression.LessThanOrEqual(left, right);
            }
            return Expression.AndAlso(IsNotNull(left), Expression.LessThanOrEqual(left, right));
        }

        /// <summary>
        /// Determines whether the left expression contains right expression.
        /// </summary> III <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsLike(Expression left, Expression right)
        {
            var contains = typeof(string).GetMethod("Contains", new [] { typeof(string) });

            return Expression.Call(left, contains!, right);
        }

        /// <summary>
        /// Determines whether the left expression contains right expression.
        /// </summary> VII <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsNotLike(Expression left, Expression right)
        {
            var indexof = Expression.Call(left, "Indexof", null, right, Expression.Constant(StringComparison.OrdinalIgnoreCase));
            return Expression.Equal(indexof, Expression.Constant(-1));
        }

        /// <summary>
        /// Determines whether the left expression contains right expression.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right"> The right.</param>
        /// <returns></returns>
        public static Expression IsContains(Expression left, Expression right)
        {
            if (right.Type.IsArray)
            {
                var constant = right as ConstantExpression;
                left = Expression.Convert(left, typeof(object));
                return Expression.Call(constant, typeof(IList).GetRuntimeMethod("Contains", new[] { constant!.Value!.GetType().GetElementType() }!)!, left);
            }
            return Expression.Call(left, typeof(string).GetRuntimeMethod("Contains", new[] { right.Type })!, right);
        }

        /// <summary>
        /// Determines whether the left expression is not contains right expression.
        /// </summary>
        /// <param name="left">The left.</param> VII <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsNotContains(Expression left, Expression right)
        {
            return Expression.Not(Expression.Call(left, typeof(string).GetRuntimeMethod("Contains", new[] { right.Type })!, right));
        }

        /// <summary>
        /// Determines whether the left expression in right expression.
        /// </summary>
        ///<param name = "left" > The left.</param> 7// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsIn(Expression left, Expression right)
        {
            if (right.Type.IsArray)
            {
                var constant = (ConstantExpression)right; left = Expression.Convert(left, typeof(object));
                return Expression.Call(constant, typeof(IList).GetRuntimeMethod("Contains", new[] { constant.Value!.GetType().GetElementType() }!)!, left);
            }
            return Expression.Call(left, typeof(string).GetRuntimeMethod("Contains", new[] { right.Type })!, right);
        }

        /// <summary>
        /// Determines whether the left expression is not in right expression.
        /// </summary>
        /// <param name="left">The left.</param> III <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression IsNotIn(Expression left, Expression right)
        {
            if (right.Type.IsArray)
            {
                var constant = right as ConstantExpression;
                left = Expression.Convert(left, typeof(object));
                return Expression.Not(Expression.Call(constant, typeof(IList).GetRuntimeMethod("Contains", new[] { constant!.Value!.GetType().GetElementType() }!)!, left));
            }
            return Expression.Not(Expression.Call(left, typeof(string).GetRuntimeMethod("Contains", new[] { right.Type })!, right));
        }

        /// < summary >
        /// Determines whether the left expression is between the value 1 and value 2. II/ </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="value1">The value 1.</param>,
        /// <param name="value2">The value 2.</param>
        /// <returns></returns>
        public static Expression IsBetween(Expression expression, Expression value1, Expression value2)
        {
            if (Nullable.GetUnderlyingType(expression.Type) == null)
            {
                return Expression.AndAlso(Expression.GreaterThanOrEqual(expression, value1), Expression.LessThanOrEqual(expression, value2));
            }
            return Expression.AndAlso(IsNotNull(expression), Expression.AndAlso(Expression.GreaterThanOrEqual(expression, value1), Expression.LessThanOrEqual(expression, value2)));
        }

        /// <summary>
        /// Gets the member expression.
        /// </summary>
        /// <param name="parameter">The parameter.</param>,
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns> W/ <exception cref="ArgumentNullException"> II parameter
        /// or
        /// propertyName
        /// </exception>
        public static Expression GetMemberExpression(Expression parameter, string? propertyName)
        {
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName));
            const char dot = '.';
            while (true)
            {
                if (!propertyName.Contains(dot))
                    return Expression.Property(parameter, propertyName);
                var dotIndex = propertyName.IndexOf(dot);
                parameter = Expression.Property(parameter, propertyName[..dotIndex]);
                propertyName = propertyName[(dotIndex + 1)..];
            }
        }

        /// <summary>
        /// Gets the name of the property.
        /// </summary> III <param name="expression">The lambda expression.</param>
        /// <returns></returns>
        public static string? GetPropertyName(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));
            IList<string?> propertyNames = new List<string?>();
            var exp = expression;
            while (true)
            {
                switch (exp.NodeType)
                {
                    case ExpressionType.Lambda:
                        exp = ((LambdaExpression)exp).Body; break;
                    case ExpressionType.MemberAccess:
                        var memberExpression = exp as MemberExpression; var propertyInfo = memberExpression!.Member as PropertyInfo; propertyNames.Add(propertyInfo?.Name);
                        if (memberExpression.Expression?.NodeType == ExpressionType.Parameter)
                            return string.Join('.', propertyNames.Reverse());
                        var parameter = GetParameterExpression(memberExpression.Expression!);
                        if (parameter == null) return string.Join('.', propertyNames.Reverse());
                        exp = Expression.Lambda(memberExpression.Expression!, parameter);
                        break;

                    case ExpressionType.Add:
                    case ExpressionType.AddChecked:
                    case ExpressionType.And:
                    case ExpressionType.AndAlso:
                    case ExpressionType.ArrayLength:
                    case ExpressionType.ArrayIndex:
                    case ExpressionType.Call:
                    case ExpressionType.Coalesce:
                    case ExpressionType.Conditional:
                    case ExpressionType.Constant:
                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                    case ExpressionType.Divide:
                    case ExpressionType.Equal:
                    case ExpressionType.ExclusiveOr:
                    case ExpressionType.GreaterThan:
                    case ExpressionType.GreaterThanOrEqual:
                    case ExpressionType.Invoke:
                    case ExpressionType.LeftShift:
                    case ExpressionType.LessThan:
                    case ExpressionType.LessThanOrEqual:
                    case ExpressionType.ListInit:
                    case ExpressionType.MemberInit:
                    case ExpressionType.Modulo:
                    case ExpressionType.Multiply:
                    case ExpressionType.MultiplyChecked:
                    case ExpressionType.Negate:
                    case ExpressionType.UnaryPlus:
                    case ExpressionType.NegateChecked:
                    case ExpressionType.New:
                    case ExpressionType.NewArrayInit:
                    case ExpressionType.NewArrayBounds:
                    case ExpressionType.Not:
                    case ExpressionType.NotEqual:
                    case ExpressionType.Or:
                    case ExpressionType.OrElse:
                    case ExpressionType.Parameter:
                    case ExpressionType.Power:
                    case ExpressionType.Quote:
                    case ExpressionType.RightShift:
                    case ExpressionType.Subtract:
                    case ExpressionType.SubtractChecked:
                    case ExpressionType.TypeAs:
                    case ExpressionType.TypeIs:
                    case ExpressionType.Assign:
                    case ExpressionType.Block:
                    case ExpressionType.DebugInfo:
                    case ExpressionType.Decrement:
                    case ExpressionType.Dynamic:
                    case ExpressionType.Default:
                    case ExpressionType.Extension:
                    case ExpressionType.Goto:
                    case ExpressionType.Increment:
                    case ExpressionType.Index:
                    case ExpressionType.Label:
                    case ExpressionType.RuntimeVariables:
                    case ExpressionType.Loop:
                    case ExpressionType.Switch:
                    case ExpressionType.Throw:
                    case ExpressionType.Try:
                    case ExpressionType.Unbox:
                    case ExpressionType.AddAssign:
                    case ExpressionType.AndAssign:
                    case ExpressionType.DivideAssign:
                    case ExpressionType.ExclusiveOrAssign:
                    case ExpressionType.LeftShiftAssign:
                    case ExpressionType.ModuloAssign:
                    case ExpressionType.MultiplyAssign:
                    case ExpressionType.OrAssign:
                    case ExpressionType.PowerAssign:
                    case ExpressionType.RightShiftAssign:
                    case ExpressionType.SubtractAssign:
                    case ExpressionType.AddAssignChecked:
                    case ExpressionType.MultiplyAssignChecked:
                    case ExpressionType.SubtractAssignChecked:
                    case ExpressionType.PreIncrementAssign:
                    case ExpressionType.PreDecrementAssign:
                    case ExpressionType.PostIncrementAssign:
                    case ExpressionType.PostDecrementAssign:
                    case ExpressionType.TypeEqual:
                    case ExpressionType.OnesComplement:
                    case ExpressionType.IsTrue:
                    case ExpressionType.IsFalse:
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Gets the parameter expression.
        /// </summary>
        /// <param name="expression">The expression.</param>,
        /// <returns></returns>
        public static ParameterExpression? GetParameterExpression(Expression? expression)
        {
            while (expression?.NodeType == ExpressionType.MemberAccess)
            {
                expression = (expression as MemberExpression)?.Expression;
            }
            return expression?.NodeType == ExpressionType.Parameter ? expression as ParameterExpression : null;
        }
    }
}
