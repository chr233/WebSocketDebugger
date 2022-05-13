#region License
/*
 * HttpBase.cs
 *
 * The MIT License
 *
 * Copyright (c) 2012-2022 sta.blockhead
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading;
using WebSocketSharp.Net;

namespace WebSocketSharp
{
  internal abstract class HttpBase
  {
    #region Private Fields

    private string              _entityBody;
    private byte[]              _entityBodyData;
    private NameValueCollection _headers;
    private static readonly int _headersMaxLength;
    private Version             _protocolVersion;

    #endregion

    #region Protected Fields

    protected static readonly string CrLf;
    protected static readonly string CrLfHt;
    protected static readonly string CrLfSp;

    #endregion

    #region Static Constructor

    static HttpBase ()
    {
      _headersMaxLength = 8192;

      CrLf = "\r\n";
      CrLfHt = "\r\n\t";
      CrLfSp = "\r\n ";
    }

    #endregion

    #region Protected Constructors

    protected HttpBase (Version protocolVersion, NameValueCollection headers)
    {
      _protocolVersion = protocolVersion;
      _headers = headers;
    }

    #endregion

    #region Internal Properties

    internal byte[] EntityBodyData {
      get {
        return _entityBodyData;
      }
    }

    #endregion

    #region Public Properties

    public string EntityBody {
      get {
        if (_entityBody == null)
          _entityBody = getEntityBody ();

        return _entityBody;
      }
    }

    public NameValueCollection Headers {
      get {
        return _headers;
      }
    }

    public Version ProtocolVersion {
      get {
        return _protocolVersion;
      }
    }

    #endregion

    #region Private Methods

    private string getEntityBody ()
    {
      if (_entityBodyData == null || _entityBodyData.LongLength == 0)
        return String.Empty;

      var contentType = _headers["Content-Type"];

      var enc = contentType != null && contentType.Length > 0
                ? HttpUtility.GetEncoding (contentType)
                : Encoding.UTF8;

      return enc.GetString (_entityBodyData);
    }

    private static byte[] readEntityBodyFrom (Stream stream, string length)
    {
      long len;

      if (!Int64.TryParse (length, out len)) {
        var msg = "It cannot be parsed.";

        throw new ArgumentException (msg, "length");
      }

      if (len < 0) {
        var msg = "It is less than zero.";

        throw new ArgumentOutOfRangeException ("length", msg);
      }

      return len > 1024
             ? stream.ReadBytes (len, 1024)
             : len > 0
               ? stream.ReadBytes ((int) len)
               : null;
    }

    private static string[] readHeadersFrom (Stream stream)
    {
      var buff = new List<byte> ();
      var cnt = 0;
      Action<int> add =
        i => {
          if (i == -1) {
            var msg = "The headers could not be read from the data stream.";

            throw new EndOfStreamException (msg);
          }

          buff.Add ((byte) i);

          cnt++;
        };

      while (true) {
        var end = stream.ReadByte ().IsEqualTo ('\r', add)
                  && stream.ReadByte ().IsEqualTo ('\n', add)
                  && stream.ReadByte ().IsEqualTo ('\r', add)
                  && stream.ReadByte ().IsEqualTo ('\n', add);

        if (cnt > _headersMaxLength) {
          var msg = "The length of the headers is greater than the max length.";

          throw new InvalidOperationException (msg);
        }

        if (end)
          break;
      }

      var bytes = buff.ToArray ();

      return Encoding.UTF8.GetString (bytes)
             .Replace (CrLfSp, " ")
             .Replace (CrLfHt, " ")
             .Split (new[] { CrLf }, StringSplitOptions.RemoveEmptyEntries);
    }

    #endregion

    #region Protected Methods

    protected static T Read<T> (
      Stream stream, Func<string[], T> parser, int millisecondsTimeout
    )
      where T : HttpBase
    {
      T ret = null;

      var timeout = false;
      var timer = new Timer (
                    state => {
                      timeout = true;
                      stream.Close ();
                    },
                    null,
                    millisecondsTimeout,
                    -1
                  );

      Exception exception = null;

      try {
        var headers = readHeadersFrom (stream);
        ret = parser (headers);

        var contentLen = ret.Headers["Content-Length"];

        if (contentLen != null && contentLen.Length > 0)
          ret._entityBodyData = readEntityBodyFrom (stream, contentLen);
      }
      catch (Exception ex) {
        exception = ex;
      }
      finally {
        timer.Change (-1, -1);
        timer.Dispose ();
      }

      if (timeout) {
        var msg = "A timeout has occurred while reading an HTTP request or response.";

        throw new WebSocketException (msg);
      }

      if (exception != null) {
        var msg = "An exception has occurred while reading an HTTP request or response.";

        throw new WebSocketException (msg, exception);
      }

      return ret;
    }

    #endregion

    #region Public Methods

    public byte[] ToByteArray ()
    {
      var s = ToString ();

      return Encoding.UTF8.GetBytes (s);
    }
    
    #endregion
  }
}
