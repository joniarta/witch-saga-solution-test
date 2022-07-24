using System.Collections.Generic;

namespace WitchSaga.Application.Services
{
    public abstract class ResponseBase
    {
        #region Fields

        private List<string> _exceptions;

        #endregion

        public ResponseBase()
        {
            this._exceptions = new List<string>();
        }

        #region Properties

        public IEnumerable<string> Exceptions
        {
            get { return this._exceptions; }
        }

        public bool HasError
        {
            get { return this._exceptions.Count != 0; }
        }

        #endregion

        #region (public) Methods

        public void AddException(string errorMessage)
        {
            this._exceptions.Add(errorMessage);
        }

        #endregion
    }
}