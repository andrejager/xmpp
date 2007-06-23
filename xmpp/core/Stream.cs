//XMPP .NET Library Copyright (C) 2006 Dieter Lunn

//This library is free software; you can redistribute it and/or modify it under
//the terms of the GNU Lesser General Public License as published by the Free
//Software Foundation; either version 2.1 of the License, or (at your option)
//any later version.

//This library is distributed in the hope that it will be useful, but WITHOUT
//ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
//FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
//details.

//You should have received a copy of the GNU Lesser General Public License along
//with this library; if not, write to the Free Software Foundation, Inc., 59
//Temple Place, Suite 330, Boston, MA 02111-1307 USA 

using System;
using System.Xml;
using System.Text;

using xmpp.common;
using xmpp;

namespace xmpp.core
{
    /// <summary>
    /// 
    /// </summary>
	[XmppTag("stream", xmpp.common.Namespaces.STREAM, typeof(Stream))]
	public class Stream : Tag
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="qname"></param>
        /// <param name="doc"></param>
		public Stream(string prefix, XmlQualifiedName qname, XmlDocument doc)
			: base(prefix, qname, doc)
		{
		}

        /// <summary>
        /// 
        /// </summary>
		public string Version
		{
			get { return this.GetAttribute("version"); }
			set { this.SetAttribute("version", value); }
		}

        /// <summary>
        /// 
        /// </summary>
		public string NS
		{
			get { return this.GetAttribute("xmlns"); }
			set { this.SetAttribute("xmlns", value); }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
		public string StartTag()
		{
			StringBuilder sb = new StringBuilder("<");
			sb.Append(this.Name);
			if (this.NamespaceURI != null)
			{
				sb.Append(" xmlns");
				if (this.Prefix != null)
				{
					sb.Append(":");
					sb.Append(this.Prefix);
				}
				sb.Append("=\"");
				sb.Append(this.NamespaceURI);
				sb.Append("\"");
			}
			foreach (XmlAttribute attr in this.Attributes)
			{
				sb.Append(" ");
				sb.Append(attr.Name);
				sb.Append("=\"");
				sb.Append(attr.Value);
				sb.Append("\"");
			}
			sb.Append(">");
			return sb.ToString();
		}
	}
}
