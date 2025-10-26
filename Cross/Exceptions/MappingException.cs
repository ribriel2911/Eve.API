using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cross.Exceptions
{
    public class MappingException<FromMap, ToMap> : Exception
        where ToMap : class
    {
        #region Constants
        private const string errorDefault = "@ERROR_MAPPING";
        #endregion

        #region Constructors
        public MappingException(string descriptionError, Exception inner)
            : base($"{errorDefault} - {typeof(FromMap).Name} =>  {typeof(ToMap).Name}: {descriptionError}", inner) { }

        public MappingException(string descriptionError)
            : base($"{errorDefault} - {typeof(FromMap).Name} =>  {typeof(ToMap).Name}: {descriptionError}") { }

        public MappingException(Exception inner)
            : this(inner.Message, inner) { }
        #endregion
    }
}
