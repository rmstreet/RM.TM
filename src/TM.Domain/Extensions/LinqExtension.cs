﻿
namespace TM.Domain.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class LinqExtension
    {
        public static IEnumerable<TResult> SelectWithCurrentAndPreviouItem<TSource, TResult>
            (this IEnumerable<TSource> source, Func<TSource, TSource, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    yield break;
                }
                TSource previous = iterator.Current;
                while (iterator.MoveNext())
                {
                    yield return projection(previous, iterator.Current);
                    previous = iterator.Current;
                }
            }
        }
    }
}
