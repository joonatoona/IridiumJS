﻿using System;
using IridiumJS.Native.Object;
using IridiumJS.Runtime;

namespace IridiumJS.Native.Date
{
    public class DateInstance : ObjectInstance
    {
        // Maximum allowed value to prevent DateTime overflow
        internal static readonly double Max = (DateTime.MaxValue - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

        // Minimum allowed value to prevent DateTime overflow
        internal static readonly double Min = -(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) - DateTime.MinValue).TotalMilliseconds;

        public DateInstance(JSEngine engine)
            : base(engine)
        {
        }

        public override string Class
        {
            get
            {
                return "Date";
            }
        }

        public DateTime ToDateTime()
        {
            if (double.IsNaN(PrimitiveValue) || PrimitiveValue > Max || PrimitiveValue < Min)
            {
                throw new JavaScriptException(Engine.RangeError);
            }
            else
            {
                return DateConstructor.Epoch.AddMilliseconds(PrimitiveValue);
            }
        }

        public double PrimitiveValue { get; set; }
    }
}
