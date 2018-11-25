using System;

namespace DragNDropXF
{
	public class GetPropertyValueEventArgs<T> : EventArgs
	{
		public T Value { get; set; }
	}
}
