﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace Urasandesu.NAnonym.Linq
{
    public static class Iterable
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Predicate<TSource> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item)) 
                    break;
            }
        }


        /// <summary>
        /// シーケンスに指定された処理を適用する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="source">入力シーケンス。</param>
        /// <param name="action">適用する処理。</param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            foreach (var item in source.Select((item, index) => new { Item = item, Index = index }))
            {
                action(item.Item, item.Index);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> proc)
        {
            foreach (var item in source.Select((item, index) => new { Item = item, Index = index }))
            {
                if (!proc(item.Item, item.Index)) 
                    break;
            }
        }


        /// <summary>
        /// 要素の重複が可能なリストに対する差リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second には含まれていないが、返される要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれ、返されたシーケンスからは削除される要素を含む IEnumerable&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの要素の差リストが格納されているシーケンス。</returns>
        public static IEnumerable<TSource> Negate<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return Negate(first, second, EqualityComparer<TSource>.Default);
        }


        /// <summary>
        /// 要素の重複が可能なリストに対する差リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second には含まれていないが、返される要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれ、返されたシーケンスからは削除される要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="comparer">値を比較する IEqualityComparer&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの要素の差リストが格納されているシーケンス。</returns>
        public static IEnumerable<TSource> Negate<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var secondHashSet = new HashSet<TSource>(comparer);
            foreach (var secondItem in second)
            {
                if (secondHashSet.Contains(secondItem)) continue;
                secondHashSet.Add(secondItem);
            }

            foreach (var firstItem in first)
            {
                if (secondHashSet.Contains(firstItem)) continue;
                yield return firstItem;
            }
        }

        
        
        /// <summary>
        /// 要素の重複が可能なリストに対する和リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">和リストの最初のセットを形成する要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">和リストの 2 番目のセットを形成する一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <returns>2 つの入力シーケンスの要素 (2 番目のセットの重複する要素は除く) を格納している IEnumerable&lt;T&gt;。</returns>
        public static IEnumerable<TSource> Replenish<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return Replenish(first, second, EqualityComparer<TSource>.Default);
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する和リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">和リストの最初のセットを形成する要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">和リストの 2 番目のセットを形成する一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="comparer">値を比較する IEqualityComparer&lt;T&gt;。</param>
        /// <returns>2 つの入力シーケンスの要素 (2 番目のセットの重複する要素は除く) を格納している IEnumerable&lt;T&gt;。</returns>
        public static IEnumerable<TSource> Replenish<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var firstHashSet = new HashSet<TSource>(comparer);
            foreach (var firstItem in first)
            {
                if (!firstHashSet.Contains(firstItem)) firstHashSet.Add(firstItem);
                yield return firstItem;
            }

            foreach (var secondItem in second)
            {
                if (firstHashSet.Contains(secondItem)) continue;
                yield return secondItem;
            }
        }


        
        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="merger">両方のシーケンスに含まれる値を、どのようにしてマージするかの処理。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> Cross<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, Func<TSource, TSource, TSource> merger)
        {
            return Cross(first, second, EqualityComparer<TSource>.Default, merger);
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="merger">両方のシーケンスに含まれる値を、どのようにしてマージするかの処理。</param>
        /// <param name="comparer">値を比較する IEqualityComparer&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> Cross<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer, 
            Func<TSource, TSource, TSource> merger)
        {
            var secondDictionary = new Dictionary<TSource, TSource>(comparer);
            foreach (var secondItem in second)
            {
                if (secondDictionary.ContainsKey(secondItem)) continue;
                secondDictionary.Add(secondItem, secondItem);
            }

            foreach (var firstItem in first)
            {
                if (!secondDictionary.ContainsKey(firstItem)) continue;
                yield return merger(firstItem, secondDictionary[firstItem]);
            }
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// 両方のシーケンスに含まれる値については、デフォルトで最初のシーケンスの値が利用される。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> CrossLeft<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return CrossLeft(first, second, EqualityComparer<TSource>.Default);
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// 両方のシーケンスに含まれる値については、デフォルトで最初のシーケンスの値が利用される。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="comparer">値を比較する IEqualityComparer&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> CrossLeft<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return Cross(first, second, comparer, (firstItem, secondItem) => firstItem);
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// 両方のシーケンスに含まれる値については、デフォルトで second のシーケンスの値が利用される。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> CrossRight<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return CrossRight(first, second, EqualityComparer<TSource>.Default);
        }



        /// <summary>
        /// 要素の重複が可能なリストに対する積リストを生成する。
        /// 両方のシーケンスに含まれる値については、デフォルトで second のシーケンスの値が利用される。
        /// </summary>
        /// <typeparam name="TSource">入力シーケンスの要素の型。</typeparam>
        /// <param name="first">second にも含まれる、返されるの要素を含む IEnumerable&lt;T&gt;。重複が有効なリスト。</param>
        /// <param name="second">最初のシーケンスにも含まれる、返される一意の要素を含む IEnumerable&lt;T&gt;。</param>
        /// <param name="comparer">値を比較する IEqualityComparer&lt;T&gt;。</param>
        /// <returns>2 つのシーケンスの積リストを構成する要素が格納されているシーケンス。</returns>
        public static IEnumerable<TSource> CrossRight<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return Cross(first, second, comparer, (firstItem, secondItem) => secondItem);
        }

        public static IEnumerable<TSource> WhereNotDefault<TSource>(this IEnumerable<TSource> source)
        {
            return source.Where(item => !EqualityComparer<TSource>.Default.Equals(item, default(TSource)));
        }

        public static IEnumerable<Tuple2<T1, T2>> Zip<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                yield return Tuple.Create(firstEnumerator.Current, secondEnumerator.Current);
        }

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource target)
        {
            return source.IndexOf(target, EqualityComparer<TSource>.Default);    
        }

        public static int IndexOf<TSource>(this IEnumerable<TSource> source, TSource target, IEqualityComparer<TSource> equalityComparer)
        {
            int index = 0;
            foreach (var item in source)
            {
                if (equalityComparer.Equals(item, target))
                {
                    return index;
                }
                ++index;
            }
            return -1;
        }

        public static bool Equivalent<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return first.Equivalent(second, EqualityComparer<TSource>.Default);
        }

        public static bool Equivalent<TSource>(
            this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> equalityComparer)
        {
            if (first.Count() != second.Count()) return false;
            return first.Zip(second).All(tuple => equalityComparer.Equals(tuple.Item1, tuple.Item2));
        }

        public static bool Equivalent<TSource1, TSource2>(
            this IEnumerable<TSource1> first, IEnumerable<TSource2> second, IEqualityComparer<TSource1, TSource2> equalityComparer)
        {
            if (first.Count() != second.Count()) return false;
            return first.Zip(second).All(tuple => equalityComparer.Equals(tuple.Item1, tuple.Item2));
        }


        public static TSource[] AddRangeTo<TSource>(this IEnumerable<TSource> source, ref TSource[] destinationArray)
        {
            var sourceCollection = default(ICollection<TSource>);
            if ((sourceCollection = source as ICollection<TSource>) != null)
            {
                sourceCollection.AddRangeTo(ref destinationArray, sourceCollection.Count);
            }
            else
            {
                var destinationList = new List<TSource>(destinationArray);
                foreach (var sourceItem in source)
                {
                    destinationList.Add(sourceItem);
                }
                destinationArray = destinationList.ToArray();
            }
            return destinationArray;
        }

        public static ICollection<TSource> AddRangeTo<TSource>(this IEnumerable<TSource> source, ICollection<TSource> destination)
        {
            var sourceCollection = default(ICollection<TSource>);
            if ((sourceCollection = source as ICollection<TSource>) != null)
            {
                sourceCollection.AddRangeTo(destination, sourceCollection.Count);
            }
            else
            {
                foreach (var sourceItem in source)
                {
                    destination.Add(sourceItem);
                }
            }
            return destination;
        }

        public static TSource[] AddRangeTo<TSource>(
            this ICollection<TSource> source, ref TSource[] destinationArray, int length)
        {
            return source.AddRangeTo(0, ref destinationArray, destinationArray.Length, length);
        }

        public static ICollection<TSource> AddRangeTo<TSource>(
            this ICollection<TSource> source, ICollection<TSource> destination, int length)
        {
            var destinationList = default(IList<TSource>);
            if ((destinationList = destination as IList<TSource>) != null)
            {
                return source.AddRangeTo(0, destinationList, destinationList.Count, length);
            }
            else
            {
                return source.AddRangeTo(0, destination, length);
            }
        }

        public static TSource[] AddRangeTo<TSource>(
            this ICollection<TSource> source, int sourceIndex, ref TSource[] destinationArray, int destinationIndex, int length)
        {
            var sourceArray = default(TSource[]);
            var sourceList = default(IList<TSource>);

            int newSize = 0;
            if (destinationArray.Length < (newSize = destinationIndex + length))
            {
                Array.Resize(ref destinationArray, newSize);
            }

            if ((sourceArray = source as TSource[]) != null)
            {
                Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
            }
            else if ((sourceList = source as IList<TSource>) != null)
            {
                for (int index = 0; index < length; index++)
                {
                    destinationArray[destinationIndex++] = sourceList[sourceIndex++];
                }
            }
            else
            {
                var sourceEnumerator = source.Skip(sourceIndex).GetEnumerator();
                for (int index = 0; index < length && sourceEnumerator.MoveNext(); index++)
                {
                    destinationArray[destinationIndex++] = sourceEnumerator.Current;
                }
            }

            return destinationArray;
        }

        public static ICollection<TSource> AddRangeTo<TSource>(
            this ICollection<TSource> source, int sourceIndex, ICollection<TSource> destination, int length)
        {
            var sourceList = default(IList<TSource>);

            if ((sourceList = source as IList<TSource>) != null)
            {
                for (int index = 0; index < length; index++)
                {
                    destination.Add(sourceList[sourceIndex++]);
                }
            }
            else
            {
                var sourceEnumerator = source.Skip(sourceIndex).GetEnumerator();
                for (int index = 0; index < length && sourceEnumerator.MoveNext(); index++)
                {
                    destination.Add(sourceEnumerator.Current);
                }
            }
            return destination;
        }

        public static ICollection<TSource> AddRangeTo<TSource>(
            this ICollection<TSource> source, int sourceIndex, IList<TSource> destinationList, int destinationIndex, int length)
        {
            var sourceList = default(IList<TSource>);

            if ((sourceList = source as IList<TSource>) != null)
            {
                for (int index = 0; index < length; index++)
                {
                    destinationList.Insert(destinationIndex++, sourceList[sourceIndex++]);
                }
            }
            else
            {
                var sourceEnumerator = source.Skip(sourceIndex).GetEnumerator();
                for (int index = 0; index < length && sourceEnumerator.MoveNext(); index++)
                {
                    destinationList.Insert(destinationIndex++, sourceEnumerator.Current);
                }
            }
            return destinationList;
        }


        public static IList<TDestination> TransformEnumerateOnly<TSource, TDestination>(
            this IList<TSource> source, Func<TSource, TDestination> selector)
        {
            return new TransformerEnumerateOnly<TSource, TDestination>(source, selector);
        }

        public static IList<TDestination> Transform<TSource, TDestination>(
            this IList<TSource> source, Func<TSource, TDestination> selector, Func<TDestination, TSource> reSelector)
        {
            return new Transformer<TSource, TDestination>(source, selector, reSelector);
        }

        public static int GetAggregatedHashCode<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(0, (accumelate, next) => accumelate ^ next.GetHashCode());
        }

        public static int GetAggregatedHashCodeOrDefault<T>(this IEnumerable<T> source)
        {
            return source.Aggregate(0, (accumelate, next) => accumelate ^ next.GetHashCodeOrDefault());
        }


        public static IEqualityComparer<T> CreateEqualityComparer<T>(T obj)
        {
            return new DelegateEqualityComparer<T>();
        }

        public static IEqualityComparer<T> CreateEqualityComparer<T>(T obj, Func<T, int> getHashCode)
        {
            return new DelegateEqualityComparer<T>(getHashCode);
        }

        public static IEqualityComparer<T> CreateEqualityComparer<T>(T obj, Func<T, T, bool> equals)
        {
            return new DelegateEqualityComparer<T>(equals);
        }

        public static IEqualityComparer<T> CreateEqualityComparer<T>(T obj, Func<T, int> getHashCode, Func<T, T, bool> equals)
        {
            return new DelegateEqualityComparer<T>(getHashCode, equals);
        }

        public static IEqualityComparer<T> CreateEqualityComparerNullable<T>(T obj)
        {
            return new DelegateEqualityComparer<T>(
                DelegateEqualityComparer<T>.NullableGetHashCode, DelegateEqualityComparer<T>.NullableEquals);
        }

        public static IEqualityComparer<T> CreateEqualityComparerNullable<T>(T obj, Func<T, int> getHashCode)
        {
            return new DelegateEqualityComparer<T>(
                DelegateEqualityComparer<T>.ToNullableGetHashCode(getHashCode), DelegateEqualityComparer<T>.NullableEquals);
        }

        public static IEqualityComparer<T> CreateEqualityComparerNullable<T>(T obj, Func<T, T, bool> equals)
        {
            return new DelegateEqualityComparer<T>(
                DelegateEqualityComparer<T>.NullableGetHashCode, DelegateEqualityComparer<T>.ToNullableEquals(equals));
        }

        public static IEqualityComparer<T> CreateEqualityComparerNullable<T>(T obj, Func<T, int> getHashCode, Func<T, T, bool> equals)
        {
            return new DelegateEqualityComparer<T>(
                DelegateEqualityComparer<T>.ToNullableGetHashCode(getHashCode), DelegateEqualityComparer<T>.ToNullableEquals(equals));
        }

        public static IEqualityComparer<T1, T2> CreateEqualityComparerNullable<T1, T2>(
            T1 x, T2 y, Func<T1, T2, bool> equals)
        {
            return new DelegateEqualityComparer<T1, T2>(
                EqualityComparer<T1, T2>.Default.GetHashCode,
                DelegateEqualityComparer<T1, T2>.ToNullableEquals(equals));
        }

        public static IEqualityComparer<T1, T2> CreateEqualityComparerNullable<T1, T2>(
            T1 x, T2 y, Func<T1, T2, int> getHashCode, Func<T1, T2, bool> equals)
        {
            return new DelegateEqualityComparer<T1, T2>(
                DelegateEqualityComparer<T1, T2>.ToNullableGetHashCode(getHashCode), 
                DelegateEqualityComparer<T1, T2>.ToNullableEquals(equals));
        }


        public static IComparer<T> CreateComparer<T>(T obj)
        {
            return new DelegateComparer<T>();
        }

        public static IComparer<T> CreateComparer<T>(T obj, Func<T, T, int> comparer)
        {
            return new DelegateComparer<T>(comparer);
        }

        public static IComparer<T> CreateComparerNullableAsc<T>(T obj)
        {
            return new DelegateComparer<T>(DelegateComparer<T>.NullableComparerAsc);
        }

        public static IComparer<T> CreateComparerNullableAsc<T>(T obj, Func<T, T, int> comparer)
        {
            return new DelegateComparer<T>(DelegateComparer<T>.ToNullableComparerAsc(comparer));
        }

        public static IComparer<T> CreateComparerNullableDsc<T>(T obj)
        {
            return new DelegateComparer<T>(DelegateComparer<T>.NullableComparerDsc);
        }

        public static IComparer<T> CreateComparerNullableDsc<T>(T obj, Func<T, T, int> comparer)
        {
            return new DelegateComparer<T>(DelegateComparer<T>.ToNullableComparerDsc(comparer));
        }


        
        
        
        public static List<T> CreateList<T>(T obj)
        {
            return new List<T>();
        }


        

    }


    public interface IEqualityComparer<T1, T2>
    {
        bool Equals(T1 x, T2 y);
        int GetHashCode(T1 x, T2 y);
    }


    public class TransformerEnumerateOnly<TSource, TDestination> : IList<TDestination>
    {
        protected readonly IList<TSource> source;
        protected readonly Func<TSource, TDestination> selector;
        public TransformerEnumerateOnly(IList<TSource> source, Func<TSource, TDestination> selector)
        {
            Required.NotDefault(source, () => source);
            Required.NotDefault(selector, () => selector);

            this.source = source;
            this.selector = selector;
        }

        #region IList<TDestination> メンバ

        public virtual int IndexOf(TDestination item)
        {
            throw new NotSupportedException();
        }

        public virtual void Insert(int index, TDestination item)
        {
            throw new NotSupportedException();
        }

        public virtual void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public virtual TDestination this[int index]
        {
            get
            {
                return selector(source[index]);
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region ICollection<TDestination> メンバ

        public virtual void Add(TDestination item)
        {
            throw new NotSupportedException();
        }

        public virtual void Clear()
        {
            throw new NotSupportedException();
        }

        public virtual bool Contains(TDestination item)
        {
            throw new NotSupportedException();
        }

        public virtual void CopyTo(TDestination[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        public int Count
        {
            get { return source.Count; }
        }

        public bool IsReadOnly
        {
            get { return source.IsReadOnly; }
        }

        public virtual bool Remove(TDestination item)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region IEnumerable<TDestination> メンバ

        public IEnumerator<TDestination> GetEnumerator()
        {
            return source.Select(selector).GetEnumerator();
        }

        #endregion

        #region IEnumerable メンバ

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }

    // NOTE: 使いどころが難しい。
    // NOTE: selector は必ず指定すること。基本的に列挙のみが可能な、ListTransformer オブジェクトが生成される。
    // NOTE: invertor を指定した場合は完全版。
    // NOTE: やっぱりクラスわけよう。
    public sealed class Transformer<TSource, TDestination> : TransformerEnumerateOnly<TSource, TDestination>
    {
        readonly Func<TDestination, TSource> invertor;
        public Transformer(IList<TSource> source, Func<TSource, TDestination> selector, Func<TDestination, TSource> invertor)
            : base(source, selector)
        {
            Required.NotDefault(invertor, () => invertor);

            this.invertor = invertor;
        }

        public override int IndexOf(TDestination item)
        {
            return source.IndexOf(invertor(item));
        }

        public override void Insert(int index, TDestination item)
        {
            source.Insert(index, invertor(item));
        }

        public override void RemoveAt(int index)
        {
            source.RemoveAt(index);
        }

        public override TDestination this[int index]
        {
            get
            {
                return selector(source[index]);
            }
            set
            {
                source[index] = invertor(value);
            }
        }

        public override void Add(TDestination item)
        {
            source.Add(invertor(item));
        }

        public override void Clear()
        {
            source.Clear();
        }

        public override bool Contains(TDestination item)
        {
            return source.Contains(invertor(item));
        }

        public override void CopyTo(TDestination[] array, int arrayIndex)
        {
            for (int i = arrayIndex; i < source.Count; i++)
            {
                array[i] = selector(source[i]);
            }
        }

        public override bool Remove(TDestination item)
        {
            return source.Remove(invertor(item));
        }
    }

}