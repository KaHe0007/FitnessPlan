using System;
using System.Linq.Expressions;

namespace FitnessClientLibrary.Extension
{
	public static class ViewModelExtensions
	{
		public static string GetPropertyName<TViewModel, TValue>(this TViewModel source, Expression<Func<TViewModel, TValue>> expression)
		{
			var me = (MemberExpression)expression.Body;
			return me.Member.Name;
		}

		public static string GetPropertyName<TViewModel, TValue>(Expression<Func<TViewModel, TValue>> expression)
		{
			var me = (MemberExpression)expression.Body;
			return me.Member.Name;
		}

		/*public static IObservable<TValue> ObserveProperty<TViewModel, TValue>(this TViewModel source, Expression<Func<TViewModel, TValue>> expression, bool beforeValueChange = false) where TViewModel : INotifyPropertyChanged, INotifyPropertyChanging
		{
			var propertyName = GetPropertyName(source, expression);
			var getValue = expression.Compile();
			if (beforeValueChange)
			{
				var events = Observable.FromEvent<PropertyChangingEventHandler, PropertyChangingEventArgs>(x => source.PropertyChanging += x, x => source.PropertyChanging -= x);
				return events.Where(x => x.PropertyName == propertyName).Select(_ => getValue.Invoke(source));
			}
			else
			{
				var events = Observable.FromEvent<PropertyChangedEventHandler, PropertyChangedEventArgs>(x => source.PropertyChanged += x, x => source.PropertyChanged -= x);
				return events.Where(x => x.PropertyName == propertyName).Select(_ => getValue.Invoke(source));
			}
		}*/
	}
}