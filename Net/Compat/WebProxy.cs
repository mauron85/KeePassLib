/*
  KeePass Password Safe - The Open-Source Password Manager
  Copyright (C) 2003-2018 Dominik Reichl <dominik.reichl@t-online.de>

  This program is free software; you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation; either version 2 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

using System;
using System.Net;

namespace KeePassLib.Net.Compat
{
    internal class WebProxy : IWebProxy
    {
        private string m_strProxyAddr;
        private int m_proxyPort;

        public WebProxy(string strProxyAddr)
        {
            this.m_strProxyAddr = strProxyAddr;
        }

        public WebProxy(string strProxyAddr, int proxyPort)
        {
            this.m_strProxyAddr = strProxyAddr;
            this.m_proxyPort = proxyPort;
        }

        public ICredentials Credentials { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Uri GetProxy(Uri destination)
        {
            throw new NotImplementedException();
        }

        public bool IsBypassed(Uri host)
        {
            throw new NotImplementedException();
        }
    }
}