using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Hope.Util
{
    static class Tool
    {
        public static TValue JsonDeepCopy<TValue>(TValue obj)
        {
            var jsonUtf8Bytes = JsonSerializer.SerializeToUtf8Bytes(obj);
            var readOnlySpan = new ReadOnlySpan<byte>(jsonUtf8Bytes);
            return JsonSerializer.Deserialize<TValue>(readOnlySpan);
        }
    }
}
