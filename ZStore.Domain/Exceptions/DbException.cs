using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZStore.Domain.Exceptions
{
    public class DbException : Exception
    {
     public DbException()
            : base() { }

        public DbException(string message)
            : base(message) { }

        public DbException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args)) { }
    }
}
